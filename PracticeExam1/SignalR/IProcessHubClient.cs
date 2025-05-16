using PracticeExam1.Domain.Models;

namespace PracticeExam1.SignalR;

public interface IProcessHubClient
{
    Task SetProgress(int progress, string message);
    Task Start();
}
