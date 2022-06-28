using ControleDeContatos.Data;
using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepository : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepository(BancoContext context)
        {
            _context = context;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel BuscarPorId(Guid id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);
            
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Celular = contato.Celular;
            contatoDB.Email = contato.Email;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();
            return contato;
        }

        public bool Delete(Guid id)
        {
            ContatoModel contatoDB = BuscarPorId(id);

            if (contatoDB == null) throw new Exception("Houve um erro na exclusão do contato");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();
            return true;
        }
    }
}
