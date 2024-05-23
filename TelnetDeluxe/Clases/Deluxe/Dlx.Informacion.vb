Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class DlxInformacion
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe


        Public Sub MostrarInfoSistema()
            Try
                Dim InfoSistema As String = "Información del sistema: " & vbNewLine _
                & "Nombre asignado a este PC: " & My.Computer.Name.ToString & vbNewLine _
                & "Nombre de Usuario: " & My.User.Name & vbNewLine _
                & "Ha iniciado la sesión: " & My.User.IsAuthenticated & vbNewLine _
                & "Sistema Operativo: " & My.Computer.Info.OSFullName.ToString & vbNewLine _
                & "Versión del Sistema Operativo: " & My.Computer.Info.OSVersion.ToString & vbNewLine _
                & "Memoria Física Disponible: " & ((My.Computer.Info.AvailablePhysicalMemory / 1024) / 1024).ToString & " Mb" & vbNewLine _
                & "Memoria Virtual Disponible: " & ((My.Computer.Info.AvailableVirtualMemory / 1024) / 1024).ToString & " Mb" & vbNewLine _
                & "Idioma Instalado: " & My.Computer.Info.InstalledUICulture.DisplayName & vbNewLine _
                & IIf(My.Computer.Network.IsAvailable, "La tarjeta de red está conectada", "La tarjeta de red no está conectada").ToString & vbNewLine _
                & "Resolución: " & My.Computer.Screen.Bounds.Width.ToString & "x" & My.Computer.Screen.Bounds.Height.ToString & " Pixels" & vbNewLine _
                & "Fecha/Hora Local: " & My.Computer.Clock.LocalTime & vbNewLine _
                & "Fecha/Hora GTM: " & My.Computer.Clock.GmtTime
                TD_Principal.MostrarEnConsola()
                TD_Principal.MostrarEnConsola(InfoSistema, Estructuras.MensajeConsola.MSG_Info)
                TD_Principal.MostrarEnConsola()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarInfoRed()
            Try
                Dim ipProperties As System.Net.NetworkInformation.IPGlobalProperties = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties()

                TD_Principal.MostrarEnConsola()
                TD_Principal.MostrarEnConsola("Nombre del Host: " & ipProperties.HostName, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                TD_Principal.MostrarEnConsola("Nombre del Dominio: " & ipProperties.DomainName, Deluxe.Estructuras.MensajeConsola.MSG_Info)

                For Each networkCard As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    TD_Principal.MostrarEnConsola()
                    TD_Principal.MostrarEnConsola("Tarjeta: " & networkCard.Id, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Nombre del Dispositivo: " & networkCard.Name, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Descripción: " & networkCard.Description, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.OperationalStatus.ToString, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.GetIPv4Statistics.BytesReceived.ToString, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Dirección MAC: " & networkCard.GetPhysicalAddress().ToString(), Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Puertas de Enlace:", Deluxe.Estructuras.MensajeConsola.MSG_Info)

                    For Each gatewayAddr As System.Net.NetworkInformation.GatewayIPAddressInformation In networkCard.GetIPProperties().GatewayAddresses
                        TD_Principal.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Puerta de Enlace: " & gatewayAddr.Address.ToString(), Estructuras.MensajeConsola.MSG_DirIP)
                    Next
                    TD_Principal.MostrarEnConsola("" & Chr(9) & " Configuración DNS:", Deluxe.Estructuras.MensajeConsola.MSG_Info)

                    For Each address As System.Net.IPAddress In networkCard.GetIPProperties().DnsAddresses
                        TD_Principal.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Entradas DNS: " & address.ToString(), Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    Next
                Next
                TD_Principal.MostrarEnConsola()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace