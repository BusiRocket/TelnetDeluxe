Option Strict On
Option Explicit On
Imports System.IO
Namespace Deluxe
    Public Class DlxOpcionesManager
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Variables As New DlxVariables
        Private VINI As New Variable_Inis

        Private BufferTemporal As String

        '--- Declaraciones para leer ficheros INI ---
        Private Declare Function GetPrivateProfileSectionNames Lib "kernel32" Alias "GetPrivateProfileSectionNamesA" (ByVal lpszReturnBuffer As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
        Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
        Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer

        Public OpcionesTD As Estructuras.Opciones_General



        Public Sub BorrarClaveIni(ByVal ArchivoINI As String, ByVal SeccionINI As String, Optional ByVal Clave As String = "")
            Try
                If Clave.Length = 0 Then
                    Call WritePrivateProfileString(SeccionINI, 0, 0, ArchivoINI)
                Else
                    Call WritePrivateProfileString(SeccionINI, Clave, 0, ArchivoINI)
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub BorrarSeccionIni(ByVal ArchivoINI As String, ByVal SeccionINI As String)
            Try
                Call WritePrivateProfileString(SeccionINI, 0, 0, ArchivoINI)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Function ConseguirValorIni(ByVal NombreArchivo As String, ByVal SeccionINI As String, ByVal NombreClave As String, Optional ByVal ValorDefecto As String = "") As String
            Try
                Dim ValorTemporal As Integer
                Dim ArrayTemporal As String = New String(Chr(0), 255)
                ValorTemporal = GetPrivateProfileString(SeccionINI, NombreClave, ValorDefecto, ArrayTemporal, Len(ArrayTemporal), NombreArchivo)
                If ValorTemporal = 0 Then
                    Return ValorDefecto
                Else
                    Return Left(ArrayTemporal, ValorTemporal)
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Return "Error"
                Exit Function
            End Try
        End Function

        Public Sub EscribirValorIni(ByVal NombreArchivo As String, ByVal SeccionINI As String, ByVal NombreClave As String, ByVal ValorClave As String)
            Try
                Call WritePrivateProfileString(SeccionINI, NombreClave, ValorClave, NombreArchivo)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Function ConseguirSeccionIni(ByVal NombreArchivo As String, ByVal SeccionINI As String) As String()
            Try
                Dim ArraySeccion() As String
                Dim n As Integer

                ReDim ArraySeccion(0)
                BufferTemporal = New String(ChrW(0), 32767)
                n = GetPrivateProfileSection(SeccionINI, BufferTemporal, BufferTemporal.Length, NombreArchivo)
                If n > 0 Then
                    BufferTemporal = BufferTemporal.Substring(0, n - 2).TrimEnd()
                    ArraySeccion = BufferTemporal.Split(New Char() {ChrW(0), "="c})
                End If
                n = Nothing
                Return ArraySeccion
            Catch oEX As Exception
                Dim rtrnerr As String() = Split("E,r,r,o,r", ",")
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Return rtrnerr
                Exit Function
            End Try
        End Function

        Public Function ConseguirSeccionesIni(ByVal NombreArchivo As String) As String()
            Try
                Dim n As Integer
                Dim ArraySecciones() As String
                ReDim ArraySecciones(0)

                BufferTemporal = New String(ChrW(0), 32767)

                n = GetPrivateProfileSectionNames(BufferTemporal, BufferTemporal.Length, NombreArchivo)
                If n > 0 Then
                    BufferTemporal = BufferTemporal.Substring(0, n - 2).TrimEnd()
                    ArraySecciones = BufferTemporal.Split(ChrW(0))
                End If
                n = Nothing
                Return ArraySecciones
            Catch oEX As Exception
                Dim rtrnerr As String() = Split("E,r,r,o,r", ",")
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Return rtrnerr
                Exit Function
            End Try
        End Function

        Public Sub New()
            Try
                InicioOpciones()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub InicioOpciones()
            Try
                Me.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                Me.OpcionesTD.Estado.Accion_NuevaIP = False
                Me.OpcionesTD.Estado.Conexion_ConectadoaInternet = False
                Me.OpcionesTD.Estado.Macro_TodoOK = True
                Me.OpcionesTD.Estado.Conexion_TarjetaRedDisp = True

                Me.OpcionesTD.Opciones.Consola_MostrarHora = True
                Me.OpcionesTD.Opciones.Dir_Ping = "208.69.34.230"
                Me.OpcionesTD.Opciones.EsperaBallonTip = 1000
                Me.OpcionesTD.Opciones.IP_WebConseguir = "http://www.showmyip.com"
                Me.OpcionesTD.Opciones.GUI_MinimToTray = False
                Me.OpcionesTD.Opciones.GUI_MostrarSplash = False
                Me.OpcionesTD.Opciones.GUI_AutoLimpiarConsola = True
                Me.OpcionesTD.Opciones.IP_LoguearConseguidas = True
                Me.OpcionesTD.Opciones.IP_CompRsinc = False
                Me.OpcionesTD.Opciones.LOG_LoguearErrores = True
                Me.OpcionesTD.Opciones.LOG_MostrarErrDetallado = True
                Me.OpcionesTD.Opciones.Telnet_Intervalo = 3


                Me.OpcionesTD.Opciones.ColorConsola.Color_Fondo = Color.Black
                Me.OpcionesTD.Opciones.ColorConsola.Color_defecto = Color.Yellow
                Me.OpcionesTD.Opciones.ColorConsola.Color_info = Color.Orange
                Me.OpcionesTD.Opciones.ColorConsola.Color_error = Color.Red
                Me.OpcionesTD.Opciones.ColorConsola.Color_router = Color.White
                Me.OpcionesTD.Opciones.ColorConsola.Color_accion = Color.YellowGreen
                Me.OpcionesTD.Opciones.ColorConsola.Color_DirIP = Color.Aqua

            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub CambiarOpciones(ByVal OTD As Estructuras.Opciones_General)
            Try
                Me.OpcionesTD = OTD
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        ' ###########################################################
        ' <*********** Funciones de los archivos CFG ***************>
        ' ###########################################################

        Public Function ListaINIs() As String()
            Try
                If Directory.Exists(Variables.CarpetaIniRouters) = False Then
                    Directory.CreateDirectory(Variables.CarpetaIniRouters)
                End If
                Return Directory.GetFiles(Variables.CarpetaIniRouters, "*.ini")
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Return Split("E,r,r,o,r", ",")
                Exit Function
            End Try
        End Function

        Public Sub GuardarCFG()
            Try
                ' Configuración General
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_DirIp"), F_Opciones.txtbox_conf_iprouter.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Puerto"), F_Opciones.txtbox_conf_puerto.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Refresco"), F_Opciones.txtbox_conf_intervalo.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_IniRouter"), TD_Principal.ConfigTelnet.Archivo)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_User"), F_Opciones.txtbox_conf_user.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Pass"), F_Opciones.txtbox_conf_pass.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_SoloCont"), Me.ComprobarCheck(F_Opciones.Check_SoloPass).ToString)

                ' Miscelánea
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IpPublica"), TD_Principal.txtbox_info_ipact.Text)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_LoguearIP"), Me.ComprobarCheck(F_Opciones.Check_LogIP).ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Conf_WebIP"), Me.OpcionesTD.Opciones.IP_WebConseguir)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IPCompRsnc"), Me.ComprobarCheck(F_Opciones.Check_ConsIP).ToString)

                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_Consola_Hora"), Me.ComprobarCheck(F_Opciones.Check_HoraConsola).ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_MinimizarTray"), Me.ComprobarCheck(F_Opciones.Check_MinimTray).ToString)
                'Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_MostrarSplash"), Me.ComprobarCheck(F_Opciones.Check_Splash).ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_AutoLimpiarConsola"), Me.ComprobarCheck(F_Opciones.Check_AutoLimpiarConsola).ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_ErroresDetallados"), Me.ComprobarCheck(F_Opciones.Check_ErroresDetallados).ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_ErroresLog"), Me.ComprobarCheck(F_Opciones.Check_ErroresLog).ToString)

                ' Colores
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_Fondo"), F_Opciones.CC_Fondo.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_defecto"), F_Opciones.CC_defecto.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_info"), F_Opciones.CC_info.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_router"), F_Opciones.CC_Router.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_accion"), F_Opciones.CC_Accion.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_dirip"), F_Opciones.CC_DirIp.BackColor.ToArgb.ToString)
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_error"), F_Opciones.CC_Error.BackColor.ToArgb.ToString)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub GuardarIP()
            Try
                Me.EscribirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IpPublica"), TD_Principal.txtbox_info_ipact.Text)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub CargarCFG()
            Try
                ' Configuración General
                F_Opciones.txtbox_conf_iprouter.Text = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_DirIp"), "192.168.1.1")
                F_Opciones.txtbox_conf_puerto.Text = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Puerto"), "23")
                F_Opciones.txtbox_conf_user.Text = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_User"), "")
                F_Opciones.txtbox_conf_pass.Text = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Pass"), "")
                Me.PonerCheck(F_Opciones.Check_SoloPass, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_SoloCont"), CStr(False))))
                F_Opciones.Combo_inirouters.SelectedItem = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_IniRouter"), "")
                Me.OpcionesTD.Opciones.Telnet_Intervalo = CType(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Refresco"), "3"), Integer)
                F_Opciones.txtbox_conf_intervalo.Text = Me.OpcionesTD.Opciones.Telnet_Intervalo.ToString


                'Miscelánea
                TD_Principal.txtbox_info_ipact.Text = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IpPublica"), "")
                Me.OpcionesTD.Opciones.Dir_Ping = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IpPing"), "")
                Me.PonerCheck(F_Opciones.Check_HoraConsola, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_Consola_Hora"), CStr(False))))
                ' IP
                Me.PonerCheck(F_Opciones.Check_LogIP, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_LoguearIP"), CStr(False))))
                Me.PonerCheck(F_Opciones.Check_ConsIP, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_IPCompRsnc"), CStr(False))))
                F_Opciones.Combo_lstip.SelectedItem = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Conf_WebIP"), "")

                Me.PonerCheck(F_Opciones.Check_MinimTray, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_MinimizarTray"), CStr(False))))
                'Me.PonerCheck(F_Opciones.Check_Splash, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_MostrarSplash"), CStr(False))))
                Me.PonerCheck(F_Opciones.Check_AutoLimpiarConsola, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_AutoLimpiarConsola"), CStr(False))))
                Me.PonerCheck(F_Opciones.Check_ErroresDetallados, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_ErroresDetallados"), CStr(False))))
                Me.PonerCheck(F_Opciones.Check_ErroresLog, CBool(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Misc"), VINI.IniGeneral("Ini_Misc_ErroresLog"), CStr(False))))



                'Colores
                F_Opciones.CC_Fondo.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_Fondo"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_Fondo.ToArgb.ToString)))
                F_Opciones.CC_defecto.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_defecto"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_defecto.ToArgb.ToString)))
                F_Opciones.CC_info.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_info"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_info.ToArgb.ToString)))
                F_Opciones.CC_Router.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_router"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_router.ToArgb.ToString)))
                F_Opciones.CC_Accion.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_accion"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_accion.ToArgb.ToString)))
                F_Opciones.CC_DirIp.BackColor = Color.FromArgb(CInt(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_dirip"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_DirIP.ToArgb.ToString)))
                F_Opciones.CC_Error.BackColor = Color.FromArgb(CType(Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_ColorCon"), VINI.IniGeneral("Ini_ColorCon_error"), TD_Principal.OpcionesTD.Opciones.ColorConsola.Color_error.ToArgb.ToString), Int32))

                ' Aplicar valores para CFG de los Routers
                TD_Principal.ConfigTelnet.IniSeleccionado = Variables.CarpetaIniRouters & "\" & F_Opciones.Combo_inirouters.SelectedItem.ToString
                TD_Principal.ConfigTelnet.Archivo = F_Opciones.Combo_inirouters.SelectedItem.ToString
                TD_Principal.ConfigTelnet.Usuario = F_Opciones.txtbox_conf_user.Text
                TD_Principal.ConfigTelnet.Pass = F_Opciones.txtbox_conf_pass.Text
                TD_Principal.ConfigTelnet.Puerto = F_Opciones.txtbox_conf_puerto.Text
                TD_Principal.ConfigTelnet.IPRouter = F_Opciones.txtbox_conf_iprouter.Text
                TD_Principal.ConfigTelnet.SoloPass = Me.ComprobarCheck(F_Opciones.Check_SoloPass)


                ' Aplicar Opciones Generales
                Me.OpcionesTD.Opciones.Consola_MostrarHora = Me.ComprobarCheck(F_Opciones.Check_HoraConsola)
                Me.OpcionesTD.Opciones.GUI_MinimToTray = Me.ComprobarCheck(F_Opciones.Check_MinimTray)
                'Me.OpcionesTD.Opciones.GUI_MostrarSplash = Me.ComprobarCheck(F_Opciones.Check_Splash)
                Me.OpcionesTD.Opciones.GUI_AutoLimpiarConsola = Me.ComprobarCheck(F_Opciones.Check_AutoLimpiarConsola)
                Me.OpcionesTD.Opciones.IP_WebConseguir = F_Opciones.Combo_lstip.SelectedItem.ToString
                Me.OpcionesTD.Opciones.IP_CompRsinc = Me.ComprobarCheck(F_Opciones.Check_ConsIP)
                Me.OpcionesTD.Opciones.IP_LoguearConseguidas = Me.ComprobarCheck(F_Opciones.Check_LogIP)
                Me.OpcionesTD.Opciones.LOG_MostrarErrDetallado = Me.ComprobarCheck(F_Opciones.Check_ErroresDetallados)
                Me.OpcionesTD.Opciones.LOG_LoguearErrores = Me.ComprobarCheck(F_Opciones.Check_ErroresLog)

                ' Aplicar Colores
                Me.OpcionesTD.Opciones.ColorConsola.Color_Fondo = F_Opciones.CC_Fondo.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_defecto = F_Opciones.CC_defecto.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_info = F_Opciones.CC_info.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_router = F_Opciones.CC_Router.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_accion = F_Opciones.CC_Accion.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_DirIP = F_Opciones.CC_DirIp.BackColor
                Me.OpcionesTD.Opciones.ColorConsola.Color_error = F_Opciones.CC_Error.BackColor


                'Aplicar los cambios
                TD_Principal.ConfigCambiada(OpcionesTD)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_CargandoOpciones"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Function CargarCFGRouter(ByVal InfRouter As Estructuras.ConfigRouter) As Estructuras.ConfigRouter
            Try
                Dim Login As String = ""
                ' Carga la configuración del INI y la guarda en las variables
                InfRouter.NombreRouter = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_NombreRouter"), "No se ha seleccionado ningún router")
                InfRouter.Revision = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Revision"))
                InfRouter.Fecha = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Fecha"))
                InfRouter.Puerto = Me.ConseguirValorIni(Variables.ArchivoIni, VINI.IniGeneral("Ini_Configuracion"), VINI.IniGeneral("Ini_Conf_Puerto"), "23")
                InfRouter.Autor = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Autor"))
                InfRouter.Modo = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Modo"))
                InfRouter.Version = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Version"))

                InfRouter.http_conectar = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_http_conectar"))
                InfRouter.http_desconectar = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_http_desconectar"))
                InfRouter.http_login = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_http_login"))
                InfRouter.http_metodologin = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_http_MetodoLogin"))
                InfRouter.http_metodo = Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_http_Metodo"))

                If TD_Principal.ConfigTelnet.SoloPass Then
                    Login = TD_Principal.ConfigTelnet.Pass & ","
                Else
                    Login = TD_Principal.ConfigTelnet.Usuario & "," & TD_Principal.ConfigTelnet.Pass & ","
                End If

                InfRouter.Comandos = Split((Login & Me.ConseguirValorIni(InfRouter.ArchivoIni, VINI.IniGeneral("Ini_Router"), VINI.IniGeneral("Ini_Router_Comandos"), "selecciona,fichero,ini")), ",")
                InfRouter.Cargado = True
                Login = Nothing

                Return InfRouter
            Catch ex As Exception
                Dim a As New Estructuras.ConfigRouter
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(ex)
                Return a
            End Try
        End Function


        ' ###########################################################
        ' <*** Funciones para manejo de elementos del form **********>
        ' ###########################################################

        Public Function ComprobarCheck(ByVal CajaCheck As CheckBox) As Boolean
            Try
                If CajaCheck.CheckState = CheckState.Checked Then
                    ComprobarCheck = True
                Else
                    ComprobarCheck = False
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                ComprobarCheck = False
                Exit Function
            End Try
        End Function

        Public Sub PonerCheck(ByVal CajaCheck As CheckBox, ByVal Valor As Boolean)
            Try
                If Valor = True Then
                    CajaCheck.CheckState = CheckState.Checked
                Else
                    CajaCheck.CheckState = CheckState.Unchecked
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public ReadOnly Property OpcionesObj() As Estructuras.Opciones_General
            Get
                Return Me.OpcionesTD
            End Get
        End Property


        Public Sub CargarOpciones()
            'CargarListaIPs()
            ' CargarCFG()
        End Sub
    End Class
End Namespace