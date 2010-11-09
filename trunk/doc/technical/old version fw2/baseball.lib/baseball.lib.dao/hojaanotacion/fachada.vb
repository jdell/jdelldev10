Namespace hojaanotacion
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.HojaAnotacion)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function [get](ByVal hojaanotacionVO As baseball.lib.vo.HojaAnotacion) As baseball.lib.vo.HojaAnotacion
            Try
                Dim action As New action.get(hojaanotacionVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal hojaanotacionVO As baseball.lib.vo.HojaAnotacion) As Boolean
            Try
                Dim action As New action.checkIfExists(hojaanotacionVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal hojaanotacionVO As baseball.lib.vo.HojaAnotacion) As baseball.lib.vo.HojaAnotacion
            Try
                Dim action As New action.add(hojaanotacionVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal hojaanotacionVO As baseball.lib.vo.HojaAnotacion) As baseball.lib.vo.HojaAnotacion
            Try
                Dim action As New action.update(hojaanotacionVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal hojaanotacionVO As baseball.lib.vo.HojaAnotacion) As Boolean
            Try
                Dim action As New action.remove(hojaanotacionVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace