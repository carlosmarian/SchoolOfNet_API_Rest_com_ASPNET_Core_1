using System;
using Microsoft.AspNetCore.Mvc;
using SchoolOfNet_API_Rest_com_ASPNET_Core_1.Data;
using SchoolOfNet_API_Rest_com_ASPNET_Core_1.Models;
using System.Linq;

namespace SchoolOfNet_API_Rest_com_ASPNET_Core_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController: ControllerBase
    {

        private readonly ApplicationDbContext database;

        public ProdutosController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            var produtos = database.Produtos.ToList();
            return Ok(new {msg = "Lista de produtos", body = produtos});
        }
        [HttpGet("{id}")]
        public IActionResult PegarProdutos(int id){
            try{
                var produtos = database.Produtos.First(p => p.ID == id);
                return Ok(new {msg = "Produto", body = produtos});
            }catch(Exception ex){
                return BadRequest(new {msg = "Id inválido"});
            }            
        }
        
        [HttpPost()]
        public IActionResult Post([FromBody] ProdutoTemp produto){
            Produto p = new Produto();
            p.Nome = produto.Nome;
            p.Preco = produto.Preco;

            database.Produtos.Add(p);
            database.SaveChanges();            

            return Ok( new {info = "Retorno positivo", body = produto});
        }

        public class ProdutoTemp{
            public string Nome { get; set; }
            public float Preco { get; set; }
        }
    }
}