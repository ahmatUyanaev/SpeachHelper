using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.SpeachRecognition
{
    public class GrammarContainer
    {
        private static Dictionary<string, Action> actions;

        public GrammarContainer()
        {
            actions = Mock();
        }

        private Dictionary<string, Action> Mock()
        {
            var dic = new Dictionary<string, Action>();

            dic.Add("Открой браузер", () => { Process.Start("https://yandex.ru/"); } );
            dic.Add("Открой вконтакте", () => { Process.Start("https://vk.com/axma_sila"); });

            return dic;
        }

        public Dictionary<string, Action> GetActions()
        {
            return actions;
        }

        public void AddAction(string command, string openSite)
        {
            actions.Add(command, () => { Process.Start(openSite); });
        }

    }
}
