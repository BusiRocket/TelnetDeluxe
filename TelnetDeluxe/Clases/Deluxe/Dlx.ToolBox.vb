Option Strict On
Option Explicit On
Imports System.Net
Imports System.Text
Namespace Deluxe
    Public Class DlxToolBox
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Variables As New DlxVariables

        Public Sub EscribirLogIP(ByVal texto As String)
            Try
                Dim EscritorLog As New System.IO.StreamWriter(Variables.ArchivoLog_IP, True)
                EscritorLog.WriteLine(texto)
                EscritorLog.Close()
                EscritorLog.Dispose()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub


        Public Function ComprobarRedLocal() As Boolean
            Try
                If My.Computer.Network.IsAvailable Then
                    Return True
                Else
                    Return False
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function HazPing(ByVal DirIp As String) As Boolean
            Try
                Dim SolicitudPing As NetworkInformation.PingReply
                Dim CliPing As New NetworkInformation.Ping

                DirIp = DevuelveIP(DirIp)

                If DirIp = "false" Then
                    Errores.MostrarError("La ip no es válida")
                    Exit Function
                End If

                SolicitudPing = CliPing.Send(DirIp)
                CliPing.Dispose()
                CliPing = Nothing
                If SolicitudPing.Status = NetworkInformation.IPStatus.Success Then
                    SolicitudPing = Nothing
                    Return True
                Else
                    SolicitudPing = Nothing
                    Return False
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function DevuelveIP(ByVal DirIp As String) As String
            Try
                Dim reg As RegularExpressions.Regex
                Dim mc As RegularExpressions.MatchCollection
                Dim DirIPActual As String

                reg = New RegularExpressions.Regex("\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", RegularExpressions.RegexOptions.IgnoreCase Or RegularExpressions.RegexOptions.Compiled Or RegularExpressions.RegexOptions.Multiline)
                mc = reg.Matches(DirIp)
                If mc.Count > 0 Then
                    DirIPActual = Trim(mc.Item(0).ToString)
                    Return DirIPActual
                Else
                    Return "False"
                End If
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Return "False"
            End Try
        End Function
    End Class
End Namespace