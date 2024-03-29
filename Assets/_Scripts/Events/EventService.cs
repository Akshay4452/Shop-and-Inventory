namespace ServiceLocator.Events
{
    public class EventService
    {
        private static EventService instance;
        public static EventService Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }
        public EventController<int> OnTabSelected { get; private set; }

        public EventService()
        {
            OnTabSelected = new EventController<int>();
        }
    }
}