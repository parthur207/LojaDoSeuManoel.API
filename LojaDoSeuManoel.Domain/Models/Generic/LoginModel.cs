using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Models.Generic
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Insira seu email.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Insira sua senha.")]
        public string Password { get; set; }

    }
}
