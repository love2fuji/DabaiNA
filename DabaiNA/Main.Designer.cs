namespace DabaiNA
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvShowDepart = new System.Windows.Forms.DataGridView();
            this.dgvShowRegion = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ServerLog = new System.Windows.Forms.RichTextBox();
            this.tpgRegion = new System.Windows.Forms.TabPage();
            this.tabConServerLog = new System.Windows.Forms.TabControl();
            this.tpgDepart = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaseDataExport2Excel = new System.Windows.Forms.Button();
            this.btnDataExport2Excel = new System.Windows.Forms.Button();
            this.btnImportRegion = new System.Windows.Forms.Button();
            this.btnOpenCSV = new System.Windows.Forms.Button();
            this.btnImportDepart = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowDepart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRegion)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tpgRegion.SuspendLayout();
            this.tabConServerLog.SuspendLayout();
            this.tpgDepart.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "短信服务";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem1,
            this.退出ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 84);
            // 
            // 显示ToolStripMenuItem1
            // 
            this.显示ToolStripMenuItem1.Name = "显示ToolStripMenuItem1";
            this.显示ToolStripMenuItem1.Size = new System.Drawing.Size(146, 40);
            this.显示ToolStripMenuItem1.Text = "显示";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(146, 40);
            this.退出ToolStripMenuItem1.Text = "退出";
            // 
            // dgvShowDepart
            // 
            this.dgvShowDepart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowDepart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShowDepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowDepart.Location = new System.Drawing.Point(4, 4);
            this.dgvShowDepart.Margin = new System.Windows.Forms.Padding(4);
            this.dgvShowDepart.Name = "dgvShowDepart";
            this.dgvShowDepart.RowHeadersWidth = 10;
            this.dgvShowDepart.RowTemplate.Height = 23;
            this.dgvShowDepart.Size = new System.Drawing.Size(1737, 723);
            this.dgvShowDepart.TabIndex = 0;
            // 
            // dgvShowRegion
            // 
            this.dgvShowRegion.AllowDrop = true;
            this.dgvShowRegion.AllowUserToAddRows = false;
            this.dgvShowRegion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowRegion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShowRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowRegion.Location = new System.Drawing.Point(4, 4);
            this.dgvShowRegion.Margin = new System.Windows.Forms.Padding(4);
            this.dgvShowRegion.Name = "dgvShowRegion";
            this.dgvShowRegion.RowHeadersWidth = 50;
            this.dgvShowRegion.RowTemplate.Height = 23;
            this.dgvShowRegion.Size = new System.Drawing.Size(1737, 723);
            this.dgvShowRegion.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ServerLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1689, 957);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ServerLog
            // 
            this.ServerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerLog.Location = new System.Drawing.Point(4, 4);
            this.ServerLog.Margin = new System.Windows.Forms.Padding(4);
            this.ServerLog.Name = "ServerLog";
            this.ServerLog.Size = new System.Drawing.Size(1681, 949);
            this.ServerLog.TabIndex = 24;
            this.ServerLog.Text = "";
            // 
            // tpgRegion
            // 
            this.tpgRegion.AutoScroll = true;
            this.tpgRegion.Controls.Add(this.dgvShowRegion);
            this.tpgRegion.Location = new System.Drawing.Point(4, 28);
            this.tpgRegion.Margin = new System.Windows.Forms.Padding(4);
            this.tpgRegion.Name = "tpgRegion";
            this.tpgRegion.Padding = new System.Windows.Forms.Padding(4);
            this.tpgRegion.Size = new System.Drawing.Size(1745, 731);
            this.tpgRegion.TabIndex = 1;
            this.tpgRegion.Text = "区域/部门基础数据";
            this.tpgRegion.UseVisualStyleBackColor = true;
            // 
            // tabConServerLog
            // 
            this.tabConServerLog.Controls.Add(this.tabPage1);
            this.tabConServerLog.Controls.Add(this.tpgRegion);
            this.tabConServerLog.Controls.Add(this.tpgDepart);
            this.tabConServerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConServerLog.Location = new System.Drawing.Point(4, 25);
            this.tabConServerLog.Margin = new System.Windows.Forms.Padding(4);
            this.tabConServerLog.Name = "tabConServerLog";
            this.tabConServerLog.SelectedIndex = 0;
            this.tabConServerLog.Size = new System.Drawing.Size(1697, 989);
            this.tabConServerLog.TabIndex = 28;
            // 
            // tpgDepart
            // 
            this.tpgDepart.Controls.Add(this.dgvShowDepart);
            this.tpgDepart.Location = new System.Drawing.Point(4, 28);
            this.tpgDepart.Margin = new System.Windows.Forms.Padding(4);
            this.tpgDepart.Name = "tpgDepart";
            this.tpgDepart.Padding = new System.Windows.Forms.Padding(4);
            this.tpgDepart.Size = new System.Drawing.Size(1745, 731);
            this.tpgDepart.TabIndex = 2;
            this.tpgDepart.Text = " ";
            this.tpgDepart.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabConServerLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 112);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1705, 1018);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态显示";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaseDataExport2Excel);
            this.groupBox1.Controls.Add(this.btnDataExport2Excel);
            this.groupBox1.Controls.Add(this.btnImportRegion);
            this.groupBox1.Controls.Add(this.btnOpenCSV);
            this.groupBox1.Controls.Add(this.btnImportDepart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1705, 112);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // btnBaseDataExport2Excel
            // 
            this.btnBaseDataExport2Excel.BackColor = System.Drawing.SystemColors.Control;
            this.btnBaseDataExport2Excel.Location = new System.Drawing.Point(48, 30);
            this.btnBaseDataExport2Excel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaseDataExport2Excel.Name = "btnBaseDataExport2Excel";
            this.btnBaseDataExport2Excel.Size = new System.Drawing.Size(135, 62);
            this.btnBaseDataExport2Excel.TabIndex = 19;
            this.btnBaseDataExport2Excel.Text = "导出基础数据";
            this.btnBaseDataExport2Excel.UseVisualStyleBackColor = false;
            // 
            // btnDataExport2Excel
            // 
            this.btnDataExport2Excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDataExport2Excel.Location = new System.Drawing.Point(214, 30);
            this.btnDataExport2Excel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDataExport2Excel.Name = "btnDataExport2Excel";
            this.btnDataExport2Excel.Size = new System.Drawing.Size(132, 62);
            this.btnDataExport2Excel.TabIndex = 17;
            this.btnDataExport2Excel.Text = "导出原来配置";
            this.btnDataExport2Excel.UseVisualStyleBackColor = false;
            // 
            // btnImportRegion
            // 
            this.btnImportRegion.BackColor = System.Drawing.SystemColors.Info;
            this.btnImportRegion.Location = new System.Drawing.Point(726, 30);
            this.btnImportRegion.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportRegion.Name = "btnImportRegion";
            this.btnImportRegion.Size = new System.Drawing.Size(170, 62);
            this.btnImportRegion.TabIndex = 16;
            this.btnImportRegion.Text = "导入区域基础数据";
            this.btnImportRegion.UseVisualStyleBackColor = false;
            // 
            // btnOpenCSV
            // 
            this.btnOpenCSV.Location = new System.Drawing.Point(488, 30);
            this.btnOpenCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCSV.Name = "btnOpenCSV";
            this.btnOpenCSV.Size = new System.Drawing.Size(164, 62);
            this.btnOpenCSV.TabIndex = 16;
            this.btnOpenCSV.Text = "查找文件（.CSV）";
            this.btnOpenCSV.UseVisualStyleBackColor = true;
            // 
            // btnImportDepart
            // 
            this.btnImportDepart.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnImportDepart.Location = new System.Drawing.Point(956, 30);
            this.btnImportDepart.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportDepart.Name = "btnImportDepart";
            this.btnImportDepart.Size = new System.Drawing.Size(170, 62);
            this.btnImportDepart.TabIndex = 16;
            this.btnImportDepart.Text = "导入部门基础数据";
            this.btnImportDepart.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 1130);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowDepart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRegion)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tpgRegion.ResumeLayout(false);
            this.tabConServerLog.ResumeLayout(false);
            this.tpgDepart.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgvShowDepart;
        public System.Windows.Forms.DataGridView dgvShowRegion;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox ServerLog;
        private System.Windows.Forms.TabPage tpgRegion;
        private System.Windows.Forms.TabControl tabConServerLog;
        private System.Windows.Forms.TabPage tpgDepart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBaseDataExport2Excel;
        private System.Windows.Forms.Button btnDataExport2Excel;
        private System.Windows.Forms.Button btnImportRegion;
        private System.Windows.Forms.Button btnOpenCSV;
        private System.Windows.Forms.Button btnImportDepart;
    }
}

