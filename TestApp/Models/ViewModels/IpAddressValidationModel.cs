using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web;

namespace TestApp.Models.ViewModels
{
    public class IpAddressValidationModel 
    {
        [Required(ErrorMessage ="Необходимо ввести IP адрес")]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}(\/([0-9]|[1-2][0-9]|3[0-2]))?$", ErrorMessage ="Неверный формат ввода адреса")]

        public string IpAddress { get; set; }

        public int id { get; }
    }
}
