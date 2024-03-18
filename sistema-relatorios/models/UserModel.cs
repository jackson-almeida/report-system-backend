using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sistema_relatorios.models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } // ? informa que a string pode vir nula.
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
