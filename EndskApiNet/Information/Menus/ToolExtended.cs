using EndskApi.Enums.Menus;
using System;

namespace EndskApi.Information.Menus
{
    public class ToolExtended : Tool, IExtendedTool
    {
        public ToolExtended(string text, InputTool input, bool isToggle, Action<Tool> useCheat,
            Action<object> extraCheatAction, Action<Tool, bool> onToggleUpdate = null,
            bool currentToggleState = false,
            InformationId infoId = InformationId.None) : base(text, input, isToggle, useCheat, onToggleUpdate, currentToggleState)
        {
            ExtraToolAction = extraCheatAction;
            InformationId = infoId;
        }

        public Action<object> ExtraToolAction { get; set; }

        public InformationId InformationId { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
