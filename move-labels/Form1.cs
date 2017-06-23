using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace move_labels
{
    public partial class Form1 : Form
    {

        int[] vx = new int[3];
        int[] vy = new int[3];

       

        int iTime = 0;
        private static Random rand=new Random();

        public Form1()
        {
            InitializeComponent(); 
            
            vx[0]  = rand.Next(-5, 5);
            vy[0] = rand.Next(-5, 5);
            vx[1] = rand.Next(-20, 5);
            vy[1] = rand.Next(-5, 5);
            vx[2] = rand.Next(-10, 5);
            vy[2] = rand.Next(-5, 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iTime++;
            label4.Text = "" + iTime;
           

            // 2次元クラスPoint型の変数cposを宣言
            Point cpos;

            // cposに、マウスのフォーム座標を取り出す。
            //// MousePositionにマウス座標のスクリーン左上からのX、Yが入っている。
            //// PointToClient()を使うと、スクリーン座標を、フォーム座標に変換できる。
            cpos = PointToClient(MousePosition);

            // ラベルに座標を表示
            //// 変換したフォーム座標は、cpos.X、cpos.Yで取り出せる。
            label1.Text = "" + cpos.X + "," + cpos.Y;
            label2.Text = "" + MousePosition.X + "," + MousePosition.Y;
            
            //新しく作ったlabel3をマウスカーソルの場所に移動
            //かつマウスカーソルがラベルの中心を目指す
            //(オフセット、ピボット(pivot)などの概念)

            label3.Left = cpos.X-label3.Width/2;
            label3.Top = cpos.Y-label3.Height/2;

            if ((label1.Left < cpos.X) && (label1.Right > cpos.X) && (label1.Top < cpos.Y) && (label1.Bottom > cpos.Y))
            {
                //pictureBox1.Visible = false;
                //timer1.Enabled = false;
            }



            label1.Left = rand.Next(ClientSize.Width-label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);
            label1.Left += vx[0];
            label1.Top += vy[0];
            label5.Left += vx[1];
            label5.Top += vy[1];
            label6.Left += vx[2];
            label6.Top += vy[2];

            if (label1.Left < 0)
            {
                vx[0] =Math.Abs(vx[0]);               
            }
            
            if(label1.Left>ClientSize.Width-label1.Width)
            {
                vx[0] =-Math.Abs(vx[0]);
            }


            if (label1.Top < 0)
            {
                vy[0] =Math.Abs(vy[0]);            
            }
            if (label1.Top > ClientSize.Height - label1.Height)
           {
               vy[0] =-Math.Abs(vy[0]);
           }
            label6.Left = rand.Next(ClientSize.Width - label6.Width);
            label6.Top = rand.Next(ClientSize.Height - label6.Height);

            if (label6.Left < 0)
            {
                vx[1] = Math.Abs(vx[1]);
            }

            if (label6.Left > ClientSize.Width - label6.Width)
            {
                vx[1] = -Math.Abs(vx[1]);
            }


            if (label6.Top < 0)
            {
                vy[1] = Math.Abs(vy[1]);
            }
            if (label6.Top > ClientSize.Height - label6.Height)
            {
                vy[1] = -Math.Abs(vy[1]);
            }
            label5.Left = rand.Next(ClientSize.Width - label5.Width);
            label5.Top = rand.Next(ClientSize.Height - label5.Height);
            if (label5.Left < 0)
            {
                vx[2] = Math.Abs(vx[2]);
            }

            if (label5.Left > ClientSize.Width - label5.Width)
            {
                vx[2] = -Math.Abs(vx[2]);
            }


            if (label5.Top < 0)
            {
                vy[2] = Math.Abs(vy[2]);
            }
            if (label5.Top > ClientSize.Height - label5.Height)
            {
                vy[2] = -Math.Abs(vy[2]);
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //0以上 intの範囲内の乱数
            Text = "" + rand.Next();
            //サイコロの目の例
            Text += "," + ((rand.Next() % 6) + 1);
            //0以上、指定の値「未満」の乱数
            //以下は0～5までの乱数
            Text += "/" + rand.Next(6);

            //指定の値以上、指定の値「未満」の乱数
            //以下は、1～7までの乱数
            Text += "/" + rand.Next(1, 7);

            //0～1未満の乱数
            Text += "/" + rand.NextDouble();
            //NextDoubleを使って1～6の乱数を算出するには？

            Text="/"+ (int)(rand.NextDouble()*6+1);
        }
    }
}
