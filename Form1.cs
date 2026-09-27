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
            if (textBox1.Text == "")
            {
                MessageBox.Show("Campo nombre obligatorio");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Campo edad obligatorio");
            }

            if (radioButton1.Checked)
            {
                msj.Text = ("Sexo: Masculino");
            }
            else if (radioButton2.Checked)
            {
                msj.Text = ("Sexo: Femenino");
            }
            else if (radioButton3.Checked)
            {
                msj.Text = ("Sexo: Otro");
            }

            String nombre = textBox1.Text;
            String edad = textBox2.Text;

            if (radioButton1.Checked && checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, del sexo masculino con interes en Deportes, Musica y Lectura");
            }
            else if (radioButton1.Checked && checkBox1.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculino con interes en Deportes y Musica");
            }
            else if (radioButton1.Checked && checkBox1.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculiuno con interes en Deportes y Lectura");
            }
            else if (radioButton1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculino con interes en Musica y Lectura");
            }
            else if (radioButton1.Checked && checkBox1.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculino con interes en Deportes");
            }
            else if (radioButton1.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculino con interes en Musica");
            }
            else if (radioButton1.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, Sexo masculino con interes en Lectura");
            }
            else if (radioButton2.Checked && checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Deportes, Musica y Lectura");
            }
            else if (radioButton2.Checked && checkBox1.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Deportes y Musica");
            }
            else if (radioButton2.Checked && checkBox1.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años,sexo femenino con interes en Deportes y Lectura");
            }
            else if (radioButton2.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Musica y Lectura");
            }
            else if (radioButton2.Checked && checkBox1.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Deportes");
            }
            else if (radioButton2.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Musica");
            }
            else if (radioButton2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo femenino con interes en Lectura");
            }
            else if (radioButton3.Checked && checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Deportes, Musica y Lectura");
            }
            else if (radioButton3.Checked && checkBox1.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Deportes y Musica");
            }
            else if (radioButton3.Checked && checkBox1.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Deportes y Lectura");
            }
            else if (radioButton3.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Musica y Lectura");
            }
            else if (radioButton3.Checked && checkBox1.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Deportes");
            }
            else if (radioButton3.Checked && checkBox2.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Musica");
            }
            else if (radioButton3.Checked && checkBox3.Checked)
            {
                msj.Text = (nombre + " con edad de " + edad + " años, sexo otro con interes en Lectura");
            }

        }
    }
}
