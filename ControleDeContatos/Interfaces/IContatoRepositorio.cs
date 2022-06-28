using ControleDeContatos.Models;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Interfaces
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
