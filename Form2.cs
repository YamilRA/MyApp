using System;
using System.Data;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form2 : Form
    {
        Datos datos;

        private int filaSeleccionadaIndex = -1;
        private int columnaSeleccionadaIndex = -1;
        public Form2()
        {
            InitializeComponent();
        }

        private void ActualizarGrid()
        {
            datos = new Datos();

            string query = @"
        SELECT 
            A.id, 
            A.nombre, 
            A.apellido_p, 
            A.apellido_m, 
            A.telefono, 
            A.correo, 
            E.Nombre AS Estado, 
            M.Nombre AS Municipio 
        FROM Datos.Alumnos AS A
        LEFT JOIN Ubicacion.Estados AS E ON A.estado_id = E.id
        LEFT JOIN Ubicacion.Municipios AS M ON A.municipio_id = M.id";

            DataSet ds = datos.Informacion(query);

            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;

                if (dataGridView1.Columns.Count >= 8)
                {
                    dataGridView1.Columns[0].DataPropertyName = "id";
                    dataGridView1.Columns[1].DataPropertyName = "nombre";
                    dataGridView1.Columns[2].DataPropertyName = "apellido_p";
                    dataGridView1.Columns[3].DataPropertyName = "apellido_m";
                    dataGridView1.Columns[4].DataPropertyName = "telefono";
                    dataGridView1.Columns[5].DataPropertyName = "correo";
                    dataGridView1.Columns[6].DataPropertyName = "Estado";
                    dataGridView1.Columns[7].DataPropertyName = "Municipio";
                }

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
            agregar.ShowDialog();
            ActualizarGrid();
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = dataGridView1.SelectedRows.Count > 0;
            ActualizarGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView filaDatos = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                int idRegistro = Convert.ToInt32(filaDatos["id"]);
                int.TryParse(filaDatos["estado_id"]?.ToString(), out int estadoId);
                int.TryParse(filaDatos["municipio_id"]?.ToString(), out int municipioId);

                Form1 actualizar = new Form1(
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "",
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "",
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "",
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "",
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "",
                    idRegistro,
                    estadoId,
                    municipioId);

                actualizar.ShowDialog();
                ActualizarGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                filaSeleccionadaIndex = e.RowIndex;
                columnaSeleccionadaIndex = e.ColumnIndex;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadaIndex >= 0 && columnaSeleccionadaIndex >= 0)
            {
                DataRowView filaDatos = (DataRowView)dataGridView1.Rows[filaSeleccionadaIndex].DataBoundItem;

                int idRegistro = Convert.ToInt32(filaDatos["id"]);
                int.TryParse(filaDatos["estado_id"]?.ToString(), out int estadoId);
                int.TryParse(filaDatos["municipio_id"]?.ToString(), out int municipioId);

                Form1 actualizar = new Form1(
                    dataGridView1.Rows[filaSeleccionadaIndex].Cells[1].Value?.ToString() ?? "",
                    dataGridView1.Rows[filaSeleccionadaIndex].Cells[2].Value?.ToString() ?? "",
                    dataGridView1.Rows[filaSeleccionadaIndex].Cells[3].Value?.ToString() ?? "",
                    dataGridView1.Rows[filaSeleccionadaIndex].Cells[4].Value?.ToString() ?? "",
                    dataGridView1.Rows[filaSeleccionadaIndex].Cells[5].Value?.ToString() ?? "",
                    idRegistro,
                    estadoId,
                    municipioId);

                actualizar.ShowDialog();
                ActualizarGrid();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            {
                string textoCelda = dataGridView1.CurrentCell.Value.ToString();

                Clipboard.SetText(textoCelda);

                MessageBox.Show("Texto copiado al portapapeles: " + textoCelda,
                    "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La celda seleccionada está vacía.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
