Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class DlxCrono
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe

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
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Function DevolverFecha(Optional ByVal HoraSolo As Boolean = False, Optional ByVal FechaSolo As Boolean = False, Optional ByVal FechaArchivo As Boolean = False) As String
            Try
                Dim devolver As String = ""
                If HoraSolo <> True Then
                    If FechaArchivo = True Then
                        devolver = DateTime.Now.ToString("dd-MM-yy")
                    Else
                        devolver = DateTime.Now.ToString("dd/MM/yy")
                    End If
                End If

                If FechaSolo <> True Then
                    If FechaArchivo = True Then
                        devolver = devolver & DateTime.Now.ToString("HH-mm")
                    Else
                        devolver = devolver & "[" & DateTime.Now.ToString("HH:mm:ss") & "] "
                    End If
                End If
                Return devolver
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Return "[" & DateTime.Now.ToString("HH:mm:ss") & "] "
                Exit Function
            End Try
        End Function

        Public Sub Cerrar()
            Try
                Me.Finalize()
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace