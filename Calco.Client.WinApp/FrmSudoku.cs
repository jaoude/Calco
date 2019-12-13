using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calco.Client.WinApp
{
    public partial class FrmSudoku : Form
    {
        public FrmSudoku()
        {
            InitializeComponent();
           
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int?[,] a = new int?[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    a[i, j] = null;

            a[0, 0] = 5; a[0, 1] = 3; a[0, 4] = 7;
            a[1, 0] = 6; a[1, 3] = 1; a[1, 4] = 9; a[1, 5] = 5;
            a[2, 1] = 9; a[2, 2] = 8; a[2, 7] = 6;

            a[3, 0] = 8; a[3, 4] = 6; a[3, 8] = 3;
            a[4, 0] = 4; a[4, 3] = 8; a[4, 5] = 3; a[4, 8] = 1;
            a[5, 0] = 7; a[5, 4] = 2; a[5, 8] = 6;

            a[6, 1] = 6; a[6, 6] = 2; a[6, 7] = 8;
            a[7, 3] = 4; a[7, 4] = 1; a[7, 5] = 9; a[7, 8] = 5;
            a[8, 4] = 8; a[8, 7] = 7; a[8, 8] = 9;

            //for (int i = 0; i < 9; i++)
            //{
            //    dt.Columns.Add();
            //}

            //for (int j = 0; j < 9; j++)
            //{
            //    // create a DataRow using .NewRow()
            //    DataRow row = dt.NewRow();

            //    // iterate over all columns to fill the row
            //    for (int i = 0; i < 9; i++)
            //    {
            //        row[i] = a[j,i].HasValue ? a[j, i].Value.ToString() : "";
            //    }

            //    // add the current row to the DataTable
            //    dt.Rows.Add(row);
            //}
            Build(a);
            dataGridViewBoard.DataSource = dt;
        }

        private void Build(int?[,] a = null)
        {
            const int cColWidth = 45;
            const int cRowHeigth = 45;
            const int cMaxCell = 9;
            const int cSidelength = cColWidth * cMaxCell + 3;

            dataGridViewBoard.Name = "DGV";
            dataGridViewBoard.AllowUserToResizeColumns = false;
            dataGridViewBoard.AllowUserToResizeRows = false;
            dataGridViewBoard.AllowUserToAddRows = false;
            dataGridViewBoard.RowHeadersVisible = false;
            dataGridViewBoard.ColumnHeadersVisible = false;
            dataGridViewBoard.GridColor = Color.DarkBlue;
            dataGridViewBoard.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridViewBoard.ScrollBars = ScrollBars.None;
            dataGridViewBoard.Size = new Size(cSidelength, cSidelength);
            dataGridViewBoard.Location = new Point(50, 50);
            dataGridViewBoard.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewBoard.ForeColor = Color.DarkBlue;
            dataGridViewBoard.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 81 cells
            for (int i = 0; i < cMaxCell; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                dataGridViewBoard.Columns.Add(TxCol);
                dataGridViewBoard.Columns[i].Name = "Col " + (i + 1).ToString();
                dataGridViewBoard.Columns[i].Width = cColWidth;
                dataGridViewBoard.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                dataGridViewBoard.Rows.Add(row);
                if (a != null)
                {
                    for (int j = 0; j < 9; j++)
                    {
                       
                        dataGridViewBoard.Rows[i].Cells[j].Value = a[j, i].HasValue ? a[j, i].Value.ToString() : "";
                    }
                }
                row.Height = cRowHeigth;
                // dataGridViewBoard.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            dataGridViewBoard.Columns[2].DividerWidth = 2;
            dataGridViewBoard.Columns[5].DividerWidth = 2;
            dataGridViewBoard.Rows[2].DividerHeight = 2;
            dataGridViewBoard.Rows[5].DividerHeight = 2;
        }
    }
}
