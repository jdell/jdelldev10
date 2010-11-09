Namespace hojaanotacionplayer
    Public Class fachada
        Inherits _common.facade

        Public Function getAll() As List(Of baseball.lib.vo.HojaAnotacionPlayer)
            Try
                Dim action As New action.getAll
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function [get](ByVal hojaanotacionplayerVO As baseball.lib.vo.HojaAnotacionPlayer) As baseball.lib.vo.HojaAnotacionPlayer
            Try
                Dim action As New action.get(hojaanotacionplayerVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function checkIfExists(ByVal hojaanotacionplayerVO As baseball.lib.vo.HojaAnotacionPlayer) As Boolean
            Try
                Dim action As New action.checkIfExists(hojaanotacionplayerVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function add(ByVal hojaanotacionplayerVO As baseball.lib.vo.HojaAnotacionPlayer) As baseball.lib.vo.HojaAnotacionPlayer
            Try
                Dim action As New action.add(hojaanotacionplayerVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function update(ByVal hojaanotacionplayerVO As baseball.lib.vo.HojaAnotacionPlayer) As baseball.lib.vo.HojaAnotacionPlayer
            Try
                Dim action As New action.update(hojaanotacionplayerVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function remove(ByVal hojaanotacionplayerVO As baseball.lib.vo.HojaAnotacionPlayer) As Boolean
            Try
                Dim action As New action.remove(hojaanotacionplayerVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

    End Class
End Namespace