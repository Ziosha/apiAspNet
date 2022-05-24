namespace apiprueba.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int CodigoDePais { get; set; }
        public virtual User User { get; set; }        
        public int UserId { get; set; }
    }
}