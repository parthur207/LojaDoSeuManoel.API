using LojaDoSeuManoel.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Domain.Models.Customer
{
    public class CreateOrderModel
    {
        [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
        [MinLength(1, ErrorMessage = "A lista de produtos deve conter ao menos um item.")]
        public List<OrderProductGameEntity> ShoppingList { get; set; }
    }
}
