using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _repositorio;
        public ContatoController(IContatoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _repositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _repositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid id)
        {
            var contato = _repositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _repositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(Guid id)
        {
            return View(_repositorio.BuscarPorId(id));
        }

        public IActionResult Apagar(Guid id)
        {
            _repositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
