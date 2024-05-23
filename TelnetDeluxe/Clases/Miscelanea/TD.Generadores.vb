Option Strict On
Option Explicit On
Namespace Deluxe
    ' Generales
    Public Delegate Sub ConexionCambiadaEventHandler(ByVal sender As Object, ByVal e As ArgumentosConexion)
    Public Delegate Sub MostrarErrorEventHandler(ByVal sender As Object, ByVal e As ArgumentosError)
    Public Delegate Sub RouterDesconectadoEventHandler(ByVal sender As Object, ByVal e As ConexionEventArgs)
    Public Delegate Sub RouterConectadoEventHandler(ByVal sender As Object, ByVal e As ConexionEventArgs)
    Public Delegate Sub ReportarProgresoEventHandler(ByVal sender As Object, ByVal e As ReportarProgresoEventArgs)


    ' Informaciones para el progreso
    Public Delegate Sub ComponentesProgresoEventHandler(ByVal sender As Object, ByVal e As ArgumentosComponentesProgreso)

    ' Mensajes
    Public Delegate Sub MensajeDisponibleEventHandler(ByVal sender As Object, ByVal e As MensajeDisponibleEventArgs)
    Public Delegate Sub NuevaIPDisponibleEventHandler(ByVal sender As Object, ByVal e As NuevaIPDisponibleEventArgs)

    ' Sección para el DScanner
    Public Delegate Sub DScanner_ProgresoEventHandler(ByVal sender As Object, ByVal e As ArgumentosComponentesProgreso)
    Public Delegate Sub DScanner_NuevaIPEscaneadaEventHandler(ByVal sender As Object, ByVal e As NuevaIPEscaneadaEventArgs)
    Public Delegate Sub DScanner_ProcesoComenzadoEventHandler(ByVal sender As Object, ByVal e As ArgumentosProcesoDeluxe)
    Public Delegate Sub DScanner_ProcesoAcabadoEventHandler(ByVal sender As Object, ByVal e As ArgumentosProcesoDeluxe)
    Public Delegate Sub DScanner_ProcesoCanceladoEventHandler(ByVal sender As Object, ByVal e As ArgumentosProcesoDeluxe)


    Public Class ArgumentosConexion
        Inherits EventArgs
        Private conx As Estructuras.Conexion

        Public Sub New(ByVal tmpconx As Estructuras.Conexion)
            conx = tmpconx
        End Sub

        Public ReadOnly Property PConexion() As Estructuras.Conexion
            Get
                Return Me.conx
            End Get
        End Property
    End Class

    Public Class ArgumentosError
        Inherits EventArgs
        Private dlxerror As String

        Public Sub New(ByVal errtmp As String)
            dlxerror = errtmp
        End Sub

        Public ReadOnly Property Mensaje() As String
            Get
                Return dlxerror
            End Get
        End Property
    End Class









    Public Class NuevaIPDisponibleEventArgs
        Inherits EventArgs
        Private m_DirIP As String = ""

        Public Sub New(ByVal IPActual As String)
            m_DirIP = IPActual
        End Sub

        Public ReadOnly Property DirIP() As String
            Get
                Return Me.m_DirIP
            End Get
        End Property
    End Class

    Public Class NuevaIPEscaneadaEventArgs
        Inherits EventArgs
        Private s_DirIP As String = ""
        Private b_IPOnline As Boolean = False

        Public Sub New(ByVal tmp_IP As String, ByVal tmp_Online As Boolean)
            s_DirIP = tmp_IP
            b_IPOnline = tmp_Online
        End Sub

        Public ReadOnly Property IP_Direccion() As String
            Get
                Return Me.s_DirIP
            End Get
        End Property

        Public ReadOnly Property IP_Online() As Boolean
            Get
                Return Me.b_IPOnline
            End Get
        End Property


    End Class


    Public Class ReportarProgresoEventArgs
        Inherits EventArgs
        Private m_Progreso As Integer = 0
        Private m_InfoProgreso As String = ""

        Public Sub New(ByVal Progreso As Integer, Optional ByVal InfoProgreso As String = "")
            If Progreso <> -1 Then
                m_Progreso = Progreso
            End If
            If InfoProgreso <> "" Then
                m_InfoProgreso = InfoProgreso
            End If
        End Sub

        Public ReadOnly Property Progreso() As Integer
            Get
                Return Me.m_Progreso
            End Get
        End Property

        Public ReadOnly Property InfoProgreso() As String
            Get
                Return Me.m_InfoProgreso
            End Get
        End Property

    End Class


    Public Class ArgumentosComponentesProgreso
        Inherits EventArgs
        Private InfoProgreso As Estructuras.ComponentesProgreso

        Public Sub New(ByVal Progreso As Estructuras.ComponentesProgreso)
            InfoProgreso = Progreso
        End Sub

        Public ReadOnly Property Progreso() As Estructuras.ComponentesProgreso
            Get
                Return Me.InfoProgreso
            End Get
        End Property

    End Class

    Public Class ArgumentosProcesoDeluxe
        Inherits EventArgs
        Private PD As Estructuras.ProcesoDeluxe

        Public Sub New(ByVal PDlx As Estructuras.ProcesoDeluxe)
            PD = PDlx
        End Sub

        Public ReadOnly Property ProcesoInfo() As Estructuras.ProcesoDeluxe
            Get
                Return Me.PD
            End Get
        End Property
    End Class


    Public Class ConexionEventArgs
        Inherits EventArgs
        Private m_MensajeError As String

        Public Sub New(Optional ByVal message As String = "")
            Me.m_MensajeError = message
        End Sub

        Public ReadOnly Property MensajeError() As String
            Get
                Return Me.m_MensajeError
            End Get
        End Property
    End Class



    Public Class MensajeDisponibleEventArgs
        Inherits EventArgs
        Private m_mensaje As String
        Private m_tipo As Deluxe.Estructuras.MensajeConsola

        Public Sub New(Optional ByVal Mensaje As String = "", Optional ByVal TipoMensaje As Deluxe.Estructuras.MensajeConsola = Deluxe.Estructuras.MensajeConsola.MSG_Defecto)
            m_mensaje = Mensaje
            m_tipo = TipoMensaje
        End Sub

        Public ReadOnly Property Mensaje() As String
            Get
                Return Me.m_mensaje
            End Get
        End Property

        Public ReadOnly Property TipoMensaje() As Deluxe.Estructuras.MensajeConsola
            Get
                Return Me.m_tipo
            End Get
        End Property

    End Class
End Namespace
