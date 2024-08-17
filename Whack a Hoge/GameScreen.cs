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
using System.Media;
using System.Runtime.CompilerServices;

namespace Whack_a_Hoge
{
    public partial class GameScreen : Form
    {
        
        //set public int (for fixing repetition)
        public int previousNum = 0;
        //Hit boolean for scoring
        public bool moleIsHit = false;
        //Hit and misses variable.
        public static int Hits = 0;
        public int Misses = -1;
        //Variable for animating the growth and shrinking of mole
        public double scale = 1.0;
        public double animStep = 0.1;
        public bool grow = false;
        public bool shrink = false;
        //where the mole is currently on screen
        public Point currentPos;
        //where the mole will appear next
        public Point newPos;

        public GameScreen()
        {
            InitializeComponent();
            //This is to fix flickering in sprites
            this.DoubleBuffered = true;
            //sets certain variables to default values before game starts
            currentPos = new System.Drawing.Point(351, 145);
            newPos = currentPos;
            pictureBox1.Location = currentPos;           
            moleIsHit = false;
            scale = 0.1;
            grow = true;
            Hits = 0;
            Misses = -1;
        }
      
        //event for changing mole, and adding to misses. Called when mole expires and timer ends.
        void ChangeMole(object sender, EventArgs e)
        {           
            //show a new random mole.
            RandomMoleShow();
            //Add to misses if the mole was not hit
            if (moleIsHit == false)
            {
                Misses++;
            }
            //display misses
            label2.Text = ("Misses: " + Misses);
            //end game if misses reaches 10.
            if (Misses == 10)
            {
                //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
                EndScreen EndScreen = new EndScreen();               
                this.Hide();
                EndScreen.Show(); 
                this.Close();
            }
            //Reset boolean
            moleIsHit = false;
        }

        //Shows a random mole
        void RandomMoleShow()
        {
            //Puts locations of holes into two arrays.
            int[] XLocations = { 124, 299, 320, 474, 166, 520 };
            int[] YLocations = { 201, 248, 138, 82, 86, 197 };
            //Creates Random number between 0 and the length of the array.
            Random ran = new Random();
            int num = ran.Next(0, YLocations.Length);
            //Check if current index = previous index. If they are equal, find a new number to make sure the mole doesnt show up in the same position
            while (num == previousNum)
            {   
                num = ran.Next(0, YLocations.Length);
            }
            //store current index number to check position next time.
            previousNum = num;
            //Set new mole position to X and Y locations with random number getting the index. then set whether it needs to grow or shrink
            newPos = new System.Drawing.Point(XLocations[num], YLocations[num]);
            if (pictureBox1.Visible == true)
            {
                //if mole is already visible, need to shrink it first. mole will be set to newPos in animation function when shrink is finished
                shrink = true;
            }
            else
            {
                //mole is hidden, because we clicked on it. Only needs to grow at new position
                scale = 0.1;
                grow = true;
                currentPos = newPos;
            }
            //Show mole
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;     
        }

        //Main hit event. Called when mole picturebox is clicked.
        void HitMole(object sender, EventArgs e)
        {
            //Play sound from files for hit
            SoundPlayer simpleSound = new SoundPlayer("PunchSound.wav");
            simpleSound.Play();
            //shrink when clicked. Animation function will hide when fully shrunk
            shrink = true;
            //Set hit to true. Then add to hits
            moleIsHit = true;
            Hits++;
            //Set Level to hits / 5, rounded up. It is a double so that the rounding works
            int level = Convert.ToInt32(Math.Ceiling((double)Hits / 5));   
            //make interval faster if level is under 15. Else, stay the same
            if (level < 15)
            {
                //make the interval change with the level, by incorperating it into equation. Interval is in milliseconds, so it begins at 2 seconds.
                timer1.Interval = 2000 - (level * 100);
                //make animation faster. Use level to calculate, so that the animation is faster when the mole disappears faster
                animStep = 0.2 + (level / 100.0);
            }
            //Set hit label to display hit amounts. Set level label to display level.
            label1.Text = ("Hits: " + Hits);
            label3.Text = ("Level: " + level);
        }

        //function for growing and shrinking the mole. Called from timer that updates quickly so that the animation is smooth.
        private void AnimationFunction(object sender, EventArgs e)
        {
            //check if growing is called
            if (grow)
            {
                //increase scale, multiplied by the step, until 1.0 is reached (1.0 is 100% of the final scale in this situation)
                scale = scale + animStep;
                if (scale > 1.0)
                {
                    scale = 1.0;
                    grow = false;
                }
                //Update position and size based on scale
                SetScaledMolePosition();
            }
            //check if shrinking is called
            if (shrink) 
            {
                //decrease scale, multiplied by the step, until 0 is reached (0 is 0% of the final scale in this situation)
                scale = scale - animStep;
                if (scale <= 0)
                {
                    scale = 0;
                    shrink = false;
                    //when shrink is finished, move to new position
                    currentPos = newPos;
                    //if the mole has been clicked, hide it. hiding it because it will be shown when timer elapses
                    if (moleIsHit == true)
                    {
                        pictureBox1.Visible = false;
                        pictureBox1.Enabled = false;
                    }
                    else
                    {
                        //grow again
                        grow = true;
                    }    
                }
                //Update position and size based on scale
                SetScaledMolePosition();
            }
        }

        private void SetScaledMolePosition()
        {
            //Sets final mole size
            int fullHeight = 98;
            int fullWidth = 151;
            //only scale horizontally from 50% to 100%
            double horizontalScale = 0.5 + 0.5 * scale;
            //setting Width and Height to percentage of final scale.
            pictureBox1.Width = Convert.ToInt32(fullWidth * horizontalScale);
            pictureBox1.Height = Convert.ToInt32(fullHeight * scale);
            //due to mole scaling being from top left, need to offset position to keep bottom of mole in the hole and keep it centred horizontally
            pictureBox1.Location = new Point(currentPos.X + (fullWidth - pictureBox1.Width) / 2, currentPos.Y + (fullHeight - pictureBox1.Height));
        }
    }
}
