﻿namespace DabaiNA
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboxBiuldInfo = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDeviceManage = new System.Windows.Forms.Button();
            this.btnQueryDeviceStatus = new System.Windows.Forms.Button();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.btnModifyDeviceInfo = new System.Windows.Forms.Button();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 76);
            // 
            // 显示ToolStripMenuItem1
            // 
            this.显示ToolStripMenuItem1.Name = "显示ToolStripMenuItem1";
            this.显示ToolStripMenuItem1.Size = new System.Drawing.Size(136, 36);
            this.显示ToolStripMenuItem1.Text = "显示";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(136, 36);
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
            this.dgvShowDepart.Size = new System.Drawing.Size(1681, 949);
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
            this.dgvShowRegion.Size = new System.Drawing.Size(1681, 949);
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
            this.tpgRegion.Size = new System.Drawing.Size(1689, 957);
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
            this.tpgDepart.Size = new System.Drawing.Size(1689, 957);
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboxBiuldInfo);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnDeviceManage);
            this.groupBox1.Controls.Add(this.btnQueryDeviceStatus);
            this.groupBox1.Controls.Add(this.btnModifyDeviceInfo);
            this.groupBox1.Controls.Add(this.btnGetDevices);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(484, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 36);
            this.label1.TabIndex = 22;
            this.label1.Text = "选择设备所属区域";
            // 
            // cboxBiuldInfo
            // 
            this.cboxBiuldInfo.FormattingEnabled = true;
            this.cboxBiuldInfo.Location = new System.Drawing.Point(477, 65);
            this.cboxBiuldInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cboxBiuldInfo.Name = "cboxBiuldInfo";
            this.cboxBiuldInfo.Size = new System.Drawing.Size(246, 26);
            this.cboxBiuldInfo.TabIndex = 21;
            this.cboxBiuldInfo.SelectedIndexChanged += new System.EventHandler(this.cboxBiuldInfo_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.Location = new System.Drawing.Point(224, 29);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 62);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "停止服务";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(83, 29);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 62);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "启动服务";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDeviceManage
            // 
            this.btnDeviceManage.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeviceManage.Location = new System.Drawing.Point(995, 29);
            this.btnDeviceManage.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeviceManage.Name = "btnDeviceManage";
            this.btnDeviceManage.Size = new System.Drawing.Size(99, 62);
            this.btnDeviceManage.TabIndex = 19;
            this.btnDeviceManage.Text = "设备管理";
            this.btnDeviceManage.UseVisualStyleBackColor = false;
            this.btnDeviceManage.Click += new System.EventHandler(this.btnDeviceManage_Click);
            // 
            // btnQueryDeviceStatus
            // 
            this.btnQueryDeviceStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQueryDeviceStatus.Location = new System.Drawing.Point(1492, 29);
            this.btnQueryDeviceStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnQueryDeviceStatus.Name = "btnQueryDeviceStatus";
            this.btnQueryDeviceStatus.Size = new System.Drawing.Size(132, 62);
            this.btnQueryDeviceStatus.TabIndex = 17;
            this.btnQueryDeviceStatus.Text = "测试Test";
            this.btnQueryDeviceStatus.UseVisualStyleBackColor = false;
            this.btnQueryDeviceStatus.Click += new System.EventHandler(this.btnQueryDeviceStatus_Click);
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGetDevices.Location = new System.Drawing.Point(757, 29);
            this.btnGetDevices.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(170, 62);
            this.btnGetDevices.TabIndex = 16;
            this.btnGetDevices.Text = "查询接入设备";
            this.btnGetDevices.UseVisualStyleBackColor = false;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // btnModifyDeviceInfo
            // 
            this.btnModifyDeviceInfo.BackColor = System.Drawing.SystemColors.Info;
            this.btnModifyDeviceInfo.Location = new System.Drawing.Point(1302, 29);
            this.btnModifyDeviceInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnModifyDeviceInfo.Name = "btnModifyDeviceInfo";
            this.btnModifyDeviceInfo.Size = new System.Drawing.Size(170, 62);
            this.btnModifyDeviceInfo.TabIndex = 16;
            this.btnModifyDeviceInfo.Text = "修改设备信息";
            this.btnModifyDeviceInfo.UseVisualStyleBackColor = false;
            this.btnModifyDeviceInfo.Click += new System.EventHandler(this.btnModifyDeviceInfo_Click);
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
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnDeviceManage;
        private System.Windows.Forms.Button btnQueryDeviceStatus;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxBiuldInfo;
        private System.Windows.Forms.Button btnModifyDeviceInfo;
    }
}

