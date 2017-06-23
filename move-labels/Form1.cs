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

        Label[] labels = new Label[3];
        private static Random rand=new Random();

        public Form1()
        {
            InitializeComponent(); 
            //vx,vyに乱数入れる
            //冗長(じょうちょう)だったコードをまとめることができた
            //冗長＝同じものが繰り返される
            int idx = 0;
            for (; idx < 3; idx++)
            {
                vx[idx] = rand.Next(-10, 10);
                vy[idx] = rand.Next(-10, 10);
            //ラベルを生成
            labels[idx] = new Label();
            labels[idx].AutoSize = true;//幅,高さ
            labels[idx].Text = "◆";
            //フォームに配置
            Controls.Add(labels[idx]);

            labels[idx].Left = rand.Next(ClientSize.Width-labels[idx].Width);
            labels[idx].Top = rand.Next(ClientSize.Height - labels[idx].Height);

            


            }
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

            for (int idx = 0; idx < 3; idx++)
            {
                labels[idx].Left += vx[idx];
                labels[idx].Top += vy[idx];

                if (labels[idx].Left < 0)
                {
                    vx[idx] = Math.Abs(vx[idx]);
                }

                if (labels[idx].Left > ClientSize.Width - labels[idx].Width)
                {
                    vx[idx] = -Math.Abs(vx[idx]);
                }


                if (labels[idx].Top < 0)
                {
                    vy[idx] = Math.Abs(vy[idx]);
                }
                if (labels[idx].Top > ClientSize.Height - labels[idx].Height)
                {
                    vy[idx] = -Math.Abs(vy[idx]);
                }


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

        private void button2_Click(object sender, EventArgs e)
        {
            for(int idx=0;idx<10;idx++)
            {
                MessageBox.Show("" + idx);
            }
        }
    }
}
