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
        int vx = -5;
        int vy = -5;
        int iTime = 0;

        public Form1()
        {
            InitializeComponent();
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

            if ((pictureBox1.Left < cpos.X) && (pictureBox1.Right > cpos.X) && (pictureBox1.Top < cpos.Y) && (pictureBox1.Bottom > cpos.Y))
            {
                pictureBox1.Visible = false;
                timer1.Enabled = false;
            }

           

            pictureBox1.Left += vx;
            pictureBox1.Top += vy;
            if (pictureBox1.Left < 0)
            {
                vx =Math.Abs(vx);               
            }
            
            if(pictureBox1.Left>ClientSize.Width-pictureBox1.Width)
            {
                vx =-Math.Abs(vx);
            }
            
            
            if (pictureBox1.Top < 0)
            {
                vy =Math.Abs(vy);            
            }
           if(pictureBox1.Top>ClientSize.Height-pictureBox1.Height)
           {
               vy =-Math.Abs(vy);
           }
           
            
        }
    }
}
