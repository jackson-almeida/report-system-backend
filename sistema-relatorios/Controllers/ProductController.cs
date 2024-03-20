using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_relatorios.database;
using sistema_relatorios.models;
using sistema_relatorios.Controllers;

namespace sistema_relatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> getAllProducts()
        {
            if (ModelState.IsValid)
            {
                var products = _context.Product.ToList();
                return Ok(products);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{code}")]
        public ActionResult<ProductModel> getProductByCode(int code)
        {
            if (ModelState.IsValid)
            {
                return Ok(_context.Product.FirstOrDefault(u => u.Code == code));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost]
        public ActionResult<ProductModel> postUser([FromBody] ProductModel productModel)
        {
            TaxRuleModel taxRule = _context.TaxRule.FirstOrDefault(u => u.Code == productModel.TaxRuleCode);

            if (ModelState.IsValid && taxRule != null)
            {
                _context.Product.Add(productModel);
                _context.SaveChanges();

                return Ok("Produto adicionado com sucesso");
            }
            else
            {
                return BadRequest("Dados inválidos!");
            }
        }
    }
}
