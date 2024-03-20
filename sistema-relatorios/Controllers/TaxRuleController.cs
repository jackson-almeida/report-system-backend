using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_relatorios.database;
using sistema_relatorios.models;

namespace sistema_relatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRuleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxRuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<TaxRuleModel>> getAllTaxRules()
        {
            if (ModelState.IsValid)
            {
                return Ok(_context.TaxRule.ToList());
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{code}")]
        public ActionResult<TaxRuleModel> getTaxRuleByCode(int code)
        {
            if (ModelState.IsValid)
            {
                return Ok(_context.TaxRule.FirstOrDefault(u => u.Code == code));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public ActionResult<TaxRuleModel> postTaxRule([FromBody] TaxRuleModel taxRuleModel)
        {
            if (ModelState.IsValid)
            {
                _context.TaxRule.Add(taxRuleModel);
                _context.SaveChanges();

                return Ok("Regra de imposto adicionada com sucesso");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult<TaxRuleModel> updateTaxRule([FromBody] TaxRuleModel taxRuleModel)
        {
            TaxRuleModel taxRule = _context.TaxRule.FirstOrDefault(u => u.Code == taxRuleModel.Code);

            if (taxRule == null)
            {
                return BadRequest("Regra de imposto não existe!");
            }

            if (ModelState.IsValid)
            {
                _context.TaxRule.Update(taxRuleModel);
                _context.SaveChanges();

                return Ok("Regra de imposto atualizada com sucesso");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
