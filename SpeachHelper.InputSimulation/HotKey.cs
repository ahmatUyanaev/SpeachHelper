using System;
using System.Collections.Generic;
using System.Linq;
using WindowsInput;
using WindowsInput.Native;

namespace SpeachHelper.InputSimulation
{
    public static class HotKey
    {
        private static InputSimulator inputSimulator = new InputSimulator();

        public static List<string> GetAllKeyBoardButtons()
        {
            return Enum.GetValues(typeof(VirtualKeyCode)).Cast<VirtualKeyCode>().Select(x => x.ToString()).ToList();
        }

        public static Action MapToInputSimulator(string argument)
        {
            var keys = argument.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(k => !string.IsNullOrWhiteSpace(k));

            var listOfKeys = new List<VirtualKeyCode>();

            foreach (var key in keys)
            {
                listOfKeys.Add((VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key));
            }

            if (listOfKeys.Count == 2)
            {
                return () => { inputSimulator.Keyboard.ModifiedKeyStroke(listOfKeys[0], listOfKeys[1]); };
            }
            else if (listOfKeys.Count == 3)
            {
                return () =>
                {
                    inputSimulator.Keyboard.ModifiedKeyStroke(listOfKeys[0],
                        new[] { listOfKeys[1], listOfKeys[2] });
                };
            }

            throw new Exception("Exception in MapToInputSimulator");
        }
    }
}