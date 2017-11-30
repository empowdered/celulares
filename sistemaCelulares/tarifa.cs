using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistemaCelulares
{
    class tarifa
    {
        string nbtarifa;
        int codigo;
        string inicio, termino;
        float coste;

        public tarifa(string a,int b,string c, string d, float e)
        {
            this.nbtarifa = a;
            this.codigo = b;
            this.inicio = c;
            this.termino = d;
            this.coste = e;
        }
        public string miNombre
        {
            get { return this.nbtarifa; }
        }
        public int miCodigo
        {
            get { return this.codigo; }
        }
        public string miInicio
        {
            get { return this.inicio; }
        }
        public string miTermino
        {
            get { return this.termino; }
        }
        public float miCoste
        {
            get { return this.coste; }
        }
    }
}
