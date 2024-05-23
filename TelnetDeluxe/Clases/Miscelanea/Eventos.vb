Option Strict On
Namespace Deluxe
    Public Class DlxEventos
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe

        Public Event MensajeDisponible_ev As MensajeDisponibleEventHandler
        Public Event NuevaIPDisponible_ev As NuevaIPDisponibleEventHandler
        Public Event ReportarProgreso_ev As ReportarProgresoEventHandler
        Public Event ConexionCambiada_ev As ConexionCambiadaEventHandler
        Public Event RouterConectado_ev As RouterConectadoEventHandler
        Public Event RouterDesconectado_ev As RouterDesconectadoEventHandler


        Public Sub New()
            AddHandler Me.MensajeDisponible_ev, AddressOf OnMensajeDisponible
            AddHandler Me.ReportarProgreso_ev, AddressOf OnReportarProgreso
            AddHandler Me.NuevaIPDisponible_ev, AddressOf OnNuevaIPDisponible
            AddHandler Me.ConexionCambiada_ev, AddressOf OnConexionCambiada
            AddHandler Me.RouterConectado_ev, AddressOf RouterConectado
            AddHandler Me.RouterDesconectado_ev, AddressOf RouterDesconectado
        End Sub

        Public Sub MensajeDisponible(Optional ByVal Mensaje As String = "", Optional ByVal TipoMensaje As Deluxe.Estructuras.MensajeConsola = Deluxe.Estructuras.MensajeConsola.MSG_Defecto)
            Dim Argumentos As New MensajeDisponibleEventArgs(Mensaje, TipoMensaje)
            RaiseEvent MensajeDisponible_ev(Me, Argumentos)
        End Sub

        Public Sub ReportarProgreso(ByVal Progreso As Integer, Optional ByVal InfoProgreso As String = "")
            Dim Argumentos As New ReportarProgresoEventArgs(Progreso, InfoProgreso)
            RaiseEvent ReportarProgreso_ev(Me, Argumentos)
        End Sub

        Public Sub NuevaIPDisponible(Optional ByVal Mensaje As String = "")
            Dim Argumentos As New NuevaIPDisponibleEventArgs(Mensaje)
            RaiseEvent NuevaIPDisponible_ev(Me, Argumentos)
        End Sub

        Public Sub ConexionCambiada(ByVal conex As Estructuras.Conexion)
            Dim Argumentos As New ArgumentosConexion(conex)
            RaiseEvent ConexionCambiada_ev(Me, Argumentos)
        End Sub

        Public Sub RouterDesconectado(Optional ByVal errorMessage As String = "")
            Dim Argumentos As New ConexionEventArgs(errorMessage)
            RaiseEvent RouterDesconectado_ev(Me, Argumentos)
        End Sub

        Public Sub RouterConectado(Optional ByVal errorMessage As String = "")
            Dim Argumentos As New ConexionEventArgs(errorMessage)
            RaiseEvent RouterConectado_ev(Me, Argumentos)
        End Sub


        Private Sub RouterConectado(ByVal sender As Object, ByVal e As ConexionEventArgs)
            Try
                TD_Principal.RouterConectado()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub RouterDesconectado(ByVal sender As Object, ByVal e As ConexionEventArgs)
            Try
                TD_Principal.RouterDesconectado()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub OnMensajeDisponible(ByVal sender As Object, ByVal e As MensajeDisponibleEventArgs)
            Try
                TD_Principal.MostrarEnConsola(e.Mensaje, e.TipoMensaje)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub OnReportarProgreso(ByVal sender As Object, ByVal e As ReportarProgresoEventArgs)
            Try
                TD_Principal.MostrarProgresoBE(e.Progreso)
                TD_Principal.MostrarInfoProgreso(e.InfoProgreso)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub OnNuevaIPDisponible(ByVal sender As Object, ByVal e As NuevaIPDisponibleEventArgs)
            Try
                TD_Principal.MostrarIPPublica(e.DirIP)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub OnConexionCambiada(ByVal sender As Object, ByVal e As ArgumentosConexion)
            Try
                TD_Principal.ConexionCambiada(e)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace
