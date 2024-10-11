using AppQuinto.Repositorio.Concrect;
using Microsoft.AspNetCore.Mvc;
using AppQuinto.Models;

namespace AppQuinto.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View(_usuarioRepository.ObterTodosUsuarios());
             
        }
      
        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Cadastrar(usuario);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AtualizarUsuario(int id)
        {
            return View(_usuarioRepository.ObterUsuario(id));
        }
        [HttpPost]
        public IActionResult AtualizarUsuario(usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Atualizar(Usuario);
                return RedirectToAction(nameof(Index));
            }
            return null;
        }
        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {
            _usuarioRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
