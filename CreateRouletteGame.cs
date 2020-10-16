using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RussianRoulette
{
    public partial class CreateRouletteGame : Form
    {
        WinLose winObj = new WinLose();
        int numPlayers = 2;
        int startChamber = 0;
        int bulletChamber = 0;
        bool LoadGun = false;
        int round = 1;
        //number generator
    private static Random random = new Random();

        public CreateRouletteGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSpinChamber.Enabled = false;
           
        }

        private void btnSpinChamber_Click(object sender, EventArgs e)
        {
            if (LoadGun == true)
            {
                startChamber = spinChamber(); //Set Chamber to start game
                bulletChamber = spinChamber(); //Bullet is which chamber
                lblPlayer.Text = "Your Turn";
                btnFire.Enabled = true;
                btnSpinChamber.Enabled = false;
                lblInfo.Text = "Fire The Gun";
                lblResult.Text = "Round 1";
                lblResult.Visible = true;
                btnPlayAgain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Load the gun firstly...");
            }
        }
        public int spinChamber()
        {

            return random.Next(1,7);
          
        }

        private void btnFire_ClickAsync(object sender, EventArgs e)
        {
            btnFire.Enabled = false;
            //Play the game on fire buuton click
            int currentChamber =Playing(numPlayers, startChamber, bulletChamber);
            startChamber = currentChamber;
            
            if (currentChamber==-1)
            {
                
                lblInfo.Text = "Game End";
                lblPlayer.Text = "";
                btnFire.Enabled = false;
                btnPlayAgain.Enabled = true;
            }
            else
            {

                lblResult.Visible = false;
               
                lblPlayer.Text = "Your Turn";
                btnFire.Enabled = true;
                round++;
                lblResult.Text = "Round "+round;
                lblResult.Visible = true;
            }
            
        }
        public int Playing(int numPlayers, int currentChamber, int bulletChamber)
        {
            for (int i = 1; i <= numPlayers; i++)
            {
               
                // bullet is fired

                if (currentChamber == bulletChamber)
                {
                    SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\GunTrack\\shot1.wav");
                    simpleSound.Play();
                   
                    if (i==1)
                    {
                       
                        lblDeadInfo.Text = "You Dead...";
                        lblResult.Text = "LOSE GAME!!!";
                        lblDeadInfo.Visible = true;
                        lblResult.Visible = true;
                        winObj.LoseGame++;
                        lblLose.Text = winObj.LoseGame.ToString();
                    }
                    else
                    {
                       
                        lblDeadInfo.Text = "Player " + i + " is dead...";
                        lblResult.Text = "WIN GAME!!!";
                        lblDeadInfo.Visible = true;
                        lblResult.Visible = true;
                        winObj.WinGame++;
                        lblWin.Text = winObj.WinGame.ToString();
                    }
                    
                   
                return -1;
                   
                }
                else
                {
                    
                    if(i==1)
                    {
                        lblResult.Text = "You Are Lucky";
                    }
                    else
                    {
                        lblResult.Text = "Player "+i+" is Lucky";
                    }
                    
                    lblResult.Visible = true;
                    lblResult.Visible = false;


                }
                if (currentChamber == 6)
                {

                    currentChamber = 1;

                }
                else
                {

                    currentChamber++;

                }

                
            }
            return currentChamber;


        }

        private void btnLoadBullet_Click(object sender, EventArgs e)
        {
            LoadGun = true;
            btnSpinChamber.Enabled = true;
            btnLoadBullet.Enabled = false;
            lblInfo.Text = "Spin The Chamber";
            round = 1;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            btnSpinChamber.Enabled = false;
            btnLoadBullet.Enabled = true;
            btnFire.Enabled = false;
            startChamber = 0;
            bulletChamber = 0;
           
            LoadGun = false;
            lblInfo.Text = "Load The Bullet";
            lblDeadInfo.Visible = false;
            lblResult.Visible = false;
            round = 1;
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
