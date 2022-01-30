using System;

namespace Veterinaria.Dominio
{
    public class Seleccionarmascota
    {
        public string IdAnimal { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string FechaNacimiento { get; set; }

        public override string ToString()
        {
            return $"Nombre: {this.Nombre} - Especie: {this.Especie} - Raza: {this.Raza} - Color: {this.Color} - Fecha Nacimiento: {this.FechaNacimiento}";
        }
    }
}
