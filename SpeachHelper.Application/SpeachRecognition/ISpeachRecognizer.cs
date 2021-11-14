namespace SpeachHelper.Application.SpeachRecognition
{
    public interface ISpeachRecognizer
    {
        void RecognizeAsync();

        void LoadGrammar(string newCommand);
    }
}