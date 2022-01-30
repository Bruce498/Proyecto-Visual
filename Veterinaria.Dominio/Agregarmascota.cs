namespace Veterinaria.Dominio
{
    public class Agregarmascota
    {
             
        public string Nombre { get; set; }
        public string Especia { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public int Cedula { get; set; }
        public string FechaNacimiento { get; set; }

        
    }
    // la base de datos se puede cambiar? id animal deberia de ser autoincemental y deberia ser int
}
