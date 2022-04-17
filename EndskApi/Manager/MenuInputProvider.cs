using EndskApi.Information.Menus;
using UnityEngine;

namespace EndskApi.Manager
{
    public static class MenuInputProvider
    {
        public static InputTool F1 => new InputTool(KeyCode.F1, ": [F1]");
        public static InputTool F2 => new InputTool(KeyCode.F2, ": [F2]");
        public static InputTool F3 => new InputTool(KeyCode.F3, ": [F3]");
        public static InputTool F4 => new InputTool(KeyCode.F4, ": [F4]");
        public static InputTool F5 => new InputTool(KeyCode.F5, ": [F5]");
        public static InputTool F6 => new InputTool(KeyCode.F6, ": [F6]");
        public static InputTool F7 => new InputTool(KeyCode.F7, ": [F7]");
        public static InputTool F8 => new InputTool(KeyCode.F8, ": [F8]");
        public static InputTool F9 => new InputTool(KeyCode.F9, ": [F9]");
        public static InputTool F10 => new InputTool(KeyCode.F10, ": [F10]");

        public static InputTool KeyPad1 => new InputTool(KeyCode.Keypad1, ": [Keypad1]");
        public static InputTool KeyPad2 => new InputTool(KeyCode.Keypad2, ": [Keypad2]");
        public static InputTool KeyPad3 => new InputTool(KeyCode.Keypad3, ": [Keypad3]");
        public static InputTool KeyPad4 => new InputTool(KeyCode.Keypad4, ": [Keypad4]");
        public static InputTool KeyPad5 => new InputTool(KeyCode.Keypad5, ": [Keypad5]");
        public static InputTool KeyPad6 => new InputTool(KeyCode.Keypad6, ": [Keypad6]");
        public static InputTool KeyPad7 => new InputTool(KeyCode.Keypad7, ": [Keypad7]");
        public static InputTool KeyPad8 => new InputTool(KeyCode.Keypad8, ": [Keypad8]");
        public static InputTool KeyPad9 => new InputTool(KeyCode.Keypad9, ": [Keypad9]");
    }
}
