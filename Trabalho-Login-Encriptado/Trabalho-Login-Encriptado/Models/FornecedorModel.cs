using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Login_Encriptado.Models
{
    public class FornecedorModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Insira o nome do fornecedor")]
        public string Nome { get; set; }
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Digite um email válido!")]
        public string Email { get; set; }
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }
        [Display(Name = "CNPJ:")]
        [Required(ErrorMessage = "Insira o CNPJ!")]
        public string CNPJ { get; set; }

        public virtual ICollection<ProdutoModel> Produtos { get; set; }
    }
}