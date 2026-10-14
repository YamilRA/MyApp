using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datos datos= new Datos();

            bool f = datos.Insertar(textBox1.Text, textBox2.Text, textBox3.Text, 
                maskedTextBox1.Text, textBox5.Text);

            if (f)

            {
                MessageBox.Show("Registro agregado correctamente");

                this.Close();
            } else{
                MessageBox.Show("Error al agregar el registro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
