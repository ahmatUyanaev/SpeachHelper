using SpeachHelper.InputSimulation.Contracts;
using System;
using WindowsInput;
using WindowsInput.Native;

namespace SpeachHelper.InputSimulation
{
    public class EdgeInputSimulator : IBrowserInputSimulation
    {
        private InputSimulator inputSimulator;

        public EdgeInputSimulator()
        {
            inputSimulator = new InputSimulator();
        }

        public Action OpenNewTabSimulate()
        {
            // CTRL + T Open new tab
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T); };
        }
    }
}
