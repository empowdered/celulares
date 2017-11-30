using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sistemaCelulares
{
    public partial class Form1 : Form
    {
        public Conexion c = new Conexion();
        public Boolean resultado = false;
        public SqlDataAdapter daClientes = null,daMovil = null,daDesvio = null,daSms = null,daSmsr = null,daHisto = null;
        public DataSet dsClientes = null, dsMovil = null, dsDesvio = null, dsSms = null, dsSmsr = null,dsHisto = null;
        public SqlDataReader myReader = null,myReader2 = null;
        SqlCommand queryUpdate = null,queryInsert = null,querySelect = null;
        
        public static int numMovil;
        public static string rutAbonado;

        public Form1()
        {
            InitializeComponent();
            this.cargarClientes();
            this.cargarMovil();
            this.cargarDesviados();
            this.cargarHisto();
        }
        public Boolean miResultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        public void guardarClientes()
        {
            SqlCommand queryInsert = null;
            try
            {
                c.Abrir();
                Cliente cc = new Cliente(txtRut.Text, txtNombres.Text, txtApellidos.Text, txtDireccion.Text);
                string instruccion = "sp_consultaRut";
                queryInsert = new SqlCommand(instruccion, this.c.miConexion);
                queryInsert.CommandType = CommandType.StoredProcedure;
                queryInsert.Parameters.AddWithValue("@rut", cc.miRut);
                queryInsert.Parameters.AddWithValue("@nombre", cc.miNombre);
                queryInsert.Parameters.AddWithValue("@apellidos", cc.miApellido);
                queryInsert.Parameters.AddWithValue("@direccion", cc.miDireccion);
                SqlParameter returnValueParam = queryInsert.Parameters.Add("@return_value", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                int returnValue;
                if ((txtRut.Text != "") && (txtNombres.Text != "") && (txtApellidos.Text != "") && (txtDireccion.Text != ""))
                {
                    queryInsert.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;
                    if (returnValue == 1)
                    {
                        MessageBox.Show("Datos ingresados correctamente");
                        this.cargarClientes();
                    }
                    if (returnValue == 0)
                    {
                        MessageBox.Show("El rut ya existe");
                    }

                }
                else
                {
                    MessageBox.Show("Faltan datos en el formulario");
                }
                // final else
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ErrorCode);
            }
            finally
            {
                this.c.Cerrar();
            }
        }
        public void Consultar()
        {
            string campo = txtRut.Text.ToString();

            try
            {

                SqlCommand consultar = new SqlCommand("Select rut From Clientes Where rut = '" + campo + "'", c.miConexion);
                myReader = consultar.ExecuteReader();

                while (myReader.Read())
                {
                    string parametro2 = txtRut.Text.ToString();
                    string parametro1 = myReader["rut"].ToString();

                    if (parametro1 == parametro2)
                    {
                        MessageBox.Show("valor-true:..." + parametro1);
                        this.miResultado = true;
                    }
                    else
                    {
                        MessageBox.Show("valor-false:..." + parametro2);
                        this.miResultado = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                myReader.Close();
            }
        }
        public void cargarClientes()
        {
            this.c.Abrir();
            try
            {

                daClientes = new SqlDataAdapter("select * from Clientes", this.c.miConexion);
                dsClientes = new DataSet();
                daClientes.Fill(dsClientes, "Clientes");
                dgvClientes.DataSource = dsClientes;
                dgvClientes.DataMember = "Clientes";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
              
            }
        }
        public void buscarCliente()
        {

            this.c.Abrir();
            if (txtRut.Text != "")
            {
                try
                {
                    SqlCommand consultar = new SqlCommand("Select * From Clientes Where rut = '" + txtRut.Text + "'", c.miConexion);
                    myReader = consultar.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtRut.Text = myReader["rut"].ToString();
                        txtRut.Enabled = false;
                        txtNombres.Text = myReader["nombres"].ToString();
                        txtApellidos.Text = myReader["apellidos"].ToString();
                        txtDireccion.Text = myReader["direccion"].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace); }
                finally
                {
                    this.c.Cerrar();
                    myReader.Close();
                }
            }
            else
            {
                MessageBox.Show("debe llenar el campo rut");
            }
        }
        public void Actualizar()
        {

            try
            {
                c.Abrir();
                Cliente cc = new Cliente(txtRut.Text, txtNombres.Text, txtApellidos.Text, txtDireccion.Text);
                string instruccion = "sp_ActualizaCliente";
                queryUpdate = new SqlCommand(instruccion, this.c.miConexion);
                queryUpdate.CommandType = CommandType.StoredProcedure;
                queryUpdate.Parameters.AddWithValue("@rut", cc.miRut);
                queryUpdate.Parameters.AddWithValue("@nombre", cc.miNombre);
                queryUpdate.Parameters.AddWithValue("@apellidos", cc.miApellido);
                queryUpdate.Parameters.AddWithValue("@direccion", cc.miDireccion);
                SqlParameter returnValueParam = queryUpdate.Parameters.Add("@return_value", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                int returnValue;
                if ((txtRut.Text != "") && (txtNombres.Text != "") && (txtApellidos.Text != "") && (txtDireccion.Text != ""))
                {
                    queryUpdate.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;
                    if (returnValue == 1)
                    {
                        MessageBox.Show("Datos actualizados correctamente");
                        this.cargarClientes();
                    }

                }
                else
                {
                    MessageBox.Show("Faltan datos en el formulario");
                }
                // final else
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ErrorCode);
            }
            finally
            {
                this.c.Cerrar();
                queryUpdate = null;
            }
        }
        private void crear_Click(object sender, EventArgs e)
        {
            this.guardarClientes();
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            this.buscarCliente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
            this.cargarMovil();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtRut.Enabled = true;
        }

        //desde aca empieza el segundo tab

        private void btnCrear_Click(object sender, EventArgs e)
        {
            this.crearMovil_abonado();
            this.cargarMovil();
            this.cargarDesviados();
        }
        public void crearMovil_abonado()
        {
            int returnValue;

            if ((txtRutC.Text != "") && (txtSaldo.Text != "") && (txtNro.Text != ""))
            {
                int numero, saldo;
                string inicio, termino;
                try
                {
                    inicio = (string)dateTimePicker1.Value.ToString();
                    termino = (string)dateTimePicker2.Value.ToString();
                    numero = int.Parse(txtNro.Text);
                    saldo = int.Parse(txtSaldo.Text);

                    this.c.Abrir();
                    Movil m = new Movil(numero, saldo, false, inicio, termino);
                    string instruccion = "sp_insertaMovil";
                    queryInsert = new SqlCommand(instruccion, this.c.miConexion);

                    queryInsert.CommandType = CommandType.StoredProcedure;
                    queryInsert.Parameters.AddWithValue("@num", m.miNumero);
                    queryInsert.Parameters.AddWithValue("@saldo", m.miSaldo);
                    queryInsert.Parameters.AddWithValue("@estado", m.miEstado);
                    queryInsert.Parameters.AddWithValue("@rutCliente", txtRutC.Text);
                    queryInsert.Parameters.AddWithValue("@inicio", m.miInicio);
                    queryInsert.Parameters.AddWithValue("@termino", m.miTermino);
                    /*
                    MessageBox.Show(m.miInicio);
                    MessageBox.Show(m.miTermino);
                    MessageBox.Show("x" + m.miNumero);
                    MessageBox.Show("x" + m.miSaldo);
                    MessageBox.Show("s" + m.miEstado);
                    */
                    SqlParameter returnValueParam = queryInsert.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    queryInsert.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;

                    if (returnValue == 1)
                    {
                        MessageBox.Show("Movil y Cliente Asociados correctamente");
                        this.cargarMovil();
                    }
                    else
                    {
                        MessageBox.Show("Error, el cliente no existe, o el numero ya esta asociado");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.LineNumber);
                }
                finally
                {
                    this.c.Cerrar();
                }

            }
            else
            {
                MessageBox.Show("Faltan datos en el formulario");
            }
        }
        public void cargarDesviados()
        {
            this.c.Abrir();
            try
            {
                string consultax = " select movil.numeromovil,movil.rutCliente,movil.estado ,movil.saldo,desvios.numeroDesvia"  
             + " from movil,desviados2,desvios where"
             + " movil.numeromovil = desviados2.idMovil and desviados2.idMovil = desvios.numeroRecibe ";

              /*select  numeromovil,saldo,rutCliente as 'Abonado',inicio as 'rige desde',termino 'fenece al',estado as 'Estado',numeroDesvia from movil*/

                daDesvio = new SqlDataAdapter(consultax, this.c.miConexion);
                dsDesvio = new DataSet();
                daDesvio.Fill(dsDesvio, "Movil");
                dgvDesvios.DataSource = dsDesvio;
                dgvDesvios.DataMember = "Movil";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }
        public void cargarMovil()
        {

            this.c.Abrir();
            try
            {
                string consulta = " select  numeromovil,saldo,rutCliente as 'Abonado',inicio as 'rige desde',termino 'fenece al',estado as 'Estado'from movil";
                  /*  "select movil.numeromovil,movil.rutCliente,movil.estado ,movil.saldo,desvios.numeroDesvia"  
               + " from movil,desviados2,desvios where"
               + " movil.numeromovil = desviados2.idMovil and desviados2.idMovil = desvios.numeroRecibe ";
                /*select  numeromovil,saldo,rutCliente as 'Abonado',inicio as 'rige desde',termino 'fenece al',estado as 'Estado',numeroDesvia from movil*/            
                
                daMovil = new SqlDataAdapter(consulta, this.c.miConexion);
                dsMovil = new DataSet();
                daMovil.Fill(dsMovil, "Desvio");
                dgvMovil.DataSource = dsMovil;
                dgvMovil.DataMember = "Desvio";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }
        public void buscarMovil()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            if (txtNro.Text!= "")
            {

                try
                {
                    this.c.Abrir();
                    SqlCommand consultar = new SqlCommand("select * from movil where numeromovil = " + (int)int.Parse(txtNro.Text), c.miConexion);
                    myReader = consultar.ExecuteReader();

                    while (myReader.Read())
                    {
                        
                        txtRutC.Text = myReader["rutCliente"].ToString();
                        txtNro.Text = myReader["numeromovil"].ToString();
                        txtNro.Enabled = false;
                        txtSaldo.Text = myReader["saldo"].ToString();
                        /*
                        string date = "01/08/2008";
                        DateTime dt = Convert.ToDateTime(date);
                        Console.WriteLine("Year: {0}, Month: {1}, Day: {2}", dt.Year, dt.Month, dt.Day);

                        // Specify exactly how to interpret the string.
                        IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

                        // Alternate choice: If the string has been input by an end user, you might  
                        // want to format it according to the current culture: 
                        // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                        DateTime dt2 = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        */
                        //dateTimePicker1.Value = (DateTime)myReader["inicio"];
                        //dateTimePicker2.Value = (DateTime)myReader["termino"];
             
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.StackTrace); 
                }
                finally
                {
                    this.c.Cerrar();
                    myReader.Close();
                }
            }
            else
            {
                if (txtNro.Text == "")
                {
                    MessageBox.Show("debe llenar el campo numero,para cargar");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.buscarMovil();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNro.Text = "";
            txtRutC.Text = "";
            txtSaldo.Text = "";
            txtNro.Enabled = true;
            dateTimePicker2.Enabled = true;
            dateTimePicker1.Enabled = true;
        }
        public void ActualizarMovil()
        {
            int returnValue;
            MessageBox.Show("por asuntos internos, no se puede modificar la fecha vigente del primer saldo, solo restaurar cantidad");
            try
            {
                this.c.Abrir();
                txtNro.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                int saldo = (int)int.Parse(txtSaldo.Text);
                int numero = (int)int.Parse(txtNro.Text);
                Movil m = new Movil(numero,saldo);
                string instruccion = "sp_actualizaMovil";

                queryInsert = new SqlCommand(instruccion, this.c.miConexion);

                queryInsert.CommandType = CommandType.StoredProcedure;
                queryInsert.Parameters.AddWithValue("@numeromovil", m.miNumero);
                queryInsert.Parameters.AddWithValue("@saldo", m.miSaldo);
                queryInsert.Parameters.AddWithValue("@rutCliente",txtRutC.Text);

                SqlParameter returnValueParam = queryInsert.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                queryInsert.ExecuteNonQuery();
                returnValue = (int)returnValueParam.Value;

                if (returnValue == 1)
                {
                    MessageBox.Show("Movil actualizado correctamente");
                    this.cargarMovil();
                }
                else
                {
                    MessageBox.Show("Error, el numero ingresado no esta vigente o el rut de abonado existe");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
                queryInsert = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((txtNro.Text != ""))
            {
                this.ActualizarMovil();
                this.cargarMovil();
            }
        }

        private void btnCrearTarifa_Click(object sender, EventArgs e)
        {
            int returnValue;
            if (txtCodTarifa.Text != "")
            {
                try
                {
                    this.c.Abrir();
                    string fechainicio = (string)dateTimePickerTarifa1.Value.ToString();
                    string fechatermino = (string)dateTimePickerTarifa2.Value.ToString();
                    int codigo = (int)int.Parse(txtCodTarifa.Text);
                    float coste = (float)float.Parse(maskedtxtCoste.Text);

                    tarifa t = new tarifa(txtNbTarifa.Text, codigo, fechainicio, fechatermino, coste);
                    string instruccion = "sp_insertaTarifa";

                    queryInsert = new SqlCommand(instruccion, this.c.miConexion);

                    queryInsert.CommandType = CommandType.StoredProcedure;
                    queryInsert.Parameters.AddWithValue("@codigo", t.miCodigo);
                    queryInsert.Parameters.AddWithValue("@coste", t.miCoste);
                    queryInsert.Parameters.AddWithValue("@inicio", t.miInicio);
                    queryInsert.Parameters.AddWithValue("@termino", t.miTermino);
                    queryInsert.Parameters.AddWithValue("@nombre", t.miNombre);

                    SqlParameter returnValueParam = queryInsert.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    queryInsert.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;

                    if (returnValue == 1)
                    {
                        MessageBox.Show("Tarifa Creada exitosamente");
                        this.cargarMovil();
                    }
                    else
                    {
                        MessageBox.Show("Error, la tarifa mencionada ya existe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    this.c.Cerrar();
                    queryInsert = null;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar el formulario de ingreso");
            }

        }

        private void btnLimpiarTarifa_Click(object sender, EventArgs e)
        {
            txtCodTarifa.Text = "";
            txtNbTarifa.Text = "";
            maskedtxtCoste.Text = "";
        }
        public void habilitarPanel(bool valor)
        {
            panelSms.Visible = valor;
            panelCell.Visible = valor;
        }
        public void cargarMenuCliente()
        {
            int returnValue;
            if ((txtNroAbonado.Text != "") && (txtRutAbonado.Text != ""))
            {
                try
                {

                    this.c.Abrir();
                    string instruccion = "sp_consultaExisteAbonado";

                    querySelect = new SqlCommand(instruccion, this.c.miConexion);

                    querySelect.CommandType = CommandType.StoredProcedure;
                    querySelect.Parameters.AddWithValue("@rutCliente", txtRutAbonado.Text);
                    querySelect.Parameters.AddWithValue("@numero", int.Parse(txtNroAbonado.Text));

                    SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    querySelect.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;

                    if (returnValue == 1)
                    {
                        MessageBox.Show("Cargando menu...");
                        Form1.numMovil = (int)int.Parse(txtNroAbonado.Text);
                        Form1.rutAbonado = txtRutAbonado.Text;
                        this.guardarHistorial("login al sistema");
                        this.habilitarPanel(true);
                        this.entregarSaldo();
                        this.cargarEnviados();
                        this.cargarRecibidos();
                    }
                    else
                    {
                        MessageBox.Show("Error, no existe movil asociado a este rut");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    this.c.Cerrar();
                    querySelect = null;
                }
            }
            else
            {
                MessageBox.Show("no puede cargar menu si no conoce los datos");
            }
        }

        private void btnHabilitarMenu_Click(object sender, EventArgs e)
        {
            this.cargarMenuCliente();
        }
        public void cargarCombos()
        {
           /* try
            {
                DataTable tablaTipos = new DataTable();

                String query = "select * from tarifas";

                SqlCommand consultarTipo = new SqlCommand(query, this.c.miConexion);

                SqlDataAdapter DaTipos = new SqlDataAdapter(consultarTipo);
                DaTipos.Fill(tablaTipos);
                //comboPlan.DataSource = tablaTipos;
                //comboPlan.DisplayMember = "nombreTarifa";
                //comboPlan.ValueMember = "idtarifa";
                tabSms.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
            * */
        }
        public void Encender()
        {
            int returnValue;
            try
            {
                this.c.Abrir();
                string instruccion = "spVerificaEstado";

                querySelect = new SqlCommand(instruccion, this.c.miConexion);

                querySelect.CommandType = CommandType.StoredProcedure;
                querySelect.Parameters.AddWithValue("@numMovil", Form1.numMovil);

                SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                querySelect.ExecuteNonQuery();
                returnValue = (int)returnValueParam.Value;

                if (returnValue == 1)
                {
                    MessageBox.Show("Encendido ok");
                    if (panelSms.Visible == false)
                    {
                        panelSms.Visible = true;
                        tabSms.Visible = true;
                    }
                }
                if (returnValue == 0)
                {
                    MessageBox.Show("Equipo ya esta encendido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
            }
        }
        public void Apagar()
        {
            int returnValue;
            try
            {
                this.c.Abrir();
                string instruccion = "sp_verificaEstado2";

                querySelect = new SqlCommand(instruccion, this.c.miConexion);

                querySelect.CommandType = CommandType.StoredProcedure;
                querySelect.Parameters.AddWithValue("@numMovil", Form1.numMovil);
                SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                querySelect.ExecuteNonQuery();
                returnValue = (int)returnValueParam.Value;

                if (returnValue == 1)
                {
                    MessageBox.Show("Apagado ok");
                    if (panelCell.Visible == true)
                    {
                        panelSms.Visible = false;
                        tabSms.Visible = false;
                    }
                }
                if (returnValue == 0)
                {
                    MessageBox.Show("Equipo ya esta Apagado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
            }
        }
        private void clickOn(object sender, MouseEventArgs e)
        {
            if (radioOn.Checked)
            {
                this.Encender();
            }
        }

        private void clickOff(object sender, EventArgs e)
        {
            if (radioOff.Checked)
            {
                this.Apagar();
            }
        }
        public void entregarSaldo()
        {
            this.c.Abrir();
           
                try
                {
                    SqlCommand consultar = new SqlCommand("select saldo from movil where numeromovil= " + Form1.numMovil, c.miConexion);
                    myReader = consultar.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtSald.Text = myReader["saldo"].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace); }
                finally
                {
                    this.c.Cerrar();
                    myReader.Close();
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNroDesvio.Text != Form1.numMovil.ToString())
            {
                int returnValue;
                try
                {
                    this.c.Abrir();
                    string instruccion = "sp_desviaNumero";

                    querySelect = new SqlCommand(instruccion, this.c.miConexion);

                    querySelect.CommandType = CommandType.StoredProcedure;
                    querySelect.Parameters.AddWithValue("@numDesvia", (int)int.Parse(txtNroDesvio.Text));
                    querySelect.Parameters.AddWithValue("@numOrigen", Form1.numMovil);
                    SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    querySelect.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;

                    if (returnValue == 1)
                    {
                        MessageBox.Show("Desvio realizado al :" + txtNroDesvio.Text);
                        
                    }
                    if (returnValue == 2)
                    {
                        MessageBox.Show("Desvio realizado al :" + txtNroDesvio.Text);
                    }
                    if (returnValue == 22)
                    {
                        MessageBox.Show("Desvios ciclicos no estan permitidos");
                        this.cargarHisto();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    
                }
                finally
                {
                    this.c.Cerrar();
                }
            }
            else
            {
                this.c.Abrir();
                MessageBox.Show("no puedes desviar al mismo numero");
                int returnValuex;
                string instruccionx = "sp_registroHistorial";
                querySelect = new SqlCommand(instruccionx, this.c.miConexion);
                querySelect.CommandType = CommandType.StoredProcedure;
                querySelect.Parameters.AddWithValue("@numero", Form1.numMovil);
                querySelect.Parameters.AddWithValue("@accion", "Desvio al mismo numero movil");
                SqlParameter returnValueParamx = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnValueParamx.Direction = ParameterDirection.ReturnValue;
                querySelect.ExecuteNonQuery();
                returnValuex = (int)returnValueParamx.Value;

                if (returnValuex == 1)
                {
                    MessageBox.Show("Se ha creado un registro de error");
                    this.cargarHisto();
                }
                this.c.Cerrar();
            }
        }

        private void btnSms_Click(object sender, EventArgs e)
        {
            int returnValue;

        if((richTxtcuerpo.Text !="")&&(txtDestino.Text!="")){
            try
            {
                this.c.Abrir();
                string instruccion = "sp_creaSms";

                querySelect = new SqlCommand(instruccion, this.c.miConexion);

                querySelect.CommandType = CommandType.StoredProcedure;
                Mensajes m = new Mensajes(richTxtcuerpo.Text, (int)int.Parse(txtDestino.Text), Form1.numMovil); 
                querySelect.Parameters.AddWithValue("@contenido", m.miContenido);
                querySelect.Parameters.AddWithValue("@destino",m.miDestino);
                querySelect.Parameters.AddWithValue("@numMovil",m.miOrigen );

                SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                returnValueParam.Direction = ParameterDirection.ReturnValue;
                querySelect.ExecuteNonQuery();
                returnValue = (int)returnValueParam.Value;

                if (returnValue == 1)
                {
                    MessageBox.Show("Sms Enviado con exito");
                    this.entregarSaldo();
                    this.cargarEnviados();
                }
                if (returnValue == 22)
                {
                    int returnValuex;
                    MessageBox.Show("No es posible enviar al mismo numero");
                    string instruccionx = "sp_registroHistorial";

                    querySelect = new SqlCommand(instruccionx, this.c.miConexion);

                    querySelect.CommandType = CommandType.StoredProcedure;
 
                    querySelect.Parameters.AddWithValue("@numero",Form1.numMovil);
                    querySelect.Parameters.AddWithValue("@accion", "envio sms al mismo numero");
                    SqlParameter returnValueParamxx = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                    returnValueParamxx.Direction = ParameterDirection.ReturnValue;
                    querySelect.ExecuteNonQuery();
                    returnValuex = (int)returnValueParamxx.Value;
               
                    if (returnValuex == 1)
                    {
                        MessageBox.Show("Se ha creado un registro de error");
                    }
                    this.cargarEnviados();
                    this.cargarHisto();
                }
                else
                {
                    MessageBox.Show("Error al enviar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }else{
            MessageBox.Show("Favor llenar cuerpo y destino");
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int returnValue;
            try
            {
                 this.c.Abrir();
                    string instruccion = "sp_eliminaDesvios";

                    querySelect = new SqlCommand(instruccion, this.c.miConexion);

                    querySelect.CommandType = CommandType.StoredProcedure;
                    querySelect.Parameters.AddWithValue("@num", Form1.numMovil);
                    SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);

                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    querySelect.ExecuteNonQuery();
                    returnValue = (int)returnValueParam.Value;

                    if (returnValue == 1)
                    {
                        MessageBox.Show("Desvioos eliminados");
                        
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }
        public void cargarEnviados()
        {
            try
            {
                string consulta = "select fecha as 'Enviado el',contenido,destino from mensaje where numMovil = " + Form1.numMovil
                +" order by fecha desc ";
                daSms = new SqlDataAdapter(consulta, this.c.miConexion);
                dsSms = new DataSet();
                daSms.Fill(dsSms, "mensaje");
                dgvSmsEnviados.DataSource = dsSms;
                dgvSmsEnviados.DataMember = "mensaje";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }

        }
        public void cargarRecibidos()
        {
            try
            {
                string consulta = "select fecha as 'Recibido el',contenido,destino from mensaje where destino = " + Form1.numMovil +
                    " order by fecha desc";
                daSmsr = new SqlDataAdapter(consulta, this.c.miConexion);
                dsSmsr = new DataSet();
                daSmsr.Fill(dsSmsr, "mensajex");
                dgvSmsRecibidos.DataSource = dsSmsr;
                dgvSmsRecibidos.DataMember = "mensajex";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            int returnValue;
            try
            {
                this.c.Abrir();
                string instruccion = "spRecarga";
                int cantidadx = (int)int.Parse(txtCantidad.Text.ToString());
                int destinox = (int)int.Parse(txtDestinoR.Text.ToString());

                querySelect = new SqlCommand(instruccion, this.c.miConexion);
                querySelect.CommandType = CommandType.StoredProcedure;
                querySelect.Parameters.AddWithValue("@cantidad",cantidadx); //txtCantidad, txtDestinoR
                querySelect.Parameters.AddWithValue("@destino",destinox);

                SqlParameter returnValueParam = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnValueParam.Direction = ParameterDirection.ReturnValue;
                querySelect.ExecuteNonQuery();

                returnValue = (int)returnValueParam.Value;
                if (returnValue == 1)
                {
                    MessageBox.Show("Se recargo saldo correctamente al numero : " + txtDestinoR.Text);
                    this.cargarRecibidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }

        private void nro(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void letra(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnConsultarx_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.Abrir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }
        public void cargarHisto()
        {
            this.c.Abrir();
            try
            {
                string consultaxx = " select * from Historial";

                /*select  numeromovil,saldo,rutCliente as 'Abonado',inicio as 'rige desde',termino 'fenece al',estado as 'Estado',numeroDesvia from movil*/

                daHisto = new SqlDataAdapter(consultaxx, this.c.miConexion);
                dsHisto = new DataSet();
                daHisto.Fill(dsHisto, "Historial");
                dgvHistorial.DataSource = dsHisto;
                dgvHistorial.DataMember = "Historial";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.c.Abrir();

            try
            {
                string consulta;

                int numero = (int)int.Parse(txtConsultar.Text);
                consulta = " select count(*) destino from mensaje where mensaje.destino = " + numero;

                SqlCommand consultar = new SqlCommand(consulta, this.c.miConexion);
                myReader2 = consultar.ExecuteReader();

                while (myReader2.Read())
                {
                    txtSmsEnviado.Text = myReader2["destino"].ToString();

                }

                string consultax;
                myReader2.Close();
                myReader2 = null;

                consultax = " select count(*) numeromovil " +
                "from Historial where Historial.numeromovil = " + numero;

                SqlCommand consultarx = new SqlCommand(consultax, this.c.miConexion);
                myReader2 = consultarx.ExecuteReader();

                while (myReader2.Read())
                {
                    txtErrores.Text = myReader2["numeromovil"].ToString();
                }
                myReader2.Close();
                myReader2 = null;

                consultax = " select count(*) contenido " +
                "from mensaje where mensaje.numMovil = " + numero + " and"
                + " mensaje.contenido = 'Saldo Recargado con exito'";

                SqlCommand consultarxx = new SqlCommand(consultax, this.c.miConexion);
                myReader2 = consultarxx.ExecuteReader();

                while (myReader2.Read())
                {
                    txtRecargas.Text = myReader2["contenido"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                this.c.Cerrar();
                myReader2.Close();
            }
           
        }
        public void guardarHistorial(string evento)
        {
            int returnValuex;
            string instruccionx = "sp_registroHistorial";

            querySelect = new SqlCommand(instruccionx, this.c.miConexion);

            querySelect.CommandType = CommandType.StoredProcedure;

            querySelect.Parameters.AddWithValue("@numero",Form1.numMovil);
            querySelect.Parameters.AddWithValue("@accion", evento);
            SqlParameter returnValueParamxx = querySelect.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            returnValueParamxx.Direction = ParameterDirection.ReturnValue;
            querySelect.ExecuteNonQuery();
            returnValuex = (int)returnValueParamxx.Value;

            if (returnValuex == 1)
            {
                MessageBox.Show("Se ha creado un registro en el historial");
            }
            this.cargarEnviados();
            this.cargarHisto();
        }

           //desde aca empieza el final de la clase, no tocar
        }  
    }

    


