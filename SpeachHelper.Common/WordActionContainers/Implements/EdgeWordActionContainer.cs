using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SpeachHelper.Common.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IWordActionContainer, IBrowserWordActionContainer
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

            dic.Add("Открой браузер", () => { Process.Start("https://yandex.ru/"); });
            dic.Add("Открой вконтакте", () => { Process.Start("https://vk.com/axma_sila"); });
            dic.Add("Новая вкладка", edgeInputSimulation.OpenNewTabSimulate());
            dic.Add("Закрой вкладку", edgeInputSimulation.CloseCurrentTab());
            dic.Add("История посещений", edgeInputSimulation.WievHistory());
            dic.Add("Верни закрытую вкладку", edgeInputSimulation.OpenLastClosedTab());
            dic.Add("Вернись назад", edgeInputSimulation.ComeBack());
            dic.Add("Вернись вперед", edgeInputSimulation.ComeForward());

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
