using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Luis;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CogBankBot.Dialogs
{
    // [LuisModel("0cd979e7-78a4-4f17-8266-495eb5498ee4", "1460b3b97d9a4273a0172631a04495f4", domain: "westus.api.cognitive.microsoft.com")]

    [LuisModel(
        modelID: "fce2c458-d12e-47ed-8e4c-36c432e59eee",
        subscriptionKey: "6c3b2c02cf0145b792ae6538dba840ab",
        domain: "westus.api.cognitive.microsoft.com")]
    [Serializable]
    public class CogBankBotLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            string message = @"Sorry, I didn't get that. Here are a couple examples that I can recognize: 
                                'Make a transaction' or 'Perform a transaction.'";

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Perform Transaction")]
        public async Task SearchingIntent(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            const string TransactionTypeEntity = "TransactionType";

            if (!result.Entities.Any())
            {
                await NoneIntent(context, result);
                return;
            }

            result.TryFindEntity(TransactionTypeEntity, out EntityRecommendation transactionEntityRec);
            if (transactionEntityRec != null)
            {
                string transactionType = transactionEntityRec.Entity;

                string message = "Here is the transaction that is to be performed: " + string.Join(", ", transactionType);
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
            else
            {
                string message = "Sorry, No transactions found matching your criteria.";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
        }
    }
}