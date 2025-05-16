using Microsoft.AspNetCore.SignalR;

namespace PracticeExam1.SignalR;

public class ProcessHub : Hub<IProcessHubClient>
{
    public async Task StartProcess()
    {
        await Clients.Caller.SetProgress(20, "Fetching...");
        await Task.Delay(1000);

        await Clients.Caller.SetProgress(40, "Processing...");
        await Task.Delay(1000);

        await Clients.Caller.SetProgress(60, "Finalizing...");
        await Task.Delay(1000);

        await Clients.Caller.SetProgress(80, "Almost done...");
        await Task.Delay(1000);

        await Clients.Caller.Start();
    }
}
