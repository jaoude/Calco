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
        public void InitializeBoard()
        {
            const int cColWidth = 35;
            const int cRowHeigth = 35;
            const int cMaxCell = 9;
            const int cSidelength = cColWidth * cMaxCell + 3;

            this.dgvBoard.Name = "dgvBoard";
            this.dgvBoard.AllowUserToResizeColumns = false;
            this.dgvBoard.AllowUserToResizeRows = false;
            this.dgvBoard.AllowUserToAddRows = false;
            this.dgvBoard.RowHeadersVisible = false;
            this.dgvBoard.ColumnHeadersVisible = false;
            this.dgvBoard.GridColor = Color.DarkBlue;
            this.dgvBoard.DefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvBoard.ScrollBars = ScrollBars.None;
            this.dgvBoard.Size = new Size(cSidelength, cSidelength);
            this.dgvBoard.Location = new Point(20, 20);
            this.dgvBoard.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.dgvBoard.ForeColor = Color.DarkBlue;
            this.dgvBoard.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 81 cells
            for (int i = 0; i < cMaxCell; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                this.dgvBoard.Columns.Add(TxCol);
                this.dgvBoard.Columns[i].Name = "Col " + (i + 1).ToString();
                this.dgvBoard.Columns[i].Width = cColWidth;
                this.dgvBoard.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeigth;
                this.dgvBoard.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            this.dgvBoard.Columns[2].DividerWidth = 2;
            this.dgvBoard.Columns[5].DividerWidth = 2;
            this.dgvBoard.Rows[2].DividerHeight = 2;
            this.dgvBoard.Rows[5].DividerHeight = 2;
        }
        public FrmSudoku()
        {
            InitializeComponent();
            InitializeBoard();
            Controls.Add(this.dgvBoard);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvBoard.DataSource = null;
            for (int i = 0; i < dgvBoard.Columns.Count; i++)
            {
                for (int j = 0; j < dgvBoard.Rows.Count; j++)
                {
                    dgvBoard.Rows[j].Cells[i].Value = DBNull.Value;
                }
            }
            dgvBoard.Refresh();
        }
    }
}
