using SpeachHelper.InputSimulation;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Locator;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SpeachHelper.SpeachRecognition
{
    public class EdgeWordActionContainer
    {
        private static Dictionary<string, Action> actions;
        private IBrowserInputSimulation edgeInputSimulation;

        public EdgeWordActionContainer()
        {
            edgeInputSimulation = ServiceLocator.GetService<EdgeInputSimulator>();
            actions = Mock();
        }

        private Dictionary<string, Action> Mock()
        {
            var dic = new Dictionary<string, Action>();

            dic.Add("Открой браузер", () => { Process.Start("https://yandex.ru/"); } );
            dic.Add("Открой вконтакте", () => { Process.Start("https://vk.com/axma_sila"); });
            dic.Add("Новая вкладка", edgeInputSimulation.OpenNewTabSimulate());

            return dic;
        }

        public Dictionary<string, Action> GetActions()
        {
            return actions;
        }

        public void AddBrowserWebSiteAction(string command, string openedSite)
        {
            actions.Add(command, () => { Process.Start(openedSite); });
        }



    }
}
