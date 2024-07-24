using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whack_a_Hoge
{
    public partial class MenuScreen : Form
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GameScreen gameScreen = new GameScreen(); //creates a variable out of the next screen
            this.Hide(); //"this" refers to the currently open screen.
            gameScreen.Show(); //shows the next screen
            
        }
    }
}
