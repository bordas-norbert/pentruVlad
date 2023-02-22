using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nota_laborator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graf graf = new Graf();
            graf.DrawGraph(e.Graphics, pictureBox1);
            if(graf.isEulerian())
            {
                listBox1.Items.Add("Este eulerian");
            }
            else { listBox1.Items.Add("Nu este eulerian"); }
            graf.Hamiltonian(listBox1);
        }
    }
}
