//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Connector;
//using System.Web.Hosting;

//using Newtonsoft.Json.Linq;


//namespace CogBankBot.Dialogs
//{
//    [Serializable]
//    class CogBankBotDialog : IDialog<object>
//    {

//        public string transactionType { get; set; }
//        public long transactionAmount { get; set; }


//        public async Task StartAsync(IDialogContext context)
//        {
//            context.Wait(MessageReceivedAsync);
//        }

//        // Initial message is processed by this method
//        async Task MessageReceivedAsync(
//            IDialogContext context, IAwaitable<IMessageActivity> result)
//        {
//            var activity = await result;

//            string messagePrompt = "What would you like to do?";
//            string messageRetry = "I don't know about that option, please select an option in the list";



//            // Check for the message text. If it's a catalog then execute the dialog sequence
//            // for this message handling
//            if (activity.Text.Contains("transaction"))
//            {
//                List<string> transactionsList = TransactionType.CreateTransactionsList();


//                var promptOptions =
//                    new PromptOptions<string>(
//                        prompt: messagePrompt,
//                        retry: messageRetry,
//                        options: transactionsList,
//                        speak: messagePrompt,
//                        retrySpeak: messageRetry);

//                PromptDialog.Choice(
//                    context: context,
//                    resume: TransactionTypeReceivedAsync,
//                    promptOptions: promptOptions);

//                //PromptDialog.Choice(
//                //   context: context,
//                //   resume: TransactionTypeReceivedAsync,
//                //   options: transactionsList,
//                //   prompt: "Which type of transaction to perform?",
//                //   retry: "Please select a valid transaction type: ",
//                //   attempts: 4,
//                //   promptStyle: PromptStyle.PerLine);
//            }
//            else
//            {
//                await context.PostAsync(
//                    "Currently, the only thing I can do is to perform a transaction. " +
//                    "Type \"transaction\" if you would like to do that");
//            }
//        }

//        async Task TransactionTypeReceivedAsync(
//            IDialogContext context, IAwaitable<string> result)
//        {
//            transactionType = await result;

//            if (transactionType == "Balance Inquiry")
//            {
//                // Balance inquiry
//                await context.PostAsync("You selected Balance Inquiry");
//            } else if (transactionType == "Funds Transfer")
//            {
//                // Funds transfer
//                PromptDialog.Number(
//                    context: context,
//                    resume: TransactionFundsTransferAsync,
//                    prompt: "Amount to be transferred?",
//                    retry: "Please enter a number between PKR 1,000 and PRK 150,000.",
//                    attempts: 4);
//            }
//            else
//            {
//                await context.PostAsync("Not valid transaction type");
//            }
//        }

//        async Task TransactionFundsTransferAsync(
//            IDialogContext context, IAwaitable<long> result)
//        {
//            transactionAmount = await result;

//            PromptDialog.Confirm(
//                context: context,
//                resume: TransactionFundsTransferConfirmedAsync,
//                prompt: "Confirm funds transfer?",
//                retry: "Please reply with either Yes or No.");
//        }

//        async Task TransactionFundsTransferConfirmedAsync(
//            IDialogContext context, IAwaitable<bool> result)
//        {
//            bool transactionConfirm = await result;

//            if (transactionConfirm) {
//                await context.PostAsync(
//                    $"You selected Transaction Type: {transactionType}, " +
//                    $"Transaction Amount: {transactionAmount}. ");
//            }
//            else
//            {
//                await context.PostAsync("You cancelled the transaction");
//            }
//        }

//    }
//}