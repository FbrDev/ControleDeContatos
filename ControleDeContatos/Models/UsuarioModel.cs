using ControleDeContatos.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "O {0} está com formato inválido")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
