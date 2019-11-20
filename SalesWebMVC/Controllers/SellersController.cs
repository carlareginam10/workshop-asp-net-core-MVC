using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}