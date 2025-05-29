using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Domain.Models.Customer
{
    public class CreateCustomerModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateOnly BirthDate { get; set; }


        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço pode ter no máximo 200 caracteres.")]
        public string Address { get; set; }


        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [Range(100000000, 999999999, ErrorMessage = "O número de telefone deve ter 9 dígitos.")]
        public int PhoneNumber { get; set; }


        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Password { get; set; }
    }
}
