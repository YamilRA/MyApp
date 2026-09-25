using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp
{
    public partial class Form1 : Form
    {
        bool save = false;
        string path;

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

        private void GuardarCSV()
        {
            using (StreamWriter sw = new StreamWriter(
                path,
                false,
                Encoding.UTF8))
            {

                foreach (Persona persona in personas)
                {
                    sw.WriteLine(
                        $"{persona.Id},{persona.Nombre},{persona.Telefono}"
                    );
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save == false)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    save = true;
                }
                else
                {
                    return;
                }
            }

            GuardarCSV();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                save = true;

                GuardarCSV();
            }
        }

    }
}
