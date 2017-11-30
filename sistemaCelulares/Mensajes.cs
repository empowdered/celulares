using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistemaCelulares
{
    class Mensajes
    {
        public string contenidox = "";
        public int destino, origen;

        public Mensajes(string a, int b, int c){
            this.contenidox = a;
            this.destino = b;
            this.origen = c;
        }
        public string miContenido
        {
            get { return this.contenidox; }
        }
        public int miDestino
        {
            get { return this.destino; }
        }
        public int miOrigen
        {
            get { return this.origen; }
        }
    }
}
