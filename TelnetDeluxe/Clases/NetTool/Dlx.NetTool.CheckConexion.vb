Option Strict On
Option Explicit On
Imports System.Net.NetworkInformation

Public Class NetTool_CheckConexion
    Private Errores As New Deluxe.DlxErrores
    Private Eventos As New Deluxe.DlxEventos
    Private UniDlxVars As New Deluxe.UniversalDeluxe

    Private CConex As Deluxe.Estructuras.Conexion
    Private WithEvents BWConexion As New System.ComponentModel.BackgroundWorker

    Public Sub New()
        Try
            CConex.Comprobando = False
            CConex.Conectado = False
            CConex.TarjetaDeRed = False
            BWConexion = New System.ComponentModel.BackgroundWorker
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub ComprobarConexion()
        Try
            Dim Crono As New Deluxe.DlxCrono
            Dim PingDefecto As String = "208.69.34.230"
            Dim IPPing As String = ""

            BWConexion.WorkerReportsProgress = True
            BWConexion.WorkerSupportsCancellation = True

            IPPing = TD_Principal.OpcionesTD.Opciones.Dir_Ping
            If IPPing = "" Then
                IPPing = PingDefecto
            End If

            If My.Computer.Network.IsAvailable Then
                CConex.TarjetaDeRed = True
                While BWConexion.IsBusy
                    Crono.Esperar(100)
                End While
                BWConexion.RunWorkerAsync(IPPing)
                CConex.Comprobando = True
            Else
                CConex.Comprobando = False
                CConex.Conectado = False
                CConex.TarjetaDeRed = False
                CConex.ComprobacionCancelada = False
                Eventos.ConexionCambiada(CConex)
            End If

            Crono.Cerrar()
            Crono = Nothing
            PingDefecto = Nothing
            IPPing = Nothing
            CConex = Nothing
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_NoConexion"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Function CheckConexion(ByVal IPPing As String, ByVal Currante As System.ComponentModel.BackgroundWorker) As Boolean
        Try
            Dim SolicitudPing As PingReply
            Dim CliPing As New Ping
            SolicitudPing = CliPing.Send(IPPing)
            CliPing.Dispose()
            CliPing = Nothing
            If SolicitudPing.Status = IPStatus.Success Then
                SolicitudPing = Nothing
                Return True
            Else
                SolicitudPing = Nothing
                Return False
            End If
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_NoConexion"))
            Errores.MostrarError(oEX)
            Return False
            Exit Function
        Finally
            Currante.Dispose()
        End Try
    End Function

    Private Sub BWConexion_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWConexion.DoWork
        Try
            Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
            e.Result = CheckConexion(e.Argument.ToString, worker)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Conexion_Comprobando"))
            Errores.MostrarVError(oEX)
            e.Result = oEX.ToString
            Exit Sub
        End Try
    End Sub

    Private Sub BWConexion_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWConexion.RunWorkerCompleted
        Try
            If e.Error Is Nothing Then
                CConex.Comprobando = False
                CConex.ComprobacionCancelada = False
                CConex.Conectado = CBool(e.Result.ToString)
            Else
                CConex.Comprobando = False
            End If
            Eventos.ConexionCambiada(CConex)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Conexion_Comprobando"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub Cerrar()
        Try
            Me.Finalize()
        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class
