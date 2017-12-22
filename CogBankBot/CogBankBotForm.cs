using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CogBankBot
{
    [Serializable]
    public class CogBankBotForm
    {

        public IForm<CogBankBotForm> BuildForm()
        {
            ActiveDelegate<CogBankBotForm> shouldShowContest =
                cogBankBotForm => DateTime.Now.DayOfWeek == DayOfWeek.Friday;

            var prompt = new PromptAttribute
            {
                Patterns =
                    new[]
                    {
                        "Hi, May I ask a few questions?",
                        "How are you today? Can I ask a few questions?",
                        "Thanks for visiting - would you answer a few questions?"
                    }
            };

            return new FormBuilder<CogBankBotForm>()
                .Confirm(prompt)
                .Confirm(
                    "You can type \"help\" at any time for more info. Would you like to proceed?")
                .Confirm(
                    "Would you like to enter a contest?",
                    shouldShowContest)
                .OnCompletion(DoSearch)
                .Build();
        }

        async Task DoSearch(IDialogContext context, CogBankBotForm cogBankBotInfo)
        {
            string message = "End of transction processing.";
            await context.PostAsync(message);
        }
    }
}