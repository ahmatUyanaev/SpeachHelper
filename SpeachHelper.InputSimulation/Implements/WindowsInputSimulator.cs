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

        public void test(int codeOne, int codeTwo)
        {
            // test how can save custome actions in db
            VirtualKeyCode valOne = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), codeOne.ToString());
        }

        public Action ChangeLanguage()
        {
            test(16, 11);
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