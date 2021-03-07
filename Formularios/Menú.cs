using Laboratorio_2_de_repaso.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_2_de_repaso
{
    public partial class Menú : Form
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vehiculoform vvehiculos = new vehiculoform();
            vvehiculos.Show();
            this.SetVisibleCore(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientesform vclientes= new clientesform();
            vclientes.Show();
            this.SetVisibleCore(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alquilerform valquier = new alquilerform();
            valquier.Show();
            this.SetVisibleCore(false);
        }
    }
}
