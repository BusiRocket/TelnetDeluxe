Option Strict Off
Option Explicit On
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class TelnetDeluxe
    Inherits System.Windows.Forms.Form
    Dim conf_ipremota As IPAddress
    Dim conf_ipfinal As IPEndPoint
    Dim WinS As Socket
    Dim CadenaRecibida As String = String.Empty
    Dim NumBytes As Integer = 0
    Dim BytesARecibir(1024) As [Byte]
    Public Version As String = "0.1 Beta"
    Dim EstamosConectados As Boolean = False
    Dim lineacomandos As String
    Dim mINI As New cIniArray
    Dim ComandoArray() As String
    Dim ArchivoIni As String = Application.StartupPath & "\TelnetDeluxe.ini"
    Dim Ini_Configuracion As String = "Config"
    Dim Ini_Comandos As String = "Comandos"
    Dim Ini_Misc As String = "Misc"

    Dim Ini_Conf_DirIp As String = "DirIp"
    Dim Ini_Conf_Puerto As String = "Puerto"
    Dim Ini_Conf_Refresco As String = "Refresco"
    Dim Ini_Comand_lista As String = "Comandos_lista"
    Dim Ini_Misc_IpPublica As String = "PIP"

    ' ###########################################################
    ' <******************** Funciones Ini ***********************>
    ' ###########################################################

    Sub guardarcfg()
        Try
            mINI.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_DirIp, txtbox_conf_iprouter.Text)
            mINI.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_Puerto, txtbox_conf_puerto.Text)
            mINI.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_Refresco, txtbox_conf_refresco.Text)
            mINI.IniWrite(ArchivoIni, Ini_Misc, Ini_Misc_IpPublica, txtbox_info_ipact.Text)
        Catch ex As Exception
            MessageBox.Show("ERROR no controlado: " & ex.Message)
        End Try
    End Sub

    Sub cargarcfg()
        Try
            txtbox_conf_iprouter.Text = mINI.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_DirIp, "192.168.1.1")
            txtbox_conf_puerto.Text = mINI.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_Puerto, "23")
            ComandoArray = Split(mINI.IniGet(ArchivoIni, Ini_Comandos, Ini_Comand_lista, "1234,1234,console enable,adsl,startup"), ",")
            txtbox_conf_refresco.Text = mINI.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_Refresco, "3")
            txtbox_info_ipact.Text = mINI.IniGet(ArchivoIni, Ini_Misc, Ini_Misc_IpPublica, "")
        Catch ex As Exception
            MessageBox.Show("ERROR no controlado: " & ex.Message)
        End Try
    End Sub


    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################

    Shared Sub Main()
        Try
            Application.Run(New TelnetDeluxe)
        Catch oex As Exception
            MessageBox.Show("ERROR no controlado: " & oex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            guardarcfg()
            Select Case Me.WindowState
                Case FormWindowState.Normal
                    Dim rect As Rectangle = Me.Bounds
                Case Else
                    Dim rect As Rectangle = Me.RestoreBounds
            End Select
        Catch ex As Exception
            MessageBox.Show("ERROR no controlado: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            WinS = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            MensajeBienvenida()
            Me.Text = "Telnet Deluxe v" & Version
            cargarcfg()
            If Environment.GetCommandLineArgs.Length > 1 Then
                lineacomandos = Environment.GetCommandLineArgs(1)
                If lineacomandos = Trim("/ryc") Then
                    Me.Show()
                    Me.Refresh()
                    Me.Update()
                    Esperar(1000)
                    Macro()
                    Esperar(2000)
                    Me.Close()
                Else
                    MostrarEnConsola("El argumento ''" & lineacomandos & "'' no se ha reconocido")
                End If
            Else
                LeerIP()
            End If
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub boton_actip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boton_actip.Click
        LeerIP()
    End Sub

    Private Sub boton_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_actualizar.Click
        Macro()
    End Sub

    Private Sub crono_principal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles crono_principal.Tick
        ComprobarMensajes()
    End Sub

    Private Sub boton_Acercade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_Acercade.Click
        TD_AcercaDe.Show()
    End Sub


    ' ###########################################################
    ' <************* Funciones para la consola ****************>
    ' ###########################################################
    Private Sub MostrarEnConsola(ByVal Datos As String)
        Try
            Consola.Text = Consola.Text & Datos & vbCrLf
            Consola.SelectionStart = Len(Consola.Text)
        Catch ex As Exception
            MessageBox.Show("ERROR no controlado: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub LimpiarConsola()
        Consola.Text = ""
        MensajeBienvenida()
    End Sub

    Private Sub MensajeBienvenida()
        Try
            MostrarEnConsola("Deluxe Telnet v" & Version & " Agosto 2007")
            MostrarEnConsola("Pulse en Renovar IP para comenzar")
            MostrarEnConsola("")
        Catch ex As Exception
            MessageBox.Show("ERROR no controlado: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Telnet *********************>
    ' ###########################################################

    Private Sub Conectar()
        Try
            ' Genera la ip para conectar
            conf_ipremota = IPAddress.Parse(txtbox_conf_iprouter.Text.Trim)
            conf_ipfinal = New IPEndPoint(conf_ipremota, CType(txtbox_conf_puerto.Text.Trim, Integer))
            WinS.Connect(conf_ipfinal)
            ' Si estamos conectados muestra el mensaje
            If WinS.Connected Then
                MostrarEnConsola("Conexión Establecida correctamente")
                MostrarEnConsola("Conectado a '" & txtbox_conf_iprouter.Text & "' puerto " & txtbox_conf_puerto.Text)
                Esperar(1000)
                ComprobarMensajes()
                crono_principal.Enabled = True
                label_estado.Text = "Conectado"
                label_estado.BackColor = Color.Green
                Me.Refresh()
            Else
                MostrarEnConsola("No se ha podido establecer la conexión, comprueba que la ip y el puerto sean correctos")
                EstamosConectados = False
            End If
        Catch oEX As SocketException
            MostrarEnConsola("No se ha podido establecer la conexión")
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            WinS.Disconnect(True)
            EstamosConectados = False
            label_estado.Text = "Desconectado"
            label_estado.BackColor = Color.Red
            MostrarEnConsola("Conexión Cerrada")
            Me.Refresh()
            crono_principal.Enabled = False
        Catch oEX As SocketException
            MostrarEnConsola("Error, no se ha podido desconectar")
        End Try
    End Sub

    Private Sub ComprobarMensajes()
        Try
            If WinS.Available > 0 Then
                Esperar(1000)
                NumBytes = WinS.Receive(BytesARecibir, BytesARecibir.Length, 0)
                CadenaRecibida = CadenaRecibida + Encoding.ASCII.GetString(BytesARecibir, 0, NumBytes)
                MostrarEnConsola(CadenaRecibida)
                CadenaRecibida = Nothing
            Else
                MostrarEnConsola("Esperando respuesta...")
            End If
        Catch oEX As SocketException
            MostrarEnConsola("Error, no se ha podido conseguir la información del router")
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub EnviarComandos(ByVal comandos As String)
        Try
            Dim BytesParaEnviar As [Byte]() = Encoding.ASCII.GetBytes(comandos & vbCrLf)
            WinS.Send(BytesParaEnviar, BytesParaEnviar.Length, SocketFlags.None)
            ComprobarMensajes()
            'txtbox_enviar.Text = ""
        Catch oEX As SocketException
            MostrarEnConsola("Error, no se ha podido enviar el comando al router")
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Generales ******************>
    ' ###########################################################

    Private Sub Macro()
        Try
            Dim cmdd As String
            Conectar()
            Esperar(3000)
            For Each cmdd In ComandoArray
                EnviarComandos(cmdd)
                Esperar(3000)
            Next
            Desconectar()
            Esperar(3000)
            MostrarEnConsola("Los comandos se realizaron con éxito")
            MostrarEnConsola("Espera unos segundos hasta que tu router sincronice")
        Catch oEX As Exception
            MostrarEnConsola("Error, ejecutando la lista de comandos")
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

    Function LeerIP() As String
        Dim htmlsucio As New System.Net.WebClient
        Dim reg As RegularExpressions.Regex
        Dim DirwebS As String = "http://www.showmyip.com"
        Dim DirIpDef As String = ""
        Try
            DirIpDef = htmlsucio.DownloadString(DirwebS)

            reg = New RegularExpressions.Regex("([0-9]+.[0-9]+.[0-9]+.[0-9]+)", RegularExpressions.RegexOptions.IgnoreCase Or RegularExpressions.RegexOptions.Compiled Or RegularExpressions.RegexOptions.Multiline)
            Dim mc As RegularExpressions.MatchCollection = reg.Matches(DirIpDef)
            LeerIP = Trim(mc.Item(0).ToString)
            MostrarEnConsola("Tu IP actual es " & LeerIP)
            If txtbox_info_ipact.Text <> LeerIP Then
                txtbox_info_ipant.Text = txtbox_info_ipact.Text
                txtbox_info_ipact.Text = LeerIP
            End If
        Catch oEX As Exception
            MostrarEnConsola("Error, no se ha podido conseguir la dirección IP")
            LeerIP = txtbox_info_ipact.Text
            MostrarEnConsola(oEX.Message)
            Exit Function
        End Try
    End Function

    Private Sub Esperar(ByVal Milisegundos As Integer)
        Try
            Dim HoraActual As DateTime
            Dim HoraFinal As DateTime
            Dim Parar As Boolean

            HoraFinal = Now()
            HoraFinal = HoraFinal.AddMilliseconds(Milisegundos)
            Parar = False
            While Not Parar
                HoraActual = Now()
                If HoraActual > HoraFinal Then
                    Parar = True
                End If
                Application.DoEvents()
            End While

            HoraActual = Nothing
            HoraFinal = Nothing
        Catch oEX As Exception
            MostrarEnConsola("Ha ocurrido un Error")
            MostrarEnConsola(oEX.Message)
            Exit Sub
        End Try
    End Sub

End Class

