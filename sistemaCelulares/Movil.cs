using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistemaCelulares
{
    class Movil
    {   
        public int numero, saldo;
        public bool estado = false;
        public string inicio, termino;

        public Movil(int a, int b, bool c,string d,string e)
        {
            this.numero = a;
            this.saldo = b;
            this.estado = c;
            this.inicio = d;
            this.termino = e;

        }
        public Movil(int a,int b)
        {
            this.numero = a;
            this.saldo = b;
        }
        public int miNumero{
            get { return numero; }
        }
        public int miSaldo
        {
            get { return saldo; }
        }
        public bool miEstado
        {
            get { return estado; }
        }
        public string miInicio
        {
            get { return inicio; }
        }
        public string miTermino
        {
            get { return termino; }
        }
    }
}
