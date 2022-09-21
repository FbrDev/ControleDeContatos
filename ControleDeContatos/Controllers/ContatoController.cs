using ControleDeContatos.Filters;
using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _repositorio;
        private readonly ISessao _sessao;
        public ContatoController(IContatoRepositorio repositorio, ISessao sessao)
        {
            _repositorio = repositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ContatoModel> contatos = _repositorio.BuscarTodos(usuarioLogado.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Evita ataque CRFS
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;
                    _repositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops, Não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro: {error.Message}";
                return View(contato);
            }
        }

        public IActionResult Editar(Guid id)
        {
            var contato = _repositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;
                    _repositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops, Não conseguimos atualizar seu contato, tente novamente. Detalhe do erro: {error.Message}";
                return View("Editar", contato);
            }
        }

        public IActionResult ApagarConfirmacao(Guid id)
        {
            return View(_repositorio.BuscarPorId(id));
        }

        public IActionResult Apagar(Guid id)
        {
            try
            {
                var apagado = _repositorio.Delete(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemError"] = $"Ops, Não conseguimos deletar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops, Não conseguimos deletar seu contato, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
