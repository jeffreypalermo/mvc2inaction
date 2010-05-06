Imports Microsoft.VisualBasic
Imports Krystalware.SlickUpload.Configuration
Imports Krystalware.SlickUpload.Streams
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Namespace SqlClient
    Public Class RepositoryFile
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

        Shared Sub Initialize()
            If _cnString Is Nothing OrElse _cnString.Length = 0 Then
                Dim section As NameValueConfigurationSection = SlickUploadConfiguration.UploadStreamProvider

                _cnString = section("connectionString")

                _table = section("table")
                _keyField = section("keyField")
                _nameField = section("fileNameField")
                _dataField = section("dataField")
            End If
        End Sub

        Public Sub New(ByVal id As Integer, ByVal name As String, ByVal length As Long)
            Initialize()

            _id = id
            _name = name
            _length = length
        End Sub

        Public Function GetDataStream() As Stream
            Initialize()

            Return New SqlClientOutputStream(_cnString, _table, _dataField, _keyField, _id)
        End Function

        Public Shared Function GetAll() As ArrayList
            Initialize()

            Dim files As ArrayList = New ArrayList

            Dim cn As IDbConnection
            Dim cmd As IDbCommand

            Try
                cn = New SqlConnection(_cnString)
                cmd = cn.CreateCommand()

                cmd.CommandText = "SELECT " + _keyField + ", " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table

                cn.Open()

                Dim rd As IDataReader

                Try
                    rd = cmd.ExecuteReader(CommandBehavior.SingleResult)
                    While (rd.Read())
                        files.Add(New RepositoryFile(rd.GetInt32(0), rd.GetString(1), rd.GetInt64(2)))
                    End While
                Finally
                    If Not rd Is Nothing Then
                        rd.Dispose()
                    End If
                End Try
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                End If

                If Not cn Is Nothing Then
                    cn.Dispose()
                End If
            End Try

            Return files
        End Function

        Public Shared Function GetById(ByVal id As Integer) As RepositoryFile
            Initialize()

            Dim cn As IDbConnection
            Dim cmd As IDbCommand

            Try
                cn = New SqlConnection(_cnString)
                cmd = cn.CreateCommand()
                cmd.CommandText = "SELECT " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table + " WHERE " + _keyField + "=" + id.ToString()

                cn.Open()

                Dim rd As IDataReader

                Try
                    rd = cmd.ExecuteReader(CommandBehavior.SingleRow)
                    If rd.Read() Then
                        Return New RepositoryFile(id, rd.GetString(0), rd.GetInt64(1))
                    Else
                        Return Nothing
                    End If
                Finally
                    If Not rd Is Nothing Then
                        rd.Dispose()
                    End If
                End Try
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                End If

                If Not cn Is Nothing Then
                    cn.Dispose()
                End If
            End Try
        End Function
    End Class
End Namespace