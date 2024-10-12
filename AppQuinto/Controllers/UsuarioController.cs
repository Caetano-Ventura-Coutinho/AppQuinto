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
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AtualizarUsuario(int Id)
        {
            return View(_usuarioRepository.ObterUsuario(Id));
        }
        [HttpPost]
        public IActionResult AtualizarUsuario(usuario Usuario)
        {
            _usuarioRepository.Atualizar(Usuario);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {
            _usuarioRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesUsuario(int Id)
        {
            return View(_usuarioRepository.ObterUsuario(Id));
        }
        [HttpPost]
        public IActionResult DetalhesUsuario(usuario Usuario)
        {
            _usuarioRepository.Atualizar(Usuario);

            return RedirectToAction(nameof(Index));
        }


    }
}
