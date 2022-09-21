using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "O {0} está com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O {0} está com formato inválido")]
        public string Celular { get; set; }
        public Guid? UsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
