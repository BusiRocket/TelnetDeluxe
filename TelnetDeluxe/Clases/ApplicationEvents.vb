Namespace My

    ' Los siguientes eventos est�n disponibles para MyApplication:
    ' 
    ' Inicio: se desencadena cuando se inicia la aplicaci�n, antes de que se cree el formulario de inicio.
    ' Apagado: generado despu�s de cerrar todos los formularios de la aplicaci�n. Este evento no se genera si la aplicaci�n termina de forma an�mala.
    ' UnhandledException: generado si la aplicaci�n detecta una excepci�n no controlada.
    ' StartupNextInstance: se desencadena cuando se inicia una aplicaci�n de instancia �nica y la aplicaci�n ya est� activa. 
    ' NetworkAvailabilityChanged: se desencadena cuando la conexi�n de red est� conectada o desconectada.
    Partial Friend Class MyApplication

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Try
                TelnetDeluxe.NuevaInstancia(e)
                Exit Sub
            Catch ex As Exception
                Dim DlxToolBox As New Dlx_ToolBox
                DlxToolBox.MostrarError(ex)
                DlxToolBox = Nothing
                Exit Sub
            End Try
        End Sub

        Public Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Dim DlxToolBox As New Dlx_ToolBox
                e.ExitApplication = False
                DlxToolBox.MostrarError(e.Exception)
                DlxToolBox = Nothing
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error No Controlado" & vbNewLine & ex.Message)
                Exit Sub
            End Try
        End Sub
    End Class

End Namespace

