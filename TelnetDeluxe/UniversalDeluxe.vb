Public Class UniversalDeluxe
    Public Traduccion As New System.Collections.Generic.Dictionary(Of String, String)
    Public VarIniPrincipal As New System.Collections.Generic.Dictionary(Of String, String)

    Public Version As String = "0.3 Beta"

    Public Sub CrearArray()

        ' ###########################################################
        ' <********************** Errores **************************>
        ' ###########################################################

        Traduccion("Error_NoControlado") = "ERROR no controlado: "
        Traduccion("Error_Generico") = "Ha ocurrido un error"

        Traduccion("Error_INIRouterBad") = "El archivo de configuraci�n no existe ("
        Traduccion("Error_NoExisteCFG") = "El archivo seleccionado no existe ("
        Traduccion("Error_NoPuedoCargarINI") = "Ha ocurrido un Error Cargando el fichero INI"
        Traduccion("Error_NoConfigCargada") = "Error. No se ha cargado el archivo de configuraci�n"
        Traduccion("Error_IntervaloLow") = "El valor de intervalo es demasiado bajo"
        Traduccion("Error_IntervaloLowTip") = "Recuerda que si envias comandos demasiado r�pido puede que no lleguen al router"

        Traduccion("Error_ComandoBad") = "El comando ''"
        Traduccion("Error_ComandoBadFin") = "'' no se ha reconocido"


        Traduccion("Error_NoPuedoConectar") = "No se ha podido establecer la conexi�n"
        Traduccion("Error_NoPuedoDesconectar") = "No se ha podido cerrar la conexi�n"
        Traduccion("Error_NoRespuestaRouter") = "Error, no se ha podido conseguir la informaci�n del router"
        Traduccion("Error_NoPuedoEnviarComando") = "Error, no se ha podido enviar el comando al router"
        Traduccion("Error_EnviandoComando") = "Ha ocurrido un error mientras se intentaba enviar el comando al router"
        Traduccion("Error_NoConectadoRouter") = "No se ha podido conectar con el router, operaci�n abortada"
        Traduccion("Error_NoConsigoIP") = "Error, no se ha podido conseguir la direcci�n IP"
        Traduccion("Error_NoConexion") = "Error mientras se comprobaba la conexi�n"
        Traduccion("Error_NoTarjetaRed") = "No hay ninguna tarjeta de red conectada"
        Traduccion("Error_ConexionPerdida") = "Se ha perdido la conexi�n con el router"
        Traduccion("Error_NoPuedoLeer") = "No he podido conseguir respuesta del router"




        Traduccion("Error_CompruebaIpPuerto") = Traduccion("Error_NoPuedoConectar") & ", comprueba que la IP y el puerto sean correctos"
        Traduccion("Error_NoPING") = "La direcci�n de red: "
        Traduccion("Error_NoPING2") = " no responde, comprueba la IP"


        Traduccion("Error_Macro") = "Fall� la automatizaci�n de comandos. Cancelando Operaci�n"
        Traduccion("Error_Macro_General") = "Parece que hubo un fallo en la automatizaci�n de comandos. La operaci�n ha terminado con un c�digo de error"
        Traduccion("Error_ConsiguiendoHTML") = "Error, El html no se descarg� correctamente"





        ' ###########################################################
        ' <********************** Mensajes Generales ***************>
        ' ###########################################################
        Traduccion("General_BienvenidaInfo") = "Deluxe Telnet v" & Version & " Septiembre 2007"
        Traduccion("General_Comenzo") = "El programa comenz� "


        ' ###########################################################
        ' <************** Mensajes de configuraci�n ****************>
        ' ###########################################################
        Traduccion("Console_Config_Intervalo") = "El intervalo de envio de comandos se ha cambiado a "
        Traduccion("Console_Config_IntervaloFin") = " segundos."



        ' ###########################################################
        ' <**************** Mensajes de informaci�n ****************>
        ' ###########################################################
        Traduccion("Console_Msg_ConexionOK") = "Conexi�n Establecida correctamente"
        Traduccion("Console_Msg_ConectadoA") = "Conectado a '"
        Traduccion("Console_Msg_ConectandoCon") = "Conectando con "
        Traduccion("Console_Msg_ConectadoAPuerto") = "' puerto "
        Traduccion("Console_Msg_Desconectado") = "Conexi�n Cerrada"
        Traduccion("Console_Msg_EsperandoRespuesta") = "Esperando respuesta..."

        Traduccion("Console_Msg_ComandosOK") = "Los comandos se realizaron con �xito"
        Traduccion("Console_Msg_ComandosOKWait") = "Espera unos segundos hasta que tu router sincronice"
        Traduccion("Console_Msg_ConsiguiendoIP") = "Intentando conseguir la direcci�n IP"
        Traduccion("Console_Msg_EsperaLarga") = "Esto puede tardar varios segundos"
        Traduccion("Console_Msg_IPActual") = "Tu IP actual es "
        Traduccion("Console_Msg_SeleccionaCFG") = "Selecciona un archivo de configuraci�n antes de comenzar"
        Traduccion("Console_Msg_LeyendoCFG") = "Leyendo archivo de configuraci�n..."
        Traduccion("Console_Msg_SeleccionaCFG") = "Selecciona un archivo de configuraci�n antes de comenzar"

        Traduccion("Console_Msg_InfoCFG") = "Archivo de configuraci�n para "
        Traduccion("Console_Msg_InfoCFG2") = ". Versi�n "
        Traduccion("Console_Msg_InfoCFG3") = "Creado por "
        Traduccion("Console_Msg_InfoCFG4") = ". �ltima modificaci�n: "
        Traduccion("Console_Msg_InfoCargOK") = "El archivo de configuraci�n se carg� correctamente..."


        ' ###########################################################
        ' <************** Mensajes de la interfaz ******************>
        ' ###########################################################
        Traduccion("Gui_General_Conectado") = "Conectado"
        Traduccion("Gui_General_DesConectado") = "Desconectado"
        Traduccion("Gui_General_Online") = "En L�nea"
        Traduccion("Gui_General_Offline") = "Sin Conexi�n"
        Traduccion("Gui_Routers_NohayINI") = "No se ha encontrado ning�n archivo"

        ' ###########################################################
        ' <********* Mensajes del �rea de notificaci�n *************>
        ' ###########################################################
        Traduccion("Tray_Msg_RenovandoIP") = "Renovando IP..."
        Traduccion("Tray_Msg_ComandosOK") = "Se han completado todos los comandos"
        Traduccion("Tray_Msg_Online") = "Conectado A Internet"
        Traduccion("Gui_General_Offline") = "Sin Conexi�n"
    End Sub

    Sub CargarArrayIni()
        '////////////////////////////////////////////////////////////////////
        '/// Variables para los archivos INI

        VarIniPrincipal("Ini_Configuracion") = "Config"
        VarIniPrincipal("Ini_Conf_DirIp") = "DirIp"
        VarIniPrincipal("Ini_Conf_Puerto") = "Puerto"
        VarIniPrincipal("Ini_Conf_Refresco") = "Refresco"
        VarIniPrincipal("Ini_Conf_User") = "Usuario"
        VarIniPrincipal("Ini_Conf_Pass") = "Contrasena"

        VarIniPrincipal("Ini_Conf_IniRouter") = "IniRouter"

        VarIniPrincipal("Ini_Misc") = "Misc"
        VarIniPrincipal("Ini_Misc_IpPublica") = "PIP"
        VarIniPrincipal("Ini_Misc_IpPing") = "IP_Ping"
        VarIniPrincipal("Ini_Misc_Consola_Hora") = "Hora_Consola"
        VarIniPrincipal("Ini_Misc_LoguearIP") = "LoguearIP"
        VarIniPrincipal("Ini_Misc_MinimizarTray") = "MinToTray"


        VarIniPrincipal("Ini_Router") = "RouterCfg"
        VarIniPrincipal("Ini_Router_NombreRouter") = "NombreRouter"
        VarIniPrincipal("Ini_Router_Comandos") = "Comandos"
        VarIniPrincipal("Ini_Router_Revision") = "Revision"
        VarIniPrincipal("Ini_Router_Fecha") = "Fecha"
        VarIniPrincipal("Ini_Router_Autor") = "Autor"
    End Sub

    Public Sub New()
        CrearArray()
        CargarArrayIni()
    End Sub
End Class