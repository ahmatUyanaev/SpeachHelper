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
            speaker.Volume = 100;// от 0 до 100
            speaker.Rate = 0;//от -10 до 10
            speaker.SelectVoice(defaultVoice);
            var res = speaker.GetInstalledVoices();
        }
        public void Say(string word)
        {
            speaker.Speak(word);
        }
    }
}
