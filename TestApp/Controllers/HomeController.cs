using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models.Repository;
using TestApp.Models;
using TestApp.Models.ViewModels;
using TestApp.Models.Services;

namespace TestApp.Controllers
{
    /// <summary>
    /// Основной контроллер приложения
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Объект интерфейса сервиса IHomeService
        /// </summary>
        private readonly IHomeService _service;

        /// <summary>
        /// конструктор по умолчанию для контроллера
        /// </summary>
        /// <param name="service">Параметер для инициализации сервиса Home Service</param>
        public HomeController(IHomeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Метод контроллера Index
        /// </summary>
        /// <returns>Страницу Index.html с аргументом _service.GetIpAddresses() </returns>
        public IActionResult Index()
        {
            return View(_service.GetIpAddresses());
        }

        /// <summary>
        /// Метод контроллера AddSubnet 
        /// </summary>
        /// <returns>Страницу AddSubnet.html </returns>
        public IActionResult AddSubnet()
        {
            return View();
        }

        /// <summary>
        /// Метод контроллера RemoveIpAddress
        /// Данный метод выполняет запрос к серивису на удаление подсети
        /// </summary>
        /// <param name="ipAddressID">
        /// Данный параметр используется для вызова метода серивса
        /// RemoveIpAddress
        /// </param>
        /// <returns>Метод возвращает редирект на метод Index контроллера Home</returns>
        public IActionResult RemoveIpAddress(int ipAddressID)
        {
            _service.RemoveIpAddress(ipAddressID);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Метод контроллера AddIpAddress
        /// Данный метод вызывает методы серивса для проверки
        /// и добаления подсети в базу данных
        /// </summary>
        /// <param name="ipAddress">
        /// Данный параметр используется для вызова методов серивса
        /// CheckIpAddress и AddIpAddress
        /// </param>
        /// <returns>
        /// В случае ,когда метод серивса CheckIpAddress возвращает True,
        /// метод возвращает редирект на метод Index контроллера Home
        /// В случае , когда метод сервиса CheckIpAddress возвращает False,
        /// метод возвращает редирект на метод AddSubnet контроллера Home
        /// с параметром, содержащим сообщение об ошибке
        /// </returns>
        public IActionResult AddIpAddress(string ipAddress)
        {
            if (_service.CheckIpAddress(ipAddress))
            {
                _service.AddIpAddress(ipAddress);
                return RedirectToAction("Index");
            } else
            {
                TempData["Error"] = "Подсеть введена неверно";
                return RedirectToAction("AddSubnet", "Home");
            }
        }

        /// <summary>
        /// Метод контроллера ChangeIpAddress
        /// 
        /// </summary>
        /// <param name="ipAddressID">
        /// Данный параметр содержит идентификатор подсети</param>
        /// <param name="ipAddressVALUE">
        /// Данный параметер содержит адрес и маску подсети вида "1.1.1.1/12"
        /// </param>
        /// <returns>Возвращает страницу EditSubnet.html с параметрами описанными выше</returns>
        public IActionResult ChangeIpAddress(int ipAddressID, string ipAddressVALUE)
        {
            ViewData["IpAddressId"] = ipAddressID;
            ViewData["IpAddressValue"] = ipAddressVALUE;

            return View("EditSubnet");
        }

        /// <summary>
        /// Метод контроллера UpdateIpAddress
        /// Данный метод вызывает методы сервиса для проверки
        /// и обновления данных о подсети в базе денных
        /// </summary>
        /// <param name="id">Данный параметр содержит идентификатор подсети</param>
        /// <param name="ipAddress">Данный параметер содержит адрес и маску подсети вида "1.1.1.1/12"</param>
        /// <returns>
        /// В случае ,когда метод серивса CheckIpAddress возвращает True,
        /// метод возвращает редирект на метод Index контроллера Home
        /// В случае , когда метод сервиса CheckIpAddress возвращает False,
        /// метод возвращает редирект на метод ChangeIpAddress контроллера Home
        /// с параметром, содержащим сообщение об ошибке
        /// </returns>
        public IActionResult UpdateIpAddress(int id, string ipAddress)
        {
            if (_service.CheckIpAddress(ipAddress))
            {
                _service.UpdateIpAddress(id, ipAddress);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Подсеть введена неверно";
                return RedirectToAction("ChangeIpAddress", "Home");
            }
        }
    }
}
