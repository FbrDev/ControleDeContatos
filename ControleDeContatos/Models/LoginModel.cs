using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
