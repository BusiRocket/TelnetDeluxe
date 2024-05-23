Option Strict On
Namespace Deluxe
    Public Class DlxVariables
        '////////////////////////////////////////////////////////////////////
        '/// Variables Generales
        Public Version As String = "0.5 Beta"
        Public TituloForm As String = "Telnet Deluxe v" & Version.ToString
        Public WebPrograma As String = "http://deluxeworld.googlepages.com"

        '////////////////////////////////////////////////////////////////////
        '/// Archivos
        Public DirActual As String = Carpeta()
        Public CarpetaIniRouters As String = DirActual & "\Routers"

        Public ArchivoIni As String = DirActual & "\TelnetDeluxe.ini"
        Public ArchivoLog_IP As String = DirActual & "\IP.log"
        Public ArchivoLog_Errores As String = DirActual & "\Errores.log"
        Public ArchivoListaWebsIp As String = DirActual & "\WebsIP.lst"
        Public ArchivoListaPuertos As String = DirActual & "\Puertos.lst"


        Public ReadOnly Property Carpeta() As String
            Get
                Return Application.StartupPath
            End Get
        End Property

    End Class
End Namespace