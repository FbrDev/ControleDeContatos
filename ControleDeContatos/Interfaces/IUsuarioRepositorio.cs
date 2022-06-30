using ControleDeContatos.Models;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(Guid id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Delete(Guid id);
    }
}
