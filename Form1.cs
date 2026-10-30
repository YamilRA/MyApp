using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        bool updateMode = false;
        int id;
        Datos datos;
        public Form1()
        {
            InitializeComponent();
            CargarEstados();
            updateMode = false;
        }

        public Form1(string nombre, string paterno, string materno,
            string telefono, string correo, int id, int estado, int municipio)
        {
            InitializeComponent();
            CargarEstados();

            textBox1.Text = nombre;
            textBox2.Text = paterno;
            textBox3.Text = materno;
            maskedTextBox1.Text = telefono;
            textBox5.Text = correo;
            comboBox1.SelectedValue = estado;
            comboBox2.SelectedValue = municipio;
            button1.Text = "Actualizar";
            updateMode = true;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos = new Datos();
            if (updateMode == false)
            {
                bool f = datos.ejecutar("Insert Into Datos.Alumnos(nombre,apellido_p,apellido_m," +
                "telefono,correo,estado_id,municipio_id)Values('" + textBox1.Text + "','" + textBox2.Text + "'," +
                "'" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" +
                comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "')");
                if (f)
                {
                    MessageBox.Show("Registro agregado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar el registro");
                }
            }
            else
            {
                SqlCommand comando = new SqlCommand(
            "UPDATE Datos.Alumnos SET nombre=@nombre, apellido_p=@apellido_p, apellido_m=@apellido_m, " +
            "telefono=@telefono, correo=@correo, estado_id=@estado_id, municipio_id=@municipio_id " +
            "WHERE id=@id");
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", textBox1.Text);
                comando.Parameters.AddWithValue("@apellido_p", textBox2.Text);
                comando.Parameters.AddWithValue("@apellido_m", textBox3.Text);
                comando.Parameters.AddWithValue("@telefono", maskedTextBox1.Text);
                comando.Parameters.AddWithValue("@correo", textBox5.Text);
                comando.Parameters.AddWithValue("@estado_id", comboBox1.SelectedValue ?? DBNull.Value);
                comando.Parameters.AddWithValue("@municipio_id", comboBox2.SelectedValue ?? DBNull.Value);
                bool f = datos.ejecutar(comando);
                if (f)
                {
                    MessageBox.Show("Registro actualizado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarEstados()
        {
            datos = new Datos();
            DataSet ds = datos.Informacion("SELECT id, Nombre FROM Ubicacion.Estados");

            if (ds != null && ds.Tables.Count > 0)
            {
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.SelectedIndex = -1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int estadoId))
            {
                CargarMunicipios(estadoId);
            }
        }

        private void CargarMunicipios(int estadoId)
        {
            datos = new Datos();
            DataSet ds = datos.Informacion("SELECT id, Nombre FROM Ubicacion.Municipios WHERE Estado_id = " + estadoId);

            if (ds != null && ds.Tables.Count > 0)
            {
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "id";
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.SelectedIndex = -1;
            }
        }


    }
}
