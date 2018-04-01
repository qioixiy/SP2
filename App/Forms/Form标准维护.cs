using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataModel;
using SP.Utils;

namespace SP
{
    public partial class Form标准维护 : Form
    {
        SqlDataAdapter adapter伙食费标准 = new SqlDataAdapter("select * from dbo.伙食费标准", DBConnect.Instance().getConnectString());
        DataSet dSet伙食费标准 = new DataSet();
        int index伙食费标准 = 0;

        SqlDataAdapter adapter食物定量标准 = new SqlDataAdapter("select * from dbo.食物定量标准", DBConnect.Instance().getConnectString());
        DataSet dSet食物定量标准 = new DataSet();
        int index食物定量标准 = 0;

        SqlDataAdapter adapter营养素标准 = new SqlDataAdapter("select * from dbo.营养素标准", DBConnect.Instance().getConnectString());
        DataSet dSet营养素标准 = new DataSet();
        int index营养素标准 = 0;

        int selectedTabIndex = 0;
        string buttonStatus伙食费标准 = "修改";
        string buttonStatus食物定量标准 = "修改";
        string buttonStatus营养素标准 = "修改";

        public Form标准维护()
        {
            InitializeComponent();
        }

        private void Form标准维护_Load(object sender, EventArgs e)
        {
            adapter伙食费标准.Fill(dSet伙食费标准);
            adapter食物定量标准.Fill(dSet食物定量标准);
            adapter营养素标准.Fill(dSet营养素标准);

            Common.dumpDataSet(dSet伙食费标准);
            Common.dumpDataSet(dSet食物定量标准);
            Common.dumpDataSet(dSet营养素标准);

            setIndex伙食费标准(0);
            setIndex食物定量标准(0);
            setIndex营养素标准(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = button1.Text;
            if (text == "保存")
            {
                button1.Text = "修改";
            }
            else
            {
                button1.Text = "保存";
            }

            if (selectedTabIndex == 0)
            {
                button1_Click_伙食费标准(button1.Text);
                buttonStatus伙食费标准 = button1.Text;
            }
            else if (selectedTabIndex == 1)
            {
                button1_Click_食物定量标准(button1.Text);
                buttonStatus食物定量标准 = button1.Text;
            }
            else if (selectedTabIndex == 2)
            {
                button1_Click_营养素标准(button1.Text);
                buttonStatus营养素标准 = button1.Text;
            }
        }

        private void button1_Click_伙食费标准(string text)
        {
            if (button1.Text == "保存")
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;

                syncToDB伙食费标准();
            }
        }

        private void button1_Click_食物定量标准(string text)
        {
            if (button1.Text == "保存")
            {
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;
                textBox13.ReadOnly = false;
                textBox14.ReadOnly = false;
                textBox15.ReadOnly = false;
                textBox16.ReadOnly = false;
                textBox17.ReadOnly = false;
                textBox18.ReadOnly = false;
                textBox19.ReadOnly = false;
                textBox20.ReadOnly = false;
                textBox21.ReadOnly = false;
                textBox22.ReadOnly = false;
                textBox23.ReadOnly = false;
                textBox24.ReadOnly = false;
                textBox25.ReadOnly = false;
                textBox26.ReadOnly = false;
                textBox27.ReadOnly = false;
                textBox28.ReadOnly = false;
                textBox29.ReadOnly = false;
                textBox30.ReadOnly = false;
                textBox31.ReadOnly = false;
                textBox32.ReadOnly = false;
            }
            else
            {
                textBox10.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox14.ReadOnly = true;
                textBox15.ReadOnly = true;
                textBox16.ReadOnly = true;
                textBox17.ReadOnly = true;
                textBox18.ReadOnly = true;
                textBox19.ReadOnly = true;
                textBox20.ReadOnly = true;
                textBox21.ReadOnly = true;
                textBox22.ReadOnly = true;
                textBox23.ReadOnly = true;
                textBox24.ReadOnly = true;
                textBox25.ReadOnly = true;
                textBox26.ReadOnly = true;
                textBox27.ReadOnly = true;
                textBox28.ReadOnly = true;
                textBox29.ReadOnly = true;
                textBox30.ReadOnly = true;
                textBox31.ReadOnly = true;
                textBox32.ReadOnly = true;

                syncToDB食物定量标准();
            }
        }
        private void button1_Click_营养素标准(string text)
        {
            if (text == "保存")
            {
                textBox33.ReadOnly = false;
                textBox34.ReadOnly = false;
                textBox35.ReadOnly = false;
                textBox36.ReadOnly = false;
                textBox37.ReadOnly = false;
                textBox38.ReadOnly = false;
                textBox39.ReadOnly = false;
                textBox40.ReadOnly = false;
                textBox41.ReadOnly = false;
                textBox42.ReadOnly = false;
                textBox43.ReadOnly = false;
                textBox44.ReadOnly = false;
                textBox45.ReadOnly = false;
                textBox46.ReadOnly = false;
                textBox47.ReadOnly = false;
            }
            else
            {
                textBox33.ReadOnly = true;
                textBox34.ReadOnly = true;
                textBox35.ReadOnly = true;
                textBox36.ReadOnly = true;
                textBox37.ReadOnly = true;
                textBox38.ReadOnly = true;
                textBox39.ReadOnly = true;
                textBox40.ReadOnly = true;
                textBox41.ReadOnly = true;
                textBox42.ReadOnly = true;
                textBox43.ReadOnly = true;
                textBox44.ReadOnly = true;
                textBox45.ReadOnly = true;
                textBox46.ReadOnly = true;
                textBox47.ReadOnly = true;

                syncToDB营养素标准();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setIndex食物定量标准(comboBox1.SelectedIndex);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(0);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(1);
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(2);
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(3);
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(4);
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(5);
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(6);
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            setIndex营养素标准(7);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(2);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(3);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(4);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(5);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(6);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            setIndex伙食费标准(7);
        }

        private void setIndex伙食费标准(int i)
        {
            index伙食费标准 = i;
            updateTexts伙食费标准();
        }


        private void setIndex食物定量标准(int i)
        {
            index食物定量标准 = i;
            updateTexts食物定量标准();
        }
        private void setIndex营养素标准(int i)
        {
            index营养素标准 = i;
            updateTexts营养素标准();
        }

        private void updateTexts伙食费标准()
        {
            int index = index伙食费标准;
            textBox1.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["一类区"];
            textBox2.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["二类区"];
            textBox3.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["三类区"];
            textBox4.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["四类区"];
            textBox5.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["五类区"];
            textBox6.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["高原一类区"];
            textBox7.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["高原二类区"];
            textBox8.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["高原三类区"];
            textBox9.Text = (string)dSet伙食费标准.Tables[0].Rows[index]["高原四类区"];
        }

        private void updateTexts食物定量标准()
        {
            int index = index食物定量标准;
            textBox10.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["粮食"];
            textBox11.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["猪肉"];
            textBox12.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["牛羊肉"];
            textBox13.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["脏腑"];
            textBox14.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["禽蛋"];
            textBox15.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["牛乳粉"];
            textBox16.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["鱼虾"];
            textBox17.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["黄豆"];
            textBox18.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["豆乳粉"];
            textBox19.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["蔬菜"];
            textBox20.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["水果"];
            textBox21.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["植物油"];
            textBox22.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["木耳"];
            textBox23.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["蘑菇"];
            textBox24.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["黄花菜"];
            textBox25.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["饮料"];
            textBox26.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["调料"];
            textBox27.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["巧克力"];
            textBox28.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["禽肉"];
            textBox29.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["海米"];
            textBox30.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["蔗糖"];
            textBox31.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["海带"];
            textBox32.Text = (string)dSet食物定量标准.Tables[0].Rows[index]["紫菜"];
        }

        private void updateTexts营养素标准()
        {
            int index = index营养素标准;
            textBox33.Text = (string)dSet营养素标准.Tables[0].Rows[index]["能量"];
            textBox34.Text = (string)dSet营养素标准.Tables[0].Rows[index]["蛋白质"];
            textBox35.Text = (string)dSet营养素标准.Tables[0].Rows[index]["钙"];
            textBox36.Text = (string)dSet营养素标准.Tables[0].Rows[index]["铁"];
            textBox37.Text = (string)dSet营养素标准.Tables[0].Rows[index]["锌"];
            textBox38.Text = (string)dSet营养素标准.Tables[0].Rows[index]["碘"];
            textBox39.Text = (string)dSet营养素标准.Tables[0].Rows[index]["硒"];
            textBox40.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素C"];
            textBox41.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素A"];
            textBox42.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素B2"];
            textBox43.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素E"];
            textBox44.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素B6"];
            textBox45.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素D"];
            textBox46.Text = (string)dSet营养素标准.Tables[0].Rows[index]["烟酸"];
            textBox47.Text = (string)dSet营养素标准.Tables[0].Rows[index]["维生素B1"];
        }

        private void syncToDB伙食费标准()
        {
            int index = index伙食费标准;
            Console.WriteLine(index);
            Common.dumpDataSet(dSet伙食费标准);
            dSet伙食费标准.Tables[0].Rows[index]["一类区"] = textBox1.Text;
            dSet伙食费标准.Tables[0].Rows[index]["二类区"] = textBox2.Text;
            dSet伙食费标准.Tables[0].Rows[index]["三类区"] = textBox3.Text;
            dSet伙食费标准.Tables[0].Rows[index]["四类区"] = textBox4.Text;
            dSet伙食费标准.Tables[0].Rows[index]["五类区"] = textBox5.Text;
            dSet伙食费标准.Tables[0].Rows[index]["高原一类区"] = textBox6.Text;
            dSet伙食费标准.Tables[0].Rows[index]["高原二类区"] = textBox7.Text;
            dSet伙食费标准.Tables[0].Rows[index]["高原三类区"] = textBox8.Text;
            dSet伙食费标准.Tables[0].Rows[index]["高原四类区"] = textBox9.Text;

            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter伙食费标准);
            adapter伙食费标准.Update(dSet伙食费标准.Tables[0]);

            Common.dumpDataSet(dSet伙食费标准);

            MessageBox.Show("保存成功");
        }

        private void syncToDB食物定量标准()
        {
            int index = index食物定量标准;
            Console.WriteLine(index);
            Common.dumpDataSet(dSet食物定量标准);
            dSet食物定量标准.Tables[0].Rows[index]["粮食"] = textBox10.Text;
            dSet食物定量标准.Tables[0].Rows[index]["猪肉"] = textBox11.Text;
            dSet食物定量标准.Tables[0].Rows[index]["牛羊肉"] = textBox12.Text;
            dSet食物定量标准.Tables[0].Rows[index]["脏腑"] = textBox13.Text;
            dSet食物定量标准.Tables[0].Rows[index]["禽蛋"] = textBox14.Text;
            dSet食物定量标准.Tables[0].Rows[index]["牛乳粉"] = textBox15.Text;
            dSet食物定量标准.Tables[0].Rows[index]["鱼虾"] = textBox16.Text;
            dSet食物定量标准.Tables[0].Rows[index]["黄豆"] = textBox17.Text;
            dSet食物定量标准.Tables[0].Rows[index]["豆乳粉"] = textBox18.Text;
            dSet食物定量标准.Tables[0].Rows[index]["蔬菜"] = textBox19.Text;
            dSet食物定量标准.Tables[0].Rows[index]["水果"] = textBox20.Text;
            dSet食物定量标准.Tables[0].Rows[index]["植物油"] = textBox21.Text;
            dSet食物定量标准.Tables[0].Rows[index]["木耳"] = textBox22.Text;
            dSet食物定量标准.Tables[0].Rows[index]["蘑菇"] = textBox23.Text;
            dSet食物定量标准.Tables[0].Rows[index]["黄花菜"] = textBox24.Text;
            dSet食物定量标准.Tables[0].Rows[index]["饮料"] = textBox25.Text;
            dSet食物定量标准.Tables[0].Rows[index]["调料"] = textBox26.Text;
            dSet食物定量标准.Tables[0].Rows[index]["巧克力"] = textBox27.Text;
            dSet食物定量标准.Tables[0].Rows[index]["禽肉"] = textBox28.Text;
            dSet食物定量标准.Tables[0].Rows[index]["海米"] = textBox29.Text;
            dSet食物定量标准.Tables[0].Rows[index]["蔗糖"] = textBox30.Text;
            dSet食物定量标准.Tables[0].Rows[index]["海带"] = textBox31.Text;
            dSet食物定量标准.Tables[0].Rows[index]["紫菜"] = textBox32.Text;

            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter食物定量标准);
            adapter食物定量标准.Update(dSet食物定量标准.Tables[0]);

            Common.dumpDataSet(dSet食物定量标准);

            MessageBox.Show("保存成功");
        }

        private void syncToDB营养素标准()
        {
            int index = index营养素标准;
            Console.WriteLine(index);
            Common.dumpDataSet(dSet营养素标准);

            dSet营养素标准.Tables[0].Rows[index]["能量"] = textBox33.Text;
            dSet营养素标准.Tables[0].Rows[index]["蛋白质"] = textBox34.Text;
            dSet营养素标准.Tables[0].Rows[index]["钙"] = textBox35.Text;
            dSet营养素标准.Tables[0].Rows[index]["铁"] = textBox36.Text;
            dSet营养素标准.Tables[0].Rows[index]["锌"] = textBox37.Text;
            dSet营养素标准.Tables[0].Rows[index]["碘"] = textBox38.Text;
            dSet营养素标准.Tables[0].Rows[index]["硒"] = textBox39.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素C"] = textBox40.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素A"] = textBox41.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素B2"] = textBox42.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素E"] = textBox43.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素B6"] = textBox44.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素D"] = textBox45.Text;
            dSet营养素标准.Tables[0].Rows[index]["烟酸"] = textBox46.Text;
            dSet营养素标准.Tables[0].Rows[index]["维生素B1"] = textBox47.Text;

            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter营养素标准);
            adapter营养素标准.Update(dSet营养素标准.Tables[0]);

            Common.dumpDataSet(dSet营养素标准);

            MessageBox.Show("保存成功");
        }

        private void form标准维护BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTabIndex = tabControl1.SelectedIndex;
            SelectedIndexChanged();
        }

        private void SelectedIndexChanged()
        {
            switch(selectedTabIndex)
            {
                case 0:
                    button1.Text = buttonStatus伙食费标准;
                    break;
                case 1:
                    button1.Text = buttonStatus食物定量标准;
                    break;
                case 2:
                    button1.Text = buttonStatus营养素标准;
                    break;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
