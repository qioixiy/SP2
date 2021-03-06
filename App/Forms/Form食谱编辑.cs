﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SP.Forms
{
    public partial class Form食谱编辑 : Form
    {
        string str1 = "";//全局变量，存放拖动单元格value      
        int nRow;//记录被拖动单元格行标
        int nColumn;//记录被拖动单元格列标

        public Form食谱编辑()
        {
            InitializeComponent();

            dataGridView1.MergeColumnNames.Add("Column8");
        }

        private void Form食谱编辑_Load(object sender, EventArgs e)
        {
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            label2.Text = 当前食谱;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            foreach (DataTable dt in tSqlData.mDataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["名称"];
                    if (当前食谱 == str)
                    {
                        updateInfoByDataRow(dr);
                        return;
                    }
                }
            }
        }


        private void updateInfoByDataRow(DataRow dr)
        {
            for (int i = 0; i < 210; )
            {
                int index = this.dataGridView1.Rows.Add();

                int offset = 0;
                switch (i / 70)
                {
                    case 0: this.dataGridView1.Rows[index].Cells[offset++].Value = "早餐"; break;
                    case 1: this.dataGridView1.Rows[index].Cells[offset++].Value = "午餐"; break;
                    case 2: this.dataGridView1.Rows[index].Cells[offset++].Value = "晚餐"; break;
                    default: this.dataGridView1.Rows[index].Cells[offset++].Value = "error"; break;
                }

                i += 7;
            }

            try
            {
                int i = 0;
                for (int offset = 1; offset <= 7; offset++)
                {
                    int index = 0;
                    for (int j = 0; j < 10; j++)
                    {
                        this.dataGridView1.Rows[index++].Cells[offset].Value = dr["菜肴" + (i + 1)]; i++;
                    }
                }
                for (int offset = 1; offset <= 7; offset++)
                {
                    int index = 10;
                    for (int j = 0; j < 10; j++)
                    {
                        this.dataGridView1.Rows[index++].Cells[offset].Value = dr["菜肴" + (i + 1)]; i++;
                    }
                }
                for (int offset = 1; offset <= 7; offset++)
                {
                    int index = 20;
                    for (int j = 0; j < 10; j++)
                    {
                        this.dataGridView1.Rows[index++].Cells[offset].Value = dr["菜肴" + (i + 1)]; i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        void sync食谱ToDB()
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            //collectDataSet
            foreach (DataRow dr in tSqlData.mDataSet.Tables[0].Rows)
            {
                string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;
                string str = (string)dr["名称"];
                if (当前食谱 == str)
                {
                    {
                        int i = 0;
                        for (int offset = 1; offset <= 7; offset++)
                        {
                            int index = 0;
                            for (int j = 0; j < 10; j++)
                            {
                                dr["菜肴" + (i + 1)] = this.dataGridView1.Rows[index++].Cells[offset].Value; i++;
                            }
                        }
                        for (int offset = 1; offset <= 7; offset++)
                        {
                            int index = 10;
                            for (int j = 0; j < 10; j++)
                            {
                                dr["菜肴" + (i + 1)] = this.dataGridView1.Rows[index++].Cells[offset].Value; i++;
                            }
                        }
                        for (int offset = 1; offset <= 7; offset++)
                        {
                            int index = 20;
                            for (int j = 0; j < 10; j++)
                            {
                                dr["菜肴" + (i + 1)] = this.dataGridView1.Rows[index++].Cells[offset].Value; i++;
                            }
                        }
                    }
                    break;
                }
            }

            SqlCommandBuilder sql_command = new SqlCommandBuilder(tSqlData.mSqlDataAdapter);
            tSqlData.mSqlDataAdapter.Update(tSqlData.mDataSet.Tables[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sync食谱ToDB();
            Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            nRow = e.RowIndex;
            nColumn = e.ColumnIndex;
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                str1 = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (str1 != "")
                {
                    dataGridView1.DoDragDrop(str1, DragDropEffects.Move);
                }
            }
        }

        private Point GetRowFromPoint(int x, int y)
        {
            int nX = -1;
            int nY = -1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Rectangle rec = dataGridView1.GetRowDisplayRectangle(i, false);

                if (dataGridView1.RectangleToScreen(rec).Contains(x, y))
                    nX = i;
            }
            for (int nI = 0; nI < dataGridView1.Columns.Count; nI++)
            {
                Rectangle rec = dataGridView1.GetColumnDisplayRectangle(nI, false);
                if (dataGridView1.RectangleToScreen(rec).Contains(x, y))
                    nY = nI;
            }
            return new Point(nX, nY);
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = GetRowFromPoint(e.X, e.Y);

            object tmp = this.dataGridView1.Rows[nRow].Cells[nColumn].Value;

            this.dataGridView1.Rows[nRow].Cells[nColumn].Value = this.dataGridView1.Rows[point.X].Cells[point.Y].Value;
            this.dataGridView1.Rows[point.X].Cells[point.Y].Value = tmp;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
