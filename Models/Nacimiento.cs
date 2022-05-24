namespace apiprueba.Models
{
    public class Nacimiento
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string  Pais { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}