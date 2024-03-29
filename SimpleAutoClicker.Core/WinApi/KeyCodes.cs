﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAutoClicker
{
    public enum MouseKeyCode : uint
    {
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100
    }

    public enum KeyboardDfFlags
    {
        KEYEVENTF_EXTENDEDKEY = 0x0001,
        KEYEVENTF_KEYUP = 0x0002,
        KEYEVENTF_SCANCODE = 0x0008,
        KEYEVENTF_UNICODE = 0x0004
    }

    public enum VirtualKeyCode : uint
    {
        VK_LBUTTON = 0x01,       // Left mouse button
        VK_RBUTTON = 0x02,       // Right mouse button
        VK_CANCEL = 0x03,        // Control-break processing
        VK_MBUTTON = 0x04,       // Middle mouse button (three-button mouse)
        VK_XBUTTON1 = 0x05,      // X1 mouse button
        VK_XBUTTON2 = 0x06,      // X2 mouse button
        VK_BACK = 0x08,          // BACKSPACE key
        VK_TAB = 0x09,           // TAB key
        VK_CLEAR = 0x0C,         // CLEAR key
        VK_RETURN = 0x0D,        // ENTER key
        VK_SHIFT = 0x10,         // SHIFT key
        VK_CONTROL = 0x11,       // CTRL key
        VK_MENU = 0x12,          // ALT key
        VK_PAUSE = 0x13,         // PAUSE key
        VK_CAPITAL = 0x14,       // CAPS LOCK key
        VK_ESCAPE = 0x1B,        // ESC key
        VK_SPACE = 0x20,         // SPACEBAR
        VK_PRIOR = 0x21,         // PAGE UP key
        VK_NEXT = 0x22,          // PAGE DOWN key
        VK_END = 0x23,           // END key
        VK_HOME = 0x24,          // HOME key
        VK_LEFT = 0x25,          // LEFT ARROW key
        VK_UP = 0x26,            // UP ARROW key
        VK_RIGHT = 0x27,         // RIGHT ARROW key
        VK_DOWN = 0x28,          // DOWN ARROW key
        VK_SELECT = 0x29,        // SELECT key
        VK_PRINT = 0x2A,         // PRINT key
        VK_EXECUTE = 0x2B,       // EXECUTE key
        VK_SNAPSHOT = 0x2C,      // PRINT SCREEN key
        VK_INSERT = 0x2D,        // INS key
        VK_DELETE = 0x2E,        // DEL key
        VK_HELP = 0x2F,          // HELP key
        VK_0 = 0x30,             // 0 key
        VK_1 = 0x31,             // 1 key
        VK_2 = 0x32,             // 2 key
        VK_3 = 0x33,             // 3 key
        VK_4 = 0x34,             // 4 key
        VK_5 = 0x35,             // 5 key
        VK_6 = 0x36,             // 6 key
        VK_7 = 0x37,             // 7 key
        VK_8 = 0x38,             // 8 key
        VK_9 = 0x39,             // 9 key
        VK_A = 0x41,             // A key
        VK_B = 0x42,             // B key
        VK_C = 0x43,             // C key
        VK_D = 0x44,             // D key
        VK_E = 0x45,             // E key
        VK_F = 0x46,             // F key
        VK_G = 0x47,             // G key
        VK_H = 0x48,             // H key
        VK_I = 0x49,             // I key
        VK_J = 0x4A,             // J key
        VK_K = 0x4B,             // K key
        VK_L = 0x4C,             // L key
        VK_M = 0x4D,             // M key
        VK_N = 0x4E,             // N key
        VK_O = 0x4F,             // O key
        VK_P = 0x50,             // P key
        VK_Q = 0x51,             // Q key
        VK_R = 0x52,             // R key
        VK_S = 0x53,             // S key
        VK_T = 0x54,             // T key
        VK_U = 0x55,             // U key
        VK_V = 0x56,             // V key
        VK_W = 0x57,             // W key
        VK_X = 0x58,             // X key
        VK_Y = 0x59,             // Y key
        VK_Z = 0x5A,             // Z key
        VK_LWIN = 0x5B,          // Left Windows key (Microsoft Natural keyboard)
        VK_RWIN = 0x5C,          // Right Windows key (Natural keyboard)
        VK_APPS = 0x5D,          // Applications key (Natural keyboard)
                                 // Skipping some codes for brevity...
                                 // Add more as needed
    }

    public enum KeyCode
    {
        None = 0,
        LButton = 1,
        RButton = 2,
        Cancel = 3,
        MButton = 4,
        XButton1 = 5,
        XButton2 = 6,
        Back = 8,
        Tab = 9,
        LineFeed = 10,
        Clear = 12,
        Return = 13,
        Enter = 13,
        ShiftKey = 16,
        ControlKey = 17,
        Menu = 18,
        Pause = 19,
        Capital = 20,
        CapsLock = 20,
        KanaMode = 21,
        HanguelMode = 21,
        HangulMode = 21,
        JunjaMode = 23,
        FinalMode = 24,
        HanjaMode = 25,
        KanjiMode = 25,
        Escape = 27,
        IMEConvert = 28,
        IMENonconvert = 29,
        IMEAccept = 30,
        IMEAceept = 30,
        IMEModeChange = 31,
        Space = 32,
        Prior = 33,
        PageUp = 33,
        Next = 34,
        PageDown = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        Snapshot = 44,
        PrintScreen = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        D0 = 48,
        D1 = 49,
        D2 = 50,
        D3 = 51,
        D4 = 52,
        D5 = 53,
        D6 = 54,
        D7 = 55,
        D8 = 56,
        D9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        RWin = 92,
        Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NumLock = 144,
        Scroll = 145,
        LShiftKey = 160,
        RShiftKey = 161,
        LControlKey = 162,
        RControlKey = 163,
        LMenu = 164,
        RMenu = 165,
        BrowserBack = 166,
        BrowserForward = 167,
        BrowserRefresh = 168,
        BrowserStop = 169,
        BrowserSearch = 170,
        BrowserFavorites = 171,
        BrowserHome = 172,
        VolumeMute = 173,
        VolumeDown = 174,
        VolumeUp = 175,
        MediaNextTrack = 176,
        MediaPreviousTrack = 177,
        MediaStop = 178,
        MediaPlayPause = 179,
        LaunchMail = 180,
        SelectMedia = 181,
        LaunchApplication1 = 182,
        LaunchApplication2 = 183,
        OemSemicolon = 186,
        Oem1 = 186,
        Oemplus = 187,
        Oemcomma = 188,
        OemMinus = 189,
        OemPeriod = 190,
        OemQuestion = 191,
        Oem2 = 191,
        Oemtilde = 192,
        Oem3 = 192,
        LatinKeyboardBar = 193,
        NumPadDot = 194,
        OemOpenBrackets = 219,
        Oem4 = 219,
        OemPipe = 220,
        Oem5 = 220,
        OemCloseBrackets = 221,
        Oem6 = 221,
        OemQuotes = 222,
        Oem7 = 222,
        Oem8 = 223,
        OemBackslash = 226,
        Oem102 = 226,
        ProcessKey = 229,
        Packet = 231,
        Attn = 246,
        Crsel = 247,
        Exsel = 248,
        EraseEof = 249,
        Play = 250,
        Zoom = 251,
        NoName = 252,
        Pa1 = 253,
        OemClear = 254,
        KeyCode = 65535,
        Shift = 65536,
        Control = 131072,
        Alt = 262144,
        Modifiers = -65536
    }

}
