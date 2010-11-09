Imports System.Data.Common
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace _common

    Friend Class DAOFactory
        Protected _factory As DbProviderFactory
        Protected _connection As DbConnection
        Protected _command As DbCommand

        Protected _dataadapter As DbDataAdapter

        Public Sub New()
            Try
                Dim con As repsol.util.config.connections.connection = repsol.util.config.connections.connection.getConnectionSetting(baseball.lib.common.variables.configpath.GetFullPath, tCONEXION.baseball.ToString)

                Me._factory = DbProviderFactories.GetFactory(con.ProviderName)
                Me._connection = Me._factory.CreateConnection
                Me._connection.ConnectionString = repsol.crypto.tripleDES.descifrar(New repsol.crypto.byteBlock(repsol.crypto.byteBlock.parse(con.ConnectionString)))
                Me._command = Me._factory.CreateCommand
                Me._command.Connection = Me._connection
                Me._dataadapter = Me._factory.CreateDataAdapter
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub New(ByVal connectionType As tCONEXION)
            Try
                Dim connectionName As String = connectionType.ToString

                Dim con As repsol.util.config.connections.connection = repsol.util.config.connections.connection.getConnectionSetting(baseball.lib.common.variables.configpath.GetFullPath, connectionName)

                Me._factory = DbProviderFactories.GetFactory(con.ProviderName)
                Me._connection = Me._factory.CreateConnection
                Me._connection.ConnectionString = repsol.crypto.tripleDES.descifrar(New repsol.crypto.byteBlock(repsol.crypto.byteBlock.parse(con.ConnectionString)))
                Me._command = Me._factory.CreateCommand
                Me._command.Connection = Me._connection
                Me._dataadapter = Me._factory.CreateDataAdapter
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Property Command() As DbCommand
            Get
                Return Me._command
            End Get
            Set(ByVal value As DbCommand)
                Me._command = value
            End Set
        End Property

        Public Property Connection() As DbConnection
            Get
                Return Me._connection
            End Get
            Set(ByVal value As DbConnection)
                Me._connection = value
            End Set
        End Property

        Public Property DataAdapter() As DbDataAdapter
            Get
                Return Me._dataadapter
            End Get
            Set(ByVal value As DbDataAdapter)
                Me._dataadapter = value
            End Set
        End Property

    End Class
End Namespace
