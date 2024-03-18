using sistema_relatorios.database;
using sistema_relatorios.models;


namespace sistema_relatorios.services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int save(UserModel userModel)
        {
            _context.User.Add(userModel); // Supondo que '_context' é o contexto do seu banco de dados
            int response = _context.SaveChanges();

            return response;
        }
    }
}
