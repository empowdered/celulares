using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistemaCelulares
{
    class Cliente
    {
        private string rut, nombres, apellidos, direccion;

        public Cliente(string a, string b, string c, string d)
        {
            rut = a;
            nombres = b;
            apellidos = c;
            direccion = d;
        }
        public Cliente()
        {
        }

        public string miRut
        {
            get { return rut; }
        }
        public string miNombre
        {
            get { return nombres; }
        }
        public string miApellido
        {
            get { return apellidos; }
        }
        public string miDireccion{
            get {return direccion;}
        }
    }
}
