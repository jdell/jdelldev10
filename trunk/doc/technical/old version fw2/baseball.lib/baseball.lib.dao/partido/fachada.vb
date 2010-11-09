Namespace partido
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.Partido)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getAllByCompeticion(ByVal competicion As vo.Competicion) As List(Of baseball.lib.vo.Partido)
            Try
                Dim action As New action.getAllByCompeticion(competicion)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal partidoVO As baseball.lib.vo.Partido, ByVal full As Boolean) As baseball.lib.vo.Partido
            Try
                Dim action As New action.get(partidoVO, full)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal partidoVO As baseball.lib.vo.Partido) As Boolean
            Try
                Dim action As New action.checkIfExists(partidoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal partidoVO As baseball.lib.vo.Partido) As baseball.lib.vo.Partido
            Try
                Dim action As New action.add(partidoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal partidoVO As baseball.lib.vo.Partido) As baseball.lib.vo.Partido
            Try
                Dim action As New action.update(partidoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal partidoVO As baseball.lib.vo.Partido) As Boolean
            Try
                Dim action As New action.remove(partidoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace