using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        //precisa colocar a dependência para SellerSErvice
        private readonly SellerService _sellerService;

        //cria construtor para injetar dependencia
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            //implementar chamada do sellerService.FindAll
            var list = _sellerService.FindAll(); //retorna lista de seller

            return View(list); // passo argumento no metodo view para gerar IActionResult contendo  a lista
        }

        //criando uma nova ação
        // IActionResult é o tipo de retorno de todas as ações

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // usado pra indicar que esse create é uma ação post
        [ValidateAntiForgeryToken] //previnir qua a aplicação sofra ataque csrf quando alguem apreveita a a sua sessão
        //de autenticação para enviar dados maliciosos aproveitando a sua autenticação
        public IActionResult Create(Seller seller)
        {
            //Adiciona o vendedor no banco de dados quando clica no botao create
            _sellerService.Insert(seller);
            //volta pra pagina index depois de gravar os dados no banco
            //uso o nameof pq se um dia trocar o nome dessa chamada não precisa alterar aqui
            return RedirectToAction("Index");
        }
    }
}