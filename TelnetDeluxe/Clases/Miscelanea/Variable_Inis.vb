Option Strict On
Option Explicit On
Public Class Variable_Inis
    '////////////////////////////////////////////////////////////////////
    '/// Variables para los archivos INI

    Public IniGeneral As New System.Collections.Generic.Dictionary(Of String, String)


    Public Sub New()
        Try
            Me.ConfigIniGeneral()
            Me.ConfigIniRouter()
            Me.ConfigIniEstad()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Opciones Generales
    Private Sub ConfigIniGeneral()
        IniGeneral("Ini_Configuracion") = "Config"
        IniGeneral("Ini_Conf_DirIp") = "DirIp"
        IniGeneral("Ini_Conf_Puerto") = "Puerto"
        IniGeneral("Ini_Conf_Refresco") = "Refresco"
        IniGeneral("Ini_Conf_User") = "Usuario"
        IniGeneral("Ini_Conf_Pass") = "Contrasena"
        IniGeneral("Ini_Conf_SoloCont") = "SoloCont"
        IniGeneral("Ini_Conf_IniRouter") = "IniRouter"


        IniGeneral("Ini_Misc") = "Misc"
        IniGeneral("Ini_Misc_IpPublica") = "PIP"
        IniGeneral("Ini_Misc_IpPing") = "IP_Ping"

        ' Opciones IP
        IniGeneral("Ini_Misc_LoguearIP") = "LoguearIP"
        IniGeneral("Ini_Misc_IPCompRsnc") = "IPCompRsnc"
        IniGeneral("Ini_Conf_WebIP") = "WebIP"

        ' GUI
        IniGeneral("Ini_Misc_MinimizarTray") = "MinToTray"
        IniGeneral("Ini_Misc_MostrarSplash") = "MSplash"
        IniGeneral("Ini_Misc_AutoLimpiarConsola") = "ALConsola"
        IniGeneral("Ini_Misc_Consola_Hora") = "Hora_Consola"

        IniGeneral("Ini_Misc_ErroresDetallados") = "ErrDetalle"
        IniGeneral("Ini_Misc_ErroresLog") = "ErrLog"



        IniGeneral("Ini_ColorCon") = "ColorConsola"
        IniGeneral("Ini_ColorCon_Fondo") = "CC_Fondo"
        IniGeneral("Ini_ColorCon_defecto") = "CC_defecto"
        IniGeneral("Ini_ColorCon_info") = "CC_info"
        IniGeneral("Ini_ColorCon_router") = "CC_router"
        IniGeneral("Ini_ColorCon_accion") = "CC_accion"
        IniGeneral("Ini_ColorCon_dirip") = "CC_dirip"
        IniGeneral("Ini_ColorCon_error") = "CC_error"

    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Configuración Router
    Private Sub ConfigIniRouter()
        IniGeneral("Ini_Router") = "RouterCfg"
        IniGeneral("Ini_Router_NombreRouter") = "NombreRouter"
        IniGeneral("Ini_Router_Comandos") = "Comandos"
        IniGeneral("Ini_Router_Revision") = "Revision"
        IniGeneral("Ini_Router_Fecha") = "Fecha"
        IniGeneral("Ini_Router_Autor") = "Autor"
        IniGeneral("Ini_Router_Modo") = "Modo"
        IniGeneral("Ini_Router_Version") = "IniVersion"
        IniGeneral("Ini_Router_http_conectar") = "http_conectar"
        IniGeneral("Ini_Router_http_desconectar") = "http_desconectar"
        IniGeneral("Ini_Router_http_login") = "http_login"
        IniGeneral("Ini_Router_http_MetodoLogin") = "MetodoLogin"
        IniGeneral("Ini_Router_http_Metodo") = "Metodo"
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Configuración Estadísticas
    Private Sub ConfigIniEstad()
        IniGeneral("Ini_Estadisticas") = "Estadisticas"
        IniGeneral("Ini_Estadisticas_VecesAbierto") = "Est_VA"
        IniGeneral("Ini_Estadisticas_TiempoEjecutando") = "Est_TA"
        IniGeneral("Ini_Estadisticas_IPsConseguidas") = "Est_IPC"
        IniGeneral("Ini_Estadisticas_Errores") = "Est_E"
        IniGeneral("Ini_Estadisticas_TiempoReconectaraInternet") = "Est_TRI"
        IniGeneral("Ini_Estadisticas_TiempoEjecutarComandos") = "Est_TEC"
        IniGeneral("Ini_Estadisticas_TiempoConectadoaRouter") = "Est_TCR"
    End Sub

End Class

