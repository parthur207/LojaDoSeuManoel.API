using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Domain.Models.Customer
{
    public class UpdatePasswordCostumerDataModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A 'senha atual' é obrigatória.")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "A 'nova senha' é obrigatória.")]
        [MinLength(6, ErrorMessage = "A nova senha deve ter pelo menos 6 caracteres.")]
        public string NewPassword { get; set; }
    }
}
