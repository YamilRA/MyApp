using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            updateMode = false;
        }

        public Form1(string nombre, string paterno, string materno,
            string telefono, string correo, int id)
        {
            InitializeComponent();
            textBox1.Text = nombre;
            textBox2.Text = paterno;
            textBox3.Text = materno;
            maskedTextBox1.Text = telefono;
            textBox5.Text = correo;
            button1.Text = "Actualizar";
            updateMode = true;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos = new Datos();
            if (updateMode == false)
            {
                bool f = datos.ejecutar("Insert Into Datos(nombre,apellido_p,apellido_m," +
                "telefono,correo)Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text
                + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "')");
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
                SqlCommand comando = new SqlCommand("Update Datos Set nombre=@nombre," +
                    "apellido_p=@apellido_p,apellido_m=@apellido_m,telefono=@telefono," +
                    "correo=@correo Where id=@id");
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", textBox1.Text);
                comando.Parameters.AddWithValue("@apellido_p", textBox2.Text);
                comando.Parameters.AddWithValue("@apellido_m", textBox3.Text);
                comando.Parameters.AddWithValue("@telefono", maskedTextBox1.Text);
                comando.Parameters.AddWithValue("@correo", textBox5.Text);
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

    }
}
