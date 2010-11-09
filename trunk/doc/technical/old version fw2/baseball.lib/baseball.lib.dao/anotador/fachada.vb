Namespace anotador
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.Anotador)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal anotadorVO As baseball.lib.vo.Anotador) As baseball.lib.vo.Anotador
            Try
                Dim action As New action.get(anotadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal anotadorVO As baseball.lib.vo.Anotador) As Boolean
            Try
                Dim action As New action.checkIfExists(anotadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal anotadorVO As baseball.lib.vo.Anotador) As baseball.lib.vo.Anotador
            Try
                Dim action As New action.add(anotadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal anotadorVO As baseball.lib.vo.Anotador) As baseball.lib.vo.Anotador
            Try
                Dim action As New action.update(anotadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal anotadorVO As baseball.lib.vo.Anotador) As Boolean
            Try
                Dim action As New action.remove(anotadorVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace