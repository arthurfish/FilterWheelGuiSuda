using System.Text;
using System.Windows.Forms;

namespace FilterWheelGuiSuda
{
    public partial class Form1 : Form
    {
        private int _deviceHandle = -1;
        private const int BAUD_RATE = 115200; // Default from Fw102C_Demo.cpp
        private const int TIMEOUT_S = 10;     // Default from Fw102C_Demo.cpp
        private const int SERIAL_BUFFER_SIZE = 256;

        // To customize filter names, modify this dictionary or load from a configuration.
        // The keys are 1-based position indices.
        private readonly Dictionary<int, string> _filterNames = new Dictionary<int, string>
        {
            { 1, "0.01mm口径滤光片" },
             { 2, "0.05口径滤光片" },
             { 3, "ND 1.0 Filter" },
             { 4, "ND 2.0 Filter" },
             { 5, "Empty Slot" },
             { 6, "Custom Filter X" }
        };

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            InitializeDevice();
        }

        private void InitializeDevice()
        {
            try
            {
                lblStatus.Text = "Initializing...";
                StringBuilder snBuffer = new StringBuilder(SERIAL_BUFFER_SIZE);
                int numDevices = FilterWheelApi.GetPorts(snBuffer);

                if (numDevices <= 0)
                {
                    string errorMsg = numDevices < 0 ? $"Error getting ports (Code: {numDevices})." : "No devices found.";
                    ShowError(errorMsg + " Ensure device is connected and drivers are installed.");
                    return;
                }

                string portList = snBuffer.ToString();
                string? firstPort = portList.Split(',').FirstOrDefault();

                if (string.IsNullOrEmpty(firstPort))
                {
                    ShowError("Could not parse serial number from device list.");
                    return;
                }

                lblStatus.Text = $"Attempting to open port: {firstPort}...";
                _deviceHandle = FilterWheelApi.Open(firstPort, BAUD_RATE, TIMEOUT_S);

                if (_deviceHandle < 0)
                {
                    ShowError($"Failed to open port {firstPort} (Handle: {_deviceHandle}). Check connection and ensure DLL is present.");
                    _deviceHandle = -1; // Ensure it's marked as invalid
                    return;
                }

                lblStatus.Text = $"Connected to {firstPort}. Handle: {_deviceHandle}. Getting position count...";
                int positionCount;
                int result = FilterWheelApi.GetDevicePositionCount(_deviceHandle, out positionCount);

                if (result != 0)
                {
                    ShowError($"Failed to get position count: {GetErrorMessage(result)}");
                    CleanupDevice(); // Close port if opened but couldn't get count
                    return;
                }

                if (positionCount <= 0)
                {
                    ShowError($"Device reported invalid position count: {positionCount}.");
                    CleanupDevice();
                    return;
                }

                lblStatus.Text = $"Device connected. Positions: {positionCount}.";
                CreatePositionButtons(positionCount);
                UpdateCurrentPositionDisplay();
            }
            catch (DllNotFoundException)
            {
                ShowError($"Critical Error: FilterWheel102_win32.dll not found. Ensure it's in the application directory ({AppDomain.CurrentDomain.BaseDirectory}) and the application is running as x86.");
            }
            catch (Exception ex)
            {
                ShowError($"An unexpected error occurred during initialization: {ex.Message}");
            }
        }

        private void CreatePositionButtons(int count)
        {
            flowLayoutPanelPositions.Controls.Clear(); // Clear any existing buttons

            for (int i = 1; i <= count; i++)
            {
                Button btn = new Button();
                btn.Tag = i; // Store 1-based position index

                if (_filterNames.TryGetValue(i, out string? customName))
                {
                    btn.Text = customName;
                }
                else
                {
                    btn.Text = $"Position {i}";
                }

                btn.AutoSize = true;
                btn.MinimumSize = new Size(120, 40); // Ensure buttons are reasonably sized
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

            lblStatus.Text = $"Setting position to {targetPosition}...";
            this.Enabled = false; // Disable form during operation

            // Run DLL call on a background thread to keep UI responsive
            int result = await Task.Run(() => FilterWheelApi.SetPosition(_deviceHandle, targetPosition));

            if (result == 0)
            {
                lblStatus.Text = $"Successfully set to position {targetPosition}.";
                // It might take time for the wheel to physically move.
                // For simplicity, we update current position immediately.
                // A more advanced implementation might poll GetPosition or wait for a signal.
                await Task.Delay(500); // Short delay to allow physical movement before querying
                UpdateCurrentPositionDisplay();
            }
            else
            {
                ShowError($"Failed to set position {targetPosition}: {GetErrorMessage(result)}");
                // Optionally, re-read current position even on failure to reflect actual state
                UpdateCurrentPositionDisplay();
            }
            this.Enabled = true; // Re-enable form
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
                    lblCurrentPosition.Text = $"Current: {customName} (Pos {currentPos})";
                }
                else
                {
                    lblCurrentPosition.Text = $"Current Position: {currentPos}";
                }
            }
            else
            {
                lblCurrentPosition.Text = $"Current Position: Unknown ({GetErrorMessage(result)})";
            }
        }

        private void ShowError(string message)
        {
            lblStatus.Text = $"ERROR: {message}";
            lblStatus.ForeColor = Color.Red;
            // Optionally, disable position buttons if device state is uncertain
            // foreach (Control ctrl in flowLayoutPanelPositions.Controls) { ctrl.Enabled = false; }
        }

        private string GetErrorMessage(int errorCode)
        {
            return errorCode switch
            {
                0 => "Success",
                0xEA => "Command not defined (0xEA)",
                0xEB => "Timeout (0xEB)",
                0xED => "Invalid string buffer (0xED)",
                _ => $"Device error code: {errorCode} (0x{errorCode:X2})"
            };
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
                lblStatus.Text = "Device disconnected.";
                lblCurrentPosition.Text = "Current Position: N/A (Disconnected)";
                flowLayoutPanelPositions.Controls.Clear();
            }
        }

        private void flowLayoutPanelPositions_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}