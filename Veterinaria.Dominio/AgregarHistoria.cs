using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class AgregarHistoria
    {
        public float IdAnimal { get; set; }
        public float Idveterinario { get; set; }
        public float Idenfermedad { get; set; }
        public DateTime FechadeEnfermedad { get; set; }
    }
}
