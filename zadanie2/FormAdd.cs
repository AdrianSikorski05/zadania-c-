using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_2___
{
    public partial class FormAdd : Form
    {
        Form1 mainForm;
        public FormAdd(Form1 mainForm)
        {
            
            InitializeComponent();
            this.mainForm = mainForm;

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int valueToAdd = Convert.ToInt32(textBox1.Text);
                mainForm.SetSelectedCellsValue(valueToAdd);
                this.Close(); 
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int value;
            
            if (!int.TryParse(textBox1.Text.ToString(), out  value))
            {
                MessageBox.Show("Wprowadź liczbę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; 
                return;
            }
            

            if (value <= 0  || value > 1000)
            {
                MessageBox.Show("Wartość musi być z zakresu od 0 do 1000!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; 
                return;
            }
        }
    }
}
