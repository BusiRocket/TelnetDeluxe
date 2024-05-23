Option Strict On
Option Explicit On
Imports System.Text
Imports System.Security.Cryptography
Namespace Deluxe
    Public Class DlxCrypt
        Dim errores As New DlxErrores

        Public Function Hash_Base64(ByVal Texto As String) As String
            Try
                Dim CadenaABytes() As Byte = System.Text.Encoding.UTF8.GetBytes(Texto)
                Return System.Convert.ToBase64String(CadenaABytes)
            Catch oEX As Exception
                errores.MostrarError(oEX)
                Return "Error"
            End Try
        End Function

        Public Function UnHash_Base64(ByVal Texto As String) As String
            Try
                Dim CadenaABytes() As Byte = System.Convert.FromBase64String(Texto)
                Return System.Text.Encoding.UTF8.GetString(CadenaABytes, 0, CadenaABytes.Length)
            Catch oEX As Exception
                errores.MostrarError(oEX)
                Return "Error"
            End Try
        End Function

        Public Function Hash_MD5(ByVal Texto As String) As String
            Try
                Dim Ue As New UnicodeEncoding()
                Dim ByteTexto() As Byte = Ue.GetBytes(Texto)
                Dim Md5 As New MD5CryptoServiceProvider()
                Dim ByteHash() As Byte = Md5.ComputeHash(ByteTexto)
                Return PreparaMD5(ByteHash)
            Catch oEX As Exception
                errores.MostrarError(oEX)
                Return "Error"
            End Try
        End Function

        Public Function PreparaMD5(ByVal BytesMD5() As Byte) As String
            Try
                Dim BytesHash() As Byte
                Dim HashFinal As String
                BytesHash = New MD5CryptoServiceProvider().ComputeHash(BytesMD5)
                HashFinal = (BitConverter.ToString(BytesHash, 0, BytesHash.GetUpperBound(0)))
                HashFinal = Replace(HashFinal, "-", "")
                Return HashFinal.ToLower
            Catch oEX As Exception
                errores.MostrarError(oEX)
                Return "Error"
            End Try
        End Function

        Public Sub Cerrar()
            Try
                Me.Finalize()
            Catch oEX As Exception
                errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace