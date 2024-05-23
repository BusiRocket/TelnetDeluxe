Option Strict On
Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports TelnetDeluxe.Deluxe
Public Class TD_Principal
    Inherits System.Windows.Forms.Form

    Public Eventos As New DlxEventos
    Private Errores As New DlxErrores
    Private UniDlxVars As New UniversalDeluxe
    Private MainLoop As New Main_Loop

    Private OpcionesMng As New DlxOpcionesManager
    Private Variables As New DlxVariables
    Private Crono As New DlxCrono
    Private Informacion As New DlxInformacion
    Private Formularios As New DlxFormularios
    Public ToolBox As New DlxToolBox

    Public miMutex As System.Threading.Mutex

    Public ConfigTelnet As Estructuras.CFGTelnet
    Public OpcionesTD As Estructuras.Opciones_General
    Public CProgreso As Estructuras.ComponentesProgreso

    Dim FirstTime As Boolean = True


    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################
    Private Sub PrimeraApertura()
        Try
            Me.TD_Tray.Visible = False
            Me.Text = Variables.TituloForm

            'Me.Show()
            'Me.Focus()
            'Me.Activate()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    Private Sub OpcionesDefecto()
        Try
            Me.OpcionesTD = OpcionesMng.OpcionesObj()

            Me.CProgreso.IconoNotificacion = Me.TD_Tray
            Me.CProgreso.IN_Titulo = Variables.TituloForm
            Me.CProgreso.IN_TipoIcono = ToolTipIcon.Info
            Me.CProgreso.IN_Esperar = OpcionesTD.Opciones.EsperaBallonTip
            Me.CProgreso.IN_Mensaje = String.Empty
            Me.CProgreso.EtiquetaEstado = Me.TDBE_labelinfo
            Me.CProgreso.Texto = String.Empty
            Me.CProgreso.TextoDefecto = Variables.TituloForm
            Me.CProgreso.EtiquetaProgreso = Me.TDLB_Progreso
            Me.CProgreso.BarraProgreso = Me.TDBE_Progreso
            Me.CProgreso.Progreso = 0
            Me.CProgreso.ProgresoMax = 100
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    Public Sub NuevaInstancia(ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)
        Try
            Dim array(e.CommandLine.Count + 1) As String
            e.BringToForeground = False
            e.CommandLine.CopyTo(array, 1)
            IniciarTD(array)
            array = Nothing
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    Public Sub IniciarTD(ByVal comandos() As String)
        Try
            ' Definir valores por defecto
            Me.TDLB_Progreso.Text = "0%"
            Me.TDBE_Progreso.Value = 0
            Me.TD_Tray.Text = Variables.TituloForm

            Me.OpcionesDefecto()

            ' Carga la configuración
            F_Opciones.CargarOpciones()

            ' Aplica las opciones
            Me.Consola.BackColor = OpcionesTD.Opciones.ColorConsola.Color_Fondo

            ' Prepara el programa
            If FirstTime = True Then
                LimpiarConsola()
                FirstTime = False
            Else
                Me.PrepararConsola()
            End If



            If comandos.Length > 1 Then
                Dim lineacomandos As String = UCase(comandos(1))
                Dim Mostrar As Boolean = True
                If lineacomandos = "/RYC" Then
                    EjecutarComandos()
                    While Not OpcionesTD.Estado.Conexion_ConectadoaInternet
                        Crono.Esperar(100)
                    End While
                    Me.Close()
                    Mostrar = True
                ElseIf lineacomandos = "/RYCS" Then
                    IrATray()
                    EjecutarComandos()
                    While Not OpcionesTD.Estado.Conexion_ConectadoaInternet
                        Crono.Esperar(100)
                    End While
                    Me.Close()
                    Mostrar = False
                ElseIf lineacomandos = "/RENOVAR" Then
                    EjecutarComandos()
                    Mostrar = True
                ElseIf lineacomandos = "/CERRAR" Then
                    Me.Close()
                    Mostrar = False
                ElseIf lineacomandos = "/TRAY" Then
                    IrATray()
                    Mostrar = False
                Else
                    'Errores.MostrarError(UniDlxVars.Traduccion("Error_ComandoBad") & lineacomandos & UniDlxVars.Traduccion("Error_ComandoBadFin"))
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
                lineacomandos = Nothing
                Mostrar = Nothing
            End If
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Funciones del formulario

    Private Sub TelnetDeluxe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim nuevaInstancia As Boolean
            miMutex = New System.Threading.Mutex(True, "Telnet Deluxe", nuevaInstancia)
            IniciarTD(Environment.GetCommandLineArgs())
            nuevaInstancia = Nothing
        Catch EX As Exception
            Errores.MostrarVError(EX)
            Exit Sub
        End Try
    End Sub

    Private Sub TelnetDeluxe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            TD_Tray.Visible = False
            TD_Tray.Dispose()
            Crono.Esperar(200)
            'If OpcionesTD.Estado.Conexion_ConectadoaRouter = True Then
            '    FuncRouter.Cerrar()
            'End If
            OpcionesMng.GuardarIP()
        Catch ex As Exception
            Errores.MostrarVError(ex)
            Exit Sub
        End Try
    End Sub

    Public Sub RouterConectado()
        Try
            Me.MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConexionOK"), Estructuras.MensajeConsola.MSG_Accion)
            Me.MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_ConectadoA") & ConfigTelnet.IPRouter & UniDlxVars.Traduccion("Console_Msg_ConectadoAPuerto") & ConfigTelnet.Puerto, Estructuras.MensajeConsola.MSG_Accion)
            Me.label_estado.Text = UniDlxVars.Traduccion("Gui_General_Conectado")
            Me.label_estado.BackColor = Color.OliveDrab
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub RouterDesconectado()
        Try
            Me.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
            Me.label_estado.Text = UniDlxVars.Traduccion("Gui_General_DesConectado")
            Me.label_estado.BackColor = Color.Red
            Me.MostrarEnConsola()
            Me.MostrarEnConsola()
            Me.MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_Desconectado"), Estructuras.MensajeConsola.MSG_Accion)
            Me.Refresh()
            'Dnet.ComprobarConexion()
            Me.EComandos.Image = My.Resources.BotonTelnetON
            Me.EComandos.Tag = "Enviar comandos Telnet"
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub ConexionCambiada(ByVal conex As TelnetDeluxe.Deluxe.ArgumentosConexion)
        Try
            If conex.PConexion.Conectado Then
                MainLoop.CronoConex.Interval = 15000
                Me.label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Online")
                Me.label_inetconex.BackColor = Color.OliveDrab
                Me.OpcionesTD.Estado.Conexion_ConectadoaInternet = True
                If Me.OpcionesTD.Opciones.IP_CompRsinc And Me.OpcionesTD.Estado.Accion_NuevaIP Then
                    Me.OpcionesTD.Estado.Accion_NuevaIP = False
                    Me.CProgreso.IN_Mensaje = UniDlxVars.Traduccion("Tray_Msg_Online")
                    Formularios.MostrarTrayTip(Me.CProgreso)
                    Me.ConseguirIpPublica()
                End If
                Me.OpcionesTD.MsgControl.NoHayTarjetaDeRed = True
            Else
                MainLoop.CronoConex.Interval = 2000
                Me.label_inetconex.Text = UniDlxVars.Traduccion("Gui_General_Offline")
                Me.label_inetconex.BackColor = Color.Red
                Me.OpcionesTD.Estado.Conexion_ConectadoaInternet = False
            End If

            If Me.ToolBox.ComprobarRedLocal() = False Then
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                Me.OpcionesTD.MsgControl.NoHayTarjetaDeRed = True
                Me.OpcionesTD.Estado.Conexion_TarjetaRedDisp = False
            Else
                Me.OpcionesTD.MsgControl.NoHayTarjetaDeRed = False
                Me.OpcionesTD.Estado.Conexion_TarjetaRedDisp = True
            End If
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            Const SC_MINIMIZE As Int32 = &HF020&
            MyBase.WndProc(m)
            If CLng(m.WParam.ToInt32) = SC_MINIMIZE Then
                If OpcionesTD.Opciones.GUI_MinimToTray = True Then
                    IrATray()
                End If
            End If
        Catch oEX As TypeInitializationException
            'Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Funciones del menú principal

    Private Sub TD_MP_AcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_AcercaDe.Click
        Try
            F_AcercaDe.Show()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Private Sub TD_MP_EjecutarComandos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_EjecutarComandos.Click
        Try
            Me.PrepararConsola()
            ' Inis Router
            If String.IsNullOrEmpty(ConfigTelnet.Archivo) Then
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_SeleccionaCFG"), Estructuras.MensajeConsola.MSG_Info)
            ElseIf File.Exists(Variables.CarpetaIniRouters & "\" & ConfigTelnet.Archivo) = False Then
                Errores.MostrarError(UniDlxVars.Traduccion("Error_INIRouterBad") & ConfigTelnet.Archivo & ")")
            Else
                F_Opciones.Combo_inirouters.Text = ConfigTelnet.Archivo
                EjecutarComandos()
            End If
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Salir.Click
        Try
            Me.Close()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MToolStripMenuItem.Click
        Try
            IrATray()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_Opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_Opciones.Click
        Try
            F_Opciones.Show()
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoSistema.Click
        Try
            Informacion.MostrarInfoSistema()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_MostrarInfoRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_MostrarInfoRed.Click
        Try
            Informacion.MostrarInfoRed()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_MP_ConseguirIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TD_MP_ConseguirIP.Click
        Try
            OpcionesTD.Estado.Accion_NuevaIP = False
            ConseguirIpPublica()
        Catch oEX As WebException
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Limpiar.Click
        Try
            LimpiarConsola()
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_SelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_SelTodo.Click
        Try
            Consola.Focus()
            Consola.SelectionStart = 0
            Consola.SelectionLength = Consola.TextLength
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub MenuConsola_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConsola_Copiar.Click
        Try
            If Consola.SelectedText.Length > 0 Then
                My.Computer.Clipboard.SetText(Consola.SelectedText)
            End If
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Funciones Automatizadas


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
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TD_Tray.DoubleClick
        Try
            SalirDeTray()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RenovarIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenovarIPToolStripMenuItem.Click
        Try
            CProgreso.IN_Mensaje = UniDlxVars.Traduccion("Tray_Msg_RenovandoIP")
            Formularios.MostrarTrayTip(CProgreso)
            EjecutarComandos()
            CProgreso.IN_Mensaje = UniDlxVars.Traduccion("Tray_Msg_ComandosOK")
            Formularios.MostrarTrayTip(CProgreso)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <*************** Se ha cambiado la config ****************>
    ' ###########################################################
    Public Sub ConfigCambiada(ByVal NuevasOpciones As Estructuras.Opciones_General)
        Try
            OpcionesTD = NuevasOpciones
            Consola.BackColor = OpcionesTD.Opciones.ColorConsola.Color_Fondo
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Sub MostrarInfoProgreso(ByVal info As String)
        Try
            If info.Length >= 64 Then
                TD_Tray.Text = info.Substring(0, 60) & "..."
            Else
                TD_Tray.Text = info
            End If
            TDBE_labelinfo.Text = info
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <************* Funciones para la consola ****************>
    ' ###########################################################

    Public Sub MostrarEnConsola(Optional ByVal Datos As String = "", Optional ByVal TipoMensaje As Estructuras.MensajeConsola = Estructuras.MensajeConsola.MSG_Defecto)
        Try
            Dim TextoAEscribir As String
            Dim Pre_Consola As String = ""

            If OpcionesTD.Opciones.Consola_MostrarHora = True And String.IsNullOrEmpty(Datos) = False Then
                Pre_Consola = Crono.DevolverFecha(True)
            End If

            If Consola.TextLength > 0 Then
                Consola.SelectionStart = Consola.TextLength
            End If

            If TipoMensaje = Estructuras.MensajeConsola.MSG_Defecto Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_defecto
            ElseIf TipoMensaje = Estructuras.MensajeConsola.MSG_Info Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_info
            ElseIf TipoMensaje = Estructuras.MensajeConsola.MSG_Error Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_error
            ElseIf TipoMensaje = Estructuras.MensajeConsola.MSG_Router Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_router
                Pre_Consola = ""
            ElseIf TipoMensaje = Estructuras.MensajeConsola.MSG_Accion Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_accion
            ElseIf TipoMensaje = Estructuras.MensajeConsola.MSG_DirIP Then
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_DirIP
            Else
                Consola.SelectionColor = OpcionesTD.Opciones.ColorConsola.Color_defecto
            End If

            TextoAEscribir = Datos

            If TipoMensaje <> Estructuras.MensajeConsola.MSG_Router Then
                TextoAEscribir = TextoAEscribir & ControlChars.CrLf
            End If

            TextoAEscribir = Pre_Consola & TextoAEscribir

            Consola.SelectedText = TextoAEscribir
            Consola.SelectionStart = Consola.Text.Length
            Consola.ScrollToCaret()
            TextoAEscribir = Nothing
            Pre_Consola = Nothing
        Catch ex As Exception
            Errores.MostrarVError(ex)
            Exit Sub
        End Try
    End Sub

    Private Sub LimpiarConsola()
        Try
            Consola.Text = ""
            MensajeBienvenida()
        Catch ex As Exception
            Errores.MostrarVError(ex)
            Exit Sub
        End Try
    End Sub

    Private Sub PrepararConsola()
        Try
            If OpcionesTD.Opciones.GUI_AutoLimpiarConsola Then
                Me.LimpiarConsola()
            Else
                MostrarEnConsola()
                MostrarEnConsola()
            End If

        Catch ex As Exception
            Errores.MostrarVError(ex)
            Exit Sub
        End Try
    End Sub

    Private Sub MensajeBienvenida()
        Try
            MostrarEnConsola()
            MostrarEnConsola(UniDlxVars.Traduccion("General_BienvenidaInfo"), Estructuras.MensajeConsola.MSG_Info)
            MostrarEnConsola(UniDlxVars.Traduccion("General_Comenzo") & System.DateTime.Now, Estructuras.MensajeConsola.MSG_Info)
            MostrarEnConsola()
        Catch ex As Exception
            Errores.MostrarVError(ex)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Generales ******************>
    ' ###########################################################

    Public Sub EjecutarComandos()
        Try
            Dim FuncRouter As New D_Sync
            FuncRouter.RouterSync()
            FuncRouter.Cerrar()
        Catch ex As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(ex)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <****************** Funciones Internet *******************>
    ' ###########################################################

    Private Sub ConseguirIpPublica()
        Try
            Dim GetIP As New NetTool_GetIp()
            GetIP.LeerIP(OpcionesTD.Opciones.IP_WebConseguir)
            GetIP.Cerrar()
            GetIP = Nothing
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_NoConsigoIP"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarIPPublica(ByVal DirIP As String)
        Try
            If DirIP <> "False" Then
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIP, Estructuras.MensajeConsola.MSG_DirIP)
                MostrarEnConsola()
                CProgreso.IN_Mensaje = UniDlxVars.Traduccion("Console_Msg_IPActual") & DirIP
                Formularios.MostrarTrayTip(CProgreso)
            Else
                Errores.MostrarError(UniDlxVars.Traduccion("Error_ConsiguiendoHTML"))
                Exit Sub
            End If

            If txtbox_info_ipact.Text <> DirIP Then
                txtbox_info_ipant.Text = txtbox_info_ipact.Text
                txtbox_info_ipact.Text = DirIP
                If OpcionesTD.Opciones.IP_LoguearConseguidas = True Then
                    ToolBox.EscribirLogIP(DirIP)
                End If
            Else
                If OpcionesTD.Estado.Accion_NuevaIP Then
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_IPIgual"), Estructuras.MensajeConsola.MSG_Info)
                    MostrarEnConsola()
                End If
            End If
            OpcionesTD.Estado.Accion_NuevaIP = False

        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_NoConsigoIP"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub EComandos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EComandos.Click
        Try
            If OpcionesTD.Estado.Macro_Ejecutando = True Then
                MostrarEnConsola()
                MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_CancelarOperacion"), Estructuras.MensajeConsola.MSG_Info)
                MostrarEnConsola()
                OpcionesTD.Estado.Macro_Cancelar = True
            Else
                Me.PrepararConsola()
                EComandos.Image = My.Resources.BotonTelnetOFF
                EComandos.Tag = "Cancelar envío de Comandos"
                If String.IsNullOrEmpty(ConfigTelnet.Archivo) Then
                    MostrarEnConsola(UniDlxVars.Traduccion("Console_Msg_SeleccionaCFG"), Estructuras.MensajeConsola.MSG_Info)
                ElseIf File.Exists(Variables.CarpetaIniRouters & "\" & ConfigTelnet.Archivo) = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_INIRouterBad") & ConfigTelnet.Archivo & ")")
                Else
                    F_Opciones.Combo_inirouters.Text = ConfigTelnet.Archivo
                    EjecutarComandos()
                End If
            End If
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub MaxProgreso(ByVal Maximo As Integer)
        Try
            TDBE_Progreso.Maximum = Maximo
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class
