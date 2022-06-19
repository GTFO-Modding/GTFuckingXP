using EndskApi.Information.Configs;
using EndskApi.Information.Menus;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EndskApi.Manager
{
    public static class MenuInputProvider
    {
        private static MenuRebinding _bindings;
        static MenuInputProvider()
        {
            var serializerSettings = new JsonSerializerOptions();
            serializerSettings.Converters.Add(new JsonStringEnumConverter());

            //var defaultValue = JsonSerializer.Serialize(new MenuRebinding(), serializerSettings);
            var config = BepInExLoader.ConfigLoader.Bind("MenuApi", "KeyBindings",
                "{\"F1\":\"F1\",\"F2\":\"F2\",\"F3\":\"F3\",\"F4\":\"F4\",\"F5\":\"F5\",\"F6\":\"F6\",\"F7\":\"F7\",\"F8\":\"F8\",\"F9\":\"F9\",\"F10\":\"None\",\"Keypad1\":\"Keypad1\",\"Keypad2\":\"Keypad2\",\"Keypad3\":\"Keypad3\",\"Keypad4\":\"Keypad4\",\"Keypad5\":\"Keypad5\",\"Keypad6\":\"Keypad6\",\"Keypad7\":\"Keypad7\",\"Keypad8\":\"Keypad8\",\"Keypad9\":\"Keypad9\"}",
                "You can remap keys here.");
            _bindings = JsonSerializer.Deserialize<MenuRebinding>(config.Value, serializerSettings);
        }

        public static InputTool F1 => new InputTool(_bindings.F1, $": [{_bindings.F1}]");
        public static InputTool F2 => new InputTool(_bindings.F2, $": [{_bindings.F2}]");
        public static InputTool F3 => new InputTool(_bindings.F3, $": [{_bindings.F3}]");
        public static InputTool F4 => new InputTool(_bindings.F4, $": [{_bindings.F4}]");
        public static InputTool F5 => new InputTool(_bindings.F5, $": [{_bindings.F5}]");
        public static InputTool F6 => new InputTool(_bindings.F6, $": [{_bindings.F6}]");
        public static InputTool F7 => new InputTool(_bindings.F7, $": [{_bindings.F7}]");
        public static InputTool F8 => new InputTool(_bindings.F8, $": [{_bindings.F8}]");
        public static InputTool F9 => new InputTool(_bindings.F9, $": [{_bindings.F9}]");
        public static InputTool F10 => new InputTool(_bindings.F10, $": [{_bindings.F10}]");

        public static InputTool KeyPad1 => new InputTool(_bindings.Keypad1, $": [{_bindings.Keypad1}]");
        public static InputTool KeyPad2 => new InputTool(_bindings.Keypad2, $": [{_bindings.Keypad2}]");
        public static InputTool KeyPad3 => new InputTool(_bindings.Keypad3, $": [{_bindings.Keypad3}]");
        public static InputTool KeyPad4 => new InputTool(_bindings.Keypad4, $": [{_bindings.Keypad4}]");
        public static InputTool KeyPad5 => new InputTool(_bindings.Keypad5, $": [{_bindings.Keypad5}]");
        public static InputTool KeyPad6 => new InputTool(_bindings.Keypad6, $": [{_bindings.Keypad6}]");
        public static InputTool KeyPad7 => new InputTool(_bindings.Keypad7, $": [{_bindings.Keypad7}]");
        public static InputTool KeyPad8 => new InputTool(_bindings.Keypad8, $": [{_bindings.Keypad8}]");
        public static InputTool KeyPad9 => new InputTool(_bindings.Keypad9, $": [{_bindings.Keypad9}]");
    }
}
