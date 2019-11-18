using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRace_of_Dog
{
    public partial class Form1 : Form
    {
        private int task = 0;
        private int  Amt=200,Amt1=200,Amt2=200;
        private Boolean Player1 = false, Player2 = false, Player3 = false;

        Player1 obj_player1 = null;
        Player2 obj_player2 = null;
        Player3 obj_player3 = null;

        public Form1()
        {
            InitializeComponent();
            tmfire.Start();
        }

        private void tmfire_Tick(object sender, EventArgs e)
        {
            
            if (task <= 10)
            {
                task++;
            }
            else {
                tmfire.Stop();
                
              pictureBox1.Hide();
              
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random rd = new Random();
            if (pb1.Left < 735)
            {
                pb1.Left += rd.Next(1, 20);
            }
            else {
                timer1.Stop();
                MessageBox.Show("dog 1 is the winner");
                results(1);
            }
            if (pb2.Left < 735) {
                 pb2.Left+= rd.Next(1, 20);
            }
            else {
                timer1.Stop();
                MessageBox.Show("dog 2 is the winner");
                results(2);
            }

            if (pb3.Left < 735)
            {
                pb3.Left += rd.Next(1, 20);
            }
            else {
                timer1.Stop();
                MessageBox.Show("dog 3 is the winner");
                results(3);
            }

            if (pb4.Left<735) {
                pb4.Left += rd.Next(1, 20);
            }
            else {
                timer1.Stop();
                MessageBox.Show("dog 4 is the winner");
                results(4);
            }
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void results(int winner) {

            if (Player1)
            {
                if (obj_player1.Dog == winner)
                {
                    Amt = obj_player1.Amount + obj_player1.Bet;
                    checkBox1.Text = obj_player1.Name + " has " + Amt + " Dollar";
                }
                else {
                    
                    Amt = obj_player1.Amount - obj_player1.Bet;
                    checkBox1.Text = obj_player1.Name + " has " + Amt + " Dollar";
                }
                

            }
            if (Player2)
            {
                if (obj_player2.Dog == winner)
                {
                    Amt1 = obj_player2.Amount + obj_player2.Bet;
                    checkBox2.Text = obj_player2.Name + " has " + Amt1 + " Dollar";
                }
                else
                {

                    Amt1 = obj_player2.Amount - obj_player2.Bet;
                    checkBox2.Text = obj_player2.Name + " has " + Amt1 + " Dollar";
                }



            }
            if (Player3)
            {
                if (obj_player3.Dog == winner)
                {
                    Amt2 = obj_player3.Amount + obj_player3.Bet;
                    checkBox3.Text = obj_player3.Name + " has " + Amt2 + " Dollar";
                }
                else
                {

                    Amt2 = obj_player3.Amount - obj_player3.Bet;
                    checkBox3.Text = obj_player3.Name + " has " + Amt2 + " Dollar";
                }
            }

        Player1 = false; Player2 = false; Player3 = false;
        button2.Visible = false;
        pb1.Left = 0; pb2.Left = 0; pb3.Left = 0; pb4.Left = 0;

            comboBox1.Text = "";
            numericUpDown1.Value = 1;
            obj_player1 = null;
            obj_player2 = null;
            obj_player3 = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("fire.wav");
            player.Play();

            timer1.Start();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    obj_player1 = new Player1("Sukh", Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(numericUpDown1.Value), Amt);
                    if (obj_player1.check() != 1 )
                    {
                        MessageBox.Show(obj_player1.Name + " check the amount once ");
                    }
                    else
                    {
                        if (comboBox1.Text != "")
                        {
                            Player1 = true;
                            button2.Visible = true;
                            MessageBox.Show("Sukh set the bet on dog " + comboBox1.SelectedItem + " and bet amount is "+numericUpDown1.Value);
                        }
                        else {
                            MessageBox.Show("select the dog first and fill the bet amount ");
                        }
                        
                    }

                }
                else if (checkBox2.Checked == true)
                {
                    obj_player2 = new Player2("Aniket", Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(numericUpDown1.Value), Amt1);
                    if (obj_player2.check() != 1)
                    {
                        MessageBox.Show(obj_player2.Name + " check the amount once ");
                    }
                    else
                    {

                        if (comboBox1.Text != "")
                        {
                            Player2 = true;
                            button2.Visible = true;
                            MessageBox.Show("Aniket set the bet on dog " + comboBox1.SelectedItem + " and bet amount is " + numericUpDown1.Value);
                        }
                        else
                        {
                            MessageBox.Show("select the dog first and fill the bet amount ");
                        }
                    }


                }

                else if (checkBox3.Checked == true)
                {
                    obj_player3 = new Player3("Harman", Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(numericUpDown1.Value), Amt2);
                    if (obj_player3.check() != 1)
                    {
                        MessageBox.Show(obj_player3.Name + " check the amount once ");
                    }
                    else
                    {

                        if (comboBox1.Text != "")
                        {
                            Player3 = true;
                            button2.Visible = true;
                            MessageBox.Show("Harman set the bet on dog " + comboBox1.SelectedItem + " and bet amount is " + numericUpDown1.Value);
                        }
                        else
                        {
                            MessageBox.Show("select the dog first and fill the bet amount ");
                        }

                    }

                }
                else {
                    MessageBox.Show("Choose yourself to Bet ");
                }

            }
            catch (Exception ex) {


            }

        }
    }
}
