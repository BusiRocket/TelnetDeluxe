Option Strict On
Option Explicit On
Imports System.IO
Namespace Deluxe
    Public Class DlxArchivos
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Variables As New DlxVariables


        Public Sub ComprobarCarpeta(ByVal Carpeta As String)
            Try
                If Directory.Exists(Carpeta) = False Then
                    Directory.CreateDirectory(Carpeta)
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        
    End Class
End Namespace