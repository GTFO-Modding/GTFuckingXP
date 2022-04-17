using System;

namespace EndskApi.Information.Menus
{
    public class Tool
    {
        public Tool()
        { }

        public Tool(string text, InputTool input, Action<Tool, bool> onToggleUpdate, bool startState)
        {
            Text = text;
            CheckInput = input;
            IsToggle = true;
            UseTool = ToggleTool;

            OnToggleUpdate = onToggleUpdate;

          CurrentToggleState = startState;
        }

        public Tool(string text, InputTool input, bool isToggle, Action<Tool> useCheat, Action<Tool, bool> onToggleUpdate = null,
        bool currentToggleState = false)
        {
            Text = text;
            CheckInput = input;
            IsToggle = isToggle;
            UseTool = useCheat;

            OnToggleUpdate = onToggleUpdate;

            CurrentToggleState = currentToggleState;
        }

        public string Text { get; set; }
        public string TextPostfix { get; set; }
        public InputTool CheckInput { get; }
        public Action<Tool> UseTool { get; set; }
        public Action<Tool, bool> OnToggleUpdate { get; set; }
        public bool IsToggle { get; set; }
        public bool CurrentToggleState { get; set; }

        public void Toggle()
        {
            CurrentToggleState = !CurrentToggleState;
            OnToggleUpdate?.Invoke(this, CurrentToggleState);
        }

        public override string ToString()
        {
            if (IsToggle)
            {
                return $"{Text}{TextPostfix}{CheckInput.Postfix} {(CurrentToggleState ? "ON" : "OFF")}";
            }
            return $"{Text}{TextPostfix}{CheckInput.Postfix}";
        }

        private static void ToggleTool(Tool tool)
        {
            tool.Toggle();
        }
    }
}
