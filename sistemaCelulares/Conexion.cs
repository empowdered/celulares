using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace sistemaCelulares
{
    public class Conexion
    {
        
        public string conexionx;
        public SqlConnection conexion;

        public Conexion()
        {
            try
            {
                this.conexionx = "Server = jpml-PC; Database = sistemaMovil; User Id = juanp; Password = jpml123;";
                conexion = new SqlConnection(conexionx);
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ErrorCode);
            }
        }
        public SqlConnection miConexion
        {
            get {return conexion;}
        }
        public void Abrir()
        {
            try
            {
                this.miConexion.Open();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.StackTrace);
            }
        }
        public void Cerrar()
        {
            this.miConexion.Close();
        }
    }
}
