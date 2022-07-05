using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
