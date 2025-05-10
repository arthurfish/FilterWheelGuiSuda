namespace FilterWheelGuiSuda
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDeviceId;
        private TextBox txtDeviceId;
        private Label lblPositionCount;
        private NumericUpDown numPositionCount;
        private Label lblSpeed;
        private NumericUpDown numSpeed;
        private Label lblTriggerMode;
        private ComboBox cmbTriggerMode;
        private Label lblMinVelocity;
        private NumericUpDown numMinVelocity;
        private Label lblMaxVelocity;
        private NumericUpDown numMaxVelocity;
        private Label lblAcceleration;
        private NumericUpDown numAcceleration;
        private Label lblSensorMode;
        private NumericUpDown numSensorMode;
        private Button btnApplySettings;
        private Button btnSaveToDevice;
        private Button btnRefresh;
        private Label lblStatus;
        // private Label lblTimeout; // If SetTimeout API is available
        // private NumericUpDown numTimeout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDeviceId = new Label();
            txtDeviceId = new TextBox();
            lblPositionCount = new Label();
            numPositionCount = new NumericUpDown();
            lblSpeed = new Label();
            numSpeed = new NumericUpDown();
            lblTriggerMode = new Label();
            cmbTriggerMode = new ComboBox();
            lblMinVelocity = new Label();
            numMinVelocity = new NumericUpDown();
            lblMaxVelocity = new Label();
            numMaxVelocity = new NumericUpDown();
            lblAcceleration = new Label();
            numAcceleration = new NumericUpDown();
            lblSensorMode = new Label();
            numSensorMode = new NumericUpDown();
            btnApplySettings = new Button();
            btnSaveToDevice = new Button();
            btnRefresh = new Button();
            lblStatus = new Label();
            grpDeviceSettings = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numPositionCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinVelocity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxVelocity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAcceleration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSensorMode).BeginInit();
            grpDeviceSettings.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeviceId
            // 
            lblDeviceId.Anchor = AnchorStyles.Left;
            lblDeviceId.AutoSize = true;
            lblDeviceId.Location = new Point(6, 15);
            lblDeviceId.Margin = new Padding(6, 0, 6, 0);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new Size(100, 31);
            lblDeviceId.TabIndex = 0;
            lblDeviceId.Text = "设备 ID:";
            // 
            // txtDeviceId
            // 
            txtDeviceId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDeviceId.Location = new Point(246, 12);
            txtDeviceId.Margin = new Padding(6);
            txtDeviceId.Name = "txtDeviceId";
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(476, 38);
            txtDeviceId.TabIndex = 1;
            // 
            // lblPositionCount
            // 
            lblPositionCount.Anchor = AnchorStyles.Left;
            lblPositionCount.AutoSize = true;
            lblPositionCount.Location = new Point(6, 77);
            lblPositionCount.Margin = new Padding(6, 0, 6, 0);
            lblPositionCount.Name = "lblPositionCount";
            lblPositionCount.Size = new Size(110, 31);
            lblPositionCount.TabIndex = 2;
            lblPositionCount.Text = "位置计数";
            // 
            // numPositionCount
            // 
            numPositionCount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numPositionCount.Location = new Point(246, 74);
            numPositionCount.Margin = new Padding(6);
            numPositionCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPositionCount.Name = "numPositionCount";
            numPositionCount.Size = new Size(476, 38);
            numPositionCount.TabIndex = 3;
            numPositionCount.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // lblSpeed
            // 
            lblSpeed.Anchor = AnchorStyles.Left;
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new Point(6, 139);
            lblSpeed.Margin = new Padding(6, 0, 6, 0);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(62, 31);
            lblSpeed.TabIndex = 4;
            lblSpeed.Text = "速度";
            // 
            // numSpeed
            // 
            numSpeed.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numSpeed.Location = new Point(246, 136);
            numSpeed.Margin = new Padding(6);
            numSpeed.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSpeed.Name = "numSpeed";
            numSpeed.Size = new Size(476, 38);
            numSpeed.TabIndex = 5;
            // 
            // lblTriggerMode
            // 
            lblTriggerMode.Anchor = AnchorStyles.Left;
            lblTriggerMode.AutoSize = true;
            lblTriggerMode.Location = new Point(6, 201);
            lblTriggerMode.Margin = new Padding(6, 0, 6, 0);
            lblTriggerMode.Name = "lblTriggerMode";
            lblTriggerMode.Size = new Size(110, 31);
            lblTriggerMode.TabIndex = 6;
            lblTriggerMode.Text = "触发模式";
            // 
            // cmbTriggerMode
            // 
            cmbTriggerMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbTriggerMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTriggerMode.FormattingEnabled = true;
            cmbTriggerMode.Items.AddRange(new object[] { "Mode 0", "Mode 1" });
            cmbTriggerMode.Location = new Point(246, 197);
            cmbTriggerMode.Margin = new Padding(6);
            cmbTriggerMode.Name = "cmbTriggerMode";
            cmbTriggerMode.Size = new Size(476, 39);
            cmbTriggerMode.TabIndex = 7;
            // 
            // lblMinVelocity
            // 
            lblMinVelocity.Anchor = AnchorStyles.Left;
            lblMinVelocity.AutoSize = true;
            lblMinVelocity.Location = new Point(6, 263);
            lblMinVelocity.Margin = new Padding(6, 0, 6, 0);
            lblMinVelocity.Name = "lblMinVelocity";
            lblMinVelocity.Size = new Size(110, 31);
            lblMinVelocity.TabIndex = 8;
            lblMinVelocity.Text = "最小速度";
            // 
            // numMinVelocity
            // 
            numMinVelocity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numMinVelocity.Location = new Point(246, 260);
            numMinVelocity.Margin = new Padding(6);
            numMinVelocity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMinVelocity.Name = "numMinVelocity";
            numMinVelocity.Size = new Size(476, 38);
            numMinVelocity.TabIndex = 9;
            // 
            // lblMaxVelocity
            // 
            lblMaxVelocity.Anchor = AnchorStyles.Left;
            lblMaxVelocity.AutoSize = true;
            lblMaxVelocity.Location = new Point(6, 325);
            lblMaxVelocity.Margin = new Padding(6, 0, 6, 0);
            lblMaxVelocity.Name = "lblMaxVelocity";
            lblMaxVelocity.Size = new Size(110, 31);
            lblMaxVelocity.TabIndex = 10;
            lblMaxVelocity.Text = "最大速度";
            // 
            // numMaxVelocity
            // 
            numMaxVelocity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numMaxVelocity.Location = new Point(246, 322);
            numMaxVelocity.Margin = new Padding(6);
            numMaxVelocity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMaxVelocity.Name = "numMaxVelocity";
            numMaxVelocity.Size = new Size(476, 38);
            numMaxVelocity.TabIndex = 11;
            // 
            // lblAcceleration
            // 
            lblAcceleration.Anchor = AnchorStyles.Left;
            lblAcceleration.AutoSize = true;
            lblAcceleration.Location = new Point(6, 387);
            lblAcceleration.Margin = new Padding(6, 0, 6, 0);
            lblAcceleration.Name = "lblAcceleration";
            lblAcceleration.Size = new Size(86, 31);
            lblAcceleration.TabIndex = 12;
            lblAcceleration.Text = "加速度";
            // 
            // numAcceleration
            // 
            numAcceleration.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numAcceleration.Location = new Point(246, 384);
            numAcceleration.Margin = new Padding(6);
            numAcceleration.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAcceleration.Name = "numAcceleration";
            numAcceleration.Size = new Size(476, 38);
            numAcceleration.TabIndex = 13;
            // 
            // lblSensorMode
            // 
            lblSensorMode.Anchor = AnchorStyles.Left;
            lblSensorMode.AutoSize = true;
            lblSensorMode.Location = new Point(6, 454);
            lblSensorMode.Margin = new Padding(6, 0, 6, 0);
            lblSensorMode.Name = "lblSensorMode";
            lblSensorMode.Size = new Size(110, 31);
            lblSensorMode.TabIndex = 14;
            lblSensorMode.Text = "传感模式";
            // 
            // numSensorMode
            // 
            numSensorMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numSensorMode.Location = new Point(246, 451);
            numSensorMode.Margin = new Padding(6);
            numSensorMode.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numSensorMode.Name = "numSensorMode";
            numSensorMode.Size = new Size(476, 38);
            numSensorMode.TabIndex = 15;
            // 
            // btnApplySettings
            // 
            btnApplySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApplySettings.Location = new Point(420, 626);
            btnApplySettings.Margin = new Padding(6);
            btnApplySettings.Name = "btnApplySettings";
            btnApplySettings.Size = new Size(180, 52);
            btnApplySettings.TabIndex = 1;
            btnApplySettings.Text = "应用设置";
            btnApplySettings.UseVisualStyleBackColor = true;
            btnApplySettings.Click += btnApplySettings_Click;
            // 
            // btnSaveToDevice
            // 
            btnSaveToDevice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveToDevice.Location = new Point(612, 626);
            btnSaveToDevice.Margin = new Padding(6);
            btnSaveToDevice.Name = "btnSaveToDevice";
            btnSaveToDevice.Size = new Size(180, 52);
            btnSaveToDevice.TabIndex = 2;
            btnSaveToDevice.Text = "保存到设备";
            btnSaveToDevice.UseVisualStyleBackColor = true;
            btnSaveToDevice.Click += btnSaveToDevice_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(24, 626);
            btnRefresh.Margin = new Padding(6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(180, 52);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "刷新设置";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(24, 692);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(768, 48);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Load settings or make changes.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpDeviceSettings
            // 
            grpDeviceSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDeviceSettings.Controls.Add(tableLayoutPanel1);
            grpDeviceSettings.Location = new Point(24, 25);
            grpDeviceSettings.Margin = new Padding(6);
            grpDeviceSettings.Name = "grpDeviceSettings";
            grpDeviceSettings.Padding = new Padding(20, 21, 20, 21);
            grpDeviceSettings.Size = new Size(768, 579);
            grpDeviceSettings.TabIndex = 0;
            grpDeviceSettings.TabStop = false;
            grpDeviceSettings.Text = "设备设置";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblDeviceId, 0, 0);
            tableLayoutPanel1.Controls.Add(txtDeviceId, 1, 0);
            tableLayoutPanel1.Controls.Add(lblPositionCount, 0, 1);
            tableLayoutPanel1.Controls.Add(numPositionCount, 1, 1);
            tableLayoutPanel1.Controls.Add(lblSpeed, 0, 2);
            tableLayoutPanel1.Controls.Add(numSpeed, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTriggerMode, 0, 3);
            tableLayoutPanel1.Controls.Add(cmbTriggerMode, 1, 3);
            tableLayoutPanel1.Controls.Add(lblMinVelocity, 0, 4);
            tableLayoutPanel1.Controls.Add(numMinVelocity, 1, 4);
            tableLayoutPanel1.Controls.Add(lblMaxVelocity, 0, 5);
            tableLayoutPanel1.Controls.Add(numMaxVelocity, 1, 5);
            tableLayoutPanel1.Controls.Add(lblAcceleration, 0, 6);
            tableLayoutPanel1.Controls.Add(numAcceleration, 1, 6);
            tableLayoutPanel1.Controls.Add(lblSensorMode, 0, 7);
            tableLayoutPanel1.Controls.Add(numSensorMode, 1, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 52);
            tableLayoutPanel1.Margin = new Padding(6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.Size = new Size(728, 506);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 746);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnSaveToDevice);
            Controls.Add(btnApplySettings);
            Controls.Add(grpDeviceSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "旋转设置";
            ((System.ComponentModel.ISupportInitialize)numPositionCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinVelocity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxVelocity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAcceleration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSensorMode).EndInit();
            grpDeviceSettings.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox grpDeviceSettings;
        private TableLayoutPanel tableLayoutPanel1;
    }
}