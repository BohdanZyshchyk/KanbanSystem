using WcfServiceInteraction.CallbackInterfaces;

namespace WcfServiceInteraction.Services.AdditionalClasses
{
    public class KanbanSystemServiceClient
    {
        public string ClientName { get; set; }
        public IServiceCallback Callback { get; set; }
    }
}
