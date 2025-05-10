using System.Runtime.InteropServices;
using System.Text;

public static class FilterWheelApi
{
    private const string DllName = "FilterWheel102_win32.dll";

    // IMPORTANT: FilterWheel102_win32.dll must be in the application's execution directory
    // or in a directory specified in the system's PATH.

    /// <summary>
    /// list all the possible port on this computer.
    /// </summary>
    /// <param name="serialNoBuffer">Port list returned string. Allocate sufficient buffer size (e.g., 256).</param>
    /// <returns>non-negtive number: number of device in the list; negtive number : failed.</returns>
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetPorts(StringBuilder serialNoBuffer);

    /// <summary>
    ///  open port function.
    /// </summary>
    /// <param name="serialNo">serial number of the device to be opened.</param>
    /// <param name="nBaud">bit per second of port.</param>
    /// <param name="timeout">set timeout value in (s).</param>
    /// <returns> non-negtive number: hdl number returned successfully; negtive number : failed.</returns>
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int Open(string serialNo, int nBaud, int timeout);

    /// <summary>
    /// close current opend port.
    /// </summary>
    /// <param name="hdl">handle of port.</param>
    /// <returns> 0: success; negtive number : failed.</returns>
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Close(int hdl);

    /// <summary>
    /// get the fiterwheel current position.
    /// </summary>
    /// <param name="hdl">handle of port.</param>
    /// <param name="pos">fiterwheel actual position (out parameter).</param>
    /// <returns>0: success; various error codes on failure.</returns>
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetPosition(int hdl, out int pos);

    /// <summary>
    /// get the fiterwheel current position count.
    /// </summary>
    /// <param name="hdl">handle of port.</param>
    /// <param name="poscount">fiterwheel actual position count (out parameter).</param>
    /// <returns>0: success; various error codes on failure.</returns>
    [DllImport(DllName, EntryPoint = "GetPositionCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetDevicePositionCount(int hdl, out int poscount); // Renamed to avoid conflict if user adds other GetPositionCount

    /// <summary>
    /// set fiterwheel's position to pos.
    /// </summary>
    /// <param name="hdl">handle of port.</param>
    /// <param name="pos">fiterwheel position.</param>
    /// <returns>0: success; various error codes on failure.</returns>
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetPosition(int hdl, int pos);

    // --- Optional: Other functions from fw_cmd_library.h can be added here as needed ---
    // Example:
    // [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    // public static extern int GetId(int hdl, StringBuilder idBuffer);
}