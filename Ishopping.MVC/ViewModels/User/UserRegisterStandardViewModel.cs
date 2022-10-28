using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserRegisterStandardViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Area { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
}
