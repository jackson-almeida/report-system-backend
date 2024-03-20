using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_relatorios.database;
using sistema_relatorios.models;
using System.Text;
using System.Security.Cryptography;
using sistema_relatorios.utils;

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
        public ActionResult<IEnumerable<UserModel>> getAllUser()
        {
            if (ModelState.IsValid)
            {
                //var users = _context.User.ToList();
                var users = _context.User
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email
                        // Inclua apenas as propriedades que você deseja retornar
                    })
                    .ToList();

                return Ok(users);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{email}")]
        public ActionResult<UserModel> getUserByEmail(string email)
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
            UserModel user = _context.User.FirstOrDefault(u => u.Email == userModel.Email);

            if (user != null)
            {
                return BadRequest("E-mail já cadastrado!");
            }

            if (ModelState.IsValid)
            {
                userModel.Password = HashPassword(userModel.Password);
                _context.User.Add(userModel);
                _context.SaveChanges();

                return Ok("Usuário adicionado com sucesso");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        public ActionResult<object> login([FromBody] UserModel userModel)
        {
            UserModel user = _context.User.FirstOrDefault(u => u.Email == userModel.Email);

            if (user == null)
            {
                return BadRequest("E-mail não existe!");
            }

            if (HashPassword(userModel.Password) != user.Password)
            {
                return BadRequest("Senha incorreta!");
            }

            if (ModelState.IsValid)
            {
                string token = TokenGenerator.GenerateToken(userModel.Email);

                return Ok(token);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
