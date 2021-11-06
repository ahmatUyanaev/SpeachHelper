using System;

namespace SpeachHelper.InputSimulation.Contracts
{
    public interface IWindowsInputSimulator
    {
        Action Copy();

        Action Paste();

        Action ChangeLanguage();
    }
}