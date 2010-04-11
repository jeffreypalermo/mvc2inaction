Imports Microsoft.VisualBasic
Imports Krystalware.SlickUpload.Configuration
Imports Krystalware.SlickUpload.Streams
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class RepositoryFileVB
    Private Shared _cnString As String
    Private Shared _table As String
    Private Shared _keyField As String
    Private Shared _nameField As String
    Private Shared _dataField As String

    Private _id As Integer
    Private _name As String
    Private _length As Long

    Public ReadOnly Property Id() As Integer
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Length() As Long
        Get
            Return _length
        End Get
    End Property

    Shared Sub New()
        Dim section As NameValueConfigurationSection = SlickUploadConfiguration.UploadStreamProvider

        Dim connectionStringName As String = section("connectionStringName")

        If Not String.IsNullOrEmpty(connectionStringName) Then
            _cnString = ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString
        Else
            _cnString = section("connectionString")
        End If

        _table = section("table")
        _keyField = section("keyField")
        _nameField = section("fileNameField")
        _dataField = section("dataField")
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal length As Long)
        _id = id
        _name = name
        _length = length
    End Sub

    Public Function GetDataStream() As Stream
        Return New SqlClientOutputStream(_cnString, _table, _dataField, _keyField, _id)
    End Function

    Public Shared Function GetAll() As List(Of RepositoryFileVB)
        Dim files As List(Of RepositoryFileVB) = New List(Of RepositoryFileVB)()

        Using cn As IDbConnection = New SqlConnection(_cnString)
            Using cmd As IDbCommand = cn.CreateCommand()
                cmd.CommandText = "SELECT " + _keyField + ", " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table

                cn.Open()

                Using rd As IDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
                    While (rd.Read())
                        files.Add(New RepositoryFileVB(rd.GetInt32(0), rd.GetString(1), rd.GetInt64(2)))
                    End While
                End Using
            End Using
        End Using

        Return files
    End Function

    Public Shared Function GetById(ByVal id As Integer) As RepositoryFileVB
        Using cn As IDbConnection = New SqlConnection(_cnString)
            Using cmd As IDbCommand = cn.CreateCommand()
                cmd.CommandText = "SELECT " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table + " WHERE " + _keyField + "=" + id.ToString()

                cn.Open()

                Using rd As IDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                    If rd.Read() Then
                        Return New RepositoryFileVB(id, rd.GetString(0), rd.GetInt64(1))
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        End Using
    End Function
End Class
