namespace WindowsFormsApplicationSP
{
    partial class FormMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.食谱生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采购计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上报接收ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.社会化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实用知识ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统维护ToolStripMenuItem,
            this.食谱生成ToolStripMenuItem,
            this.采购计划ToolStripMenuItem,
            this.上报接收ToolStripMenuItem,
            this.社会化ToolStripMenuItem,
            this.实用知识ToolStripMenuItem,
            this.数据管理ToolStripMenuItem,
            this.系统帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统维护ToolStripMenuItem
            // 
            this.系统维护ToolStripMenuItem.Name = "系统维护ToolStripMenuItem";
            this.系统维护ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统维护ToolStripMenuItem.Text = "系统维护";
            // 
            // 食谱生成ToolStripMenuItem
            // 
            this.食谱生成ToolStripMenuItem.Name = "食谱生成ToolStripMenuItem";
            this.食谱生成ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.食谱生成ToolStripMenuItem.Text = "食谱生成";
            // 
            // 采购计划ToolStripMenuItem
            // 
            this.采购计划ToolStripMenuItem.Name = "采购计划ToolStripMenuItem";
            this.采购计划ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.采购计划ToolStripMenuItem.Text = "采购计划";
            // 
            // 上报接收ToolStripMenuItem
            // 
            this.上报接收ToolStripMenuItem.Name = "上报接收ToolStripMenuItem";
            this.上报接收ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.上报接收ToolStripMenuItem.Text = "上报接收";
            // 
            // 社会化ToolStripMenuItem
            // 
            this.社会化ToolStripMenuItem.Name = "社会化ToolStripMenuItem";
            this.社会化ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.社会化ToolStripMenuItem.Text = "社会化";
            // 
            // 实用知识ToolStripMenuItem
            // 
            this.实用知识ToolStripMenuItem.Name = "实用知识ToolStripMenuItem";
            this.实用知识ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.实用知识ToolStripMenuItem.Text = "实用知识";
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 系统帮助ToolStripMenuItem
            // 
            this.系统帮助ToolStripMenuItem.Name = "系统帮助ToolStripMenuItem";
            this.系统帮助ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统帮助ToolStripMenuItem.Text = "系统帮助";
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 486);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainWindow";
            this.Text = "军人食谱系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 食谱生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采购计划ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上报接收ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 社会化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实用知识ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统帮助ToolStripMenuItem;
    }
}