Namespace hojaanotacionpitcher
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.HojaAnotacionPitcher)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal hojaanotacionpitcherVO As baseball.lib.vo.HojaAnotacionPitcher) As baseball.lib.vo.HojaAnotacionPitcher
            Try
                Dim action As New action.get(hojaanotacionpitcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal hojaanotacionpitcherVO As baseball.lib.vo.HojaAnotacionPitcher) As Boolean
            Try
                Dim action As New action.checkIfExists(hojaanotacionpitcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal hojaanotacionpitcherVO As baseball.lib.vo.HojaAnotacionPitcher) As baseball.lib.vo.HojaAnotacionPitcher
            Try
                Dim action As New action.add(hojaanotacionpitcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal hojaanotacionpitcherVO As baseball.lib.vo.HojaAnotacionPitcher) As baseball.lib.vo.HojaAnotacionPitcher
            Try
                Dim action As New action.update(hojaanotacionpitcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal hojaanotacionpitcherVO As baseball.lib.vo.HojaAnotacionPitcher) As Boolean
            Try
                Dim action As New action.remove(hojaanotacionpitcherVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace