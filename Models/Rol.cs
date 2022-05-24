using System.Collections.Generic;

namespace apiprueba.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRol> UserRols { get; set; }  
    }
}