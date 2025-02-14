using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooej1
{
    internal class Persona
    {
        //Persona: Edad, sueldo, nombre
        //atrubutos o miembros
        private int edad;
        private float sueldo;
        private string nombre;
        
        /*public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public int getEdad() { 
        return this.edad;
        }*/

        //PROPIEDAD 
        public int Edad {  get { return edad; } set {  edad = value; } }
    }
}
