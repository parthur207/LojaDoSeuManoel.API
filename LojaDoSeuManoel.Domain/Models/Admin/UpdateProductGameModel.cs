﻿using LojaDoSeuManoel.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Domain.Models.Admin
{
    public class UpdateProductGameModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Name { get;  set; }


        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string Description { get;  set; }


        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve estar entre 0.01 e 999999.99.")]
        public decimal Price { get;  set; }


        [Range(0, 1000, ErrorMessage = "A altura deve estar entre 0 e 1000.")]
        public decimal Height { get;  set; }


        [Range(0, 1000, ErrorMessage = "A largura deve estar entre 0 e 1000.")]
        public decimal Width { get;  set; }


        [Range(0, 1000, ErrorMessage = "O comprimento deve estar entre 0 e 1000.")]
        public decimal Length { get;  set; }


        [Url(ErrorMessage = "A URL da imagem deve ser válida.")]
        public string? ImageUrl { get; set; }
    }
}
