Namespace hojaanotacioncatcher
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.HojaAnotacionCatcher)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal hojaanotacioncatcherVO As baseball.lib.vo.HojaAnotacionCatcher) As baseball.lib.vo.HojaAnotacionCatcher
            Try
                Dim action As New action.get(hojaanotacioncatcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal hojaanotacioncatcherVO As baseball.lib.vo.HojaAnotacionCatcher) As Boolean
            Try
                Dim action As New action.checkIfExists(hojaanotacioncatcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal hojaanotacioncatcherVO As baseball.lib.vo.HojaAnotacionCatcher) As baseball.lib.vo.HojaAnotacionCatcher
            Try
                Dim action As New action.add(hojaanotacioncatcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal hojaanotacioncatcherVO As baseball.lib.vo.HojaAnotacionCatcher) As baseball.lib.vo.HojaAnotacionCatcher
            Try
                Dim action As New action.update(hojaanotacioncatcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal hojaanotacioncatcherVO As baseball.lib.vo.HojaAnotacionCatcher) As Boolean
            Try
                Dim action As New action.remove(hojaanotacioncatcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace