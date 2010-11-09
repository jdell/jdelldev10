Namespace jugador
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.Jugador)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal jugadorVO As baseball.lib.vo.Jugador) As baseball.lib.vo.Jugador
            Try
                Dim action As New action.get(jugadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal jugadorVO As baseball.lib.vo.Jugador) As Boolean
            Try
                Dim action As New action.checkIfExists(jugadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal jugadorVO As baseball.lib.vo.Jugador) As baseball.lib.vo.Jugador
            Try
                Dim action As New action.add(jugadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal jugadorVO As baseball.lib.vo.Jugador) As baseball.lib.vo.Jugador
            Try
                Dim action As New action.update(jugadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal jugadorVO As baseball.lib.vo.Jugador) As Boolean
            Try
                Dim action As New action.remove(jugadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace