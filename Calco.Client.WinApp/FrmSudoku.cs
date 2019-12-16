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
        public void InitializeBoard(DataTable dt)
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

            if (dt != null)
            {
                for (int i = 0; i < cMaxCell; i++)
                    for (int j = 0; j < cMaxCell; j++)
                        this.dgvBoard.Rows[i].Cells[j].Value = dt.Rows[i][j];
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
            InitializeBoard(null);
            this.dgvBoard.ClearSelection();
            Controls.Add(this.dgvBoard);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvBoard.DataSource = null;
            dgvBoard.Rows.Clear();
            dgvBoard.Columns.Clear();
            InitializeBoard(null);
            this.dgvBoard.ClearSelection();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvBoard.DataSource = null;
            dgvBoard.Rows.Clear();
            dgvBoard.Columns.Clear();
            InitializeBoard(null);

            Data.Init();
            InitializeBoard(Data.dt1);
            this.dgvBoard.ClearSelection();

            foreach (DataGridViewRow row in this.dgvBoard.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.BackColor = Color.LightGray;
                        cell.ReadOnly = true;
                    }
                }
            }
        }


        private void dgvBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dgvBoard_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dgvBoard_KeyPress);
        }
    }
}