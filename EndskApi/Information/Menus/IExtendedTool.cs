using EndskApi.Enums.Menus;
using System;

namespace EndskApi.Information.Menus
{
    public interface IExtendedTool
    {
        Action<object> ExtraToolAction { get; set; }

        InformationId InformationId { get; set; }
    }
}
