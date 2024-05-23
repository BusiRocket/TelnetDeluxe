Option Strict On
Imports System.Net.NetworkInformation
Imports System.IO
Public Class Dlx_ToolBox

    Dim UniDlxVars As New UniversalDeluxe

    '////////////////////////////////////////////////////////////////////
    '/// Variables Generales
    Public Version As String = UniDlxVars.Version
    Public TituloForm As String = "Telnet Deluxe v" & Version


    '////////////////////////////////////////////////////////////////////
    '/// Archivos
    Public DirActual As String = Application.StartupPath
    Public CarpetaIniRouters As String = DirActual & "\Routers"

    Public ArchivoIni As String = DirActual & "\TelnetDeluxe.ini"
    Public ArchivoLog_IP As String = DirActual & "\IP.log"
    Public ArchivoLog_Errores As String = DirActual & "\Errores.log"
    Public ArchivoListaWebsIp As String = DirActual & "\WebsIP.lst"

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
    End Structure

    Public Structure Opciones
        Dim Consola_MostrarHora As Boolean
        Dim FUNC_IPShow_Web As String
        Dim GUI_MinimToTray As Boolean
        Dim LOG_LoguearErrores As Boolean
        Dim LOG_LoguearIPs As Boolean
        Dim LOG_MostrarErrDetallado As Boolean
        Dim Telnet_Intervalo As Integer
        Dim EsperaBallonTip As Integer
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
        Dim EstamosConectados As Boolean
        Dim ComprobarIP As Boolean
        Dim NuevaIP As Boolean
        Dim ConectadoAInet As Boolean
        Dim MacroOK As Boolean
        Dim IniRouterCargada As Boolean
        Dim TarjetaRedConectada As Boolean
        Dim EjecutandoMacro As Boolean
        Dim PararMacro As Boolean
    End Structure

    Public Enum MensajeConsola
        MSG_Defecto
        MSG_Info
        MSG_Error
        MSG_Router
        MSG_Accion
        MSG_DirIP
    End Enum



    Public Sub EscribirLogIP(ByVal texto As String)
        Try
            Dim EscritorLog As New System.IO.StreamWriter(ArchivoLog_IP, True)
            EscritorLog.WriteLine(texto)
            EscritorLog.Close()
            EscritorLog.Dispose()
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
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
            TelnetDeluxe.MostrarEnConsola(My.Computer.Info.OSFullName.ToString & "  Versión: " & My.Computer.Info.OSVersion.ToString, MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola("Memoria Física Disponible: " & ((My.Computer.Info.AvailablePhysicalMemory / 1024) / 1024).ToString & " MB", Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola("Memoria Virtual Disponible: " & ((My.Computer.Info.AvailableVirtualMemory / 1024) / 1024).ToString & " MB", Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola("Idioma Instalado: " & My.Computer.Info.InstalledUICulture.DisplayName, Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola(RedDisponible, Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola("Resolución: " & My.Computer.Screen.Bounds.Width.ToString & "x" & My.Computer.Screen.Bounds.Height.ToString & " Pixels", Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola()
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarInfoRed()
        Try
            Dim ipProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()

            TelnetDeluxe.MostrarEnConsola()
            TelnetDeluxe.MostrarEnConsola("Nombre del Host: " & ipProperties.HostName, Dlx_ToolBox.MensajeConsola.MSG_Info)
            TelnetDeluxe.MostrarEnConsola("Nombre del Dominio: " & ipProperties.DomainName, Dlx_ToolBox.MensajeConsola.MSG_Info)

            For Each networkCard As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                TelnetDeluxe.MostrarEnConsola()
                TelnetDeluxe.MostrarEnConsola("Tarjeta: " & networkCard.Id, Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Nombre del Dispositivo: " & networkCard.Name, Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Descripción: " & networkCard.Description, Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.OperationalStatus.ToString, Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Estado: " & networkCard.GetIPv4Statistics.BytesReceived.ToString, Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Dirección MAC: " & networkCard.GetPhysicalAddress().ToString(), Dlx_ToolBox.MensajeConsola.MSG_Info)
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Puertas de Enlace:", Dlx_ToolBox.MensajeConsola.MSG_Info)

                For Each gatewayAddr As GatewayIPAddressInformation In networkCard.GetIPProperties().GatewayAddresses
                    TelnetDeluxe.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Puerta de Enlace: " & gatewayAddr.Address.ToString(), MensajeConsola.MSG_DirIP)
                Next
                TelnetDeluxe.MostrarEnConsola("" & Chr(9) & " Configuración DNS:", Dlx_ToolBox.MensajeConsola.MSG_Info)

                For Each address As Net.IPAddress In networkCard.GetIPProperties().DnsAddresses
                    TelnetDeluxe.MostrarEnConsola("" & Chr(9) & "" & Chr(9) & " Entradas DNS: " & address.ToString(), Dlx_ToolBox.MensajeConsola.MSG_Info)
                Next
            Next
            TelnetDeluxe.MostrarEnConsola()
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Function MostrarHora() As String
        Try
            Dim Hora, Minuto, Segundo As String
            Hora = System.DateTime.Now.Hour.ToString
            Minuto = System.DateTime.Now.Minute.ToString
            Segundo = System.DateTime.Now.Second.ToString

            If Hora.Length <= 1 Then
                Hora = "0" & Hora
            End If

            If Minuto.Length <= 1 Then
                Minuto = "0" & Minuto
            End If

            If Segundo.Length <= 1 Then
                Segundo = "0" & Segundo
            End If
            Return "[" & Hora & ":" & Minuto & ":" & Segundo & "] "
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Return "[" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & "] "
            Exit Function
        End Try
    End Function



    Public Sub Esperar(ByVal Milisegundos As Integer)
        Try
            Dim HoraActual As DateTime
            Dim HoraFinal As DateTime
            Dim Parar As Boolean

            HoraFinal = Now()
            HoraFinal = HoraFinal.AddMilliseconds(Milisegundos)
            Parar = False
            While Not Parar
                HoraActual = Now()
                If HoraActual > HoraFinal Then
                    Parar = True
                End If
                Application.DoEvents()
            End While

            HoraActual = Nothing
            HoraFinal = Nothing
            Parar = Nothing
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Public Function DiaSemana(ByVal dia As Integer) As String
        Try
            Dim Semana() As String = Nothing
            Semana.SetValue("Domingo", 0)
            Semana.SetValue("Lunes", 1)
            Semana.SetValue("Martes", 2)
            Semana.SetValue("Miércoles", 3)
            Semana.SetValue("Jueves", 4)
            Semana.SetValue("Viernes", 5)
            Semana.SetValue("Sábado", 6)
            Return Semana(dia)
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Return ""
            Exit Function
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
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
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
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <*** Funciones para manejo del inicio **********>
    ' ###########################################################

    Public Function ExecComandos(ByVal LineaComandos As String) As Boolean
        Try
            Dim mostrar As Boolean
            LineaComandos = UCase(LineaComandos)
            If LineaComandos = "/RYC" Then
                Esperar(1000)
                TelnetDeluxe.Macro()
                While Not TelnetDeluxe.Estado.ConectadoAInet
                    Esperar(100)
                End While
                TelnetDeluxe.Close()
                mostrar = True
            ElseIf LineaComandos = "/RYCS" Then
                TelnetDeluxe.IrATray()
                Esperar(1000)
                TelnetDeluxe.Macro()
                While Not TelnetDeluxe.Estado.ConectadoAInet
                    Esperar(100)
                End While
                TelnetDeluxe.Close()
                mostrar = False
            ElseIf LineaComandos = "/RENOVAR" Then
                Esperar(3000)
                TelnetDeluxe.Macro()
                mostrar = False
            ElseIf LineaComandos = "/CERRAR" Then
                TelnetDeluxe.Close()
                mostrar = False
            ElseIf LineaComandos = "/TRAY" Then
                TelnetDeluxe.IrATray()
                mostrar = False
            Else
                MostrarError(UniDlxVars.Traduccion("Error_ComandoBad") & LineaComandos & UniDlxVars.Traduccion("Error_ComandoBadFin"))
                mostrar = False
            End If
            Return mostrar
        Catch oEX As Exception
            MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            MostrarError(oEX)
            Exit Function
        End Try
    End Function



    ' ###########################################################
    ' <*** Funciones para Mostrar/Registrar Errores ************>
    ' ###########################################################

    Public Sub MostrarError(ByVal DlxError As Exception)
        Try
            If TelnetDeluxe.OpcionesTD.LOG_MostrarErrDetallado = True Then
                TelnetDeluxe.MostrarEnConsola(DlxError.Message, Dlx_ToolBox.MensajeConsola.MSG_Error)
                TelnetDeluxe.MostrarEnConsola(DlxError.InnerException.ToString, Dlx_ToolBox.MensajeConsola.MSG_Error)
                TelnetDeluxe.MostrarEnConsola(DlxError.Source, Dlx_ToolBox.MensajeConsola.MSG_Error)
                TelnetDeluxe.MostrarEnConsola(DlxError.StackTrace, Dlx_ToolBox.MensajeConsola.MSG_Error)
                TelnetDeluxe.MostrarEnConsola(DlxError.TargetSite.ToString, Dlx_ToolBox.MensajeConsola.MSG_Error)
            End If
            If TelnetDeluxe.OpcionesTD.LOG_LoguearErrores = True Then
                GuardarError(DlxError)
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), Dlx_ToolBox.MensajeConsola.MSG_Error)
            TelnetDeluxe.MostrarEnConsola(oEX.Message, Dlx_ToolBox.MensajeConsola.MSG_Error)
            Exit Sub
        End Try
    End Sub

    Private Sub GuardarError(ByVal DlxError As Exception)
        Try
            Dim EscritorLog As New System.IO.StreamWriter(ArchivoLog_Errores, True)
            EscritorLog.WriteLine("Error registrado el: " & System.DateTime.Now & vbNewLine & "     Error detallado: ")
            EscritorLog.WriteLine(DlxError.Message)
            EscritorLog.WriteLine(DlxError.InnerException.ToString, Dlx_ToolBox.MensajeConsola.MSG_Error)
            EscritorLog.WriteLine(DlxError.Source, Dlx_ToolBox.MensajeConsola.MSG_Error)
            EscritorLog.WriteLine(DlxError.StackTrace, Dlx_ToolBox.MensajeConsola.MSG_Error)
            EscritorLog.WriteLine(DlxError.TargetSite.ToString, Dlx_ToolBox.MensajeConsola.MSG_Error)
            EscritorLog.Close()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), Dlx_ToolBox.MensajeConsola.MSG_Error)
            TelnetDeluxe.MostrarEnConsola(oEX.Message, Dlx_ToolBox.MensajeConsola.MSG_Error)
            Exit Sub
        End Try
    End Sub

    Public Sub MostrarError(ByVal DlxError As String)
        Try
            TelnetDeluxe.MostrarEnConsola(DlxError, Dlx_ToolBox.MensajeConsola.MSG_Error)
            If TelnetDeluxe.OpcionesTD.LOG_LoguearErrores = True Then
                GuardarError(DlxError)
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), Dlx_ToolBox.MensajeConsola.MSG_Error)
            TelnetDeluxe.MostrarEnConsola(oEX.Message, Dlx_ToolBox.MensajeConsola.MSG_Error)
            Exit Sub
        End Try
    End Sub

    Private Sub GuardarError(ByVal DlxError As String)
        Try
            Dim EscritorLog As New System.IO.StreamWriter(ArchivoLog_Errores, True)
            EscritorLog.WriteLine(System.DateTime.Now & " - " & DlxError)
            EscritorLog.Close()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), Dlx_ToolBox.MensajeConsola.MSG_Error)
            TelnetDeluxe.MostrarEnConsola(oEX.Message, Dlx_ToolBox.MensajeConsola.MSG_Error)
            Exit Sub
        End Try
    End Sub

End Class
