using SimpleAutoClicker;
using System.Runtime.InteropServices;

public class Program
{
    [DllImport("User32.dll")]
    private static extern short GetAsyncKeyState(System.Int32 vKey);
    

    // Define the INPUT structure
    

    public static void Main()
    {
        ActionMouseClick act = new ActionMouseClick(MouseKeyCode.MOUSEEVENTF_RIGHTDOWN);

        

        while (true)
        {
           
            if ((GetAsyncKeyState(0x4) != 0))
            {
                Console.WriteLine(act.DoAction());
            }
            
        }
    }
}