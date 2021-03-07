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

namespace Laboratorio_2_de_repaso
{
    public partial class clientesform : Form
    {
        //Listas
        List<Clientes> clientes = new List<Clientes>();
        string archivo1 = "clientes.txt";
        
        public clientesform()
        {
            InitializeComponent();
        }

        public void guardar()
        {
            FileStream stream = new FileStream(archivo1, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i< clientes.Count; i++)
            {
                writer.WriteLine(clientes[i].Nit);
                writer.WriteLine(clientes[i].Nombre);
                writer.WriteLine(clientes[i].Direccion);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Clientes tempcliente = new Clientes();
                tempcliente.Nit = reader.ReadLine();
                tempcliente.Nombre = reader.ReadLine();
                tempcliente.Direccion = reader.ReadLine();
                clientes.Add(tempcliente);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //declaramos un objeto cliente de la clase clientes
                Clientes tempcliente = new Clientes();
                tempcliente.Nit = textBox1.Text;
                tempcliente.Nombre = textBox2.Text;
                tempcliente.Direccion = textBox3.Text;
                //para asignarle los datos leidos del archivo
                clientes.Add(tempcliente);
                //luego guardar el tempcliente en la lista de clienters
                guardar();

                limpiar();
                MessageBox.Show("Cliente agregado correctamente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menú vmenu = new Menú();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void clientesform_Load(object sender, EventArgs e)
        {
            leer_datos();
        }
    }
}
