using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Visual
{
    static class Program
    {
        
       
        static void Main()
        {
            ConexionBD con = new ConexionBD();
            List<string> resultado = new List<string>();


            con.abrir();

            //resultado = con.Seleccionar("Linda");
            con.insertarSocio();
            con.ModificarSocio();
            con.EliminarSocio();


            con.cerrar();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
