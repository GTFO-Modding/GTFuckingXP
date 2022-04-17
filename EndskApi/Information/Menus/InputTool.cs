using UnityEngine;

namespace EndskApi.Information.Menus
{
    public class InputTool
    {
        public InputTool(KeyCode inputKey, string postfix)
        {
            InputKey = inputKey;
            Postfix = postfix;
        }

        public KeyCode InputKey { get; set; }
        public string Postfix { get; set; }

        public virtual bool CheckKeyDown()
        {
            return Input.GetKeyDown(InputKey);
        }

        public virtual bool CheckKey()
        {
            return Input.GetKey(InputKey);
        }
    }
}
