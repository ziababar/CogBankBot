using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Web.Hosting;


namespace CogBankBot.Dialogs
{
//    public class CogBankBotDialog
//    {
//    }


    [Serializable]
    class CogBankBotDialog : IDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        // Initial message is processed by this method
        async Task MessageReceivedAsync(
            IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result;

            
            // Check for the message text. If it's a catalog then execute the dialog sequence
            // for this message handling
            if (activity.Text.Contains("transaction"))
            {
                List<string> transactionsList = TransactionType.CreateTransactionsList();

                PromptDialog.Choice(
                    context: context,
                    resume: TransactionTypeReceivedAsync,
                    options: transactionsList,
                    prompt: "Which type of transaction to perform?",
                    retry: "Please select a valid transaction type: ",
                    attempts: 4,
                    promptStyle: PromptStyle.PerLine);
            }
            else
            {
                await context.PostAsync(
                    "Currently, the only thing I can do is to perform a transaction. " +
                    "Type \"transaction\" if you would like to do that");
            }
        }

        async Task TransactionTypeReceivedAsync(
            IDialogContext context, IAwaitable<string> result)
        {
            string transactionType = await result;

            if (transactionType == "Balance Inquiry")
            {
                // Balance inquiry
                await context.PostAsync("You selected Balance Inquiry");
            } else if (transactionType == "Funds Transfer")
            {
                // Funds transfer
                await context.PostAsync("You selected Funds Transfer");
            }
            else
            {
                await context.PostAsync("Not valid transaction type");
            }
        }           

    }
}