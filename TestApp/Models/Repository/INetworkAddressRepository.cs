using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Repository
{
    /// <summary>
    /// Интерфейс репозитория NetworkAddressRepository
    /// Описывает сигнатуры методов репозитория
    /// </summary>
    public interface INetworkAddressRepository
    {
        /// <summary>
        /// Сигнатура метода получения все подсетей из таблицы БД
        /// </summary>
        /// <returns>Возвращает список объектов модели IpAddressModel</returns>
        IEnumerable<IpAddressModel> GetAllIpAddressesFromDataBase();

        /// <summary>
        /// Сигнатура метода добавления подсети в базу данных
        /// </summary>
        /// <param name="ip">Параметр содержит адрес подсети с маской</param>
        void AddIpAddressToDataBase(String ip);

        /// <summary>
        /// Сигнатура метода удаления подсети из таблицы БД
        /// </summary>
        /// <param name="id">Параметр содержит идентификатор подсети в таблице БД</param>
        void RemoveIpAddressFromDataBase(int id);

        /// <summary>
        /// Сигнатура метода обновления данных о подсети в таблице БД
        /// </summary>
        /// <param name="id">Параметр содержит идентификатор подсети в таблице БД</param>
        /// <param name="address">
        /// Параметр содержит измененный адрес и маску подсети ,
        /// который необходимо записать в таблицу БД
        /// </param>
        void UpdateIpAddressInDataBase(int id, string address);

        
    }
}
