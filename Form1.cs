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
using CsvHelper;
using System.Globalization;

namespace MyApp
{
    public partial class Form1 : Form
    {
        bool save = false;
        string path;
        List<Persona> registros = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    registros = csv.GetRecords<Persona>().ToList();
                }

                foreach (var registro in registros)
                {
                    dataGridView1.Rows.Add(
                        registro.id,
                        registro.name,
                        registro.email
                    );
                }
                button2.Visible = true;
            }
        }

        private void GuardarCSV(){
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("id,name,email");

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        string[] datos = new string[fila.Cells.Count];

                        for (int i = 0; i < fila.Cells.Count; i++)
                        {
                            datos[i] = fila.Cells[i].Value?.ToString() ?? "";
                        }

                        sw.WriteLine(string.Join(",", datos));
                    }
                }
                dataGridView1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuardarCSV();
        }

    }
}