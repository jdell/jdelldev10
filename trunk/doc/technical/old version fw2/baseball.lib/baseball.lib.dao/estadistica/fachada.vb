Namespace estadistica
    Public Class fachada
        Inherits _common.facade

        Public Function getAllForBaseRunning(ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaBaseRunning)
            Try
                Dim action As New action.getAllForBaseRunning(filtro)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getAllForBatting(ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaBatting)
            Try
                Dim action As New action.getAllForBatting(filtro)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getAllForCatcher(ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaCatcher)
            Try
                Dim action As New action.getAllForCatcher(filtro)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getAllForFielding(ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaFielding)
            Try
                Dim action As New action.getAllForFielding(filtro)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getAllForPitcher(ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaPitcher)
            Try
                Dim action As New action.getAllForPitcher(filtro)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace