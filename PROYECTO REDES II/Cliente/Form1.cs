using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        string respuesta;
        string envio;
        static string ip;
        string Dato;
        byte[] Bytes;
        string nombreCarpeta;
        string peticion;
        string archivo;
        public Form1()
        {
            InitializeComponent();
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            envio = textBox1.Text;
        }

        public static string enviarIP()
        {
            return ip;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ip = textBox2.Text;
            respuesta = Conexión.Conectar(envio);  

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ip = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreCarpeta = textBox3.Text;
            Paquete paquete = new Paquete("CrearC", nombreCarpeta);
            peticion = paquete.Serializar();
            Conexión.CrearCarpeta(peticion);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            archivo = openFileDialog1.FileName;
            label2.Text = label2.Text = archivo;
        }

        private void label2_Click(object sender, EventArgs e)
        {
     
        }
    }
}
