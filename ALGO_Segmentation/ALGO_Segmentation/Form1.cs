using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGO_Segmentation
{
    public partial class Form1 : Form
    {
        private List<Point> ListPoints;
        private List<Cluster> ListClusters; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListPoints = new List<Point>();
            ListClusters = new List<Cluster>();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ListPoints.Add(new Point(e.X, e.Y));

            panel1.Invalidate(true);   // forcer le refresh du panel
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            pen = new Pen(Color.Red);

            foreach(Point p in ListPoints)
            {
                Rectangle rect;
                rect = new Rectangle(p.X-2, p.Y-2, 4, 4);

                e.Graphics.DrawEllipse(pen, rect);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach(Point p in ListPoints)
            for(int i=0;i<ListPoints.Count;i++)
            {
                ListClusters.Add(new Cluster
                {
                    ListIndexPoints = new List<int>() { i },
                    CenterX = ListPoints[i].X,
                    CenterY = ListPoints[i].Y
                }) ;
            }
            //chercher 
             for (int i = 0; i < ListPoints.Count ; i++)
            {
                for (int j = 0; j < ListPoints.Count; j++)
                {
                    Math.Sqrt(Math.Pow(ListPoints[i].X - ListPoints[j].X, 2) - Math.Pow(ListPoints[i].Y - ListPoints[j].Y, 2));
                }
            }
        }
    }
}
