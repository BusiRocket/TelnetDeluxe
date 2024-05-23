'Option Strict Off
'Option Explicit On
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Public Class TelnetDeluxe
    Inherits System.Windows.Forms.Form
    Private WithEvents ClienteWeb As New System.Net.WebClient

    Dim Traduc As New UniversalDeluxe

    '////////////////////////////////////////////////////////////////////
    '/// Variables Generales
    Dim Version As String = Traduc.Version
    Public TituloForm As String = "Telnet Deluxe v" & Version
    Dim lineacomandos As String
    Dim IntervaloComandos As Integer = 3
    Dim EsperaBallonTip As Integer = 1000


    '////////////////////////////////////////////////////////////////////
    '/// Variables para la conexión Winsock

    Dim conf_ipremota As IPAddress
    Dim conf_ipfinal As IPEndPoint
    Dim WinS As Socket
    Dim CadenaRecibida As String = String.Empty
    Dim NumBytes As Integer = 0
    Dim BytesARecibir(1024) As [Byte]
    Dim EstamosConectados As Boolean = False
    Dim ComprobarIP As Boolean = False
    Dim ConectadoAInet As Boolean = False
    Dim DirPING As String = "208.69.34.230"
    Dim ConsolaUltimoMensaje As String = ""


    '////////////////////////////////////////////////////////////////////
    '/// Variables Configuración para el Router
    Dim ComandoArray() As String
    Dim NombreRouter As String
    Dim Revision As String
    Dim Fecha As String
    Dim Autor As String
    Dim IniRouterCargada As Boolean = False


    '////////////////////////////////////////////////////////////////////
    '/// Variables para los Ficheros y Carpetas

    Dim DirActual As String = Application.StartupPath
    Dim ArchivoIni As String = DirActual & "\TelnetDeluxe.ini"
    Dim CarpetaIniRouters As String = DirActual & "\Routers"


    '////////////////////////////////////////////////////////////////////
    '/// Variables para los archivos INI

    Dim DeluxeIniMgr As New cIniArray

    Dim Ini_Configuracion As String = "Config"
    Dim Ini_Conf_DirIp As String = "DirIp"
    Dim Ini_Conf_Puerto As String = "Puerto"
    Dim Ini_Conf_Refresco As String = "Refresco"
    Dim Ini_Conf_IniRouter As String = "IniRouter"

    Dim Ini_Misc As String = "Misc"
    Dim Ini_Misc_IpPublica As String = "PIP"
    Dim Ini_Misc_IpPing As String = "IP_Ping"

    Dim Ini_Router As String = "RouterCfg"
    Dim Ini_Router_NombreRouter As String = "NombreRouter"
    Dim Ini_Router_Comandos As String = "Comandos"
    Dim Ini_Router_Revision As String = "Revision"
    Dim Ini_Router_Fecha As String = "Fecha"
    Dim Ini_Router_Autor As String = "Autor"



    ' ###########################################################
    ' <******************** Funciones Ini ***********************>
    ' ###########################################################

    Sub guardarcfg()
        Try
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_DirIp, txtbox_conf_iprouter.Text)
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_Puerto, txtbox_conf_puerto.Text)
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_Refresco, txtbox_conf_refresco.Text)
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Configuracion, Ini_Conf_IniRouter, Combo_inirouters.Text)
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Misc, Ini_Misc_IpPublica, txtbox_info_ipact.Text)
            DeluxeIniMgr.IniWrite(ArchivoIni, Ini_Misc, Ini_Misc_IpPing, DirPING)
        Catch ex As Exception
            MessageBox.Show(Traduc.Uni_Error_NoControlado & ex.Message)
        End Try
    End Sub

    Sub cargarcfg()
        Try
            Dim ArchIniRouter As String
            ' Configuración
            txtbox_conf_iprouter.Text = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_DirIp, "192.168.1.1")
            txtbox_conf_puerto.Text = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_Puerto, "23")
            ArchIniRouter = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_IniRouter, "")

            ' Inis Router
            If String.IsNullOrEmpty(ArchIniRouter) Then
                MostrarEnConsola("Selecciona un archivo de configuración antes de comenzar", "Info")
            ElseIf File.Exists(CarpetaIniRouters & "\" & ArchIniRouter) = False Then
                MostrarEnConsola(Traduc.Uni_Error_INIRouterBad & ArchIniRouter & ")", "Error")
            Else
                Combo_inirouters.Text = ArchIniRouter
                CargarIniRouter()
            End If
            IntervaloComandos = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Configuracion, Ini_Conf_Refresco, IntervaloComandos)
            txtbox_conf_refresco.Text = IntervaloComandos

            'Miscelánea
            txtbox_info_ipact.Text = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Misc, Ini_Misc_IpPublica, "")
            DirPING = DeluxeIniMgr.IniGet(ArchivoIni, Ini_Misc, Ini_Misc_IpPing, DirPING)
        Catch ex As Exception
            MessageBox.Show(Traduc.Uni_Error_NoControlado & ex.Message)
        End Try
    End Sub


    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################

    Public Sub IniciarTD(ByVal e As System.EventArgs)
        Try
            Timer_ConexInet.Enabled = True
            Me.Show()
            Me.Update()
            TD_Tray.Visible = False
            TD_Tray.Text = TituloForm
            WinS = Nothing
            MensajeBienvenida()
            Me.Text = TituloForm
            Me.boton_actualizar.Enabled = False
            ConseguirIniRouters()
            cargarcfg()
            If Environment.GetCommandLineArgs.Length > 1 Then
                lineacomandos = Environment.GetCommandLineArgs(1)
                If lineacomandos = Trim("/ryc") Then
                    Esperar(1000)
                    Macro()
                    While Not ConectadoAInet
                        Esperar(100)
                    End While
                    Me.Close()
                ElseIf lineacomandos = Trim("/rycs") Then
                    Me.WindowState = FormWindowState.Minimized
                    TD_Tray.Visible = True
                    ShowInTaskbar = False
                    Esperar(1000)
                    Macro()
                    While Not ConectadoAInet
                        Esperar(100)
                    End While
                    Me.Close()
                ElseIf lineacomandos = Trim("/renovar") Then
                    Esperar(1000)
                    Macro()
                ElseIf lineacomandos = Trim("/cerrar") Then
                    Me.Close()
                ElseIf lineacomandos = Trim("/tray") Then
                    Me.WindowState = FormWindowState.Minimized
                    TD_Tray.Visible = True
                    ShowInTaskbar = False
                Else
                    MostrarEnConsola(Traduc.Uni_Error_ComandoBad & lineacomandos & Traduc.Uni_Error_ComandoBadFin, "Error")
                End If
            End If
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Shared Sub Main()
        Try
            Application.Run(New TelnetDeluxe)
        Catch oex As Exception
            MessageBox.Show("ERROR: " & oex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer_ConexInet.Enabled = False
            crono_principal.Enabled = False
            TD_Tray.Visible = False
            WinS = Nothing
            guardarcfg()
            Select Case Me.WindowState
                Case FormWindowState.Normal
                    Dim rect As Rectangle = Me.Bounds
                Case Else
                    Dim rect As Rectangle = Me.RestoreBounds
            End Select
        Catch ex As Exception
            MessageBox.Show(Traduc.Uni_Error_NoControlado & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            IniciarTD(e)
            'Consola.BackgroundImage = My.Resources.Resources.FondoConsola
            'Consola.BackgroundImageLayout = ImageLayout.Stretch
            'Consola.BackColor = Color.Transparent
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_actualizar.Click
        Try
            Macro()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub crono_principal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles crono_principal.Tick
        Try
            ComprobarMensajes()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_Acercade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_Acercade.Click
        Try
            TD_AcercaDe.Show()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_cargarini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_cargarini.Click
        Try
            CargarIniRouter()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Consola_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Consola.TextChanged
        Consola.Focus()
    End Sub

    Private Sub boton_ocultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_ocultar.Click
        Try
            Me.WindowState = FormWindowState.Minimized
            TD_Tray.Visible = True
            ShowInTaskbar = False
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub RestaurarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurarToolStripMenuItem.Click
        Try
            Restaurar()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TD_Tray.DoubleClick
        Try
            Restaurar()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub label_estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label_estado.Click
        Try
            MostrarInfo()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Timer_ConexInet_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ConexInet.Tick
        Try
            ComprobarConexion()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub RenovarIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenovarIPToolStripMenuItem.Click
        Try
            MostrarTrayTip("Renovando IP...")
            Macro()
            MostrarTrayTip("Se han completado todos los comandos")
        Catch oEX As Exception
            MostrarEnConsola(Traduc.Uni_Error_Generico, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub txtbox_conf_puerto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbox_conf_puerto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtbox_conf_refresco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbox_conf_refresco.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtbox_conf_refresco_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbox_conf_refresco.TextChanged
        Try
            If String.IsNullOrEmpty(txtbox_conf_refresco.Text) Or CType(txtbox_conf_refresco.Text, Integer) < 1 Then
                MostrarEnConsola(Traduc.Uni_Error_IntervaloLow, "Error")
                MostrarEnConsola(Traduc.Uni_Error_IntervaloLowTip, "Error")
                txtbox_conf_refresco.Text = IntervaloComandos
            Else
                IntervaloComandos = CType(txtbox_conf_refresco.Text, Integer)
                MostrarEnConsola(Traduc.Uni_Console_Config_Intervalo & IntervaloComandos & Traduc.Uni_Console_Config_IntervaloFin, "Info")
                MostrarEnConsola()
            End If
        Catch oEX As Exception
            MostrarEnConsola(Traduc.Uni_Error_Generico, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Restaurar()
        Try
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Me.BringToFront()
            ShowInTaskbar = True
            TD_Tray.Visible = False
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MostrarTrayTip(ByVal MensajeTip As String)
        If TD_Tray.Visible = True Then
            TD_Tray.BalloonTipIcon = ToolTipIcon.Info
            TD_Tray.BalloonTipTitle = TituloForm
            TD_Tray.BalloonTipText = MensajeTip
            TD_Tray.ShowBalloonTip(EsperaBallonTip)
        End If
    End Sub

    ' ###########################################################
    ' <************* Funciones para la consola ****************>
    ' ###########################################################
    Private Sub MostrarEnConsola(Optional ByVal Datos As String = "", Optional ByVal ColorTxt As String = "defecto")
        Try
            'Consola.SelectionStart = Consola.Text.Length
            'Consola.SelectionLength = Consola.Text.Length
            If ColorTxt = "defecto" Then
                Consola.SelectionColor = Color.Yellow
            ElseIf ColorTxt = "Info" Then
                Consola.SelectionColor = Color.Orange
            ElseIf ColorTxt = "Error" Then
                Consola.SelectionColor = Color.Red
            ElseIf ColorTxt = "Router" Then
                Consola.SelectionColor = Color.White
            ElseIf ColorTxt = "Accion" Then
                Consola.SelectionColor = Color.YellowGreen
            ElseIf ColorTxt = "DirIP" Then
                Consola.SelectionColor = Color.Aqua
            Else
                Consola.SelectionColor = Color.Yellow
            End If
            Consola.SelectedText = Datos & ControlChars.CrLf
            Consola.SelectionStart = Consola.Text.Length
            Consola.ScrollToCaret()
            Consola.Update()
            If String.IsNullOrEmpty(Datos) = False Then
                ConsolaUltimoMensaje = Datos
            End If
        Catch ex As Exception
            MessageBox.Show(Traduc.Uni_Error_NoControlado & ex.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub LimpiarConsola()
        Consola.Text = ""
        MensajeBienvenida()
    End Sub

    Private Sub MensajeBienvenida()
        Try
            MostrarEnConsola()
            MostrarEnConsola(Traduc.Uni_General_BienvenidaInfo, "Info")
            'MostrarEnConsola("Pulse en Renovar IP para comenzar", "Info")
            MostrarEnConsola(Traduc.Uni_General_Comenzo & System.DateTime.Now, "Info")
            MostrarEnConsola()
        Catch ex As Exception
            MessageBox.Show(Traduc.Uni_Error_NoControlado & ex.Message)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Telnet *********************>
    ' ###########################################################

    Private Sub Conectar()
        Try
            WinS = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            ' Genera la ip para conectar
            conf_ipremota = IPAddress.Parse(txtbox_conf_iprouter.Text.Trim)
            conf_ipfinal = New IPEndPoint(conf_ipremota, CType(txtbox_conf_puerto.Text.Trim, Integer))
            WinS.Connect(conf_ipfinal)
            ' Si estamos conectados muestra el mensaje
            If WinS.Connected Then
                MostrarEnConsola(Traduc.Uni_Console_Msg_ConexionOK, "Info")
                MostrarEnConsola(Traduc.Uni_Console_Msg_ConectadoA & txtbox_conf_iprouter.Text & Traduc.Uni_Console_Msg_ConectadoAPuerto & txtbox_conf_puerto.Text, "Info")
                'Esperar(1000)
                'ComprobarMensajes()
                crono_principal.Enabled = True
                label_estado.Text = Traduc.Uni_Gui_General_Conectado
                label_estado.BackColor = Color.Green
                Me.Refresh()
            Else
                MostrarEnConsola(Traduc.Uni_Error_CompruebaIpPuerto, "Error")
                EstamosConectados = False
            End If
        Catch oEX As SocketException
            MostrarEnConsola(Traduc.Uni_Error_NoPuedoConectar, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            WinS.Disconnect(True)
            WinS = Nothing
            EstamosConectados = False
            label_estado.Text = Traduc.Uni_Gui_General_DesConectado
            label_estado.BackColor = Color.Red
            MostrarEnConsola(Traduc.Uni_Console_Msg_Desconectado, "Info")
            Me.Refresh()
            crono_principal.Enabled = False
        Catch oEX As SocketException
            MostrarEnConsola(Traduc.Uni_Error_NoPuedoDesconectar, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub ComprobarMensajes()
        Try
            If WinS.Available > 0 Then
                Esperar(1000)
                NumBytes = WinS.Receive(BytesARecibir, BytesARecibir.Length, 0)
                CadenaRecibida = CadenaRecibida + Encoding.ASCII.GetString(BytesARecibir, 0, NumBytes)
                MostrarEnConsola(CadenaRecibida, "Router")
                CadenaRecibida = Nothing
            Else
                MostrarEnConsola(Traduc.Uni_Console_Msg_EsperandoRespuesta, "Accion")
            End If
        Catch oEX As SocketException
            MostrarEnConsola(Traduc.Uni_Error_NoRespuestaRouter, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub EnviarComandos(ByVal comandos As String)
        Try
            Dim BytesParaEnviar As [Byte]() = Encoding.ASCII.GetBytes(comandos & vbCrLf)
            WinS.Send(BytesParaEnviar, BytesParaEnviar.Length, SocketFlags.None)
            'ComprobarMensajes()
        Catch oEX As SocketException
            MostrarEnConsola(Traduc.Uni_Error_NoPuedoEnviarComando, "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Generales ******************>
    ' ###########################################################

    Private Sub Macro()
        Try
            LimpiarConsola()
            If IniRouterCargada = False Then
                MostrarEnConsola(Traduc.Uni_Error_NoConfigCargada, "Error")
                MostrarEnConsola()
                Exit Sub
            End If
            'LeerIP()
            Conectar()
            Esperar(3000)
            For Each cmdd As String In ComandoArray
                EnviarComandos(cmdd)
                Esperar(IntervaloComandos * 1000)
            Next
            Desconectar()
            Esperar(3000)
            MostrarEnConsola()
            MostrarEnConsola(Traduc.Uni_Console_Msg_ComandosOK, "Accion")
            MostrarEnConsola(Traduc.Uni_Console_Msg_ComandosOKWait, "Info")
            MostrarEnConsola()
            Esperar(3000)
            ComprobarConexion()
            ComprobarIP = True
        Catch oEX As Exception
            MostrarEnConsola("Error, ejecutando la lista de comandos", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub
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
            MostrarEnConsola("Ha ocurrido un Error", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MostrarInfo()
        Try
            Dim RedDisponible As String
            If My.Computer.Network.IsAvailable Then
                RedDisponible = "La conexión de red está conectada"
            Else
                RedDisponible = "La conexión de red no está conectada"
            End If
            MostrarEnConsola(My.Computer.Info.OSFullName.ToString & "  Versión: " & My.Computer.Info.OSVersion.ToString, "Info")
            MostrarEnConsola("Memoria Física Disponible: " & ((My.Computer.Info.AvailablePhysicalMemory / 1024) / 1024).ToString & " MB", "Info")
            MostrarEnConsola("Memoria Virtual Disponible: " & ((My.Computer.Info.AvailableVirtualMemory.ToString / 1024) / 1024).ToString & " MB", "Info")
            MostrarEnConsola("Idioma Instalado" & My.Computer.Info.InstalledUICulture.DisplayName, "Info")
            MostrarEnConsola(RedDisponible, "Info")
            MostrarEnConsola("Resolucion " & My.Computer.Screen.Bounds.Width.ToString & "x" & My.Computer.Screen.Bounds.Height.ToString & " Pixels", "Info")
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    ' ###########################################################
    ' <****************** Funciones Internet *******************>
    ' ###########################################################

    Function LeerIP() As String
        Try
            Dim reg As RegularExpressions.Regex
            Dim mc As RegularExpressions.MatchCollection
            Dim IPShow_Web As String = "http://www.showmyip.com"
            Dim DirIpDef As String = ""

            MostrarEnConsola("Intentando conseguir la dirección IP", "Accion")
            MostrarEnConsola("Esto puede tardar varios segundos", "Info")
            MostrarEnConsola()
            MostrarEnConsola("Conectando con " & IPShow_Web, "Accion")
            MostrarEnConsola()

            Dim Archivo As New System.IO.StreamReader(ClienteWeb.OpenRead(IPShow_Web))
            DirIpDef = Archivo.ReadToEnd()
            Archivo.Close()

            If DirIpDef <> "" Then
                reg = New RegularExpressions.Regex("([0-9]+.[0-9]+.[0-9]+.[0-9]+)", RegularExpressions.RegexOptions.IgnoreCase Or RegularExpressions.RegexOptions.Compiled Or RegularExpressions.RegexOptions.Multiline)
                mc = reg.Matches(DirIpDef)
                LeerIP = Trim(mc.Item(0).ToString)
                MostrarEnConsola("Tu IP actual es " & LeerIP, "DirIP")
                MostrarEnConsola()
                MostrarTrayTip("Tu IP actual es " & LeerIP)
                If txtbox_info_ipact.Text <> LeerIP Then
                    txtbox_info_ipant.Text = txtbox_info_ipact.Text
                    txtbox_info_ipact.Text = LeerIP
                End If
                ComprobarIP = False
            Else
                MostrarEnConsola("Error, El html no se descargó correctamente", "Error")
                LeerIP = txtbox_info_ipact.Text
                Exit Function
            End If
        Catch oEX As Exception
            MostrarEnConsola("Error, no se ha podido conseguir la dirección IP", "Error")
            LeerIP = txtbox_info_ipact.Text
            MostrarEnConsola(oEX.Message, "Error")
            Exit Function
        End Try
    End Function



    Private Sub ComprobarConexion()
        Try
            If My.Computer.Network.Ping(DirPING) Then
                label_inetconex.Text = Traduc.Uni_Gui_General_Online
                label_inetconex.BackColor = Color.Green
                Timer_ConexInet.Interval = 15000
                If ComprobarIP = True Then
                    MostrarTrayTip("Conectado A Internet")
                    LeerIP()
                    ComprobarIP = False
                    ConectadoAInet = True
                End If
            Else
                label_inetconex.Text = Traduc.Uni_Gui_General_Offline
                label_inetconex.BackColor = Color.Red
                Timer_ConexInet.Interval = 2000
                ConectadoAInet = False
            End If
        Catch oEX As Exception
            MostrarEnConsola("Ha ocurrido un Error Cargando el fichero INI", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones De Archivo *****************>
    ' ###########################################################

    Sub ConseguirIniRouters()
        Try
            If Directory.Exists(CarpetaIniRouters) = False Then
                Directory.CreateDirectory(CarpetaIniRouters)
            End If
            Dim ArchivosINIRouters() As String = Directory.GetFiles(CarpetaIniRouters, "*.ini")
            Me.Combo_inirouters.Items.Clear()
            If ArchivosINIRouters.Length <> 0 Then
                For Each ArchIniRouter As String In ArchivosINIRouters
                    ArchIniRouter = ArchIniRouter.Substring(CarpetaIniRouters.Length + 1)
                    Me.Combo_inirouters.Items.Add(ArchIniRouter)
                Next
                If Me.Combo_inirouters.Items.Count > 0 Then
                    Me.Combo_inirouters.SelectedIndex = 0
                End If
            Else
                Me.Combo_inirouters.Items.Add("No se ha encontrado ningún archivo")
            End If
        Catch oEX As Exception
            MostrarEnConsola("Ha ocurrido un Error", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Sub CargarIniRouter()
        Try
            Dim IniSeleccionado As String = CarpetaIniRouters & "\" & Me.Combo_inirouters.Text.ToString
            If File.Exists(IniSeleccionado) = False Then
                MostrarEnConsola("El archivo seleccionado no existe (" & IniSeleccionado & ")", "Error")
                Exit Sub
            End If
            MostrarEnConsola("Leyendo archivo de configuración...", "Accion")
            MostrarEnConsola()
            NombreRouter = DeluxeIniMgr.IniGet(IniSeleccionado, Ini_Router, Ini_Router_NombreRouter, "No se ha seleccionado ningún router")
            ComandoArray = Split(DeluxeIniMgr.IniGet(IniSeleccionado, Ini_Router, Ini_Router_Comandos, "selecciona,fichero,ini"), ",")
            Revision = DeluxeIniMgr.IniGet(IniSeleccionado, Ini_Router, Ini_Router_Revision, "")
            Fecha = DeluxeIniMgr.IniGet(IniSeleccionado, Ini_Router, Ini_Router_Fecha, "")
            Autor = DeluxeIniMgr.IniGet(IniSeleccionado, Ini_Router, Ini_Router_Autor, "")
            IniRouterCargada = True
            Me.Text = NombreRouter & " | INI by " & Autor & " | " & TituloForm
            Me.boton_actualizar.Enabled = True
            MostrarEnConsola("Archivo de configuración para " & NombreRouter & ". Versión " & Revision, "Info")
            MostrarEnConsola("Creado por " & Autor & ". Última modificación: " & Fecha, "Info")
            MostrarEnConsola()
            MostrarEnConsola("El archivo de configuración se cargó correctamente...", "Accion")
            MostrarEnConsola()
        Catch oEX As Exception
            MostrarEnConsola("Ha ocurrido un Error Cargando el fichero INI", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub



End Class

