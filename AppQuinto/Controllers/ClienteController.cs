using AppQuinto.Models;
using AppQuinto.Repositorio.Concrect;
using Microsoft.AspNetCore.Mvc;

namespace AppQuinto.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }

        public IActionResult Index()
        {
            return View(_ClienteRepository.ObterTodosCliente());

        }

        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _ClienteRepository.Cadastrar(cliente);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AtualizarCliente(int Id)
        {
            return View(_ClienteRepository.ObterCliente(Id));
        }
        [HttpPost]
        public IActionResult AtualizarCliente(Cliente cliente)
        {
            _ClienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ExcluirCliente(int id)
        {
            _ClienteRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesCliente(int Id)
        {
            return View(_ClienteRepository.ObterCliente(Id));
        }
        [HttpPost]
        public IActionResult DetalhesCliente(Cliente cliente)
        {
            _ClienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }


    }
}
