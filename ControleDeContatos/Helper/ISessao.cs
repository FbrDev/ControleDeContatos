﻿using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoveSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
