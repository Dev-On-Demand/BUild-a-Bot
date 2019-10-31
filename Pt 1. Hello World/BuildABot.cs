using Microsoft.Bot.Builder;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace BuildABot
{
    public class BuildABot : ActivityHandler
    {
        public BuildABot()
        {

        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and welcome!"), cancellationToken);
                }
            }
        }
        //public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if(turnContext.Activity.Type == ActivityTypes.Message)
        //    {
        //        var reply = turnContext.Activity.CreateReply($"You said: {turnContext.Activity.Text}");

        //        await turnContext.SendActivityAsync(reply, cancellationToken);
        //    }
        //}
    }
}