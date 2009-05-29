namespace hz.sms.DBUtility
{
    using System;
    using System.Data;

    public interface IDataAccess:IDisposable
    {
        void Close();
        DataSet ExecuteDataSet(IDbCommand command);
        DataSet ExecuteDataSet(string commandText);
        DataSet ExecuteDataSet(string commandText, CommandType commandType);
        DataSet ExecuteDataSet(string commandText, IDataParameter[] parameters);
        DataSet ExecuteDataSet(string commandText, CommandType commandType, IDataParameter[] parameters);
        int ExecuteNonQuery(IDbCommand command);
        int ExecuteNonQuery(string commandText);
        int ExecuteNonQuery(string commandText, CommandType commandType);
        int ExecuteNonQuery(string commandText, IDataParameter[] parameters);
        int ExecuteNonQuery(string commandText, CommandType commandType, IDataParameter[] parameters);
        IDataReader ExecuteReader(IDbCommand command);
        IDataReader ExecuteReader(string commandText);
        IDataReader ExecuteReader(string commandText, CommandType commandType);
        IDataReader ExecuteReader(string commandText, IDataParameter[] parameters);
        IDataReader ExecuteReader(string commandText, CommandType commandType, IDataParameter[] parameters);
        object ExecuteScalar(IDbCommand command);
        object ExecuteScalar(string commandText);
        object ExecuteScalar(string commandText, CommandType commandType);
        object ExecuteScalar(string commandText, IDataParameter[] parameters);
        object ExecuteScalar(string commandText, CommandType commandType, IDataParameter[] parameters);
        void FillDataSet(IDbCommand command, DataSet dataSet, string[] tableNames);
        void FillDataSet(string commandText, CommandType commandType, DataSet dataSet);
        void FillDataSet(string commandText, CommandType commandType, DataSet dataSet, string[] tableNames);
        void FillDataSet(string commandText, CommandType commandType, IDataParameter[] parameters, DataSet dataSet);
        void FillDataSet(string commandText, CommandType commandType, IDataParameter[] parameters, DataSet dataSet, string[] tableNames);

        string CommandText { get; }

        string ConnectionString { get; }
    }
}

