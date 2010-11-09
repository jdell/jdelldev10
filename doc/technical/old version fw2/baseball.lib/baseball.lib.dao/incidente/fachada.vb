
Imports gesInef.lib.vo
Namespace equipo
    Public Class fachada
        Inherits _common.facade

        Public Function Seleccionarequipos() As baseball.lib.vo.Equipo()
            Try
                Dim action As New Action.GetequiposAction
                Return _common.Plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function SeleccionarequiposPorAreasUsuario(ByVal usuario As gesInef.lib.vo.usuario.UsuarioVO) As baseball.lib.vo.Equipo()
            Try
                Dim action As New Action.GetequiposByAreasUsuarioAction(usuario)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function Seleccionarequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As baseball.lib.vo.Equipo
            Try
                Dim action As New Action.GetequipoAction(equipoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Insertarequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As Object
            Try
                Dim action As New Action.AddequipoAction(equipoVO)
                Return _common.Plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function Actualizarequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As Object
            Try
                Dim action As New Action.UpdequipoAction(equipoVO)
                Return _common.Plain.PlainActionProcessor.process(factory, action)

            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function
        Public Function ActualizarequipoCab(ByVal equipoVO As baseball.lib.vo.Equipo) As Object
            Try
                Dim action As New Action.UpdequipoCabAction(equipoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New Exception("Código repetido [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function Borrarequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As Object
            Try
                Dim action As New Action.DelequipoAction(equipoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New Exception("Código en uso [" + Convert.ToString(ex.ObjKey) + "]. Operación cancelada.", ex)
            Catch ex As repsol.exceptions.InternalErrorException
                Throw ex
            End Try
        End Function

        Public Function SeleccionarFicherosequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As String()
            Try
                Dim action As New Action.GetFicherosequipoAction(equipoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function PuedeCerrarequipo(ByVal equipoVO As baseball.lib.vo.Equipo) As Boolean
            Try
                Dim action As New Action.CanCloseequipoAction(equipoVO)
                Return _common.plain.PlainActionProcessor.process(factory, action)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace