namespace apiprueba.Models
{
    public class UserRol
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Rol Rol { get; set; }
        public int RolId { get; set; }
    }
}