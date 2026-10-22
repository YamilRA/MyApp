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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyApp
{
    public partial class Form2 : Form
    {
        Datos datos;
        public Form2()
        {
            InitializeComponent();
        }

        private void ActualizarGrid()
        {
            datos = new Datos();
            DataSet ds = datos.Informacion("Select * from Datos");

            if (ds != null)
            {
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns[0].DataPropertyName = "id";
                dataGridView1.Columns[1].DataPropertyName = "nombre";
                dataGridView1.Columns[2].DataPropertyName = "apellido_p";
                dataGridView1.Columns[3].DataPropertyName = "apellido_m";
                dataGridView1.Columns[4].DataPropertyName = "telefono";
                dataGridView1.Columns[5].DataPropertyName = "correo";

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("No se pudo obtener la información de la base de datos.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 agregar = new Form1();
            agregar.Show();
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 actualizar = new Form1(
                dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            actualizar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
