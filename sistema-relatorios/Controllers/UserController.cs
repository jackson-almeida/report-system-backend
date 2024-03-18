using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_relatorios.database;
using sistema_relatorios.models;

namespace sistema_relatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> getAllUser()
        {
            if (ModelState.IsValid)
            {
                return Ok(_context.User.Find());
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{email}")]
        public ActionResult<UserModel> getUserByEmail(string email) // receber email
        {
            if (ModelState.IsValid)
            {
                return Ok(_context.User.FirstOrDefault(u => u.Email == email));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public ActionResult<UserModel> postUser([FromBody] UserModel userModel)
        {
            ActionResult<UserModel> user = getUserByEmail(userModel.Email);

            if (user != null)
            {
                return BadRequest("E-mail já cadastrado!");
            }

            if (ModelState.IsValid)
            {
                _context.User.Add(userModel);
                _context.SaveChanges();

                return Ok("Usuário adicionado com sucesso");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
