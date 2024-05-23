Public Class UniversalDeluxe
    Public Version As String = "0.2 Beta"

    Public Uni_Error_NoControlado As String = "ERROR no controlado: "
    Public Uni_Error_Generico As String = "Ha ocurrido un error"
    Public Uni_Error_INIRouterBad As String = "El archivo de configuración no existe ("
    Public Uni_Error_ComandoBad As String = "El comando ''"
    Public Uni_Error_ComandoBadFin As String = "'' no se ha reconocido"
    Public Uni_Error_IntervaloLow As String = "El valor de intervalo es demasiado bajo"
    Public Uni_Error_IntervaloLowTip As String = "Recuerda que si envias comandos demasiado rápido puede que no lleguen al router"
    Public Uni_Error_NoPuedoConectar As String = "No se ha podido establecer la conexión"
    Public Uni_Error_CompruebaIpPuerto As String = Uni_Error_NoPuedoConectar & ", comprueba que la IP y el puerto sean correctos"
    Public Uni_Error_NoPuedoDesconectar As String = "No se ha podido cerrar la conexión"
    Public Uni_Error_NoRespuestaRouter As String = "Error, no se ha podido conseguir la información del router"
    Public Uni_Error_NoPuedoEnviarComando As String = "Error, no se ha podido enviar el comando al router"
    Public Uni_Error_NoConfigCargada As String = "Error. No se ha cargado el archivo de configuración"
    

    Public Uni_General_BienvenidaInfo As String = "Deluxe Telnet v" & Version & " Agosto 2007"
    Public Uni_General_Comenzo As String = "El programa comenzó "



    Public Uni_Console_Config_Intervalo As String = "El intervalo de envio de comandos se ha cambiado a "
    Public Uni_Console_Config_IntervaloFin As String = " segundos."

    Public Uni_Console_Msg_ConexionOK As String = "Conexión Establecida correctamente"
    Public Uni_Console_Msg_ConectadoA As String = "Conectado a '"
    Public Uni_Console_Msg_ConectadoAPuerto As String = "' puerto "
    Public Uni_Console_Msg_Desconectado As String = "Conexión Cerrada"
    Public Uni_Console_Msg_EsperandoRespuesta As String = "Esperando respuesta..."
    Public Uni_Console_Msg_ComandosOK As String = "Los comandos se realizaron con éxito"
    Public Uni_Console_Msg_ComandosOKWait As String = "Espera unos segundos hasta que tu router sincronice"


    Public Uni_Gui_General_Conectado = "Conectado"
    Public Uni_Gui_General_DesConectado = "Desconectado"
    Public Uni_Gui_General_Online = "En Línea"
    Public Uni_Gui_General_Offline = "Sin Conexión"
End Class