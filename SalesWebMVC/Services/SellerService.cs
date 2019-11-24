using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //tem que ter uma dependencia para o db context
        //readonly quer dizer que não pode ser alterada
        private readonly SalesWebMVCContext _context;

        //precisa do construtor para que a chamada de dependência possa acontecer
        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }    
        
        //operação para retornar uma lista de vendedores do banco de dados

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert (Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        
          
    }
}
