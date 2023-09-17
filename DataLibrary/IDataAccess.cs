using System.Collections.Generic;
namespace DataLibrary
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task<int> LoadIntValue<U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionStrings);
    }
}