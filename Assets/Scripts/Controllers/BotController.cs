using System.Collections.Generic;
using UnityEngine;

namespace MyProject
{
    public class BotController:BaseController
    {
        public List<Bot> GetBotsList { get; } = new List<Bot>();
        public int CountBot;
        
        public void Init()
        {
            var bot = Resources.Load<Bot>("Enemy");
            for(var index =0; index<CountBot; index++)
            {
                var tempBot = Bot.Instantiate(bot,
                Move.GetPoint(Main.Instance.Player),Quaternion.identity);

                tempBot.agent.avoidancePriority = index;
                tempBot.Target = Main.Instance.Player;
                AddBotToList(tempBot);
            }

        }
        public void AddBotToList(Bot bot)
        {
            
                if (!GetBotsList.Contains(bot))
                {
                    GetBotsList.Add(bot);
                }
            
        }
        public void RemoveBotFromList(Bot bot)
        {
            if(GetBotsList.Contains(bot))
            {
                GetBotsList.Remove(bot);
            }
        }
        public override void MyUpdate()
        {
            if (!IsActive) return;
            foreach(var bot in GetBotsList)
            {
                bot.Tick();
            }
        }
    }
}
