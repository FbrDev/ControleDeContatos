using ControleDeContatos.Data;
using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepository : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepository(BancoContext context)
        {
            _context = context;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);
            
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.Senha = usuario.Senha == null ? usuarioDB.Senha : usuario.Senha;
            usuarioDB.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();
            return usuario;
        }

        public bool Delete(Guid id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na exclusão do usuário");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDb = BuscarPorId(alterarSenhaModel.Id);

            if (usuarioDb == null) throw new Exception("Houve na atualização da senha, usuário não encontrado!");

            if (!usuarioDb.senhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha Atual não confere");

            if (usuarioDb.senhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual.");

            usuarioDb.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDb.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();
            return usuarioDb;
        }
    }
}
