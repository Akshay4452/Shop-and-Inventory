using ServiceLocator.Utilities;

namespace ServiceLocator.Events
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public EventController<int> OnTabSelected { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            OnTabSelected = new EventController<int>();
        }
    }
}