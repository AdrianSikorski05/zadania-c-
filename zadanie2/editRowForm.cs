using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zadanie_2___
{
    public partial class editRowForm : Form
    {
        Form1 mainForm;
        public editRowForm(Form1 mainForm, int A, int B, int C, int D)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            textBox1.Text = A.ToString();
            textBox2.Text = B.ToString();
            textBox3.Text = C.ToString();
            textBox4.Text = D.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int updatedA = Convert.ToInt32(textBox1.Text);
            int updatedB = Convert.ToInt32(textBox2.Text);
            int updatedC = Convert.ToInt32(textBox3.Text);
            int updatedD = Convert.ToInt32(textBox4.Text);



            
            mainForm.UpdateSelectedRow(updatedA, updatedB, updatedC, updatedD);// Zaktualizowanie danych w formularzu gł.

           
            this.Close(); // Zamknięcie formularza
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            int value;

            if (int.TryParse(textBox1.Text, out value))
            {
                if (!(value > 0 && value < 1000 ) )
                {
                    MessageBox.Show("Błąd wpisz liczbę z przedziału 1 do 999!");
                    e.Cancel = true;
                }
 
            }
            else {
                MessageBox.Show("Błąd wpisz liczbę!");
                e.Cancel = true;
            }

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value))
            {
                if (!(value > 0 && value < 1000))
                {
                    MessageBox.Show("Błąd wpisz liczbę z przedziału 1 do 999!");
                    e.Cancel = true;
                }

            }
            else
            {
                MessageBox.Show("Błąd wpisz liczbę!");
                e.Cancel = true;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (int.TryParse(textBox3.Text, out value))
            {
                if (!(value > 0 && value < 1000))
                {
                    MessageBox.Show("Błąd wpisz liczbę z przedziału 1 do 999!");
                    e.Cancel = true;
                }

            }
            else
            {
                MessageBox.Show("Błąd wpisz liczbę!");
                e.Cancel = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (int.TryParse(textBox4.Text, out value))
            {
                if (!(value > 0 && value < 1000))
                {
                    MessageBox.Show("Błąd wpisz liczbę z przedziału 1 do 999!");
                    e.Cancel = true;
                }

            }
            else
            {
                MessageBox.Show("Błąd wpisz liczbę!");
                e.Cancel = true;
            }
        }


    }
}
