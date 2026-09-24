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

namespace MyApp
{
    public partial class Form1 : Form
    {
        bool save = false;
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevo_Click_1(object sender, EventArgs e)
        {
            texto.Clear();
            texto.Focus();
            path = "";
            save = false;
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                save = true;
                texto.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                guardar.Enabled = false;
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (save == false)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    save = true;
                }

            }
            texto.SaveFile(path, RichTextBoxStreamType.PlainText);
            guardar.Enabled = false;
        }

        private void guardarcomo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                texto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardar.Enabled = true;
                save = true;
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
