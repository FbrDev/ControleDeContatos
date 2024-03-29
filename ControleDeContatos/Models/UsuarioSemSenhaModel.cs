﻿using ControleDeContatos.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "O {0} está com formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public PerfilEnum? Perfil { get; set; }
    }
}
