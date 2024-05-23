Option Strict On
Imports System.Net.NetworkInformation

Public Class Dlx_ToolBox

    Dim UniDlxVars As New UniversalDeluxe

    '////////////////////////////////////////////////////////////////////
    '/// Variables Generales
    Public Version As String = UniDlxVars.Version
    Public TituloForm As String = "Telnet Deluxe v" & Version


    '////////////////////////////////////////////////////////////////////
    '/// Archivos
    Public DirActual As String = Application.StartupPath
    Public ArchivoIni As String = DirActual & "\TelnetDeluxe.ini"
    Public CarpetaIniRouters As String = DirActual & "\Routers"
    Public ArchivoLog_IP As String = DirActual & "\IP.log"


    Public Sub EscribirLogIP(ByVal texto As String)
        Try
            Dim EscritorLog As New System.IO.StreamWriter(ArchivoLog_IP, True)
            EscritorLog.WriteLine(texto)
            EscritorLog.Close()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub


    Public Sub MostrarInfoSistema()
        Try
            Dim RedDisponible As String

            If My.Computer.Network.IsAvailable Then
                RedDisponible = "La tarjeta de red está conectada"
            Else
                RedDisponible = "La tarjeta de red no está conectada"
            End If
            TelnetDeluxe.MostrarEnConsola()
            TelnetDeluxe.MostrarEnConsola(My.Computer.Info.OSFullName.ToString & "  Versión: " & My.Computer.Info.OSVersion.ToString, "Info")
            TelnetDeluxe.MostrarEnConsola("Memoria Física Disponible: " & ((My.Computer.Info.AvailablePhysicalMemory / 1024) / 1024).ToString & " MB", "Info")
            TelnetDeluxe.MostrarEnConsola("Memoria Virtual Disponible: " & ((My.Computer.Info.AvailableVirtualMemory / 1024) / 1024).ToString & " MB", "Info")
            TelnetDeluxe.MostrarEnConsola("Idioma Instalado: " & My.Computer.Info.InstalledUICulture.DisplayName, "Info")
            TelnetDeluxe.MostrarEnConsola(RedDisponible, "Info")
            TelnetDeluxe.MostrarEnConsola("Resolución: " & My.Computer.Screen.Bounds.Width.ToString & "x" & My.Computer.Screen.Bounds.Height.ToString & " Pixels", "Info")
            TelnetDeluxe.MostrarEnConsola()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarInfoRed()
        Try
            Dim ipProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()

            TelnetDeluxe.MostrarEnConsola()
            TelnetDeluxe.MostrarEnConsola("Nombre del Host: " & ipProperties.HostName, "Info")
            TelnetDeluxe.MostrarEnConsola("Nombre del Dominio: " & ipProperties.DomainName, "Info")

            For Each networkCard As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                TelnetDeluxe.MostrarEnConsola()
                TelnetDeluxe.MostrarEnConsola("Tarjeta: " & networkCard.Id, "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Nombre del Dispositivo: " & networkCard.Name, "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Descripción: " & networkCard.Description, "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.OperationalStatus.ToString, "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.GetIPv4Statistics.BytesReceived.ToString, "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Dirección MAC: " & networkCard.GetPhysicalAddress().ToString(), "Info")
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Puertas de Enlace:", "Info")

                For Each gatewayAddr As GatewayIPAddressInformation In networkCard.GetIPProperties().GatewayAddresses
                    TelnetDeluxe.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Puerta de Enlace: " & gatewayAddr.Address.ToString(), "DirIP")
                Next
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Configuración DNS:", "Info")

                For Each address As Net.IPAddress In networkCard.GetIPProperties().DnsAddresses
                    TelnetDeluxe.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Entradas DNS: " & address.ToString(), "Info")
                Next
            Next
            TelnetDeluxe.MostrarEnConsola()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

End Class
