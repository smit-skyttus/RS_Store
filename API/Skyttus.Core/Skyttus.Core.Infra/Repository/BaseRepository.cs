using FastMember;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Skyttus.Core.Infra.Repository
{
    public abstract class BaseRepository
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
            => (_context) = (context);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map) where T : new()
        {
            using (var context = _context)
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }

                        return entities;
                    }
                }
            }
        }

        public DataTable RawSqlQuery(string query)
        {
            //using (var context = _context)
            //{
            //var dbConnection = context.Database.GetDbConnection();
            SqlConnection dbConnection = new SqlConnection(_context.Database.GetConnectionString());
            SqlCommand command = dbConnection.CreateCommand();

            command.CommandText = query;
            command.CommandType = CommandType.Text;

            command.Connection.Open();

            DataTable dt = new DataTable();
            var da = new SqlDataAdapter(command);
            da.Fill(dt);

            command.Connection.Close();
            command.Dispose();
            return dt;
            //}
        }

        public DataTable RawSqlQueryWithParameters(string query, List<SqlParameter> sqlParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = query,
                    Connection = connection,
                    CommandType = commandType,
                };


                /// Un-comment below for loop once we pass parameter to Store Procedure from UI.
                foreach (var param in sqlParameters)
                {
                    cmd.Parameters.Add(param);
                    //cmd.CommandTimeout = 500;
                }

                cmd.CommandTimeout = 0;

                DataTable Dt = new DataTable();

                cmd.Connection.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(Dt);

                cmd.Connection.Close();
                cmd.Dispose();
                return Dt;
            }
        }
        public DataSet RawSqlQueryForMultipleResultWithParameter(string query, List<SqlParameter> sqlParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = query,
                    Connection = connection,
                    CommandType = commandType,
                };
                /// Un-comment below for loop once we pass parameter to Store Procedure from UI.
                foreach (var param in sqlParameters)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.CommandTimeout = 0;
                cmd.Connection.Open();
                DataSet ds = new DataSet();
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                cmd.Connection.Close();
                cmd.Dispose();
                return ds;
            }
        }

        public DataSet RawSqlQueryForMultipleResult(string query)
        {
            //using (var context = _context)
            //{
            //var dbConnection = context.Database.GetDbConnection();
            SqlConnection dbConnection = new SqlConnection(_context.Database.GetConnectionString());
            SqlCommand command = dbConnection.CreateCommand();

            command.CommandText = query;
            command.CommandType = CommandType.Text;

            command.Connection.Open();

            DataSet ds = new DataSet();
            var da = new SqlDataAdapter(command);
            da.Fill(ds);

            command.Connection.Close();
            command.Dispose();
            return ds;
            //}
        }

        public void DirectBulkCopy<T>(List<T> entities, string[] copyParameters, string destinationTableName)
        {
            var connectionString = _context.Database.GetConnectionString();
            
            using (var sqlCopy = new SqlBulkCopy(connectionString))
            {
                sqlCopy.DestinationTableName = destinationTableName;
                sqlCopy.BatchSize = 1000;
                
                using(var reader = ObjectReader.Create(entities, copyParameters))
                {
                    sqlCopy.WriteToServer(reader);
                }
            }
        }
        public void DirectBulkCopy<T>(List<T> entities, string[] copyParameters, string destinationTableName,string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var bulkCopy = new SqlBulkCopy(connection)
                {
                    DestinationTableName = destinationTableName,
                    BatchSize = 1000
                };
                using (var reader = ObjectReader.Create(entities, copyParameters))
                {
                    bulkCopy.WriteToServer(reader);
                }
                bulkCopy.Close();
            }
        }
        public void DirectBulkCopy<T>(DataTable dt, string destinationTableName)
        {
            var connectionString = _context.Database.GetConnectionString();

            using (var sqlCopy = new SqlBulkCopy(connectionString))
            {
                sqlCopy.DestinationTableName = destinationTableName;
                sqlCopy.BatchSize = 1000;
                sqlCopy.WriteToServer(dt);
            }
        }

        public void ExecuteQuery(string query,string destinationTable,string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText=query;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
                connection.Close();
            }
        }
    }
}
