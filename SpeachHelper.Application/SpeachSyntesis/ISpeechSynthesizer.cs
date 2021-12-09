using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Application.SpeachSyntesis
{
    public interface ISpeechSynthesizer
    {
        void Say(string word);
    }
}
