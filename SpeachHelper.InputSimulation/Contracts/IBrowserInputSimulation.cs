using System;

namespace SpeachHelper.InputSimulation.Contracts
{
    public interface IBrowserInputSimulation
    {
        Action OpenNewTabSimulate();

        Action WievHistory();

        Action OpenLastClosedTab();

        Action CloseCurrentTab();

        Action ComeBack();

        Action ComeForward();

    }
}
