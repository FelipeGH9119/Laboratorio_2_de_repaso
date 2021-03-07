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
    public partial class vehiculoform : Form
    {
        List<Vehículos> vehiculos = new List<Vehículos>();
        string archivo2 = "vehículos.txt";
        public vehiculoform()
        {
            InitializeComponent();
        }

        public void guardar()
        {
            FileStream stream = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < vehiculos.Count; i++)
            {
                writer.WriteLine(vehiculos[i].Placa);
                writer.WriteLine(vehiculos[i].Marca);
                writer.WriteLine(vehiculos[i].Modelo);
                writer.WriteLine(vehiculos[i].Color);
                writer.WriteLine(vehiculos[i].Precio_kilometro);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Vehículos tempvehiculos = new Vehículos();
                tempvehiculos.Placa = reader.ReadLine();
                tempvehiculos.Marca = reader.ReadLine();
                tempvehiculos.Modelo= reader.ReadLine();
                tempvehiculos.Color = reader.ReadLine();
                tempvehiculos.Precio_kilometro = float.Parse(reader.ReadLine());
                vehiculos.Add(tempvehiculos);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            comboBox1.Text = null;
            textBox5.Text = null;
        }


        // url = https
        private int verificar_repeticion(string placa) // retorna 1 si se encuentra en la lista
        {
            int resultado = 0;
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].Placa.Contains(placa))
                   resultado = 1;
            }
            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {

                Vehículos tempvehiculo = new Vehículos();
                tempvehiculo.Placa = textBox1.Text;
                tempvehiculo.Marca = textBox2.Text;
                tempvehiculo.Modelo = textBox3.Text;
                tempvehiculo.Color = comboBox1.Text;
                tempvehiculo.Precio_kilometro = float.Parse(textBox5.Text);

                if (verificar_repeticion(textBox1.Text) != 1)
                {
                    vehiculos.Add(tempvehiculo);
                    guardar();
                    limpiar();
                    MessageBox.Show("Vehiculo agregado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pueden agregar vehiculos repetidos en la base de datos");
                }

               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menú vmenu = new Menú();
            vmenu.Show();
            this.SetVisibleCore(false);
        }
       
        private void vehiculoform_Load(object sender, EventArgs e)
        {
            leer_datos();
        }
    }
}
