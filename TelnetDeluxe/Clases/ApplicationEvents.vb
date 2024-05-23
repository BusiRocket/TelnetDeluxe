Namespace My

    ' Los siguientes eventos están disponibles para MyApplication:
    ' 
    ' Inicio: se desencadena cuando se inicia la aplicación, antes de que se cree el formulario de inicio.
    ' Apagado: generado después de cerrar todos los formularios de la aplicación. Este evento no se genera si la aplicación termina de forma anómala.
    ' UnhandledException: generado si la aplicación detecta una excepción no controlada.
    ' StartupNextInstance: se desencadena cuando se inicia una aplicación de instancia única y la aplicación ya está activa. 
    ' NetworkAvailabilityChanged: se desencadena cuando la conexión de red está conectada o desconectada.
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

