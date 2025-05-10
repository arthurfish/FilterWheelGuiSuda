using System.Text;
using System.Windows.Forms;

namespace FilterWheelGuiSuda
{
    public partial class Form1 : Form
    {
        private int _deviceHandle = -1;
        private const int BAUD_RATE = 115200;
        private const int TIMEOUT_S = 10;
        private const int SERIAL_BUFFER_SIZE = 256;
        private string _deviceSerialNumber = string.Empty;


        private readonly Dictionary<int, string> _filterNames = new Dictionary<int, string>
        {
            // Example:
             { 1, "0.01mm口径滤光片" },
             { 2, "0.05mm口径滤光片" },
             { 3, "0.10mm口径滤光片" },
             { 4, "0.15mm口径滤光片" },
             { 5, "0.20mm口径滤光片" },
             { 6, "0.25mm口径滤光片" },

        };

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            UpdateConnectionStatusUI(false); // Initial state: disconnected
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            InitializeDevice();
        }

        private void InitializeDevice()
        {
            try
            {
                lblStatus.ForeColor = SystemColors.ControlText;
                lblStatus.Text = "Initializing...";
                Application.DoEvents(); // Allow UI to update

                StringBuilder snBuffer = new StringBuilder(SERIAL_BUFFER_SIZE);
                int numDevices = FilterWheelApi.GetPorts(snBuffer);

                if (numDevices <= 0)
                {
                    string errorMsg = numDevices < 0 ? $"Error getting ports (Code: {FilterWheelApi.GetErrorMessage(numDevices)})." : "No devices found.";
                    ShowError(errorMsg + " Ensure device is connected and drivers are installed.");
                    UpdateConnectionStatusUI(false);
                    return;
                }

                string portList = snBuffer.ToString();
                _deviceSerialNumber = portList.Split(',').FirstOrDefault() ?? string.Empty;

                if (string.IsNullOrEmpty(_deviceSerialNumber))
                {
                    ShowError("Could not parse serial number from device list.");
                    UpdateConnectionStatusUI(false);
                    return;
                }

                lblStatus.Text = $"Attempting to open port: {_deviceSerialNumber}...";
                Application.DoEvents();
                _deviceHandle = FilterWheelApi.Open(_deviceSerialNumber, BAUD_RATE, TIMEOUT_S);

                if (_deviceHandle < 0)
                {
                    ShowError($"Failed to open port {_deviceSerialNumber} ({FilterWheelApi.GetErrorMessage(_deviceHandle)}). Check connection and ensure DLL is present.");
                    _deviceHandle = -1;
                    UpdateConnectionStatusUI(false);
                    return;
                }

                lblStatus.Text = $"Connected to {_deviceSerialNumber}. Handle: {_deviceHandle}.";
                UpdateConnectionStatusUI(true);

                // Get Device ID
                StringBuilder idBuffer = new StringBuilder(256);
                if (FilterWheelApi.GetId(_deviceHandle, idBuffer) == 0)
                {
                    lblDeviceId.Text = $"设备ID: {idBuffer.ToString()}";
                }
                else
                {
                    lblDeviceId.Text = "无法读取设备ID";
                }


                int positionCount;
                int result = FilterWheelApi.GetDevicePositionCount(_deviceHandle, out positionCount);

                if (result != 0)
                {
                    ShowError($"Failed to get position count: {FilterWheelApi.GetErrorMessage(result)}");
                    // Don't CleanupDevice here, port is open, but critical info missing. User might want to check settings.
                    lblStatus.Text += " | Error getting position count.";
                    return; // Keep connected but indicate error
                }

                if (positionCount <= 0)
                {
                    ShowError($"Device reported invalid position count: {positionCount}. Check Settings.");
                    lblStatus.Text += $" | Invalid position count ({positionCount}).";
                    return; // Keep connected but indicate error
                }
                
                lblStatus.Text = $"设备已连接: {_deviceSerialNumber}. 当前位置: {positionCount}.";
                CreatePositionButtons(positionCount);
                UpdateCurrentPositionDisplay();
            }
            catch (DllNotFoundException)
            {
                ShowError($"Critical Error: FilterWheel102_win32.dll not found. Ensure it's in the application directory ({AppDomain.CurrentDomain.BaseDirectory}) and the application is running as x86.");
                UpdateConnectionStatusUI(false);
            }
            catch (Exception ex)
            {
                ShowError($"An unexpected error occurred during initialization: {ex.Message}");
                UpdateConnectionStatusUI(false);
            }
        }

        private void CreatePositionButtons(int count)
        {
            flowLayoutPanelPositions.Controls.Clear();

            for (int i = 1; i <= count; i++)
            {
                Button btn = new Button();
                btn.Tag = i; 

                if (_filterNames.TryGetValue(i, out string? customName))
                {
                    btn.Text = customName;
                }
                else
                {
                    btn.Text = $"Position {i}";
                }
                
                btn.AutoSize = true;
                btn.MinimumSize = new Size(120, 40); 
                btn.Margin = new Padding(5);
                btn.Click += PositionButton_Click;
                flowLayoutPanelPositions.Controls.Add(btn);
            }
        }

        private async void PositionButton_Click(object? sender, EventArgs e)
        {
            if (_deviceHandle < 0 || sender is not Button clickedButton)
            {
                return;
            }

            if (clickedButton.Tag is not int targetPosition)
            {
                return;
            }

            lblStatus.ForeColor = SystemColors.ControlText;
            lblStatus.Text = $"目标位置 {targetPosition}...";
            this.Enabled = false; 

            int result = await Task.Run(() => FilterWheelApi.SetPosition(_deviceHandle, targetPosition));

            if (result == 0)
            {
                lblStatus.Text = $"成功设置位置 {targetPosition}.";
                await Task.Delay(500); 
                UpdateCurrentPositionDisplay();
            }
            else
            {
                ShowError($"Failed to set position {targetPosition}: {FilterWheelApi.GetErrorMessage(result)}");
                UpdateCurrentPositionDisplay();
            }
            this.Enabled = true; 
        }

        private void UpdateCurrentPositionDisplay()
        {
            if (_deviceHandle < 0)
            {
                lblCurrentPosition.Text = "Current Position: N/A (Disconnected)";
                return;
            }

            int currentPos;
            int result = FilterWheelApi.GetPosition(_deviceHandle, out currentPos);
            if (result == 0)
            {
                if (_filterNames.TryGetValue(currentPos, out string? customName))
                {
                     lblCurrentPosition.Text = $"当前: {customName} (位置 {currentPos})";
                }
                else
                {
                     lblCurrentPosition.Text = $"当前位置: {currentPos}";
                }
            }
            else
            {
                lblCurrentPosition.Text = $"当前位置：未知 ({FilterWheelApi.GetErrorMessage(result)})";
            }
        }
        
        private void ShowError(string message)
        {
            lblStatus.Text = $"ERROR: {message}";
            lblStatus.ForeColor = Color.Red;
        }

        private void UpdateConnectionStatusUI(bool connected)
        {
            btnSettings.Enabled = connected;
            // Position buttons are managed by CreatePositionButtons and CleanupDevice
            if (!connected)
            {
                flowLayoutPanelPositions.Controls.Clear();
                lblCurrentPosition.Text = "Current Position: N/A (Disconnected)";
                lblDeviceId.Text = "Device ID: N/A";
            }
        }


        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            CleanupDevice();
        }

        private void CleanupDevice()
        {
            if (_deviceHandle >= 0)
            {
                FilterWheelApi.Close(_deviceHandle);
                _deviceHandle = -1;
                lblStatus.Text = "设备断开连接";
            }
            _deviceSerialNumber = string.Empty;
            UpdateConnectionStatusUI(false);
        }

        private void btnReconnect_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "尝试重连中...";
            lblStatus.ForeColor = SystemColors.ControlText;
            Application.DoEvents();
            CleanupDevice(); // Ensure clean state
            InitializeDevice(); // Re-initialize
        }

        private void btnSettings_Click(object? sender, EventArgs e)
        {
            if (_deviceHandle < 0)
            {
                MessageBox.Show("Device is not connected. Please connect first.", "Not Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SettingsForm settingsForm = new SettingsForm(_deviceHandle))
            {
                settingsForm.ShowDialog(this);
                // If position count was changed, re-initialize to update UI
                if (settingsForm.PositionCountWasChanged)
                {
                    lblStatus.Text = "位置计数已变化。正在重新初始化。";
                    Application.DoEvents();
                    // A full re-initialization might be needed if handles/etc become invalid.
                    // For now, let's try to re-read critical info and update UI.
                    CleanupDevice();
                    InitializeDevice();
                }
                else
                {
                    // Refresh current position as other settings might affect it or user expects it
                    UpdateCurrentPositionDisplay();
                }
            }
        }
    }
}