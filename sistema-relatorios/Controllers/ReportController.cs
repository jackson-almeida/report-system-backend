using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_relatorios.database;

namespace sistema_relatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
    }
}
