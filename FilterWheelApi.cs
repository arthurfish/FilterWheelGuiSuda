using System.Runtime.InteropServices;
using System.Text;

public static class FilterWheelApi
{
    private const string DllName = "FilterWheel102_win32.dll";

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetPorts(StringBuilder serialNoBuffer);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int Open(string serialNo, int nBaud, int timeout);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Close(int hdl);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetPosition(int hdl, out int pos);

    [DllImport(DllName, EntryPoint = "GetPositionCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetDevicePositionCount(int hdl, out int poscount);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetPosition(int hdl, int pos);

    // --- Added functions based on fw_cmd_library.h ---

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetTimeout(int hdl, int timeout);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetPositionCount(int hdl, int count);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetSpeed(int hdl, int speed);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetTriggerMode(int hdl, int mode);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetMinVelocity(int hdl, int min);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetMaxVelocity(int hdl, int max);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetAcceleration(int hdl, int acceleration);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetSensorMode(int hdl, int mode);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Save(int hdl);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetSpeed(int hdl, out int speed);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTriggerMode(int hdl, out int triggermode);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMinVelocity(int hdl, out int minvelocity);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMaxVelocity(int hdl, out int maxvelocity);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetAcceleration(int hdl, out int acceleration);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetSensorMode(int hdl, out int sensormode);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetId(int hdl, StringBuilder idBuffer);

    // Helper to get error message string
    public static string GetErrorMessage(int errorCode)
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
}