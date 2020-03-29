using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calco.Client.WinApp
{
    public static class Data
    {
        public static DataTable dt1 = new DataTable();

        public static void Init()
        {

            int?[,] a = new int?[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    a[i, j] = null;

            //a[0, 0] = 5; a[0, 1] = 3; a[0, 2] = 4; a[0, 4] = 7;
            //a[1, 0] = 6; a[1, 3] = 1; a[1, 4] = 9; a[1, 5] = 5;
            //a[2, 1] = 9; a[2, 2] = 8; a[2, 7] = 6;

            //a[3, 0] = 8; a[3, 4] = 6; a[3, 8] = 3;
            //a[4, 0] = 4; a[4, 1] = 2; a[4, 2] = 6; a[4, 3] = 8; a[4, 4] = 5; a[4, 5] = 3; a[4, 6] = 7; a[4, 7] = 9; a[4, 8] = 1;
            //a[5, 0] = 7; a[5, 4] = 2; a[5, 8] = 6;

            //a[6, 1] = 6; a[6, 6] = 2; a[6, 7] = 8;
            //a[7, 3] = 4; a[7, 4] = 1; a[7, 5] = 9; a[7, 8] = 5;
            //a[8, 4] = 8; a[8, 7] = 7; a[8, 8] = 9;


            a[0, 0] = 9; a[0, 1] = 7; a[0, 4] = 2; a[0, 6] = 4;
            a[1, 0] = 8; a[1, 1] = 2; a[1, 3] = 3; a[1, 5] = 9; a[1, 8] = 1;
            a[2, 1] = 6; a[2, 2] = 3; a[2, 4] = 8; a[2, 5] = 5;

            a[3, 2] = 6; a[3, 3] = 2; a[3, 8] = 5;
            a[4, 1] = 8; a[4, 2] = 2; a[4, 4] = 3; a[4, 6] = 1; a[4, 7] = 6;
            a[5, 0] = 4; a[5, 5] = 1; a[5, 6] = 7;

            a[6, 4] = 6; a[6, 6] = 9; a[6, 7] = 7;
            a[7, 0] = 2; a[7, 3] = 5;
            a[8, 2] = 8; a[8, 7] = 3;


            ////a[0, 1] = 7; a[0, 6] = 4;
            ////a[1, 5] = 9; a[1, 8] = 1;
            ////a[2, 1] = 6; a[2, 2] = 3; a[2, 4] = 8;

            ////a[3, 2] = 6; a[3, 3] = 2; a[3, 8] = 5;
            ////a[4, 1] = 8; a[4, 2] = 2; a[4, 4] = 3; a[4, 6] = 1; a[4, 7] = 6;
            ////a[5, 0] = 4; a[5, 5] = 1; a[5, 6] = 7;

            ////a[6, 4] = 6; a[6, 6] = 9; a[6, 7] = 7;
            ////a[7, 0] = 2; a[7, 3] = 5;
            ////a[8, 2] = 8; a[8, 7] = 3;

            for (int i = 0; i < 9; i++)
            {
                dt1.Columns.Add(new DataColumn("", typeof(System.String)));
            }

            for (int i = 0; i < 9; i++)
            {
                dt1.Rows.Add();
                for (int j = 0; j < 9; j++)
                    dt1.Rows[i][j] = a[i, j].HasValue ? a[i, j].Value.ToString() : string.Empty;
            }
        }
    }
}
