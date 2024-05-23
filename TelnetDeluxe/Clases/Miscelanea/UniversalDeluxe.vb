Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class UniversalDeluxe
        Public Traduccion As New System.Collections.Generic.Dictionary(Of String, String)
         Private Variables As New DlxVariables


        Public Sub CrearArray()

            ' ###########################################################
            ' <********************** Errores **************************>
            ' ###########################################################

            '////////////////////////////////////////////////////////////////////
            '/// Genéricos
            Traduccion("Error_NoControlado") = "ERROR no controlado: "
            Traduccion("Error_Generico") = "Ha ocurrido un error"

            '////////////////////////////////////////////////////////////////////
            '/// Genéricos
            Traduccion("Error_Conexion_Comprobando") = "Ha ocurrido un error mientras se comprobaba la conexión"

            '////////////////////////////////////////////////////////////////////
            '/// Errores de CFG
            Traduccion("Error_INIRouterBad") = "El archivo de configuración no existe ("
            Traduccion("Error_NoExisteCFG") = "El archivo seleccionado no existe ("
            Traduccion("Error_NoPuedoCargarINI") = "Ha ocurrido un Error Cargando el fichero INI"
            Traduccion("Error_NoConfigCargada") = "Error. No se ha cargado el archivo de configuración"
            Traduccion("Error_IntervaloLow") = "El valor de intervalo es demasiado bajo"
            Traduccion("Error_IntervaloLowTip") = "Recuerda que si envias comandos demasiado rápido puede que no lleguen al router"

            Traduccion("Error_CargandoListaIPs") = "Ha ocurrido un error cargando la lista de IP's"
            Traduccion("Error_CargandoListaPuertos") = "Ha ocurrido un error cargando la lista de Puertos"
            Traduccion("Error_CargandoOpciones") = "Ha ocurrido un error cargando las opciones."

            '////////////////////////////////////////////////////////////////////
            '/// Errores linea de comandos
            Traduccion("Error_ComandoBad") = "El comando ''"
            Traduccion("Error_ComandoBadFin") = "'' no se ha reconocido"


            Traduccion("Error_NoPuedoConectar") = "No se ha podido establecer la conexión"
            Traduccion("Error_NoPuedoDesconectar") = "No se ha podido cerrar la conexión"


            Traduccion("Error_NoConexion") = "Error mientras se comprobaba la conexión"
            Traduccion("Error_NoTarjetaRed") = "No hay ninguna tarjeta de red conectada"

            '////////////////////////////////////////////////////////////////////
            '/// Errores del Router
            Traduccion("Error_NoRespuestaRouter") = "Error, no se ha podido conseguir la información del router"
            Traduccion("Error_NoPuedoEnviarComando") = "Error, no se ha podido enviar el comando al router"
            Traduccion("Error_EnviandoComando") = "Ha ocurrido un error mientras se intentaba enviar el comando al router"
            Traduccion("Error_NoConectadoRouter") = "No se ha podido conectar con el router, operación abortada"
            Traduccion("Error_ConexionPerdida") = "Se ha perdido la conexión con el router"
            Traduccion("Error_NoPuedoLeer") = "No he podido conseguir respuesta del router"




            Traduccion("Error_CompruebaIpPuerto") = Traduccion("Error_NoPuedoConectar") & ", comprueba que la IP y el puerto sean correctos"
            Traduccion("Error_NoPING") = "La dirección de red: "
            Traduccion("Error_NoPING2") = " no responde, comprueba que la IP sea correcta"


            Traduccion("Error_Macro") = "Falló la automatización de comandos." & vbNewLine & "Cancelando Operación..."
            Traduccion("Error_Macro_General") = "Parece que hubo un fallo en la automatización de comandos." & vbNewLine & "La operación ha terminado con un código de error"

            ' Errores Comprobando Ip Pública
            Traduccion("Error_PIPC_ConsiguiendoHTML") = "Error, el html no se descargó correctamente"
            Traduccion("Error_PIPC_HTMLNoIp") = "Error, el html descargado no contiene ninguna IP"
            Traduccion("Error_PIPC_NoRed") = "No se puede conseguir la IP pública ya que no hay ninguna tarjeta de red conectada."
            Traduccion("Error_PIPC_Nocontrolado") = "Ha ocurrido un error no controlado, no ha sido posible conseguir la dirección IP pública"



            ' ###########################################################
            ' <********************** Mensajes Generales ***************>
            ' ###########################################################
            Traduccion("General_BienvenidaInfo") = "Telnet Deluxe v" & Variables.Version & " (Enero 2008)"
            Traduccion("General_Comenzo") = "El programa comenzó "


            ' ###########################################################
            ' <************** Mensajes de configuración ****************>
            ' ###########################################################
            Traduccion("Console_Config_Intervalo") = "El intervalo de envio de comandos se ha cambiado a "
            Traduccion("Console_Config_IntervaloFin") = " segundos."



            ' ###########################################################
            ' <**************** Mensajes de información ****************>
            ' ###########################################################
            Traduccion("Console_Msg_ConexionOK") = "Conexión Establecida correctamente"
            Traduccion("Console_Msg_ConectadoA") = "Conectado a '"
            Traduccion("Console_Msg_ConectandoCon") = "Conectando con "
            Traduccion("Console_Msg_ConectadoAPuerto") = "' puerto "
            Traduccion("Console_Msg_Desconectado") = "Conexión Cerrada"
            Traduccion("Console_Msg_EsperandoRespuesta") = "Esperando respuesta..."
            Traduccion("Console_Msg_CancelarOperacion") = "Cancelando envío de comandos, por favor espere..."
            Traduccion("Console_Msg_OperacionCancelada") = "Se ha cancelado la operación."
            Traduccion("Console_Msg_ConexionCerrada") = "El router ha cerrado la conexión." & "¿Has escrito bien la contraseña?"


            Traduccion("Console_Msg_ComandosOK") = "Los comandos se realizaron con éxito"
            Traduccion("Console_Msg_ComandosOKWait") = "Espera unos segundos hasta que tu router sincronice"
            Traduccion("Console_Msg_ConsiguiendoIP") = "Intentando conseguir la dirección IP"
            Traduccion("Console_Msg_EsperaLarga") = "Esto puede tardar varios segundos"
            Traduccion("Console_Msg_IPActual") = "Tu IP actual es "
            Traduccion("Console_Msg_SeleccionaCFG") = "Selecciona un archivo de configuración antes de comenzar"
            Traduccion("Console_Msg_LeyendoCFG") = "Leyendo archivo de configuración..."
            Traduccion("Console_Msg_SeleccionaCFG") = "Selecciona un archivo de configuración antes de comenzar"
            Traduccion("Console_Msg_IPIgual") = "Vaya, parece que no ha sido posible cambiar la IP." & vbNewLine & "Comprueba que has seleccionado el modelo de tu router en las opciones" & vbNewLine & "Tambien deberías comprobar si el usuario y la contraseña son correctos"

            Traduccion("Console_Msg_InfoCFG") = "Archivo de configuración para "
            Traduccion("Console_Msg_InfoCFG2") = ". Versión "
            Traduccion("Console_Msg_InfoCFG3") = "Creado por "
            Traduccion("Console_Msg_InfoCFG4") = ". Última modificación: "
            Traduccion("Console_Msg_InfoCargOK") = "El archivo de configuración se cargó correctamente..."


            ' ###########################################################
            ' <************** Mensajes de la interfaz ******************>
            ' ###########################################################
            Traduccion("Gui_General_Conectado") = "Conectado"
            Traduccion("Gui_General_DesConectado") = "Desconectado"
            Traduccion("Gui_General_Online") = "En Línea"
            Traduccion("Gui_General_Offline") = "Sin Conexión"
            Traduccion("Gui_Routers_NohayINI") = "No se ha encontrado ningún archivo de configuración para los routers" & vbNewLine & "Bájate la última versión de " & Variables.WebPrograma
            Traduccion("Gui_Routers_NohaylstIP") = "No se ha encontrado el archivo 'WebsIP.lst' que contiene la lista de webs necesarias para conseguir la IP pública, se usará www.showmyip.com"
            Traduccion("Gui_Routers_NohaylstPuertos") = "No se ha encontrado el archivo 'Puertos.lst' que contiene la lista de los puertos necesarios para el scanner."

            ' ###########################################################
            ' <********* Mensajes del área de notificación *************>
            ' ###########################################################
            Traduccion("Tray_Msg_RenovandoIP") = "Renovando IP..."
            Traduccion("Tray_Msg_ComandosOK") = "Se han completado todos los comandos"
            Traduccion("Tray_Msg_Online") = "Conectado A Internet"

        End Sub

        Public Sub New()
            CrearArray()
        End Sub
    End Class
End Namespace