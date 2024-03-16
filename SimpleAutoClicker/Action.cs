using System.Runtime.InteropServices;

namespace SimpleAutoClicker
{
    public enum ActionMode
    {
        KeyPress,
        MouseClick
    }

    public enum ActivationMode
    {
        Hold,
        Switch,
    }

    public interface IAction
    {
        uint DoAction();
    }

    public class ActionMouseClick: IAction
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint cInputs, INPUT[] pInputs, int cbSize);

        private MouseKeyCode _keyCodeDown;
        private MouseKeyCode _keyCodeUp;
        private INPUT[] _inputs;

        public ActionMouseClick(MouseKeyCode keyCode)
        {
            _keyCodeDown = keyCode;
            switch (keyCode) 
            {
                case MouseKeyCode.MOUSEEVENTF_RIGHTDOWN:
                    _keyCodeUp = MouseKeyCode.MOUSEEVENTF_RIGHTUP;
                    break;

                case MouseKeyCode.MOUSEEVENTF_LEFTDOWN:
                    _keyCodeDown = MouseKeyCode.MOUSEEVENTF_LEFTUP;
                    break;

                case MouseKeyCode.MOUSEEVENTF_MIDDLEDOWN:
                    _keyCodeDown = MouseKeyCode.MOUSEEVENTF_MIDDLEUP;
                    break;

                default: break;
            }

            _inputs = new INPUT[2];
            _inputs[0].Type = 0;
            _inputs[0].Data.MouseInput = new MOUSEINPUT
            {
                dwFlags = (uint)_keyCodeDown,
            };

            _inputs[1].Type = 0;
            _inputs[1].Data.MouseInput = new MOUSEINPUT
            {
                dwFlags = (uint)_keyCodeUp,
            };

        }
        public uint DoAction() 
        {
            return SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }

    public class ActionKeyPress: IAction
    {
        public uint DoAction() { return 0; }
    }


    public class ActionItem
    {
        public ActionMode Mode { get; private set; }
        public ActivationMode ActivationMode { get; private set; }
        public int ActionsPerSecond { get; private set; }
        public IAction? Action { get; private set; }
       
    }
}
