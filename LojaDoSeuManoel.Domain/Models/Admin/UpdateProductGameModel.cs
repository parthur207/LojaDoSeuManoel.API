using LojaDoSeuManoel.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Domain.Models.Admin
{
    public class UpdateProductGameModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Name { get; private set; }


        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string Description { get; private set; }


        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve estar entre 0.01 e 999999.99.")]
        public decimal Price { get; private set; }


        [Required(ErrorMessage = "O status é obrigatório.")]
        [EnumDataType(typeof(ProductGameStatusEnum), ErrorMessage = "Status inválido.")]
        public ProductGameStatusEnum Status { get; private set; }


        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [EnumDataType(typeof(ProductGameCategoryEnum), ErrorMessage = "Categoria inválida.")]
        public ProductGameCategoryEnum Category { get; private set; }


        [Url(ErrorMessage = "A URL da imagem deve ser válida.")]
        public string? ImageUrl { get; private set; }
    }
}
