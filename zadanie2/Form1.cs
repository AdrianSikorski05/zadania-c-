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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;
            
        }

       

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                FormAdd newForm = new FormAdd(this);
                newForm.Show();
            }
        }
        public void SetSelectedCellsValue(int value)///FormAdd
        {


            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (!cell.ReadOnly)
                {

                    cell.Value = value;

                }
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!cell.ReadOnly  && !string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {

                    if (!int.TryParse(e.FormattedValue.ToString(), out int value))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText = "Wprowadź liczbę!";
                        e.Cancel = true;
                        return;
                    }

                    if (value <= 0 || value >= 1000)
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText = "Wartość musi być większa od 0 i mniejsza od 1000!";
                        e.Cancel = true;
                        return;
                    }

                    dataGridView1.Rows[e.RowIndex].ErrorText = "";
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                UpdateSums();
            }
        }

        private void UpdateSums()
        {
            for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
            {
                int sum = 0;

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    if (int.TryParse(dataGridView1.Rows[i].Cells[columnIndex].Value?.ToString(), out int value))/// ? jeżeli wyrażenie jest równe null, to wyrażenie  to zwróci null bez wyjątków 
                    {
                        sum += value;
                    }
                }

                dataGridView1.Rows[0].Cells[columnIndex].Value = sum;
            }
        }




        private void btnAddRow_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add();
            UpdateSums();
           
        }

       

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var row = dataGridView1.Rows[selectedRowIndex];
              
                if (!row.ReadOnly)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);
                        UpdateSums();

                    }
                    else
                    {
                        MessageBox.Show("Nie możesz usunąć nowego wiersza, który jeszcze nie został przekazany.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie możesz usunąć tego wiersza, ponieważ jest tylko do odczytu.");
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz, który chcesz usunąć.");
            }
        }


        private void btnEditRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var row = dataGridView1.Rows[selectedRowIndex];

                
                if (!row.ReadOnly)
                {

                    if (!row.IsNewRow)
                    {
                      
                        int A = Convert.ToInt32(row.Cells["Column1"].Value);
                        int B = Convert.ToInt32(row.Cells["Column2"].Value);
                        int C = Convert.ToInt32(row.Cells["Column3"].Value);
                        int D = Convert.ToInt32(row.Cells["Column4"].Value);

                       
                        editRowForm editForm = new editRowForm(this, A, B, C, D);
                        editForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nie możesz usunąć nowego wiersza, który jeszcze nie został przekazany.");
                    }

                }
                else
                {
                    MessageBox.Show("Nie możesz edytować tego wiersza, ponieważ jest tylko do odczytu.");
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz, który chcesz edytować.");
            }

        }

        public void UpdateSelectedRow(int updatedA, int updatedB, int updatedC, int updatedD)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var row = dataGridView1.Rows[selectedRowIndex];

                
                row.Cells["Column1"].Value = updatedA;
                row.Cells["Column2"].Value = updatedB;
                row.Cells["Column3"].Value = updatedC;
                row.Cells["Column4"].Value = updatedD;
            }
        }
    }
}
