using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.Models.Repository;
using System.Net;


namespace TestApp.Models.Services
{
    /// <summary>
    /// Класс реализует методы сервиса
    /// </summary>
    public class HomeService : IHomeService
    {
        /// <summary>
        /// Репозиторий подсетей
        /// </summary>
        private readonly INetworkAddressRepository _networkAddressRepository;
        
        /// <summary>
        /// Метод конструктора репозитория INetworkRepository
        /// </summary>
        /// <param name="networkAddressRepository">Объект интерфейса networkAddressRepository</param>
        public HomeService(INetworkAddressRepository networkAddressRepository)
        {
            _networkAddressRepository = networkAddressRepository;
        }

        /// <summary>
        /// Вспомогательный приватный метод для проверки валидности подсети 
        /// средствами библиотеки System.Net.IPAddress
        /// </summary>
        /// <param name="ipAddress">Адрес и маска подсети</param>
        /// <returns>   
        /// True, если подсеть валидна
        /// False, если подсеть невалидна
        /// </returns>
        private bool CheckViaStandartLib(string ipAddress)
        {
            if (ipAddress.Contains('/') && !String.IsNullOrEmpty(ipAddress))
            {
                string _ip = ipAddress.Split('/')[0];
                string _mask = ipAddress.Split('/')[1];

                if (int.TryParse(_mask, out int _subnetMask))
                {
                    if (_subnetMask >= 1 && _subnetMask <= 32 && _ip.Length >= 7)
                    {
                        return IPAddress.TryParse(_ip, out IPAddress checkedIp);
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Вспомогательный приватный метод для проверки валидности подсети 
        /// средствами сторонней библиотеки IPNetwork2
        /// </summary>
        /// <param name="ipAddress">Адрес и маска подсети</param>
        /// <returns>   
        /// True, если подсеть валидна
        /// False, если подсеть невалидна
        /// </returns>
        private bool CheckViaThirdPartyLib(string ipAddress)
        {
            try
            {
                IPNetwork _ipnetwork = IPNetwork.Parse(ipAddress);
            }
            catch (Exception error)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Реализация метода проверки валидности подсети с 
        /// помощью вспомогательных приватных методов
        /// описанных выше
        /// </summary>
        /// <param name="ipAddress">Адрес и маска подсети</param>
        /// <returns>   
        /// True, если подсеть валидна
        /// False, если подсеть невалидна
        /// </returns>
        public bool CheckIpAddress(string ipAddress)
        {

            //return CheckViaThirdPartyLib(ipAddress);
            return CheckViaStandartLib(ipAddress);
        }

        /// <summary>
        /// Реализация метода добавления подсети в таблицу БД
        /// Данный метод обращается к методу репозитория для взаимодействия с БД
        /// </summary>
        /// <param name="ip">Идентификатор подсети в таблице БД</param>
        public void AddIpAddress(string ip)
        {
            _networkAddressRepository.AddIpAddressToDataBase(ip);
        }

        /// <summary>
        /// Реализация метода получения подсетей из таблицы БД
        /// Данный метод обращается к методу репозитория для взаимодействия с БД
        /// </summary>
        /// <returns>
        /// Возвращает список моделей IpAddressModel 
        /// полученный из метода репозитория
        /// </returns>
        public IEnumerable<IpAddressModel> GetIpAddresses()
        {
            return _networkAddressRepository.GetAllIpAddressesFromDataBase();
        }

        /// <summary>
        /// Реализация метода удаления подсети из таблицы БД
        /// Данный метод обращается к методу репозитория для взаимодействия с БД
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        public void RemoveIpAddress(int id)
        {
            _networkAddressRepository.RemoveIpAddressFromDataBase(id);
        }

        /// <summary>
        /// Реализация метода обновления  данных о подсети в таблицы БД
        /// Данный метод обращается к методу репозитория для взаимодействия с БД
        /// </summary>
        /// <param name="id">Идентификатор подсети в таблице БД</param>
        /// <param name="address">Адрес и маска подсети</param>
        public void UpdateIpAddress(int id, string address)
        {
            _networkAddressRepository.UpdateIpAddressInDataBase(id,address);
        }
    }
}
