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

namespace Laboratorio_2_de_repaso.Formularios
{
    public partial class alquilerform : Form
    {
        List<Clientes> clientes = new List<Clientes>();
        string archivo1 = "clientes.txt";
        List<Vehículos> vehiculos = new List<Vehículos>();
        string archivo2 = "vehículos.txt";
        public alquilerform()
        {
            InitializeComponent();
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
            reader.Close();


            FileStream stream2 = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Vehículos tempvehiculos = new Vehículos();
                tempvehiculos.Placa = reader2.ReadLine();
                tempvehiculos.Marca = reader2.ReadLine();
                tempvehiculos.Modelo = reader2.ReadLine();
                tempvehiculos.Color = reader2.ReadLine();
                tempvehiculos.Precio_kilometro = float.Parse(reader2.ReadLine());
                vehiculos.Add(tempvehiculos);

            }
            reader2.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Menú vmenu = new Menú();
            vmenu.Show();
            this.SetVisibleCore(false);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        void mostrar()
        {
            comboBox1.DisplayMember = "Nit";
            comboBox1.ValueMember= "";
            comboBox1.DataSource = null;
            comboBox1.DataSource = clientes;
            comboBox1.Refresh();

            comboBox2.ValueMember = "Placa";
            comboBox2.DataSource=null;
            comboBox2.DataSource = vehiculos;

        }
        private void alquilerform_Load(object sender, EventArgs e)
        {
            leer_datos();

            mostrar();
       //     Vehículos vehiculo = vehiculos.Find(v =>v.Placa)
            //clase objeto = lista_a_buscar.Find(v =>v.(la columna/variable a buscar))
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
