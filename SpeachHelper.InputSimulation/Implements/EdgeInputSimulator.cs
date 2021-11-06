using SpeachHelper.InputSimulation.Contracts;
using System;
using WindowsInput;
using WindowsInput.Native;

namespace SpeachHelper.InputSimulation.Implements
{
    public class EdgeInputSimulator : IBrowserInputSimulation
    {
        private InputSimulator inputSimulator;

        public EdgeInputSimulator()
        {
            inputSimulator = new InputSimulator();
        }

        public Action CloseCurrentTab()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_W); };
        }

        public Action ComeBack()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.LEFT); };
        }

        public Action ComeForward()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.RIGHT); };
        }

        public Action OpenLastClosedTab()
        {
            return () =>
            {
                inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL,
                    new[] { VirtualKeyCode.SHIFT, VirtualKeyCode.VK_T });
            };
        }

        public Action OpenNewTabSimulate()
        {
            // CTRL + T Open new tab
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T); };
        }

        public Action WievHistory()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_H); };
        }
    }
}