
using KeyAPI;
using SimpleAutoClicker;
using System.Diagnostics;
using static SimpleAutoClicker.User32;


public class Program
{
    public static void Main()
    {
        ActionKeysPressWithModifiers act = new ActionKeysPressWithModifiers(new List<VirtualKeyCode> { VirtualKeyCode.VK_CONTROL }, new List<VirtualKeyCode> { VirtualKeyCode.VK_A });

        KeystrokeAPI keystroke = new KeystrokeAPI();
        keystroke.CreateKeyboardHook((character) => { Console.WriteLine(character); });
        //ExecuteAction(act);

       
        
    }

    private static void ExecuteAction(ActionKeysPressWithModifiers act)
    {
        while (true)
        {
            NOP((double)1);
            if (User32.GetAsyncKeyState(4) != 0)
            {
                act.DoAction();
            }
        }
    }


    private static void NOP(double durationSeconds)
    {
        var durationTicks = Math.Round(durationSeconds * Stopwatch.Frequency);
        var sw = Stopwatch.StartNew();

        while (sw.ElapsedTicks < durationTicks)
        {

        }
    }

}
