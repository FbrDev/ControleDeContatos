using ControleDeContatos.Models;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Interfaces
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel BuscarPorId(Guid id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Delete(Guid id);
    }
}
