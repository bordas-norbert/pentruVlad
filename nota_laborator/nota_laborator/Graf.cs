using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace nota_laborator
{
    public class Graf
    {
        public static int[,] mat;
        public static List<PointF> puncte;
        public static int n;
        static public int size = 5;

        public int N { get { return n; } }
        public int[,] M { get { return mat; } }
        public Graf()
        {
            StreamReader file = new StreamReader("input.txt");
            string buffer;
            string[] noduri;
            n = int.Parse(file.ReadLine());
            mat = new int[n, n];
            int x, y;
            while((buffer = file.ReadLine()) != null)
            {
                noduri = buffer.Split(' ');
                x = int.Parse(noduri[0]);
                y = int.Parse(noduri[1]);
                mat[x, y] = mat[y, x] = 1;
            }
        }

        public void DrawGraph(Graphics g, PictureBox picturebox)
        {
            PointF punct = new PointF(0, 0);
            puncte = new List<PointF>();
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                punct.X = rnd.Next(10, picturebox.Width - 10);
                punct.Y = rnd.Next(10, picturebox.Height- 10);
                puncte.Add(punct);
                g.FillEllipse(Brushes.Black, punct.X-size, punct.Y-size, 2*size+1, 2*size+1);
                g.DrawString(Convert.ToString(i), new Font("Arial", 18, FontStyle.Regular), new SolidBrush(Color.Black), punct.X, punct.Y);
            }
            Pen p = new Pen(Color.PaleGoldenrod, 2);
            for(int i=0; i<n; i++)
                for(int j=0; j<n; j++)
                    if (mat[i,j] == 1)
                    {
                        g.DrawLine(p, puncte[i], puncte[j]);
                    }

        }

        public bool isEulerian()
        {
            int nrImpar = 0, s;
            for (int i = 0; i < n; i++)
            {
                s = 0;
                for (int j = 0; j < n; j++)
                    if (mat[i, j] == 1)
                        s++;
                if (s % 2 == 1)
                    nrImpar++;
            }

            return nrImpar <= 2;
        }

        public void Hamiltonian(ListBox l)
        {
            Hamilton ham = new Hamilton(this);
            if (ham.getPath.Count == 0)
            { l.Items.Add("Nu am gasit drum hamiltonian"); return; }
            foreach(int x in ham.getPath)
            l.Items.Add(x + " ");
        }
        
    }


}

