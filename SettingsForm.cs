using System.Text;

namespace FilterWheelGuiSuda
{
    public partial class SettingsForm : Form
    {
        private readonly int _deviceHandle;
        public bool PositionCountWasChanged { get; private set; } = false;
        private int _initialPositionCount = 0;

        public SettingsForm(int deviceHandle)
        {
            InitializeComponent();
            _deviceHandle = deviceHandle;
            this.Load += SettingsForm_Load;
        }

        private void SettingsForm_Load(object? sender, EventArgs e)
        {
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            if (_deviceHandle < 0)
            {
                MessageBox.Show("Device not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int value;
            StringBuilder sb = new StringBuilder(256);

            // Device ID
            if (FilterWheelApi.GetId(_deviceHandle, sb) == 0) txtDeviceId.Text = sb.ToString();
            else txtDeviceId.Text = "Error reading ID";

            // Timeout (No GetTimeout in API, assuming it's part of Open or a fixed value)
            // numTimeout.Enabled = false; // If not gettable/settable independently after Open

            // Position Count
            if (FilterWheelApi.GetDevicePositionCount(_deviceHandle, out value) == 0)
            {
                numPositionCount.Value = value;
                _initialPositionCount = value;
            }
            else ShowReadError("Position Count");

            // Speed
            if (FilterWheelApi.GetSpeed(_deviceHandle, out value) == 0) numSpeed.Value = value;
            else ShowReadError("Speed");

            // Trigger Mode (Assuming 0 or 1 from demo)
            if (FilterWheelApi.GetTriggerMode(_deviceHandle, out value) == 0)
            {
                cmbTriggerMode.SelectedIndex = (value == 0 || value == 1) ? value : -1;
            }
            else ShowReadError("Trigger Mode");

            // Min Velocity
            if (FilterWheelApi.GetMinVelocity(_deviceHandle, out value) == 0) numMinVelocity.Value = value;
            else ShowReadError("Min Velocity");

            // Max Velocity
            if (FilterWheelApi.GetMaxVelocity(_deviceHandle, out value) == 0) numMaxVelocity.Value = value;
            else ShowReadError("Max Velocity");

            // Acceleration
            if (FilterWheelApi.GetAcceleration(_deviceHandle, out value) == 0) numAcceleration.Value = value;
            else ShowReadError("Acceleration");

            // Sensor Mode
            if (FilterWheelApi.GetSensorMode(_deviceHandle, out value) == 0) numSensorMode.Value = value; // Using NumericUpDown for now
            else ShowReadError("Sensor Mode");

            lblStatus.Text = "当前设置已加载.";
        }

        private void btnApplySettings_Click(object? sender, EventArgs e)
        {
            if (_deviceHandle < 0) return;

            lblStatus.Text = "应用设置中...";
            int result;
            bool oneFailed = false;

            // Set Timeout (If API supports it independently, otherwise this is conceptual)
            // result = FilterWheelApi.SetTimeout(_deviceHandle, (int)numTimeout.Value);
            // if (result != 0) { ShowWriteError("Timeout", result); oneFailed = true; }

            // Set Position Count
            int newPositionCount = (int)numPositionCount.Value;
            result = FilterWheelApi.SetPositionCount(_deviceHandle, newPositionCount);
            if (result != 0) { ShowWriteError("Position Count", result); oneFailed = true; }
            else if (newPositionCount != _initialPositionCount) PositionCountWasChanged = true;


            // Set Speed
            result = FilterWheelApi.SetSpeed(_deviceHandle, (int)numSpeed.Value);
            if (result != 0) { ShowWriteError("Speed", result); oneFailed = true; }

            // Set Trigger Mode
            if (cmbTriggerMode.SelectedIndex != -1)
            {
                result = FilterWheelApi.SetTriggerMode(_deviceHandle, cmbTriggerMode.SelectedIndex);
                if (result != 0) { ShowWriteError("Trigger Mode", result); oneFailed = true; }
            }

            // Set Min Velocity
            result = FilterWheelApi.SetMinVelocity(_deviceHandle, (int)numMinVelocity.Value);
            if (result != 0) { ShowWriteError("Min Velocity", result); oneFailed = true; }

            // Set Max Velocity
            result = FilterWheelApi.SetMaxVelocity(_deviceHandle, (int)numMaxVelocity.Value);
            if (result != 0) { ShowWriteError("Max Velocity", result); oneFailed = true; }

            // Set Acceleration
            result = FilterWheelApi.SetAcceleration(_deviceHandle, (int)numAcceleration.Value);
            if (result != 0) { ShowWriteError("Acceleration", result); oneFailed = true; }

            // Set Sensor Mode
            result = FilterWheelApi.SetSensorMode(_deviceHandle, (int)numSensorMode.Value);
            if (result != 0) { ShowWriteError("Sensor Mode", result); oneFailed = true; }


            lblStatus.Text = oneFailed ? "One or more settings failed to apply. Check messages." : "Settings applied successfully.";
            if (!oneFailed && PositionCountWasChanged)
            {
                MessageBox.Show("位置计数已改变。请重新进入主窗口。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveToDevice_Click(object? sender, EventArgs e)
        {
            if (_deviceHandle < 0) return;

            lblStatus.Text = "正在将设置保存到设备...";
            int result = FilterWheelApi.Save(_deviceHandle);
            if (result == 0)
            {
                lblStatus.Text = "成功将设置保存到设备.";
                MessageBox.Show("成功将设置保存到设备", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowWriteError("Save to Device", result);
            }
        }

        private void ShowReadError(string settingName)
        {
            lblStatus.Text = $"Error reading {settingName}.";
            // Optionally disable the corresponding control or show specific error in a tooltip
        }

        private void ShowWriteError(string settingName, int errorCode)
        {
            lblStatus.Text = $"Error setting {settingName}: {FilterWheelApi.GetErrorMessage(errorCode)}";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentSettings();
        }
    }
}