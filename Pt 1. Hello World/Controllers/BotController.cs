using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;

namespace BuildABot.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class BotController : ControllerBase
    {
        public BotController(IBotFrameworkHttpAdapter adapter, IBot bot)
        {
            _bot = bot;
            _adapter = adapter;
        }

        private readonly IBotFrameworkHttpAdapter _adapter;
        private readonly IBot _bot;

        [HttpPost]
        public async Task PostAsync()
        {
            await _adapter.ProcessAsync(Request, Response, _bot);
        }
    }
}
