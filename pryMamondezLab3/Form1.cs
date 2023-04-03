using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMamondezLab3
{
    public partial class Form1 : Form
    {
        Paises p = new Paises();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            p.paises = Convert.ToInt32(txtPais);
            p.Buscar();
            if (p.paises==0)
            {
                MessageBox.Show("No existe el pais");
            }
            else
            {
                txtNombre.Text = p.Nombres;
                txtCapital.Text = p.capitales;
                    
            }

        }
    }
}
