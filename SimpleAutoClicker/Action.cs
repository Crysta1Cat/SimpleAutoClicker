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
                    _keyCodeUp = MouseKeyCode.MOUSEEVENTF_LEFTUP;
                    break;

                case MouseKeyCode.MOUSEEVENTF_MIDDLEDOWN:
                    _keyCodeUp = MouseKeyCode.MOUSEEVENTF_MIDDLEUP;
                    break;

                default: break;
            }

            _inputs = new INPUT[2];
            _inputs[0].Type = InputType.INPUT_MOUSE;
            _inputs[0].Data.MouseInput = new MOUSEINPUT
            {
                dwFlags = (uint)_keyCodeDown,
            };

            _inputs[1].Type = InputType.INPUT_MOUSE;
            _inputs[1].Data.MouseInput = new MOUSEINPUT
            {
                dwFlags = (uint)_keyCodeUp,
            };

        }
        public uint DoAction() 
        {
            return User32.SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }

    public class ActionKeyPress: IAction
    {
        private VirtualKeyCode _virtualKeyCode;
        private INPUT[] _inputs;

        public ActionKeyPress(VirtualKeyCode KeyCode) 
        {
            _virtualKeyCode = KeyCode;
            _inputs = new INPUT[2];
            _inputs[0].Type = InputType.INPUT_KEYBOARD;
            _inputs[0].Data.KeyboardInput = new KEYBDINPUT
            {
                wVk = (ushort)_virtualKeyCode,
                dwFlags = 0,
            };

            _inputs[1].Type = InputType.INPUT_KEYBOARD;
            _inputs[1].Data.KeyboardInput = new KEYBDINPUT
            {
                wVk = (ushort)_virtualKeyCode,
                dwFlags = (uint)KeyboardDfFlags.KEYEVENTF_KEYUP,
            };
        }

      
        public uint DoAction() 
        {
            return User32.SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(INPUT))); 
        }
    }

    public class ActionKeysPressWithModifiers
    {
        private List<VirtualKeyCode> _modifiers;
        private List<VirtualKeyCode> _keys;
        private INPUT[] _inputs;

        public ActionKeysPressWithModifiers(List<VirtualKeyCode> Modifiers, List<VirtualKeyCode> Keys)
        {
            _inputs = new INPUT[Modifiers.Count * 2 + Keys.Count * 2];
            _modifiers = Modifiers;
            _keys = Keys;

            if (Modifiers.Count > 0) 
            {
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    _inputs[i].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Modifiers[i],
                        dwFlags = 0
                    };
                }

                for (int i = Modifiers.Count; i < Modifiers.Count + Keys.Count * 2; i += 2)
                {
                    _inputs[i].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Keys[i - Modifiers.Count],
                        dwFlags = 0
                    };

                    _inputs[i + 1].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i + 1].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Keys[i - Modifiers.Count],
                        dwFlags = (uint)KeyboardDfFlags.KEYEVENTF_KEYUP,
                    };
                }

                for (int i = Modifiers.Count + Keys.Count * 2; i < _inputs.Length; i++)
                {
                    _inputs[i].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Modifiers[i - (Modifiers.Count + Keys.Count * 2)],
                        dwFlags = (uint)KeyboardDfFlags.KEYEVENTF_KEYUP,
                    };
                }
            }
            else
            {
                for (int i = 0; i < Keys.Count; i++)
                {
                    _inputs[i].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Keys[i],
                        dwFlags = 0
                    };
                    _inputs[i].Type = InputType.INPUT_KEYBOARD;
                    _inputs[i].Data.KeyboardInput = new KEYBDINPUT
                    {
                        wVk = (ushort)Keys[i],
                        dwFlags = (uint)KeyboardDfFlags.KEYEVENTF_KEYUP
                    };
                }
            }

            
        }


        public uint DoAction()
        {
            return User32.SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }


    public class ActionItem
    {
        public ActionMode Mode { get; private set; }
        public ActivationMode ActivationMode { get; private set; }
        public int ActionsPerSecond { get; private set; }
        public IAction? Action { get; private set; }

        public ActionItem(ActionMode mode, ActivationMode activationMode, int actionsPerSecond, IAction? action)
        {
            Mode = mode;
            ActivationMode = activationMode;
            ActionsPerSecond = actionsPerSecond;
            Action = action;
        }


        public void DoAction()
        {
            
            if (Action != null) 
            {
                //int tempActions = 0;
            }
        }


    }
}
