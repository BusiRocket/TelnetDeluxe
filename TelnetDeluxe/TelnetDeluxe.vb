Option Strict On
Option Explicit On
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Public Class TelnetDeluxe
    Inherits System.Windows.Forms.Form

    ' Esta constante corresponde al valor del WParam del mensaje que se envia a la forma cuando se minimiza
    Private Const SC_MINIMIZE As Int32 = &HF020&
    Private UniDlxVars As New UniversalDeluxe
    Private DlxToolBox As New Dlx_ToolBox
    Private DlxTCP As New TcpClient

    
    '////////////////////////////////////////////////////////////////////
    '/// Variables Generales


    Dim EsperaBallonTip As Integer = 1000
    Dim TarjetaRedConectada As Boolean = True
    Dim IPShow_Web As String = "http://www.showmyip.com"

    '////////////////////////////////////////////////////////////////////
    '/// Variables para la conexión Winsock

    Public DirPING As String = "208.69.34.230"
    Dim LectorTCP As NetworkStream
    Dim MensajeRecibido As Boolean = False

    '////////////////////////////////////////////////////////////////////
    '/// Variables Configuración para el Router
    Public ComandoArray() As String
    
    Public IniSeleccionado As String
    Public Version As String = UniDlxVars.Version
    Public TituloForm As String = "Telnet Deluxe v" & Version

    '////////////////////////////////////////////////////////////////////
    '/// Variables de estado
    Dim EstamosConectados As Boolean = False
    Dim ComprobarIP As Boolean = False
    Dim ConectadoAInet As Boolean = False
    Dim MacroOK As Boolean = True
    Public IniRouterCargada As Boolean = False

    '////////////////////////////////////////////////////////////////////
    '/// Opciones Editables por el usuario

    Public Opciones_Consola_MostrarHora As Boolean = True
    Public Opciones_LOG_LoguearIPs As Boolean = True
    Public Opciones_GUI_MinimToTray As Boolean = False

    Public Opciones_Telnet_Intervalo As Integer = 3

    Public ExtCFG_Archivo As String
    Public ExtCFG_Usuario As String
    Public ExtCFG_Pass As String
    Public ExtCFG_Puerto As String
    Public ExtCFG_IPRouter As String





    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################

    Public Sub IniciarTD(ByVal e As System.EventArgs)
        Try
            Dim lineacomandos As String
            TDLB_Progreso.Text = "0%"
            TDBE_Progreso.Value = 0
            Timer_ConexInet.Enabled = True
            TD_Opciones.ConseguirIniRouters()
            TD_Opciones.CargarCFG()
            TD_Tray.Visible = False
            TD_Tray.Text = DlxToolBox.TituloForm
            LimpiarConsola()
            Me.Text = DlxToolBox.TituloForm
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
                    IrATray()
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
                    IrATray()
                Else
                    MostrarEnConsola(UniDlxVars.Traduccion("Error_ComandoBad") & lineacomandos & UniDlxVars.Traduccion("Error_ComandoBadFin"), "Error")
                End If
            End If
            lineacomandos = Nothing
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Shared Sub Main()
        Try
            'Application.Run(New TelnetDeluxe)
        Catch oex As Exception
            MessageBox.Show("ERROR: " & oex.Message)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Funciones del formulario

    Private Sub TelnetDeluxe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer_ConexInet.Enabled = False
            crono_principal.Enabled = False
            TD_Tray.Visible = False

            MacroOK = False
            If EstamosConectados = True Then
                Desconectar()
            End If

            TD_Opciones.GuardarIP()
            Select Case Me.WindowState
                Case FormWindowState.Normal
                    Dim rect As Rectangle = Me.Bounds
                Case Else
                    Dim rect As Rectangle = Me.RestoreBounds
            End Select

        Catch ex As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & vbNewLine & ex.Message & vbNewLine & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            IniciarTD(e)
            Me.WindowState = FormWindowState.Normal
            Me.BringToFront()
            Me.UpdateZOrder()
            Me.CenterToScreen()
            Me.Focus()
        Catch EX As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & vbNewLine & EX.Message)
            Exit Sub
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            MyBase.WndProc(m)
            If CLng(m.WParam.ToInt32) = SC_MINIMIZE Then
                If Opciones_GUI_MinimToTray = True Then
                    IrATray()
                End If
            End If
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub



    '////////////////////////////////////////////////////////////////////
    '/// Funciones del menú principal

    Private Sub TD_MP_AcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_AcercaDe.Click
        Try
            TD_AcercaDe.Show()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    Private Sub TD_MP_EjecutarComandos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_EjecutarComandos.Click
        Try
            LimpiarConsola()
            ' Inis Router
            If String.IsNullOrEmpty(ExtCFG_Archivo) Then
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_SeleccionaCFG"), "Info")
            ElseIf File.Exists(DlxToolBox.CarpetaIniRouters & "\" & ExtCFG_Archivo) = False Then
                MostrarEnConsola(UniDlxVars.Traduccion("Error_INIRouterBad") & ExtCFG_Archivo & ")", "Error")
            Else
                TD_Opciones.Combo_inirouters.Text = ExtCFG_Archivo
                CargarIniRouter()
                Macro()
            End If
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Salir.Click
        Try
            Me.Close()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MToolStripMenuItem.Click
        Try
            IrATray()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Opciones.Click
        Try
            TD_Opciones.Show()
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoSistema.Click
        Try
            DlxToolBox.MostrarInfoSistema()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoRed.Click
        Try
            DlxToolBox.MostrarInfoRed()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_ConseguirIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_ConseguirIP.Click
        Try
            If Currante_ConseguirIP.IsBusy = False Then
                Currante_ConseguirIP.RunWorkerAsync()
            End If
        Catch oEX As WebException
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message & oEX.InnerException.Message, "Error")
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Funciones del menú de la consola

    Private Sub MenuConsola_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MenuConsola.Opening
        Try
            If Consola.SelectionLength > 0 Then
                MenuConsola_Copiar.Enabled = True
            Else
                MenuConsola_Copiar.Enabled = False
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Limpiar.Click
        Try
            LimpiarConsola()
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_SelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_SelTodo.Click
        Try
            Consola.SelectionStart = 0
            Consola.SelectionLength = Consola.TextLength
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Copiar.Click
        Try
            My.Computer.Clipboard.SetText(Consola.SelectedText)
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Funciones Automatizadas

    Private Sub crono_principal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles crono_principal.Tick
        Try
            ComprobarMensajes()
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

    Private Sub Consola_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Consola.TextChanged
        Try
            Consola.Update()
        Catch oEX As Exception
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Funciones del Tray

    Private Sub RestaurarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurarToolStripMenuItem.Click
        Try
            SalirDeTray()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TD_Tray.DoubleClick
        Try
            SalirDeTray()
        Catch oEX As Exception
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RenovarIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenovarIPToolStripMenuItem.Click
        Try
            MostrarTrayTip(UniDlxVars.Traduccion("Tray_Msg_RenovandoIP"))
            Macro()
            MostrarTrayTip(UniDlxVars.Traduccion("Tray_Msg_ComandosOK"))
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    ' ###########################################################
    ' <************ Funciones de control de Form ***************>
    ' ###########################################################
    Sub IrATray()
        Try
            Me.WindowState = FormWindowState.Minimized
            TD_Tray.Visible = True
            ShowInTaskbar = False
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico") & "Err2", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Sub SalirDeTray()
        Try
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Me.BringToFront()
            ShowInTaskbar = True
            TD_Tray.Visible = False
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico") & "Err2", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub MostrarTrayTip(ByVal MensajeTip As String)
        If TD_Tray.Visible = True Then
            TD_Tray.BalloonTipIcon = ToolTipIcon.Info
            TD_Tray.BalloonTipTitle = DlxToolBox.TituloForm
            TD_Tray.BalloonTipText = MensajeTip
            TD_Tray.ShowBalloonTip(EsperaBallonTip)
        End If
    End Sub


    Sub MostrarProgresoBE(ByVal Progreso As Integer)
        Try
            Dim TantoPorCiento As Integer = CType((100 / TDBE_Progreso.Maximum + 1) * Progreso, Integer)

            If TantoPorCiento < 100 Then
                TDLB_Progreso.Text = TantoPorCiento.ToString & "%"
            Else
                TDLB_Progreso.Text = "100%"
            End If

            If Progreso <= TDBE_Progreso.Maximum Then
                TDBE_Progreso.Value = Progreso
            Else
                TDBE_Progreso.Value = TDBE_Progreso.Maximum
            End If
            TantoPorCiento = Nothing
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico") & "Err1", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Sub MostrarInfoProgreso(ByVal info As String)
        Try
            TD_Tray.Text = info
            TDBE_labelinfo.Text = info
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico") & "Err2", "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub



    ' ###########################################################
    ' <************* Funciones para la consola ****************>
    ' ###########################################################

    Public Sub MostrarEnConsola(Optional ByVal Datos As String = "", Optional ByVal ColorTxt As String = "defecto")
        Try
            Dim TextoAEscribir As String
            Dim Pre_Consola As String = ""

            If Opciones_Consola_MostrarHora = True And String.IsNullOrEmpty(Datos) = False Then
                Pre_Consola = "[" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & "] "
            End If

            If String.IsNullOrEmpty(Datos) = False Then
                TextoAEscribir = Datos & ControlChars.CrLf
            Else
                TextoAEscribir = Datos & ControlChars.CrLf
            End If

            TextoAEscribir = Pre_Consola & TextoAEscribir
            Consola.SelectionStart = Consola.TextLength

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
            Consola.SelectedText = TextoAEscribir
            Consola.SelectionStart = Consola.Text.Length
            Consola.ScrollToCaret()
            TextoAEscribir = Nothing
            Pre_Consola = Nothing
        Catch ex As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & ex.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub LimpiarConsola()
        Try
            Consola.Text = ""
            MensajeBienvenida()
        Catch ex As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub MensajeBienvenida()
        Try
            MostrarEnConsola()
            MostrarEnConsola(UniDlxVars.Traduccion("General_BienvenidaInfo"), "Info")
            MostrarEnConsola(UniDlxVars.Traduccion("General_Comenzo") & System.DateTime.Now, "Info")
            MostrarEnConsola()
        Catch ex As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & ex.Message)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Telnet *********************>
    ' ###########################################################

    Private Sub Conectar()
        Try
            If My.Computer.Network.Ping(ExtCFG_IPRouter) Then
                DlxTCP = New TcpClient(ExtCFG_IPRouter.Trim, CInt(ExtCFG_Puerto.Trim))
                If DlxTCP.Connected Then
                    LectorTCP = DlxTCP.GetStream
                    LectorTCP.ReadTimeout = 3
                    LectorTCP.WriteTimeout = 3
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConexionOK"), "Info")
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConectadoA") & ExtCFG_IPRouter & UniDlxVars.Traduccion("Console_Msg_ConectadoAPuerto") & ExtCFG_Puerto, "Info")
                    label_estado.Text = UniDlxVars.Traduccion("Gui_General_Conectado")
                    label_estado.BackColor = Color.OliveDrab

                    crono_principal.Enabled = True
                    EstamosConectados = True
                    Me.Refresh()
                Else
                    MostrarEnConsola(UniDlxVars.Traduccion("Error_CompruebaIpPuerto"), "Error")
                    EstamosConectados = False
                    MacroOK = False
                End If
            Else
                MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPING") & ExtCFG_IPRouter & UniDlxVars.Traduccion("Error_NoPING2"), "Error")
                EstamosConectados = False
                MacroOK = False
            End If
        Catch oEX As SocketException
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPuedoConectar"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            MacroOK = False
            Exit Sub
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            DlxTCP.Close()
            EstamosConectados = False
            label_estado.Text = UniDlxVars.Traduccion("Gui_General_DesConectado")
            label_estado.BackColor = Color.Red
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_Desconectado"), "Info")
            Me.Refresh()
            crono_principal.Enabled = False
        Catch oEX As SocketException
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPuedoDesconectar"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            MacroOK = False
            Exit Sub
        End Try
    End Sub

    Private Sub ComprobarMensajes()
        Try
            Dim CadenaRecibida As String = String.Empty
            Dim NumBytes As Integer = 0
            Dim BytesARecibir(1024) As [Byte]
            Dim DatosParaRecibir As [Byte]()

            If DlxTCP.Connected Then
                If LectorTCP.DataAvailable Then
                    Esperar(1000)
                    DatosParaRecibir = New [Byte](256) {}
                    If LectorTCP.CanRead Then
                        Dim bytes As Int32 = LectorTCP.Read(DatosParaRecibir, 0, DatosParaRecibir.Length)
                        CadenaRecibida = System.Text.Encoding.ASCII.GetString(DatosParaRecibir, 0, bytes)
                        MostrarEnConsola(CadenaRecibida, "Router")
                        MostrarInfoProgreso("Recibidos " & CadenaRecibida.Length.ToString & " Bytes")
                        CadenaRecibida = Nothing
                    Else
                        MostrarEnConsola(UniDlxVars.Traduccion("Error_ConexionPerdida"), "Error")
                    End If
                Else
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_EsperandoRespuesta"), "Accion")
                End If
            Else
                MostrarEnConsola(UniDlxVars.Traduccion("Error_ConexionPerdida"), "Error")
                MacroOK = False
            End If

            CadenaRecibida = Nothing
            NumBytes = Nothing
            BytesARecibir = Nothing
        Catch oEX As SocketException
            MacroOK = False
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoRespuestaRouter"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub EnviarComandos(ByVal comandos As String)
        Try
            Dim BytesParaEnviar As [Byte]() = Encoding.ASCII.GetBytes(comandos & vbCrLf)
             If LectorTCP.CanWrite Then
                LectorTCP.Write(BytesParaEnviar, 0, BytesParaEnviar.Length)
                BytesParaEnviar = Nothing
            Else
                MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPuedoEnviarComando"), "Accion")
                MacroOK = False
            End If
        Catch oEX As SocketException
            MostrarEnConsola(UniDlxVars.Traduccion("Error_EnviandoComando"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            MacroOK = False
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Generales ******************>
    ' ###########################################################

    Private Sub Macro()
        Try
            If IniRouterCargada = False Then
                MostrarEnConsola(UniDlxVars.Traduccion("Error_NoConfigCargada"), "Error")
                MostrarEnConsola()
                Exit Sub
            Else
                If My.Computer.Network.IsAvailable = False Then
                    MostrarEnConsola(UniDlxVars.Traduccion("Error_NoTarjetaRed"), "Error")
                    MostrarEnConsola(UniDlxVars.Traduccion("Error_Macro"), "Error")
                    MostrarEnConsola()
                    Exit Sub
                Else
                    TDLB_Progreso.Text = "0%"
                    TDBE_Progreso.Value = 0
                    'LeerIP()
                    Conectar()
                    Esperar(3000)
                    If EstamosConectados = False Then
                        MostrarEnConsola(UniDlxVars.Traduccion("Error_NoConectadoRouter"), "Error")
                        MostrarEnConsola()
                        Exit Sub
                    Else
                        TDBE_Progreso.Maximum = ComandoArray.Length

                        For Each cmdd As String In ComandoArray
                            If MacroOK = True Then
                                MostrarProgresoBE(TDBE_Progreso.Value + 1)
                                MostrarInfoProgreso("Enviando Comando: " & cmdd)
                                EnviarComandos(cmdd)
                                Esperar(Opciones_Telnet_Intervalo * 1000)
                            Else
                                MostrarEnConsola()
                                MostrarEnConsola(UniDlxVars.Traduccion("Error_Macro"), "Error")
                                MostrarEnConsola()
                                Desconectar()
                                Exit Sub
                            End If
                        Next
                        Desconectar()
                        Esperar(3000)
                        If MacroOK = True Then
                            MostrarEnConsola()
                            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ComandosOK"), "Accion")
                            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ComandosOKWait"), "Info")
                            MostrarEnConsola()
                            MostrarInfoProgreso(UniDlxVars.Traduccion("Console_Msg_ComandosOK"))
                            Esperar(3000)
                            ComprobarConexion()
                            ComprobarIP = True
                        Else
                            MostrarEnConsola()
                            MostrarInfoProgreso(UniDlxVars.Traduccion("Error_Macro_General"))
                            MostrarEnConsola(UniDlxVars.Traduccion("Error_Macro_General"), "Error")
                            MostrarEnConsola()
                            MostrarProgresoBE(TDBE_Progreso.Maximum)
                            MostrarInfoProgreso("Ocurrió un error")
                            Desconectar()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Macro_General"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            MostrarProgresoBE(TDBE_Progreso.Maximum)
            MostrarInfoProgreso("Ocurrió un error")
            Desconectar()
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
            Parar = Nothing
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Internet *******************>
    ' ###########################################################

    Sub LeerIP()
        Try
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConsiguiendoIP"), "Accion")
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_EsperaLarga"), "Info")
            MostrarEnConsola()
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConectandoCon") & IPShow_Web, "Accion")
            MostrarEnConsola()
            If Currante_ConseguirIP.IsBusy = False And ConectadoAInet Then
                Currante_ConseguirIP.RunWorkerAsync()
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoConsigoIP"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Currante_ConseguirIP_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Currante_ConseguirIP.DoWork
        Try
            Dim ClienteWeb As New System.Net.WebClient
            If My.Computer.Network.IsAvailable Then
                Dim Archivo As New System.IO.StreamReader(ClienteWeb.OpenRead(IPShow_Web))
                e.Result = Archivo.ReadToEnd()
                Archivo.Close()
                Archivo.Dispose()
                Archivo = Nothing
            Else
                e.Result = ""
            End If
            ClienteWeb.Dispose()

            ClienteWeb = Nothing
        Catch oEX As Exception
            'MessageBox.Show(UniDlxVars.Traduccion("Error_Generico") & vbNewLine & oEX.Message)
            e.Result = ""
            Exit Sub
        End Try
    End Sub

    Private Sub Currante_ConseguirIP_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Currante_ConseguirIP.RunWorkerCompleted
        Try
            MostrarIP(e.Result.ToString)
            e = Nothing
            Currante_ConseguirIP.Dispose()
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarIP(ByVal RawHtml As String)
        Try
            Dim reg As RegularExpressions.Regex
            Dim mc As RegularExpressions.MatchCollection
            Dim DirIPActual As String

            If RawHtml <> "" Then
                reg = New RegularExpressions.Regex("([0-9]+.[0-9]+.[0-9]+.[0-9]+)", RegularExpressions.RegexOptions.IgnoreCase Or RegularExpressions.RegexOptions.Compiled Or RegularExpressions.RegexOptions.Multiline)
                mc = reg.Matches(RawHtml)
                DirIPActual = Trim(mc.Item(0).ToString)
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIPActual, "DirIP")
                MostrarEnConsola()
                MostrarTrayTip(UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIPActual)

                If txtbox_info_ipact.Text <> DirIPActual Then
                    txtbox_info_ipant.Text = txtbox_info_ipact.Text
                    txtbox_info_ipact.Text = DirIPActual

                    If Opciones_LOG_LoguearIPs = True Then
                        DlxToolBox.EscribirLogIP(DirIPActual)
                    End If

                End If
                ComprobarIP = False
            Else
                MostrarEnConsola(UniDlxVars.Traduccion("Error_ConsiguiendoHTML"), "Error")
                DirIPActual = txtbox_info_ipact.Text
                Exit Sub
            End If
            reg = Nothing
            mc = Nothing
            DirIPActual = Nothing
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoConsigoIP"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    Private Sub ComprobarConexion()
        Try
            If My.Computer.Network.IsAvailable Then
                TarjetaRedConectada = True
                If Currante_Ping.IsBusy = False Then
                    Currante_Ping.RunWorkerAsync()
                End If
            Else
                If TarjetaRedConectada Then
                    MostrarEnConsola(UniDlxVars.Traduccion("Error_NoTarjetaRed"), "Error")
                    TarjetaRedConectada = False
                    label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Offline")
                    label_inetconex.BackColor = Color.Red
                    Timer_ConexInet.Interval = 2000
                    ConectadoAInet = False
                End If
                Exit Sub
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoConexion"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub Currante_Ping_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Currante_Ping.DoWork
        Try
            If My.Computer.Network.IsAvailable Then
                If My.Computer.Network.Ping(DirPING) Then
                    e.Result = True
                Else
                    e.Result = False
                End If
            Else
                e.Result = False
            End If
        Catch oEX As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_Generico") & vbNewLine & oEX.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Currante_Ping_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Currante_Ping.RunWorkerCompleted
        Try
            MostrarConexionInet(CBool(e.Result.ToString))
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarConexionInet(ByVal Conectado As Boolean)
        Try
            If Conectado = True Then
                label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Online")
                label_inetconex.BackColor = Color.OliveDrab
                Timer_ConexInet.Interval = 15000
                ConectadoAInet = True
                If ComprobarIP = True Then
                    MostrarTrayTip(UniDlxVars.Traduccion("Tray_Msg_Online"))
                    LeerIP()
                    ComprobarIP = False
                End If
            Else
                label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Offline")
                label_inetconex.BackColor = Color.Red
                Timer_ConexInet.Interval = 3000
                ConectadoAInet = False
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    ' ###########################################################
    ' <****************** Funciones De Archivo *****************>
    ' ###########################################################
    Sub CargarIniRouter()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr
            'Dim IniSeleccionado As String = CarpetaIniRouters & "\" & TD_Opciones.Combo_inirouters.Text.ToString
            If File.Exists(IniSeleccionado) = False Then
                MostrarEnConsola(UniDlxVars.Traduccion("Error_NoExisteCFG") & IniSeleccionado & ")", "Error")
                Exit Sub
            Else
                Dim NombreRouter As String
                Dim Revision As String
                Dim Fecha As String
                Dim Autor As String
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_LeyendoCFG"), "Accion")
                MostrarEnConsola()

                NombreRouter = DeluxeIniMgr.INIMgr_Conseguir(IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_NombreRouter"), "No se ha seleccionado ningún router")
                ComandoArray = Split(ExtCFG_Usuario & "," & ExtCFG_Pass & "," & DeluxeIniMgr.INIMgr_Conseguir(IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Comandos"), "selecciona,fichero,ini"), ",")
                Revision = DeluxeIniMgr.INIMgr_Conseguir(IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Revision"), "")
                Fecha = DeluxeIniMgr.INIMgr_Conseguir(IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Fecha"), "")
                Autor = DeluxeIniMgr.INIMgr_Conseguir(IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Autor"), "")
                IniRouterCargada = True
                Me.Text = NombreRouter & " | INI by " & Autor & " | " & DlxToolBox.TituloForm
                'Me.boton_actualizar.Enabled = True
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCFG") & NombreRouter & UniDlxVars.Traduccion("Console_Msg_InfoCFG2") & Revision, "Info")
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCFG3") & Autor & UniDlxVars.Traduccion("Console_Msg_InfoCFG4") & Fecha, "Info")
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCargOK"), "Accion")
                MostrarEnConsola()
                DeluxeIniMgr = Nothing
            End If
        Catch oEX As Exception
            MostrarEnConsola(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"), "Error")
            MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub
End Class

