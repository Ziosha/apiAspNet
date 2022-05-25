
using System.Collections.Generic;
using apiprueba.Dtos.Telefono;

namespace apiprueba.Dtos.User
{
    public class UserPhoneDto
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection <PhoneDto> phones{ get; set; }
    }
}