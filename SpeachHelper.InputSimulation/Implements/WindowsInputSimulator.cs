using SpeachHelper.InputSimulation.Contracts;
using System;
using WindowsInput;
using WindowsInput.Native;

namespace SpeachHelper.InputSimulation.Implements
{
    public class WindowsInputSimulator : IWindowsInputSimulator
    {
        private InputSimulator inputSimulator;

        public WindowsInputSimulator()
        {
            inputSimulator = new InputSimulator();
        }

        public Action ChangeLanguage()
        {
            return () => inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.MENU);
        }

        public Action Copy()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C); };
        }

        public Action Paste()
        {
            return () => { inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V); };
        }
    }
}
