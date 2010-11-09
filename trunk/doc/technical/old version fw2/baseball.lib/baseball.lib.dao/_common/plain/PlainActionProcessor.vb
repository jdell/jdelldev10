Namespace _common.plain

    Friend NotInheritable Class PlainActionProcessor

        Public Sub New()

        End Sub

        Friend Shared Function process(ByVal factory As _common.DAOFactory, ByVal action As NonTransactionalPlainAction) As Object

            Dim connection As IDbConnection = Nothing
            Try
                connection = factory.Connection
                connection.Open()

                factory.Command = connection.CreateCommand

                Return action.execute(factory)

            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Function

        Friend Shared Function process(ByVal factory As _common.DAOFactory, ByVal action As TransactionalPlainAction) As Object
            Dim boolCommited As Boolean = False
            Dim connection As IDbConnection = Nothing
            Dim transaction As IDbTransaction = Nothing

            Try

                connection = factory.Connection
                connection.Open()

                factory.Command = connection.CreateCommand
                transaction = connection.BeginTransaction(IsolationLevel.Serializable)
                factory.Command.Transaction = transaction

                Dim result As Object
                result = action.execute(factory)

                transaction.Commit()
                boolCommited = True

                Return result

            Catch ex As Exception
                Throw ex
            Finally
                Try
                    If Not (transaction.Connection Is Nothing) Then
                        If Not boolCommited Then
                            transaction.Rollback()
                        End If
                    End If
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Try
        End Function

        'Friend Shared Function process(ByVal factory As _common.DAOFactory, ByVal action As TransactionalPlainAction()) As Object
        '    Dim boolCommited As Boolean = False
        '    Dim connection As IDbConnection = Nothing
        '    Dim transaction As IDbTransaction = Nothing

        '    Try

        '        connection = factory.Connection
        '        connection.Open()

        '        factory.Command = connection.CreateCommand
        '        transaction = connection.BeginTransaction(IsolationLevel.Serializable)
        '        factory.Command.Transaction = transaction

        '        Dim result As Object
        '        For i As Integer = 0 To action.Length - 1
        '            result = action(i).execute(factory)
        '        Next

        '        transaction.Commit()
        '        boolCommited = True

        '        Return result

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Try
        '            If Not (transaction.Connection Is Nothing) Then
        '                If Not boolCommited Then
        '                    transaction.Rollback()
        '                End If
        '                connection.Close()
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
        '    End Try
        'End Function
    End Class
End Namespace