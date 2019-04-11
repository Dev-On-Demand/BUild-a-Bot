using Microsoft.Bot.Builder;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;

namespace BuildABot
{
    public class BuildABot : IBot
    {
        public BuildABot()
        {

        }

        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(turnContext.Activity.Type == ActivityTypes.Message)
            {
                var reply = turnContext.Activity.CreateReply($"You said: {turnContext.Activity.Text}");

                await turnContext.SendActivityAsync(reply, cancellationToken);
            }
        }
    }
}