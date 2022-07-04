using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Campo {0} está com formato inválido.")]
        public string Email { get; set; }
    }
}
