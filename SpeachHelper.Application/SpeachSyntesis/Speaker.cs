using System.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Application.SpeachSyntesis
{
    public class Speaker : ISpeechSynthesizer
    {
        private SpeechSynthesizer speaker = new SpeechSynthesizer();
        private string defaultVoice = "Microsoft Irina Desktop";
        public Speaker()
        {
            speaker.Volume = 100;
            speaker.Rate = 0;
            speaker.SelectVoice(defaultVoice);
        }
        public void Say(string word)
        {
            speaker.Speak(word);
        }
    }
}
