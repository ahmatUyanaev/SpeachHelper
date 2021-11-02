using Microsoft.Speech.Recognition;

namespace SpeachHelper.Application.SpeachRecognition
{
    public interface ISpeachRecognizer
    {
        void RecognizeAsync();

        void LoadGrammar(GrammarBuilder newGrammar);
    }
}
