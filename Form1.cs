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
        List<Persona> personas = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = personas.Count + 1;

            Persona persona = new Persona(
                id,
                textBox1.Text,
                maskedTextBox1.Text
            );

            personas.Add(persona);

            dataGridView1.Rows.Add(
                persona.Id,
                persona.Nombre,
                persona.Telefono
            );

            textBox1.Clear();
            maskedTextBox1.Clear();
        }
    }
}


