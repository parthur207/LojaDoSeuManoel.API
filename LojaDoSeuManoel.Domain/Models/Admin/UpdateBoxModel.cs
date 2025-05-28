using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Models.Admin
{
    public class UpdateBoxModel
    {
        [Required]
        public BoxTypeEnum BoxType { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que 0.")]
        public decimal Height { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que 0.")]
        public decimal Width { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "O comprimento deve ser maior que 0.")]
        public decimal Length { get; set; }
    }
}
