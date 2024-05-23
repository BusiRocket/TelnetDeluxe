Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class DlxFormularios
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Crono As New DlxCrono

        ' ###########################################################
        ' <*** Funciones para mostrar el progreso **********>
        ' ###########################################################

        Public Sub IniciarProgreso(ByVal CProgreso As Estructuras.ComponentesProgreso)
            Try
                CProgreso.EtiquetaProgreso.Text = "0%"
                CProgreso.Progreso = 0
                CProgreso.BarraProgreso.Value = 0
                CProgreso.BarraProgreso.Maximum = CProgreso.ProgresoMax
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarProgreso(ByVal CProgreso As Estructuras.ComponentesProgreso)
            Try
                ComponentesProgresoCambiados(CProgreso)
                MostrarProgresoBE(CProgreso)
                If CProgreso.Texto = String.Empty Then
                    CProgreso.Texto = CProgreso.TextoDefecto
                End If
                CProgreso.IconoNotificacion.Text = CProgreso.Texto
                CProgreso.EtiquetaEstado.Text = CProgreso.Texto
            Catch oEX As Exception
                Exit Sub
            End Try
        End Sub

        Private Sub ComponentesProgresoCambiados(ByVal CProgreso As Estructuras.ComponentesProgreso)
            Try
                CProgreso.IconoNotificacion.BalloonTipIcon = CProgreso.IN_TipoIcono
                CProgreso.IconoNotificacion.BalloonTipTitle = CProgreso.IN_Titulo
                CProgreso.BarraProgreso.Maximum = CProgreso.ProgresoMax
                CProgreso.BarraProgreso.Minimum = 0
            Catch oEX As Exception
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarProgresoBE(ByVal CProgreso As Estructuras.ComponentesProgreso)
            Try
                Dim TantoPorCiento As Integer = CType((100 / CProgreso.BarraProgreso.Maximum + 1) * CProgreso.Progreso, Integer)

                If TantoPorCiento < CProgreso.BarraProgreso.Maximum Then
                    CProgreso.EtiquetaProgreso.Text = TantoPorCiento.ToString & "%"
                Else
                    CProgreso.EtiquetaProgreso.Text = "100%"
                End If

                If CProgreso.Progreso <= CProgreso.BarraProgreso.Maximum Then
                    CProgreso.BarraProgreso.Value = CProgreso.Progreso
                Else
                    CProgreso.BarraProgreso.Value = CProgreso.BarraProgreso.Maximum
                End If
                TantoPorCiento = Nothing
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarTrayTip(ByVal CProgreso As Estructuras.ComponentesProgreso)
            Try
                ComponentesProgresoCambiados(CProgreso)
                If CProgreso.IconoNotificacion.Visible = True Then
                    CProgreso.IconoNotificacion.BalloonTipText = CProgreso.IN_Mensaje
                    CProgreso.IconoNotificacion.ShowBalloonTip(CProgreso.IN_Esperar)
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub


        ' ###########################################################
        ' <*** Funciones para manejo de elementos del form **********>
        ' ###########################################################

        Public Function ComprobarCheck(ByVal CajaCheck As CheckBox) As Boolean
            Try
                If CajaCheck.CheckState = CheckState.Checked Then
                    ComprobarCheck = True
                Else
                    ComprobarCheck = False
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                ComprobarCheck = False
                Exit Function
            End Try
        End Function

        Public Sub PonerCheck(ByVal CajaCheck As CheckBox, ByVal Valor As Boolean)
            Try
                If Valor = True Then
                    CajaCheck.CheckState = CheckState.Checked
                Else
                    CajaCheck.CheckState = CheckState.Unchecked
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub


        ' ###########################################################
        ' <*** Funciones para manejo del inicio **********>
        ' ###########################################################

        Public Function ExecComandos(ByVal LineaComandos As String) As Boolean
            Try
                Dim mostrar As Boolean
                LineaComandos = UCase(LineaComandos)
                If LineaComandos = "/RYC" Then
                    Crono.Esperar(1000)
                    TD_Principal.EjecutarComandos()
                    While Not TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaInternet
                        Crono.Esperar(100)
                    End While
                    TD_Principal.Close()
                    mostrar = True
                ElseIf LineaComandos = "/RYCS" Then
                    TD_Principal.IrATray()
                    Crono.Esperar(1000)
                    TD_Principal.EjecutarComandos()
                    While Not TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaInternet
                        Crono.Esperar(100)
                    End While
                    TD_Principal.Close()
                    mostrar = False
                ElseIf LineaComandos = "/RENOVAR" Then
                    Crono.Esperar(3000)
                    TD_Principal.EjecutarComandos()
                    mostrar = False
                ElseIf LineaComandos = "/CERRAR" Then
                    TD_Principal.Close()
                    mostrar = False
                ElseIf LineaComandos = "/TRAY" Then
                    TD_Principal.IrATray()
                    mostrar = False
                Else
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_ComandoBad") & LineaComandos & UniDlxVars.Traduccion("Error_ComandoBadFin"))
                    mostrar = False
                End If
                Return mostrar
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Function
            End Try
        End Function
    End Class
End Namespace