using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Krystalware.SlickUpload.Configuration;
using Krystalware.SlickUpload.Streams;

public class RepositoryFileCS
{
    static string _cnString;
    static string _table;
    static string _keyField;
    static string _nameField;
    static string _dataField;
    
    int _id;
    string _name;
    long _length;

    public int Id
    {
        get
        {
            return _id;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public long Length
    {
        get
        {
            return _length;
        }
    }

    static RepositoryFileCS()
    {
        NameValueConfigurationSection section = SlickUploadConfiguration.UploadStreamProvider;

        string connectionStringName = section["connectionStringName"];

        if (!string.IsNullOrEmpty(connectionStringName))
            _cnString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        else
            _cnString = section["connectionString"];

        _table = section["table"];
        _keyField = section["keyField"];
        _nameField = section["fileNameField"];
        _dataField = section["dataField"];
    }

    public RepositoryFileCS(int id, string name, long length)
    {
        _id = id;
        _name = name;
        _length = length;
    }

    public Stream GetDataStream()
    {
        return new SqlClientOutputStream(_cnString, _table, _dataField, _keyField, _id);
    }

    public static List<RepositoryFileCS> GetAll()
    {        
        List<RepositoryFileCS> files = new List<RepositoryFileCS>();

        using (IDbConnection cn = new SqlConnection(_cnString))
        using (IDbCommand cmd = cn.CreateCommand())
        {
            cmd.CommandText = "SELECT " + _keyField + ", " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table;

            cn.Open();

            using (IDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                while (rd.Read())
                {
                    files.Add(new RepositoryFileCS(rd.GetInt32(0), rd.GetString(1), rd.GetInt64(2)));
                }
            }
        }

        return files;
    }

    public static RepositoryFileCS GetById(int id)
    {
        using (IDbConnection cn = new SqlConnection(_cnString))
        using (IDbCommand cmd = cn.CreateCommand())
        {
            cmd.CommandText = "SELECT " + _nameField + ", CAST(DATALENGTH(" + _dataField + ") AS bigint) AS Length FROM " + _table + " WHERE " + _keyField + "=" + id.ToString();

            cn.Open();

            using (IDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleRow))
            {
                if (rd.Read())
                {
                    return new RepositoryFileCS(id, rd.GetString(0), rd.GetInt64(1));
                }
                else
                {
                    return null;
                }
            }
        }
    }
}