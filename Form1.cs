using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tienda objProductos = new Tienda();
            objProductos.grabar(Convert.ToInt32 (textBox1.Text), textBox2.Text,Convert.ToInt32 (textBox3.Text));//pasamos a grabar lo que hay en las txt
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tienda objProductos = new Tienda();
            objProductos.listar(dataGridView1);
            //int producto = 101;
            //string nombre = "TECLADO";
            //int stock = 11;

            //string sql = $"INSTERT INTO Productos VALUE ({producto}, '{nombre}', {stock})";//concatena todo con +",'"+
            ////interpolar: poner el $ antes de las comillas dobles para que el lenguaje tome el valor de las variables
            ////las variables van entre {} y las comillas simples van afuera de las llaves
            //MessageBox.Show(sql);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tienda objProductos = new Tienda();
            objProductos.eliminar(Convert.ToInt32(textBox1.Text));
        }
    }
}
