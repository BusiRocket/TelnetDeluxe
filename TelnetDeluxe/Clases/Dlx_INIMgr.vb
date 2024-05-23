Option Strict On
Option Explicit On

Public Class Dlx_IniMgr

    Private BufferTemporal As String

    '--- Declaraciones para leer ficheros INI ---
    Private Declare Function GetPrivateProfileSectionNames Lib "kernel32" Alias "GetPrivateProfileSectionNamesA" (ByVal lpszReturnBuffer As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer

    Public Sub INIMgr_BorrarClave(ByVal ArchivoINI As String, ByVal SeccionINI As String, Optional ByVal Clave As String = "")
        If Len(Clave) = 0 Then
            Call WritePrivateProfileString(SeccionINI, 0, 0, ArchivoINI)
        Else
            Call WritePrivateProfileString(SeccionINI, Clave, 0, ArchivoINI)
        End If
    End Sub

    Public Sub INIMgr_BorrarSeccion(ByVal ArchivoINI As String, ByVal SeccionINI As String)
        Call WritePrivateProfileString(SeccionINI, 0, 0, ArchivoINI)
    End Sub

    Public Function INIMgr_Conseguir(ByVal NombreArchivo As String, ByVal SeccionINI As String, ByVal NombreClave As String, Optional ByVal ValorDefecto As String = "") As String
        Dim ValorTemporal As Integer
        Dim ArrayTemporal As String
        ArrayTemporal = New String(Chr(0), 255)
        ValorTemporal = GetPrivateProfileString(SeccionINI, NombreClave, ValorDefecto, ArrayTemporal, Len(ArrayTemporal), NombreArchivo)
        If ValorTemporal = 0 Then
            Return ValorDefecto
        Else
            Return Left(ArrayTemporal, ValorTemporal)
        End If
    End Function

    Public Sub INIMgr_Escribir(ByVal NombreArchivo As String, ByVal SeccionINI As String, ByVal NombreClave As String, ByVal ValorClave As String)
         Call WritePrivateProfileString(SeccionINI, NombreClave, ValorClave, NombreArchivo)
    End Sub

    Public Function INIMgr_ConseguirSeccion(ByVal NombreArchivo As String, ByVal SeccionINI As String) As String()
        Dim ArraySeccion() As String
        Dim n As Integer

        ReDim ArraySeccion(0)
        BufferTemporal = New String(ChrW(0), 32767)
        n = GetPrivateProfileSection(SeccionINI, BufferTemporal, BufferTemporal.Length, NombreArchivo)
        If n > 0 Then
            BufferTemporal = BufferTemporal.Substring(0, n - 2).TrimEnd()
            ArraySeccion = BufferTemporal.Split(New Char() {ChrW(0), "="c})
        End If
        Return ArraySeccion
    End Function

    Public Function INIMgr_ConseguirSecciones(ByVal NombreArchivo As String) As String()
        Dim n As Integer
        Dim ArraySecciones() As String
        ReDim ArraySecciones(0)

        BufferTemporal = New String(ChrW(0), 32767)

        n = GetPrivateProfileSectionNames(BufferTemporal, BufferTemporal.Length, NombreArchivo)
        If n > 0 Then
            BufferTemporal = BufferTemporal.Substring(0, n - 2).TrimEnd()
            ArraySecciones = BufferTemporal.Split(ChrW(0))
        End If
        Return ArraySecciones
    End Function
    '

End Class
