using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestApp.Models.Repository
{
    /// <summary>
    /// Класс реализует подключение к БД
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Переменная конфигурации
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Метод конструктора. 
        /// Инициализирует переменную конфигурации
        /// </summary>
        /// <param name="config">Объъект интерфейса IConfiguration</param>
        protected BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Поле класса BaseRepository.
        /// Тип IDbConnection
        /// Поле содержит инициализированное подключение к БД
        /// </summary>
        protected IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    }
}
