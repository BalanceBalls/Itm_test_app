using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Services
{
    /// <summary>
    /// Интерйейс сервиса HomeService
    /// Описывает сигнатуры методов сервиса
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// Сигнатура метода добавления подсети 
        /// </summary>
        /// <param name="ip">Адрес и маска подсети</param>
        void AddIpAddress(String ip);

        /// <summary>
        /// Сигнатура метода удаления подсети
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        void RemoveIpAddress(int id);

        /// <summary>
        /// Сигнатура метода обновления данных о подсети
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        /// <param name="address">Адрес и маска подсети</param>
        void UpdateIpAddress(int id , string address);

        /// <summary>
        /// Сигнатура метода получения списпка подсетей
        /// </summary>
        /// <returns>Список объектов модели IpAddressModel</returns>
        IEnumerable<IpAddressModel> GetIpAddresses();

        /// <summary>
        /// Сигнатура метода проверки валидности подсети
        /// </summary>
        /// <param name="ipAddress">Адрес и маска подсети</param>
        /// <returns>
        /// True, если подсеть валидна
        /// False, если подсеть невалидна
        /// </returns>
        bool CheckIpAddress(string ipAddress);

    }
}
