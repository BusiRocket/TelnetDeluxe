Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class Estructuras

        ' ################################################
        ' #  Estructuras

        ' ------------------------------------------------
        ' Estadisticas
        Public Structure Estadisticas
            Dim VecesAbierto As Double
            Dim TiempoAbierto As Double
            Dim IPsConseguidas As Double
            Dim Errores As Double
            Dim TiempoReconectaraInternet As Double
            Dim TiempoEjecutarComandos As Double
            Dim TiempoConectadoaRouter As Double
        End Structure


        ' ------------------------------------------------
        ' Generales

        Public Structure ComponentesProgreso
            Dim IconoNotificacion As Windows.Forms.NotifyIcon
            Dim IN_TipoIcono As Windows.Forms.ToolTipIcon
            Dim IN_Titulo As String
            Dim IN_Esperar As Integer
            Dim IN_Mensaje As String
            Dim EtiquetaEstado As Windows.Forms.ToolStripStatusLabel
            Dim Texto As String
            Dim TextoDefecto As String
            Dim EtiquetaProgreso As Windows.Forms.ToolStripStatusLabel
            Dim BarraProgreso As Windows.Forms.ToolStripProgressBar
            Dim Progreso As Integer
            Dim ProgresoMax As Integer
        End Structure

        Public Structure ProcesoDeluxe
            Dim EnEjecucion As Boolean
            Dim OperacionCompleta As Boolean
            Dim TodoOK As Boolean
            Dim Cancelado As Boolean
        End Structure

        Public Structure Opciones
            Dim Consola_MostrarHora As Boolean
            Dim ColorConsola As ColorConsola
            Dim Dir_Ping As String
            Dim EsperaBallonTip As Integer
            Dim GUI_MinimToTray As Boolean
            Dim GUI_MostrarSplash As Boolean
            Dim GUI_AutoLimpiarConsola As Boolean
            Dim IP_WebConseguir As String
            Dim IP_CompRsinc As Boolean
            Dim IP_LoguearConseguidas As Boolean
            Dim LOG_LoguearErrores As Boolean
            Dim LOG_MostrarErrDetallado As Boolean
            Dim Telnet_Intervalo As Integer
        End Structure

        ' ------------------------------------------------
        ' Para Router Sync

        Public Structure Conexion
            Dim Conectado As Boolean
            Dim Comprobando As Boolean
            Dim TarjetaDeRed As Boolean
            Dim ComprobacionCancelada As Boolean
        End Structure

        Public Structure MsgControl
            Dim EsperandoRespuesta As Boolean
            Dim NoHayTarjetaDeRed As Boolean
        End Structure

        Public Structure InfoRouter
            Dim NombreRouter As String
            Dim Revision As String
            Dim Fecha As String
            Dim Autor As String
        End Structure

        Public Structure CFGTelnet
            Dim Archivo As String
            Dim Usuario As String
            Dim Pass As String
            Dim Puerto As String
            Dim IPRouter As String
            Dim IniSeleccionado As String
            Dim SoloPass As Boolean
        End Structure

        Public Structure ConfigRouter
            Dim Cargado As Boolean
            Dim Intervalo As Integer
            Dim IpRouter As String
            Dim Puerto As String
            Dim Autor As String
            Dim ArchivoIni As String
            ' Contenidos dentro del INI
            Dim Comandos() As String
            Dim Fecha As String
            Dim Modo As String
            Dim NombreRouter As String
            Dim Revision As String
            Dim Version As String
            Dim http_login As String
            Dim http_metodo As String
            Dim http_metodologin As String
            Dim http_conectar As String
            Dim http_desconectar As String
        End Structure

        ' ------------------------------------------------
        ' Para Telnet Deluxe

        Public Structure Opciones_General
            Dim Estado As Estado
            Dim Opciones As Opciones
            Dim MsgControl As MsgControl
        End Structure

        Public Structure ColorConsola
            Dim Color_Fondo As Color
            Dim Color_defecto As Color
            Dim Color_info As Color
            Dim Color_error As Color
            Dim Color_router As Color
            Dim Color_accion As Color
            Dim Color_DirIP As Color
        End Structure

        Public Structure Estado
            Dim Accion_NuevaIP As Boolean
            Dim Conexion_ConectadoaRouter As Boolean
            Dim Conexion_ConectadoaInternet As Boolean
            Dim Conexion_TarjetaRedDisp As Boolean
            Dim Info_Progreso As Integer
            Dim Info_ProgresoMax As Integer
            Dim Macro_Cancelar As Boolean
            Dim Macro_Ejecutando As Boolean
            Dim Macro_TodoOK As Boolean
        End Structure

        ' ################################################
        ' #  Enumeraciones

        Public Enum MensajeConsola
            MSG_Defecto
            MSG_Info
            MSG_Error
            MSG_Router
            MSG_Accion
            MSG_DirIP
        End Enum

        Public Enum FormatoLog
            HTML
            Texto
        End Enum
    End Class
End Namespace
