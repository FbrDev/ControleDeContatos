using ControleDeContatos.Models;

namespace ControleDeContatos.Interfaces
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoveSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
