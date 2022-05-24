using System.Collections.Generic;

namespace apiprueba.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int? Edad1 { get; set; }
        public virtual ICollection<Nacimiento> Nacimientos { get; set; }
        public virtual ICollection<Telefono> Telofonos { get; set; }
        public virtual ICollection<UserRol> UserRols { get; set; }
        public virtual User Users{ get; set; }
        public int? TutorId { get; set; }
    }
}