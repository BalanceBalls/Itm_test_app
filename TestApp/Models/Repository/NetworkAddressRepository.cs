using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestApp.Models.Repository
{
    /// <summary>
    /// Данный класс реализует методы взаимодействия с таблицей БД
    /// </summary>
    public class NetworkAddressRepository : BaseRepository, INetworkAddressRepository
    {
       
        /// <summary>
        /// Конструктор класса NetworkAddressRepository
        /// </summary>
        /// <param name="config">Объект IConfiguration</param>
        public NetworkAddressRepository(IConfiguration config) : base(config) { }

        /// <summary>
        /// Метод реализует добавление в таблицу БД новой подсети
        /// </summary>
        /// <param name="ip">Адрес и маска подсети</param>
        public void AddIpAddressToDataBase(string ip)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
insert into	IpAddresses  (IpAddress) 

values
(  
    @{nameof(ip)}
)
", new { ip });

            }
        }

        /// <summary>
        /// Метод реализует получение подсетей с идентификаторами из таблицы БД
        /// </summary>
        /// <returns>Возвращает список моделей IpAddressModel</returns>
        public IEnumerable<IpAddressModel> GetAllIpAddressesFromDataBase()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<IpAddressModel>($@"
select	id                  {nameof(IpAddressModel.Id)},
		IpAddress		    {nameof(IpAddressModel.IpAdderss)}
from    IpAddresses
");
            }
        }

        /// <summary>
        /// Метод реализует удаление подсети из таблицы БД
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        public void RemoveIpAddressFromDataBase(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
delete  from IpAddresses
Where Id = @{nameof(id)}
", new { id });
            }
        }

        /// <summary>
        /// Метод реализует обновление данных о подсети в таблице БД
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        /// <param name="address">Обновленные данные о подсети, которые необходимо внести в таблицу БД</param>
        public void UpdateIpAddressInDataBase(int id, string address)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
update	IpAddresses   
set IpAddress =    @{nameof(address)}
where Id =         @{nameof(id)}
", new { id , address });
            }
        }
    }
}
