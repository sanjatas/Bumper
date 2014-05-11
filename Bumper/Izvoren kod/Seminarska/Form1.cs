using Seminarska.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminarska
{
    public partial class Bumper : Form
    {
        private CarsDoc CarsDoc;
        private LentiDoc LentiDoc;
        private DupkiDoc DupkiDoc;
        private int generirajKola;
        private Random random;
        private TextureBrush tba;
        private Bitmap biImg;
        Image img;
        public static int poeni;
        public static int bestScore;
        private int level;
        private int sekundi;
        private bool zgolemiLvl;
        private Budala jas = new Budala(new Point(135, 450));
        private bool clicked;
        private Sounds sounds;
        public Image eksplozija { get; set; }
        private Image zvukON;
        private Image zvukOFF;
        private bool ekplodiraj = false;
        private bool flag;
        private Image Kontroli;

        public Bumper()
        {
            InitializeComponent();
            Kontroli = Resources.kontrolii;
            flag = false;
            zvukON = Resources.soundON;
            zvukOFF = Resources.soundOFF;
            CarsDoc = new CarsDoc();
            LentiDoc = new LentiDoc();
            DupkiDoc = new DupkiDoc();
            generirajKola = 0;
            poeni = 0;
            level = 1;
            sekundi = 0;
            //asvalt
            img = Properties.Resources.Road2;
            biImg = new Bitmap(img);
            tba = new TextureBrush(biImg);
            clicked = true;

            sounds = new Sounds();

            DoubleBuffered = true;
            random = new Random();
            zgolemiLvl = false;
            bestScore = 0;
            eksplozija = Properties.Resources.explosion_;
            TextReader tr = new StreamReader("highscores.txt");
            lbHighScore.Text = tr.ReadLine() + "pts";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sekundi++;
            //lblSekundi.Text = sekundi + " sec";
            zgolemiLvl = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (generirajKola % 20 == 0)
            {
                int linija = random.Next(3);
                if (linija == 0)
                {
                    DupkiDoc.AddDupka(new Point(30, 0));
                }
                else if (linija == 1)
                {

                    DupkiDoc.AddDupka(new Point(120, 0));
                }
                else
                {
                    DupkiDoc.AddDupka(new Point(230, 0));
                }
            }
            if (generirajKola % 5 == 0)
            {
                LentiDoc.AddLenta(new Point(108, 0));
                LentiDoc.AddLenta(new Point(206, 0));
            }
            if (generirajKola % 30 == 0)
            {
                int linija = random.Next(9);
                int y = 0;

                int x;

                if (linija < 1)
                {

                    x = 25;
                    CarsDoc.AddCar(new Point(x, y));
                }
                else if (linija >= 1 && linija < 2)
                {
                    x = 135;
                    CarsDoc.AddCar(new Point(x, y));
                }
                else if (linija >= 2 && linija < 3)
                {
                    x = 245;
                    CarsDoc.AddCar(new Point(x, y));
                }
                else if (linija >= 3 && linija < 5)
                {
                    x = 25;
                    CarsDoc.AddCar(new Point(x, y));
                    x = 135;
                    CarsDoc.AddCar(new Point(x, y));
                }
                else if (linija >= 5 && linija < 7)
                {
                    x = 25;
                    CarsDoc.AddCar(new Point(x, y));
                    x = 245;
                    CarsDoc.AddCar(new Point(x, y));
                }
                else
                {
                    x = 135;
                    CarsDoc.AddCar(new Point(x, y));
                    x = 245;
                    CarsDoc.AddCar(new Point(x, y));
                }
            }

            generirajKola++;
            poeni = sekundi * level;
            if (timer1.Interval > 20)
            {
                if (sekundi > 1 && sekundi % 8 == 0 && zgolemiLvl == true)
                {
                    if (flag)
                    sounds.levelup.Play();
                    level++;
                    timer1.Interval -= 6;
                    lblLevel.Text = level + "";
                    zgolemiLvl = false;
                }


            }


            lblPoints.Text = poeni + " pts";
            CarsDoc.Move(Width);
            LentiDoc.Move(Width);
            DupkiDoc.Move(Width);
            if (!CheckGame())
            {
                ekplodiraj = true;
            }
            Bitmap bufl = new Bitmap(pbStaza.Width, pbStaza.Height);
            using (Graphics g = Graphics.FromImage(bufl))
            {
                g.FillRectangle(tba, new Rectangle(0, 0, pbStaza.Width, pbStaza.Height));
                LentiDoc.Draw(g);
                DupkiDoc.Draw(g);
                jas.Draw(g);
                CarsDoc.Draw(g);
                if(ekplodiraj == true)
                    g.DrawImage(eksplozija, jas.Centar.X + 10, jas.Centar.Y + 40, 70, 110);
                pbStaza.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
                bufl.Dispose();
            }



            if (!CheckGame())
            {
                if (flag)
                sounds.gameOver.Play();
                Write();
                Form2 f2 = new Form2();
                DialogResult dk = f2.ShowDialog();
                if (dk == System.Windows.Forms.DialogResult.Retry)
                {
                    pbTryAgain_Click(sender, e);
                }
                else if (dk == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }


        }

        private bool CheckGame()
        {
            foreach (Car c in CarsDoc.Cars)
            {
                if (c.Centar.X == jas.Centar.X)
                {
                    if (c.Centar.Y <= jas.Centar.Y + 100 && c.Centar.Y >= jas.Centar.Y ||
                        c.Centar.Y <= jas.Centar.Y + 205 && c.Centar.Y >= jas.Centar.Y)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        return false;
                    }
                }
            }
            return true;
        }



        private void GameHide()
        {

            pbBack.Hide();
            pbStop.Hide();
            pbStaza.Hide();
            label1.Hide();
            label2.Hide();
            lblLevel.Hide();
            lblPoints.Hide();
            lblSekundi.Hide();
            pbTryAgain.Hide();
        }

        private void GameShow()
        {
            pbBack.Show();
            pbStop.Show();
            pbTryAgain.Show();
            pbStaza.Show();
            label1.Show();
            label2.Show();
            lblPoints.Show();
            lblLevel.Show();
            lblSekundi.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbKontroli.Font = new Font(lbKontroli.Font.FontFamily, 15);
            pbControls.Image = Kontroli;
            flag = true;
            pbSound.Image = zvukON;
            pbSound2.Image = zvukOFF;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            GameShow();
            pnlMeny.Hide();
            pbTryAgain_Click(sender, e);
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if(flag)
                sounds.prefrlanje.Play();
                jas.Move("desno");
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (flag)
                sounds.prefrlanje.Play();
                jas.Move("levo");
            }
            else if (e.KeyCode == Keys.Up)
            {
                jas.Move("gore");
            }
            else if (e.KeyCode == Keys.Down)
            {
                jas.Move("dole");
            }
            if (e.KeyCode == Keys.P)
            {
                pbStop_Click(sender, e);
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }

        }


        private void pbStop_Click(object sender, EventArgs e)
        {
            if (clicked)
            {
                timer1.Stop();
                timer2.Stop();
                this.KeyPreview = false;
                pbStop.BackgroundImage = Properties.Resources.unnamed;
                clicked = false;
            }
            else if (!clicked)
            {
                timer1.Start();
                timer2.Start();
                this.KeyPreview = true;
                pbStop.BackgroundImage = Properties.Resources.Stop;
                clicked = true;
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            GameHide();
            pnlMeny.Show();
        }

        private void pbTryAgain_Click(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("highscores.txt");
            lbHighScore.Text = tr.ReadLine() + "pts";
            CarsDoc = new CarsDoc();
            generirajKola = 0;
            poeni = 0;
            level = 1;
            jas = new Budala(new Point(135, 450));
            timer1.Interval = 80;
            timer1.Start();
            timer2.Start();
            sekundi = 0;
            //  lblSekundi.Text = "0 sec";
            lblLevel.Text = "1";
            zgolemiLvl = false;
            ekplodiraj = false;
            sounds.gameOver.Stop();
        }

        static void Write()
        {
            
            TextReader tr = new StreamReader("highscores.txt");
            bestScore = int.Parse(tr.ReadLine());
            
            tr.Close();

            

            if (bestScore < poeni)
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                File.WriteAllText("highscore.txt", String.Empty);
                tw.WriteLine(poeni);
                tw.Close();
            }
            
            
            
        }

        private void pbStop_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbStop_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pbBack_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbTryAgain_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pbTryAgain_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {

        }

        private void pbPlayGame_Click(object sender, EventArgs e)
        {
            GameShow();
            pnlMeny.Hide();
            pbTryAgain_Click(sender, e);
        }

        private void pbQuitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Dvizete ja kolickata so pomos na kopcinjata levo i desno");
            pnlHelp.Show();
        }

        private void pbHelp_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbHelp, "Help");
        }

        private void pbPlayGame_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbPlayGame, "Play game");
        }

        private void pbQuitGame_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbQuitGame, "Quit game");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnlHelp.Hide();
        }

        private void pbSound2_Click(object sender, EventArgs e)
        {
            flag = false;
        }

        private void pbSound_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void lbKontroli_Click(object sender, EventArgs e)
        {

        }

        private void pbControls_Click(object sender, EventArgs e)
        {

        }
    }
}
