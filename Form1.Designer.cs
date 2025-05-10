namespace FilterWheelGuiSuda
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelPositions;
        private Label lblStatus;
        private Label lblCurrentPosition;
        private Button btnReconnect;
        private Button btnSettings;
        private Label lblDeviceId; // To display device ID

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
            flowLayoutPanelPositions = new FlowLayoutPanel();
            lblStatus = new Label();
            lblCurrentPosition = new Label();
            btnReconnect = new Button();
            btnSettings = new Button();
            lblDeviceId = new Label();
            pnlBottom = new Panel();
            pnlButtons = new Panel();
            pnlBottom.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelPositions
            // 
            flowLayoutPanelPositions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelPositions.AutoScroll = true;
            flowLayoutPanelPositions.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelPositions.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelPositions.Location = new Point(24, 25);
            flowLayoutPanelPositions.Margin = new Padding(6, 6, 6, 6);
            flowLayoutPanelPositions.Name = "flowLayoutPanelPositions";
            flowLayoutPanelPositions.Padding = new Padding(10, 10, 10, 10);
            flowLayoutPanelPositions.Size = new Size(918, 411);
            flowLayoutPanelPositions.TabIndex = 0;
            flowLayoutPanelPositions.WrapContents = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(24, 95);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(920, 37);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status: Initializing...";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentPosition
            // 
            lblCurrentPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentPosition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentPosition.Location = new Point(24, 52);
            lblCurrentPosition.Margin = new Padding(6, 0, 6, 0);
            lblCurrentPosition.Name = "lblCurrentPosition";
            lblCurrentPosition.Size = new Size(920, 37);
            lblCurrentPosition.TabIndex = 1;
            lblCurrentPosition.Text = "Current Position: N/A";
            lblCurrentPosition.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnReconnect
            // 
            btnReconnect.Location = new Point(24, 17);
            btnReconnect.Margin = new Padding(6, 6, 6, 6);
            btnReconnect.Name = "btnReconnect";
            btnReconnect.Size = new Size(180, 52);
            btnReconnect.TabIndex = 0;
            btnReconnect.Text = "重连";
            btnReconnect.UseVisualStyleBackColor = true;
            btnReconnect.Click += btnReconnect_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Enabled = false;
            btnSettings.Location = new Point(764, 17);
            btnSettings.Margin = new Padding(6, 6, 6, 6);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(180, 52);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "旋转设置";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // lblDeviceId
            // 
            lblDeviceId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDeviceId.Location = new Point(24, 8);
            lblDeviceId.Margin = new Padding(6, 0, 6, 0);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new Size(920, 37);
            lblDeviceId.TabIndex = 2;
            lblDeviceId.Text = "Device ID: N/A";
            lblDeviceId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(lblDeviceId);
            pnlBottom.Controls.Add(lblCurrentPosition);
            pnlBottom.Controls.Add(lblStatus);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 535);
            pnlBottom.Margin = new Padding(6, 6, 6, 6);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(968, 149);
            pnlBottom.TabIndex = 2;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnReconnect);
            pnlButtons.Controls.Add(btnSettings);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 450);
            pnlButtons.Margin = new Padding(6, 6, 6, 6);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(16, 10, 16, 10);
            pnlButtons.Size = new Size(968, 85);
            pnlButtons.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 684);
            Controls.Add(pnlButtons);
            Controls.Add(pnlBottom);
            Controls.Add(flowLayoutPanelPositions);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(674, 544);
            Name = "Form1";
            Text = "滤光片轮控制";
            pnlBottom.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel pnlBottom;
        private Panel pnlButtons;
    }
}