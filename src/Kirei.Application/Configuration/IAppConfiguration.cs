namespace Kirei.Application.Configuration
{
    public interface IAppConfiguration
    {
        IApplicationSection Application { get; set; }
        IActionsSection Actions { get; set; }
    }
}
