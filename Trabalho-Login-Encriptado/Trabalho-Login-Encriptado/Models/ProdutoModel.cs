using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Login_Encriptado.Models
{
    public class ProdutoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }
        [Display(Name = "Descrição:")]
        [Required(ErrorMessage = "Digite a descrição!")]
        public string Descricao { get; set; }
        [Display(Name = "Qtde em Estoque:")]
        [Required(ErrorMessage = "Digite a quantidade em estoque!")]
        public int Qtde_Estoque { get; set; }
        [Display(Name = "Custo:")]
        [Required(ErrorMessage = "Digite o Valor de custo!")]
        public float Custo { get; set; }

        public int? FornecedorId { get; set; }
        public FornecedorModel Fornecedor { get; set; }
    }
}