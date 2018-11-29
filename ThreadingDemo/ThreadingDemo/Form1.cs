using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; // MUST USE SYSTEM.THREADING

namespace ThreadingDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DoMoreTimeConsumingWork()
        {
            Thread.Sleep(3500); // Mili - Seconds
        }

        private void DoTimeConsumingWork()
        {
            Thread.Sleep(30); // Mili - Seconds
        }

        private void btnTimeConsumingWork_Click(object sender, EventArgs e)
        {
            /******Spam The print numbers button to watch  the click event
                       execute only after the thread completes******/

            //btnTimeConsumingWork.Enabled = false;
            //btnPrintNumbers.Enabled = false;

            DoMoreTimeConsumingWork();

            //btnTimeConsumingWork.Enabled = true;
            //btnPrintNumbers.Enabled = true;
        }

        private void btnPrintNumbers_Click(object sender, EventArgs e)
        {
            btnTimeConsumingWork.Enabled = false;
            btnPrintNumbers.Enabled = false;

            for (int i = 100; i >= 1; i--)
            {
                DoTimeConsumingWork();
                listBox1.Items.Add(i);
                Application.DoEvents(); //Application.DoEvents() is nessessary to push numbers 
                //Individually instead of all at once... Comment out the line & watch the difference.
            }

            btnTimeConsumingWork.Enabled = true;
            btnPrintNumbers.Enabled = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
