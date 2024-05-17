using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            int value = (int)numericUpDown1.Value;

            if (value < 3 || value > 6) 
            {
                MessageBox.Show("Błąd Wpisz liczbę z przedziału 3-6!");
                e.Cancel = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int length = (int)numericUpDown1.Value;

            button1.Enabled = false;

            await Task.Run(() =>  GenerateCombinationsNumbers(length));

            button1.Enabled = true;
            

        }


        private void GenerateCombinationsNumbers (int length) {

            int totalCombinations = (int)Math.Pow(10, length);

            UpdateProgressBar(totalCombinations);

            for (int i = 0; i < totalCombinations; i++) { 
            
                string combination =  i.ToString().PadLeft(length,'0');

                DisplayCombination(combination);

                UpdateProgressStatus(i + 1, totalCombinations);


                Thread.Sleep(100);
            }

           
        }

        private void DisplayCombination(string combination) {

            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(DisplayCombination), combination);
            }
            else 
            { 
                 textBox1.AppendText(combination + Environment.NewLine);
                 
            }
        
        
        }


        private void UpdateProgressStatus(int current, int maximum) {

            if (label2.InvokeRequired)
            {
                label2.Invoke(new Action<int,int>(UpdateProgressStatus), current, maximum);
            }
            else
            {
                progressBar1.Value = current;
                label2.Text = $"Permutacja: {current} / {maximum}";

            }


        }

        private void UpdateProgressBar(int maximum) {

            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int>(UpdateProgressBar), maximum);
            }
            else
            {
                progressBar1.Maximum = maximum;
                progressBar1.Value = 0;


            }


        }


    }
}
