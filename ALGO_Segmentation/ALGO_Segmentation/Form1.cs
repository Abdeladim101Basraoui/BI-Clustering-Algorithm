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
            Brush b = new SolidBrush(Color.Red);
            pen = new Pen(Color.Red);
            Rectangle rect;
            foreach (Point p in ListPoints)
            {
                
                rect = new Rectangle(p.X-2, p.Y-2, 4, 4);

                //e.Graphics.DrawEllipse(pen, rect);
                e.Graphics.FillEllipse(b, rect);
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
            double d;
            double dmin = Double.MaxValue;
            int imin = 0;
            int jmin = 0;
             for (int i = 0; i < ListPoints.Count ; i++)
            {
                for (int j = 0; j < ListPoints.Count; j++)
                {
                    d = Math.Sqrt(Math.Pow(ListPoints[i].X - ListPoints[j].X, 2) - Math.Pow(ListPoints[i].Y - ListPoints[j].Y, 2));
                    if(d<dmin)
                    {
                        dmin = d;
                        imin = i;
                        jmin = j;
                    }
                }
            }
             //----------center cluster 1-------//
            double centerX1 = ListClusters[imin].CenterX;
            double centerY1 = ListClusters[imin].CenterY;
            //-----------Center cluster 2------//
            double centerX2 = ListClusters[jmin].CenterX;
            double centerY2 = ListClusters[jmin].CenterY;
            //---------number of point imin in liste clusters------//
            double N1 = ListClusters[imin].ListIndexPoints.Count;
            //---------number of point in jmin of the 2nd cluster------//
            double N2 = ListClusters[jmin].ListIndexPoints.Count;
            
            Cluster C = new Cluster();
            C.ListIndexPoints = new List<int>() { };
            C.ListIndexPoints.AddRange(ListClusters[imin].ListIndexPoints) ;
            C.ListIndexPoints.AddRange(ListClusters[jmin].ListIndexPoints) ;
            //C.CenterX = (center1*N1 +center2*N2)/N1+N2;
            
        }
    }
}
