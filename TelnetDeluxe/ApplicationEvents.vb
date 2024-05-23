Namespace My

    ' Los siguientes eventos est�n disponibles para MyApplication:
    ' 
    ' Inicio: se desencadena cuando se inicia la aplicaci�n, antes de que se cree el formulario de inicio.
    ' Apagado: generado despu�s de cerrar todos los formularios de la aplicaci�n. Este evento no se genera si la aplicaci�n termina de forma an�mala.
    ' UnhandledException: generado si la aplicaci�n detecta una excepci�n no controlada.
    ' StartupNextInstance: se desencadena cuando se inicia una aplicaci�n de instancia �nica y la aplicaci�n ya est� activa. 
    ' NetworkAvailabilityChanged: se desencadena cuando la conexi�n de red est� conectada o desconectada.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Try
                TD_Principal.NuevaInstancia(e)
                Exit Sub
            Catch ex As Exception
                Dim Errores As New Deluxe.DlxErrores
                Errores.MostrarError(ex)
                Errores = Nothing
                Exit Sub
            End Try
        End Sub

        Public Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Dim Errores As New Deluxe.DlxErrores
                e.ExitApplication = False
                Errores.MostrarError(e.Exception)
                Errores = Nothing
                Exit Sub
            Catch ex As Exception
                Dim Errores As New Deluxe.DlxErrores
                Errores.MostrarVError(ex)
                Errores = Nothing
                Exit Sub
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace

