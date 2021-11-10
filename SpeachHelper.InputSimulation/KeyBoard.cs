using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace SpeachHelper.InputSimulation
{
    public class KeyBoard
    {
        public List<string> GetAllKeyBoardButtons()
        {
            return Enum.GetValues(typeof(VirtualKeyCode)).Cast<VirtualKeyCode>().Select(x => x.ToString()).ToList();
        }

        public VirtualKeyCode MapToInputSimulator(string key)
        {
            return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key);
        }
    }
}
