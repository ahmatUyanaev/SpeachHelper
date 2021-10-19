using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.InputSimulation.Contracts
{
    public interface IWindowsInputSimulator
    {
        Action Copy();
        Action Paste();
    }
}
