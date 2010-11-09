Namespace _common.secciones
    Public Class PISection
        Inherits section

        Private _servidor As String
        Private _FOE As Integer
        Private _formula As String
        Private _fuelGasBens As String
        Private _fuelGasTurbina As String
        Private _fuelGasHornos As String
        Private _fuelOilBens As String

        Public Sub New()
            Me._name = "PI"
            Me._servidor = "sslcg04PI"
            Me._FOE = 25
            Me._formula = "$valorTM$ * $valorPI$ / (9590 * 0.0041868)"
            Me._fuelGasBens = "050FG0PC"
            Me._fuelGasHornos = "050FG2PC"
            Me._fuelGasTurbina = "050FG1PC"
            Me._fuelOilBens = "050FO0PC"
        End Sub

        Public Property Servidor() As String
            Get
                Return _servidor
            End Get
            Set(ByVal value As String)
                _servidor = value
            End Set
        End Property

        Public Property FOE() As Integer
            Get
                Return _FOE
            End Get
            Set(ByVal value As Integer)
                _FOE = value
            End Set
        End Property

        Public Property Formula() As String
            Get
                Return _formula
            End Get
            Set(ByVal value As String)
                _formula = value
            End Set
        End Property

        Public Property FuelGasBens() As String
            Get
                Return _fuelGasBens
            End Get
            Set(ByVal value As String)
                _fuelGasBens = value
            End Set
        End Property

        Public Property FuelGasHornos() As String
            Get
                Return _fuelGasHornos
            End Get
            Set(ByVal value As String)
                _fuelGasHornos = value
            End Set
        End Property

        Public Property FuelGasTurbina() As String
            Get
                Return _fuelGasTurbina
            End Get
            Set(ByVal value As String)
                _fuelGasTurbina = value
            End Set
        End Property

        Public Property FuelOilBens() As String
            Get
                Return _fuelOilBens
            End Get
            Set(ByVal value As String)
                _fuelOilBens = value
            End Set
        End Property

        Public Function EvalFormula(ByVal valorTM As Single, ByVal valorPI As Single) As Single
            Dim res As Single = 0

            Dim expresion As String = Me.Formula
            expresion = expresion.Replace("$valorTM$", valorTM)
            expresion = expresion.Replace("$valorPI$", valorPI)

            res = baseball.lib.common.funciones.Eval.execute(expresion)

            Return res
        End Function


        ''' <summary>
        ''' Indica sin un tag indicado es un tag a tener en cuenta o no
        ''' </summary>
        ''' <param name="tag">tag a evaluar</param>
        ''' <returns>resultado de la evaluación</returns>
        ''' <remarks>
        ''' Los tags deberían almacenarse en una lista. Se almacenan así -en propiedades- por falta de tiempo y restricciones del XML.
        ''' La version 2.0 del mismo debería permitirlo.
        ''' </remarks>
        Public Function IsTag(ByVal tag As String) As Boolean
            Return _
             (FuelGasBens.Trim.CompareTo(tag.Trim) = 0) OrElse _
             (FuelGasHornos.Trim.CompareTo(tag.Trim) = 0) OrElse _
             (FuelGasTurbina.Trim.CompareTo(tag.Trim) = 0) OrElse _
             (FuelOilBens.Trim.CompareTo(tag.Trim) = 0)
        End Function

    End Class
End Namespace


