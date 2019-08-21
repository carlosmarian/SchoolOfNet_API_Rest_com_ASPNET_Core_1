using Microsoft.AspNetCore.Mvc;

namespace SchoolOfNet_API_Rest_com_ASPNET_Core_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController: ControllerBase
    {
        [HttpGet]
        public IActionResult PegarProdutos(){
            return Ok(new {nome = "Carlos", empresa = "Teste de empresa"});
        }
        [HttpGet("{id}")]
        public IActionResult PegarProdutos(int id){
            return Ok(new {nome = "Carlos", empresa = "Teste de empresa 2", id = id});
        }
    }
}