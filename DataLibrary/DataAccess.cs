using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);
                return rows.ToList();
            }
        }

        //public Task SaveData<T>(string sql, T parameters, string connectionStrings)
        //{
        //    using (IDbConnection connection = new MySqlConnection(connectionStrings))
        //    {
        //        return connection.ExecuteAsync(sql, parameters);
        //    }
        //}


        public async Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sql, parameters);
                }
            }
            catch (MySqlException ex) // Handle MySQL-specific exceptions
            {
                // Log the exception or handle it in some way
                // You can also throw a custom exception with a user-friendly message
                // Example:
                // throw new CustomDatabaseException("Error saving data to the database", ex);
            }
            catch (Exception ex) // Handle general exceptions
            {
                // Log the exception or handle it in some way
                // You can also throw a custom exception with a user-friendly message
                // Example:
                // throw new CustomException("An unexpected error occurred", ex);
            }
        }




        public async Task<int> LoadIntValue<U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters);
                return result;
            }
        }
    }
}
