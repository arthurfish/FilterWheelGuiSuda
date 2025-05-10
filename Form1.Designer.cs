namespace FilterWheelGuiSuda
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelPositions;
        private Label lblStatus;
        private Label lblCurrentPosition;

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
            flowLayoutPanelPositions.Size = new Size(718, 411);
            flowLayoutPanelPositions.TabIndex = 0;
            flowLayoutPanelPositions.WrapContents = false;
            flowLayoutPanelPositions.Paint += flowLayoutPanelPositions_Paint;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(24, 513);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(720, 48);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: Initializing...";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentPosition
            // 
            lblCurrentPosition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentPosition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentPosition.Location = new Point(24, 455);
            lblCurrentPosition.Margin = new Padding(6, 0, 6, 0);
            lblCurrentPosition.Name = "lblCurrentPosition";
            lblCurrentPosition.Size = new Size(720, 48);
            lblCurrentPosition.TabIndex = 2;
            lblCurrentPosition.Text = "Current Position: N/A";
            lblCurrentPosition.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 581);
            Controls.Add(lblCurrentPosition);
            Controls.Add(lblStatus);
            Controls.Add(flowLayoutPanelPositions);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(574, 441);
            Name = "Form1";
            Text = "Filter Wheel Control";
            ResumeLayout(false);
        }
    }
}