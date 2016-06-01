using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grap
{
    public partial class Form1 : Form
    {
        
        //Variables
        public struct PAC
        {
            public Rectangle pos;
            public bool over;
            public Size size;
        }//Структура точки
        Graphics grf;
        Point[] BPA = new Point[4];
        PAC[] PAP = new PAC[4];
        int PointIndex;
        Pen p = new Pen(Color.Blue, 1);
        Pen p1 = new Pen(Color.GreenYellow, 1);
        SolidBrush bb = new SolidBrush(Color.Blue);
        SolidBrush rb = new SolidBrush(Color.Red);
        public BufferedGraphics bufferedGraphics;
        public BufferedGraphicsContext bufferedGraphicsContext;
        bool selected = false;

        public Form1()
        {
            InitializeComponent();
            Build_Points_Array();
            grf = panel1.CreateGraphics();
            bufferedGraphicsContext = BufferedGraphicsManager.Current;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Отображение начального графика
            DrawTOBuffer();
            bufferedGraphics.Render();
        }

        //Заполнение массива точек
        private void Build_Points_Array()
        {
            //Массив для вывода кривой Безье
            BPA[0].X = 10;
            BPA[0].Y = 10;
            BPA[1].X = 300;
            BPA[1].Y = 10;
            BPA[2].X = 300;
            BPA[2].Y = 300;
            BPA[3].X = 590;
            BPA[3].Y = 300;
            //Массив для вывода точек
            PAP[0].pos.X = BPA[0].X - 3;
            PAP[0].pos.Y = BPA[0].Y - 3;
            PAP[0].over = false;
            PAP[0].pos.Size = new Size(6, 6);
            PAP[1].pos.X = BPA[1].X - 3;
            PAP[1].pos.Y = BPA[1].Y - 3;
            PAP[1].over = false;
            PAP[1].pos.Size = new Size(6, 6);
            PAP[2].pos.X = BPA[2].X - 3;
            PAP[2].pos.Y = BPA[2].Y - 3;
            PAP[2].over = false;
            PAP[2].pos.Size = new Size(6, 6);
            PAP[3].pos.X = BPA[3].X - 3;
            PAP[3].pos.Y = BPA[3].Y - 3;
            PAP[3].over = false;
            PAP[3].pos.Size = new Size(6, 6);
        }
                
        //Нахождение сфокусированной точки
        private void FindPointIndex()
        {
            for (int i = 0; i < PAP.Length; i++)
            {
                Point mp = panel1.PointToClient(Cursor.Position);
                if (mp.X >= PAP[i].pos.X &&
                    mp.X <= PAP[i].pos.X + PAP[i].pos.Width &&
                    mp.Y >= PAP[i].pos.Y &&
                    mp.Y <= PAP[i].pos.Y + PAP[i].pos.Height)
                {
                    PAP[i].over = true;
                    PointIndex = i;
                }
                else
                {
                    PAP[i].over = false;
                }
            }
        }

        //Перемещение точки
        private void TransPoint(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mp = panel1.PointToClient(Cursor.Position);
                PAP[PointIndex].pos.X = mp.X - 3;
                PAP[PointIndex].pos.Y = mp.Y - 3;
                BPA[PointIndex].X = mp.X;
                BPA[PointIndex].Y = mp.Y;
            }
        }

        //Перемещение курсора при зажатой левой кнопки
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            FindPointIndex();
            if (e.Button == MouseButtons.Left && selected == true)
            {
                TransPoint(e);
            }
            DrawTOBuffer();
            bufferedGraphics.Render();
        }

        //Рисуем в буфере
        public void DrawTOBuffer()
        {
            bufferedGraphicsContext.MaximumBuffer = new Size(panel1.Width, panel1.Height);
            bufferedGraphics = bufferedGraphicsContext.Allocate(grf, new Rectangle(0, 0, this.Width, this.Height));
            bufferedGraphics.Graphics.Clear(Color.White);
            bufferedGraphics.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            bufferedGraphics.Graphics.DrawLine(p1, BPA[0], BPA[1]);
            bufferedGraphics.Graphics.DrawLine(p1, BPA[2], BPA[3]);
            bufferedGraphics.Graphics.DrawBezier(p, BPA[0], BPA[1], BPA[2], BPA[3]);
            for (int i = 0; i < PAP.Length; i++)
            {
                if (PAP[i].over == true)
                    bufferedGraphics.Graphics.FillEllipse(rb, PAP[i].pos);
                else
                    bufferedGraphics.Graphics.FillEllipse(bb, PAP[i].pos);
            }
        }//Хороший код 

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < PAP.Length; i++)
                {
                    if (PAP[i].over == true)
                    {
                        selected = true;
                        break;
                    }
                    else
                        selected = false;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selected = false;
            }
        }
    }
}
