using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //Se usuario estiver logado, redirecionar para home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoDoUsuario();
            return RedirectToAction("Index");
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
                        if (usuario.senhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novasenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novasenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de Contatos - Redefinição de Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemError"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente.";
                        }


                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemError"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }

                return View("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops, Não conseguimos redefinir sua senha, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
