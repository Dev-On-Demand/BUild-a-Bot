using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BuildABot.Adapters
{
    public class BuildABotAdapter : BotFrameworkHttpAdapter
    {
        public BuildABotAdapter(IConfiguration configuration, ILogger<BotFrameworkHttpAdapter> logger)
            : base(configuration, logger)
        {
            OnTurnError = async (turnContext, exception) =>
            {
                logger.LogError(exception, $"[OnTurnError] unhandled error : {exception.Message}");

                await turnContext.SendActivityAsync("The bot encounted an error or bug.");
                await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.");

                await SendTraceActivityAsync(turnContext, exception);
            };
        }

        private static async Task SendTraceActivityAsync(ITurnContext turnContext, Exception exception)
        {
            if (turnContext.Activity.ChannelId == Channels.Emulator)
            {
                Activity traceActivity = new Activity(ActivityTypes.Trace)
                {
                    Label = "TurnError",
                    Name = "OnTurnError Trace",
                    Value = exception.Message,
                    ValueType = "https://www.botframework.com/schemas/error",
                };

                await turnContext.SendActivityAsync(traceActivity);
            }
        }
    }
}
