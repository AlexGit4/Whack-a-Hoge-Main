using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Whack_a_Hoge
{
    public partial class GameScreen : Form
    {
        //set public int (for fixing repetition)
        public int previousnum = 0;
        //Hit boolean for scoring
        public bool moleIsHit = false;
        //Hit and misses variable.
        public static int Hits = 0;
        public int Misses = -1;
        bool Playing = true;
        public GameScreen()
        {
            InitializeComponent();
            pictureBox1.Location = new System.Drawing.Point(351, 145);
            
        }

       

        void ChangeMole(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"C:\Users\21077\OneDrive - Bayfield High School\Pictures\ezgif.com-animated-gif-maker2.gif");
            timer2.Enabled = true;
            HideAllMoles();
            RandomMoleShow();
            //Add to score
            if (moleIsHit == false)
            {
                Misses++;
            }

            label2.Text = ("Misses: " + Misses);
            if (Misses == 10)
            {
                
                EndScreen EndScreen = new EndScreen(); //creates a variable out of the next screen
                this.Hide(); //"this" refers to the currently open screen.
                EndScreen.Show(); //shows the next screen
                this.Close();
            }
            //Reset boolean
            moleIsHit = false;

        }

        void RandomMoleShow()
        {

            //Put location into two arrays.
            int[] XLocations = { 124, 299, 320, 474, 166, 520 };
            int[] YLocations = { 201, 248, 138, 82, 86, 197 };
            //Create Random number.
            Random ran = new Random();
            int num = ran.Next(0, YLocations.Length);
            //Check if current number = previous number
            while (num == previousnum)
            {
                //if they are equal, find a new number.
                num = ran.Next(0, YLocations.Length);
            }
            //set current number to previous number.
            previousnum = num;
            //Set mole position to X and Y locations with random number getting the index
            pictureBox1.Location = new System.Drawing.Point(XLocations[num], YLocations[num]);
            //Show mole
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;




        }
        void HideAllMoles()
        {
            //Hides moles

            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
        }

        void HitMole(object sender, EventArgs e)
        {

            //hide mole
            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;



            //set hit to true
            moleIsHit = true;
            //Add to hits
            Hits++;
            //Set Level to hits / 5
            int level = Convert.ToInt32(Math.Ceiling((double)Hits / 5));
            //make interval faster
            timer1.Interval = 2000 - (level * 50);
            //set hit label to display hit amounts
            label1.Text = ("Hits: " + Hits);
            //set level label to desplay level
            label3.Text = ("Level: " + level);
        }

        void ChangeSprite(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"C:\Users\21077\OneDrive - Bayfield High School\Pictures\ezgif.com-animated-gif-maker.gif");
            //timer2.Enabled = false;
            //timer3.Enabled = true;
        }

        void Stopsprite(object sender, EventArgs e)
        {

            //timer3.Enabled = false;
        }



    }
}
