Option Strict On
Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Text
Public Class TelnetDeluxe
    Inherits System.Windows.Forms.Form

    ' Esta constante corresponde al valor del WParam del mensaje que se envia a la forma cuando se minimiza
    Private Const SC_MINIMIZE As Int32 = &HF020&
    Private UniDlxVars As New UniversalDeluxe
    Private DlxToolBox As New Dlx_ToolBox
    Private DlxTCP As New TcpClient

    Public Estado As Dlx_ToolBox.Estado
    Public ConfigTelnet As Dlx_ToolBox.CFGTelnet
    Public OpcionesTD As Dlx_ToolBox.Opciones
    Public ColorConsola As Dlx_ToolBox.ColorConsola

    Public Version As String = UniDlxVars.Version
    Public TituloForm As String = "Telnet Deluxe v" & Version

    '////////////////////////////////////////////////////////////////////
    '/// Variables Generales


    '////////////////////////////////////////////////////////////////////
    '/// Variables para la conexión Winsock

    Public DirPING As String = "208.69.34.230"
    Dim LectorTCP As NetworkStream
    Dim MensajeRecibido As Boolean = False

    '////////////////////////////////////////////////////////////////////
    '/// Variables Configuración para el Router
    Public ComandoArray() As String



    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################
    Public Sub NuevaInstancia(ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)
        Try
            Dim tam As Integer = e.CommandLine.Count
            Dim array(e.CommandLine.Count + 1) As String

            e.BringToForeground = False
            e.CommandLine.CopyTo(array, 1)
            IniciarTD(array)
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    Private Sub OpcionesDefecto()
        Try
            Estado.EstamosConectados = False
            Estado.ComprobarIP = False
            Estado.NuevaIP = True
            Estado.ConectadoAInet = False
            Estado.MacroOK = True
            Estado.IniRouterCargada = False
            Estado.TarjetaRedConectada = True

            OpcionesTD.Consola_MostrarHora = True
            OpcionesTD.LOG_LoguearIPs = True
            OpcionesTD.GUI_MinimToTray = False
            OpcionesTD.LOG_LoguearErrores = True
            OpcionesTD.LOG_MostrarErrDetallado = True
            OpcionesTD.FUNC_IPShow_Web = "http://www.showmyip.com"
            OpcionesTD.Telnet_Intervalo = 3
            OpcionesTD.EsperaBallonTip = 1000

            ColorConsola.Color_Fondo = Color.FromArgb(64, 64, 64)
            ColorConsola.Color_defecto = Color.Yellow
            ColorConsola.Color_info = Color.Orange
            ColorConsola.Color_error = Color.Red
            ColorConsola.Color_router = Color.White
            ColorConsola.Color_accion = Color.YellowGreen
            ColorConsola.Color_DirIP = Color.Aqua

        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    Public Sub IniciarTD(ByVal comandos() As String)
        Try
            Dim lineacomandos As String
            Dim Mostrar As Boolean = True

            ' Definir valores por defecto
            TDLB_Progreso.Text = "0%"
            TDBE_Progreso.Value = 0
            Timer_ConexInet.Enabled = True
            TD_Tray.Visible = False
            TD_Tray.Text = DlxToolBox.TituloForm
            Me.Text = DlxToolBox.TituloForm

            OpcionesDefecto()

            ' Carga la configuración

            TD_Opciones.CargarOpciones()

            ' Aplica las opciones
            Consola.BackColor = ColorConsola.Color_Fondo

            ' Prepara el programa
            LimpiarConsola()
            DlxToolBox.Esperar(500)

            Me.Show()
            Me.Focus()
            Me.Activate()

            If comandos.Length > 1 Then
                lineacomandos = UCase(comandos(1))
                If lineacomandos = "/RYC" Then
                    DlxToolBox.Esperar(1000)
                    Macro()
                    While Not Estado.ConectadoAInet
                        DlxToolBox.Esperar(100)
                    End While
                    Me.Close()
                    Mostrar = True
                ElseIf lineacomandos = "/RYCS" Then
                    IrATray()
                    DlxToolBox.Esperar(1000)
                    Macro()
                    While Not Estado.ConectadoAInet
                        DlxToolBox.Esperar(100)
                    End While
                    Me.Close()
                    Mostrar = False
                ElseIf lineacomandos = "/RENOVAR" Then
                    DlxToolBox.Esperar(3000)
                    Macro()
                    Mostrar = False
                ElseIf lineacomandos = "/CERRAR" Then
                    Me.Close()
                    Mostrar = False
                ElseIf lineacomandos = "/TRAY" Then
                    IrATray()
                    Mostrar = False
                Else
                    'DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_ComandoBad") & lineacomandos & UniDlxVars.Traduccion("Error_ComandoBadFin"))
                    Mostrar = False
                End If

                If Mostrar = True Then
                    Me.WindowState = FormWindowState.Normal
                    Me.BringToFront()
                    Me.UpdateZOrder()
                    Me.CenterToScreen()
                    Me.Focus()
                Else

                End If
            End If
            lineacomandos = Nothing
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
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
            Estado.MacroOK = False
            DlxToolBox.Esperar(200)
            If Estado.EstamosConectados = True Then
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
            Dim miMutex As System.Threading.Mutex
            Dim nuevaInstancia As Boolean
            miMutex = New System.Threading.Mutex(True, "Telnet Deluxe", nuevaInstancia)
            IniciarTD(Environment.GetCommandLineArgs())
        Catch EX As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & vbNewLine & EX.Message)
            Exit Sub
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            MyBase.WndProc(m)
            If CLng(m.WParam.ToInt32) = SC_MINIMIZE Then
                If OpcionesTD.GUI_MinimToTray = True Then
                    IrATray()
                End If
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Funciones del menú principal

    Private Sub TD_MP_AcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_AcercaDe.Click
        Try
            TD_AcercaDe.Show()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Private Sub TD_MP_EjecutarComandos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_EjecutarComandos.Click
        Try
            LimpiarConsola()
            ' Inis Router
            If String.IsNullOrEmpty(ConfigTelnet.Archivo) Then
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_SeleccionaCFG"), Dlx_ToolBox.MensajeConsola.MSG_Info)
            ElseIf File.Exists(DlxToolBox.CarpetaIniRouters & "\" & ConfigTelnet.Archivo) = False Then
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_INIRouterBad") & ConfigTelnet.Archivo & ")")
            Else
                TD_Opciones.Combo_inirouters.Text = ConfigTelnet.Archivo
                CargarIniRouter()
                Macro()
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Salir.Click
        Try
            Me.Close()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MToolStripMenuItem.Click
        Try
            IrATray()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Opciones.Click
        Try
            TD_Opciones.Show()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoSistema.Click
        Try
            DlxToolBox.MostrarInfoSistema()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoRed.Click
        Try
            DlxToolBox.MostrarInfoRed()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_ConseguirIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_ConseguirIP.Click
        Try
            Estado.NuevaIP = False
            LeerIP()
        Catch oEX As WebException
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Limpiar.Click
        Try
            LimpiarConsola()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_SelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_SelTodo.Click
        Try
            Consola.Focus()
            Consola.SelectionStart = 0
            Consola.SelectionLength = Consola.TextLength
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Copiar.Click
        Try
            My.Computer.Clipboard.SetText(Consola.SelectedText)
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Funciones Automatizadas

    Private Sub crono_principal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles crono_principal.Tick
        Try
            ComprobarMensajes()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub Timer_ConexInet_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ConexInet.Tick
        Try
            ComprobarConexion()
            If Estado.EjecutandoMacro = True Then
                EComandos.Image = My.Resources.BotonTelnetOFF
                EComandos.Tag = "Cancelar envío de Comandos"
            Else
                EComandos.Image = My.Resources.BotonTelnetON
                EComandos.Tag = "Ejecutar Comandos Telnet"
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
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
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TD_Tray.DoubleClick
        Try
            SalirDeTray()
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <*************** Se ha cambiado la config ****************>
    ' ###########################################################

    Public Sub ConfigCambiada()
        Try
            Consola.BackColor = ColorConsola.Color_Fondo
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Sub SalirDeTray()
        Try
            Me.WindowState = FormWindowState.Normal
            ShowInTaskbar = True
            TD_Tray.Visible = False
            Me.Activate()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MostrarTrayTip(ByVal MensajeTip As String)
        If TD_Tray.Visible = True Then
            TD_Tray.BalloonTipIcon = ToolTipIcon.Info
            TD_Tray.BalloonTipTitle = DlxToolBox.TituloForm
            TD_Tray.BalloonTipText = MensajeTip
            TD_Tray.ShowBalloonTip(OpcionesTD.EsperaBallonTip)
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Sub MostrarInfoProgreso(ByVal info As String)
        Try
            TD_Tray.Text = info
            TDBE_labelinfo.Text = info
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub



    ' ###########################################################
    ' <************* Funciones para la consola ****************>
    ' ###########################################################

    Public Sub MostrarEnConsola(Optional ByVal Datos As String = "", Optional ByVal TipoMensaje As Dlx_ToolBox.MensajeConsola = Dlx_ToolBox.MensajeConsola.MSG_Defecto)
        Try
            Dim TextoAEscribir As String
            Dim Pre_Consola As String = ""

            If OpcionesTD.Consola_MostrarHora = True And String.IsNullOrEmpty(Datos) = False Then
                Pre_Consola = DlxToolBox.MostrarHora
            End If

            If String.IsNullOrEmpty(Datos) = False Then
                TextoAEscribir = Datos & ControlChars.CrLf
            Else
                TextoAEscribir = Datos & ControlChars.CrLf
            End If

            TextoAEscribir = Pre_Consola & TextoAEscribir
            Consola.SelectionStart = Consola.TextLength

            If TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_Defecto Then
                Consola.SelectionColor = ColorConsola.Color_defecto
            ElseIf TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_Info Then
                Consola.SelectionColor = ColorConsola.Color_info
            ElseIf TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_Error Then
                Consola.SelectionColor = ColorConsola.Color_error
            ElseIf TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_Router Then
                Consola.SelectionColor = ColorConsola.Color_router
            ElseIf TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_Accion Then
                Consola.SelectionColor = ColorConsola.Color_accion
            ElseIf TipoMensaje = Dlx_ToolBox.MensajeConsola.MSG_DirIP Then
                Consola.SelectionColor = ColorConsola.Color_DirIP
            Else
                Consola.SelectionColor = ColorConsola.Color_defecto
            End If
            Consola.SelectedText = TextoAEscribir
            Consola.SelectionStart = Consola.Text.Length
            Consola.ScrollToCaret()
            TextoAEscribir = Nothing
            Pre_Consola = Nothing
        Catch ex As Exception
            MessageBox.Show(UniDlxVars.Traduccion("Error_NoControlado") & ex.Message)
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
            MostrarEnConsola(UniDlxVars.Traduccion("General_BienvenidaInfo"), Dlx_ToolBox.MensajeConsola.MSG_Info)
            MostrarEnConsola(UniDlxVars.Traduccion("General_Comenzo") & System.DateTime.Now, Dlx_ToolBox.MensajeConsola.MSG_Info)
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
            If My.Computer.Network.IsAvailable Then
                Dim SolicitudPing As NetworkInformation.PingReply
                Dim CliPing As New NetworkInformation.Ping
                SolicitudPing = CliPing.Send(DirPING)


                If SolicitudPing.Status = IPStatus.Success Then
                    DlxTCP = New TcpClient(ConfigTelnet.IPRouter.Trim, CInt(ConfigTelnet.Puerto.Trim))
                    If DlxTCP.Connected Then
                        LectorTCP = DlxTCP.GetStream
                        LectorTCP.ReadTimeout = 3
                        LectorTCP.WriteTimeout = 3
                        'MostrarEnConsola(DlxTCP.ReceiveTimeout.ToString, Dlx_ToolBox.MensajeConsola.MSG_DirIP)

                        MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConexionOK"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
                        MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConectadoA") & ConfigTelnet.IPRouter & UniDlxVars.Traduccion("Console_Msg_ConectadoAPuerto") & ConfigTelnet.Puerto, Dlx_ToolBox.MensajeConsola.MSG_Accion)
                        label_estado.Text = UniDlxVars.Traduccion("Gui_General_Conectado")
                        label_estado.BackColor = Color.OliveDrab

                        crono_principal.Enabled = True
                        Estado.EstamosConectados = True
                        Me.Refresh()
                    Else
                        DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_CompruebaIpPuerto"))
                        Estado.EstamosConectados = False
                        Estado.MacroOK = False
                    End If
                ElseIf SolicitudPing.Status = IPStatus.DestinationHostUnreachable Then
                    DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPING") & ConfigTelnet.IPRouter & UniDlxVars.Traduccion("Error_NoPING2"))
                    Estado.EstamosConectados = False
                    Estado.MacroOK = False
                Else
                    DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPING") & ConfigTelnet.IPRouter & UniDlxVars.Traduccion("Error_NoPING2"))
                    Estado.EstamosConectados = False
                    Estado.MacroOK = False
                End If
                CliPing.Dispose()
            Else
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                Estado.EstamosConectados = False
                Estado.MacroOK = False
            End If
        Catch oEX As SocketException
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
            DlxToolBox.MostrarError(oEX)
            Estado.MacroOK = False
            Exit Sub
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            DlxTCP.Close()
            DlxTCP = Nothing
            Estado.EstamosConectados = False
            label_estado.Text = UniDlxVars.Traduccion("Gui_General_DesConectado")
            label_estado.BackColor = Color.Red
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_Desconectado"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
            Me.Refresh()
            crono_principal.Enabled = False
        Catch oEX As SocketException
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoDesconectar"))
            DlxToolBox.MostrarError(oEX)
            Estado.MacroOK = False
            Exit Sub
        End Try
    End Sub

    Private Sub ComprobarMensajes()
        Try
            Dim CadenaRecibida As String = String.Empty
            Dim NumBytes As Integer = 0
            Dim BytesARecibir(1024) As [Byte]
            Dim DatosParaRecibir As [Byte]()

            If Estado.PararMacro = True Then
                Exit Sub
            ElseIf DlxTCP.Connected Then
                If LectorTCP.DataAvailable Then
                    DlxToolBox.Esperar(1000)
                    DatosParaRecibir = New [Byte](256) {}
                    If LectorTCP.CanRead Then
                        Dim bytes As Int32 = LectorTCP.Read(DatosParaRecibir, 0, DatosParaRecibir.Length)
                        CadenaRecibida = System.Text.Encoding.ASCII.GetString(DatosParaRecibir, 0, bytes)
                        MostrarEnConsola(CadenaRecibida, Dlx_ToolBox.MensajeConsola.MSG_Router)
                        MostrarInfoProgreso("Recibidos " & CadenaRecibida.Length.ToString & " Bytes")
                        CadenaRecibida = Nothing
                    Else
                        DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_ConexionPerdida"))
                    End If
                Else
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_EsperandoRespuesta"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
                End If
            Else
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_ConexionPerdida"))
                Estado.MacroOK = False
            End If

            CadenaRecibida = Nothing
            NumBytes = Nothing
            BytesARecibir = Nothing
        Catch oEX As SocketException
            Estado.MacroOK = False
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoRespuestaRouter"))
            DlxToolBox.MostrarError(oEX)
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
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoEnviarComando"))
                Estado.MacroOK = False
            End If
        Catch oEX As SocketException
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_EnviandoComando"))
            DlxToolBox.MostrarError(oEX)
            Estado.MacroOK = False
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Generales ******************>
    ' ###########################################################

    Public Sub Macro()
        Try
            Estado.MacroOK = True
            Estado.PararMacro = False
            TDLB_Progreso.Text = "0%"
            TDBE_Progreso.Value = 0

            Estado.EjecutandoMacro = True


            If Estado.IniRouterCargada = False Then
                CargarIniRouter()
            End If

            TDBE_Progreso.Maximum = ComandoArray.Length


            If My.Computer.Network.IsAvailable = False Then
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Macro"))
                MostrarEnConsola()
                Exit Sub
            End If

            'LeerIP()
            Conectar()
            DlxToolBox.Esperar(3000)

            If Estado.EstamosConectados = False Then
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoConectadoRouter"))
                MostrarEnConsola()
                Exit Sub
            End If

            For Each ComandoTelnet As String In ComandoArray
                If Estado.MacroOK = True And Estado.PararMacro = False Then
                    Me.Cursor = Cursors.WaitCursor
                    MostrarProgresoBE(TDBE_Progreso.Value + 1)
                    MostrarInfoProgreso("Enviando Comando: " & ComandoTelnet)
                    EnviarComandos(ComandoTelnet)
                    Me.Cursor = Cursors.Default
                    DlxToolBox.Esperar(OpcionesTD.Telnet_Intervalo * 1000)
                Else
                    Exit For
                End If
            Next

            Desconectar()
            DlxToolBox.Esperar(3000)

            If Estado.PararMacro = True Then
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_OperacionCancelada"), Dlx_ToolBox.MensajeConsola.MSG_Error)
                Estado.ComprobarIP = False
                Estado.NuevaIP = False
            ElseIf Estado.MacroOK = True Then
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ComandosOK"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ComandosOKWait"), Dlx_ToolBox.MensajeConsola.MSG_Info)
                MostrarEnConsola()
                MostrarInfoProgreso(UniDlxVars.Traduccion("Console_Msg_ComandosOK"))
                DlxToolBox.Esperar(3000)
                ComprobarConexion()
                Estado.ComprobarIP = True
                Estado.NuevaIP = True
            Else
                MostrarEnConsola()
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Macro"))
                MostrarEnConsola()
                MostrarInfoProgreso(UniDlxVars.Traduccion("Error_Macro_General"))
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
                MostrarEnConsola()
                MostrarProgresoBE(TDBE_Progreso.Maximum)
                Estado.ComprobarIP = False
            End If

            EComandos.Image = My.Resources.BotonTelnetON
            EComandos.Tag = "Ejecutar Comandos Telnet"
            Estado.EjecutandoMacro = False
            MostrarProgresoBE(0)
            MostrarInfoProgreso("Telnet Deluxe...")

        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
            DlxToolBox.MostrarError(oEX)
            MostrarProgresoBE(TDBE_Progreso.Maximum)
            MostrarInfoProgreso("Ocurrió un error")
            Desconectar()
            Exit Sub
        End Try
    End Sub


    ' ###########################################################
    ' <****************** Funciones Internet *******************>
    ' ###########################################################

    Sub LeerIP()
        Try
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConsiguiendoIP"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_EsperaLarga"), Dlx_ToolBox.MensajeConsola.MSG_Info)
            MostrarEnConsola()
            MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConectandoCon") & OpcionesTD.FUNC_IPShow_Web, Dlx_ToolBox.MensajeConsola.MSG_Accion)
            MostrarEnConsola()
            If Currante_ConseguirIP.IsBusy = False And Estado.ConectadoAInet Then
                Currante_ConseguirIP.RunWorkerAsync()
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoConsigoIP"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub Currante_ConseguirIP_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Currante_ConseguirIP.DoWork
        Try
            Dim ClienteWeb As New System.Net.WebClient

            If My.Computer.Network.IsAvailable Then
                Dim Archivo As New System.IO.StreamReader(ClienteWeb.OpenRead(OpcionesTD.FUNC_IPShow_Web))
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarIP(ByVal RawHtml As String)
        Try
            Dim reg As RegularExpressions.Regex
            Dim mc As RegularExpressions.MatchCollection
            Dim DirIPActual As String

            If RawHtml <> "" Then
                reg = New RegularExpressions.Regex("\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", RegularExpressions.RegexOptions.IgnoreCase Or RegularExpressions.RegexOptions.Compiled Or RegularExpressions.RegexOptions.Multiline)
                mc = reg.Matches(RawHtml)
                If mc.Count > 0 Then
                    DirIPActual = Trim(mc.Item(0).ToString)
                Else
                    DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_ConsiguiendoHTML"))
                    Exit Sub
                End If

                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIPActual, Dlx_ToolBox.MensajeConsola.MSG_DirIP)
                MostrarEnConsola()
                MostrarTrayTip(UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIPActual)

                If txtbox_info_ipact.Text <> DirIPActual Then
                    txtbox_info_ipant.Text = txtbox_info_ipact.Text
                    txtbox_info_ipact.Text = DirIPActual
                    If OpcionesTD.LOG_LoguearIPs = True Then
                        DlxToolBox.EscribirLogIP(DirIPActual)
                    End If
                Else
                    If Estado.NuevaIP Then
                        MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_IPIgual"), Dlx_ToolBox.MensajeConsola.MSG_Info)
                        MostrarEnConsola()
                    End If
                End If
                Estado.ComprobarIP = False
                Estado.NuevaIP = False
            Else
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_ConsiguiendoHTML"))
                Exit Sub
            End If
            reg = Nothing
            mc = Nothing
            DirIPActual = Nothing
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoConsigoIP"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Private Sub ComprobarConexion()
        Try
            If My.Computer.Network.IsAvailable Then
                Estado.TarjetaRedConectada = True
                If Currante_Ping.IsBusy = False Then
                    Currante_Ping.RunWorkerAsync()
                End If
            Else
                If Estado.TarjetaRedConectada Then
                    DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                    Estado.TarjetaRedConectada = False
                    label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Offline")
                    label_inetconex.BackColor = Color.Red
                    Timer_ConexInet.Interval = 2000
                    Estado.ConectadoAInet = False
                End If
                Exit Sub
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoConexion"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub Currante_Ping_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Currante_Ping.DoWork
        Try
            If My.Computer.Network.IsAvailable Then
                Dim SolicitudPing As NetworkInformation.PingReply
                Dim CliPing As New NetworkInformation.Ping
                SolicitudPing = CliPing.Send(DirPING)
                If SolicitudPing.Status = IPStatus.Success Then
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
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarConexionInet(ByVal Conectado As Boolean)
        Try
            If Conectado = True Then
                label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Online")
                label_inetconex.BackColor = Color.OliveDrab
                Timer_ConexInet.Interval = 15000
                Estado.ConectadoAInet = True
                If Estado.ComprobarIP = True Then
                    MostrarTrayTip(UniDlxVars.Traduccion("Tray_Msg_Online"))
                    LeerIP()
                End If
            Else
                label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Offline")
                label_inetconex.BackColor = Color.Red
                Timer_ConexInet.Interval = 3000
                Estado.ConectadoAInet = False
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    ' ###########################################################
    ' <****************** Funciones De Archivo *****************>
    ' ###########################################################
    Sub CargarIniRouter()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr
            If File.Exists(ConfigTelnet.IniSeleccionado) = False Then
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoExisteCFG") & ConfigTelnet.IniSeleccionado & ")")
                Exit Sub
            Else
                Dim InfoRouter As New Dlx_ToolBox.InfoRouter

                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_LeyendoCFG"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
                MostrarEnConsola()

                ' Carga la configuración del INI y la guarda en las variables
                InfoRouter.NombreRouter = DeluxeIniMgr.INIMgr_Conseguir(ConfigTelnet.IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_NombreRouter"), "No se ha seleccionado ningún router")
                ComandoArray = Split(ConfigTelnet.Usuario & "," & ConfigTelnet.Pass & "," & DeluxeIniMgr.INIMgr_Conseguir(ConfigTelnet.IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Comandos"), "selecciona,fichero,ini"), ",")
                InfoRouter.Revision = DeluxeIniMgr.INIMgr_Conseguir(ConfigTelnet.IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Revision"), "")
                InfoRouter.Fecha = DeluxeIniMgr.INIMgr_Conseguir(ConfigTelnet.IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Fecha"), "")
                InfoRouter.Autor = DeluxeIniMgr.INIMgr_Conseguir(ConfigTelnet.IniSeleccionado, UniDlxVars.VarIniPrincipal("Ini_Router"), UniDlxVars.VarIniPrincipal("Ini_Router_Autor"), "")
                Estado.IniRouterCargada = True

                Me.Text = InfoRouter.NombreRouter & " | INI by " & InfoRouter.Autor & " | " & DlxToolBox.TituloForm

                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCFG") & InfoRouter.NombreRouter & UniDlxVars.Traduccion("Console_Msg_InfoCFG2") & InfoRouter.Revision, Dlx_ToolBox.MensajeConsola.MSG_Info)
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCFG3") & InfoRouter.Autor & UniDlxVars.Traduccion("Console_Msg_InfoCFG4") & InfoRouter.Fecha, Dlx_ToolBox.MensajeConsola.MSG_Info)
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_InfoCargOK"), Dlx_ToolBox.MensajeConsola.MSG_Accion)
                MostrarEnConsola()

                DeluxeIniMgr = Nothing
                InfoRouter = Nothing
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Private Sub EComandos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EComandos.Click
        Try
            If Estado.EjecutandoMacro = True Then
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_CancelarOperacion"), Dlx_ToolBox.MensajeConsola.MSG_Info)
                MostrarEnConsola()
                Estado.PararMacro = True
            Else
                LimpiarConsola()
                EComandos.Image = My.Resources.BotonTelnetOFF
                EComandos.Tag = "Cancelar envío de Comandos"
                If String.IsNullOrEmpty(ConfigTelnet.Archivo) Then
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_SeleccionaCFG"), Dlx_ToolBox.MensajeConsola.MSG_Info)
                ElseIf File.Exists(DlxToolBox.CarpetaIniRouters & "\" & ConfigTelnet.Archivo) = False Then
                    DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_INIRouterBad") & ConfigTelnet.Archivo & ")")
                Else
                    TD_Opciones.Combo_inirouters.Text = ConfigTelnet.Archivo
                    CargarIniRouter()
                    Macro()
                End If
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class

