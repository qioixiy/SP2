using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP.Forms;
using DataModel;
using System.Data.SqlClient;

namespace SP
{
    public partial class FormMainWindow : Form
    {
        public UserContext mUserContext;

        public FormMainWindow()
        {
            mUserContext = new UserContext();

            InitializeComponent();
        }

        private void 上报接收ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 使用单位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form伙食单位参数().ShowDialog();
        }

        private void 系统密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form更改密码().ShowDialog();
        }

        private void 食谱备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new 食谱备份().ShowDialog();
        }

        private void 食谱恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱恢复().ShowDialog();
        }

        private void 食谱清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();//实例化一个类
                con.ConnectionString = DBConnect.Instance().getConnectString();
                con.Open();

                string strdel = "DELETE FROM [SP].[dbo].[食谱]";
                SqlCommand comm = new SqlCommand(strdel, con);//sql 语句命令
                comm.ExecuteNonQuery();// 执行sql 语句命令

                con.Close();

                MessageBox.Show("食谱已经清空");
            }
            catch(Exception ex)
            {
                MessageBox.Show("发生异常" + ex.ToString());
            }
            finally
            {

            }
        }

        private void 标准维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form标准维护().ShowDialog();
        }

        private void 营养标准ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form营养维护().ShowDialog();
        }

        private void 军粮差价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form军粮差价().ShowDialog();
        }

        private void 打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 更换背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 标准模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱生成标准模式().ShowDialog();
        }

        private void 自定义模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱生成自定义模式().ShowDialog();
        }

        private void 点菜模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱生成点菜模式().ShowDialog();
        }

        private void 食谱调用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱调用().ShowDialog();
        }

        private void 食谱编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 食谱评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 总体评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 伙食费评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 热能分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 食谱打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new Form食谱公布表打印().ShowDialog();
            }
            catch
            {
                MessageBox.Show("发生异常");
            }
            finally
            {

            }
        }

        private void 节日食谱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form节日食谱().ShowDialog();
        }

        private void 计划汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form计划汇总().ShowDialog();
        }

        private void 计划维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form计划维护().ShowDialog();
        }

        private void 外购计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form外购计划().ShowDialog();
        }

        private void 食谱上报ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱上报().ShowDialog();
        }

        private void 食谱接收ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 食谱查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form食谱查看().ShowDialog();
        }

        private void 包伙制食堂ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 购买制食堂ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 膳食指南ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 美食天地ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 名菜制作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 小菜制作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选料配菜ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 基础数据备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 基础数据恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 常用原料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form常用原料().ShowDialog();
        }

        private void 常用菜肴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form菜肴优选().ShowDialog();
        }

        private void 原料编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form原料编辑().ShowDialog();
        }

        private void 菜肴编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form菜肴编辑().ShowDialog();
        }

        private void 模板编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 标准模式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form食谱调试().ShowDialog();
        }

        private void 自定义模式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form自定义模式编辑().ShowDialog();
        }

        private void 权重调整ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form权重调整().ShowDialog();
        }

        private void 节日食谱ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form数据管理节日食谱().ShowDialog();
        }

        private void 淡旺季区分ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 自产菜登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 库存菜登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于食谱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormIconTest().ShowDialog();
        }

        private void 总体评估ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            总体评估ToolStripMenuItem_Click(sender, e);
        }

        private void 伙食费评估ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            伙食费评估ToolStripMenuItem_Click(sender, e);
        }

        private void 热能分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            热能分析ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Form伙食单位参数().ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new 食谱备份().ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new Form标准维护().ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new 食谱备份().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new Form食谱恢复().ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            new Form营养维护().ShowDialog();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {
            this.Text = Program.FormMainWindowInstance.mUserContext.当前食谱;
        }
    }
}
