using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if(usuario.senhaValida(loginModel.Senha))
                            return RedirectToAction("Index", "Home");

                        TempData["MensagemError"] = $"A senha do Usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemError"] = $"Usuário e/ou senha inválido(os), por favor tente novamente.";
                }

                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops, Não conseguimos realizar seu login, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
