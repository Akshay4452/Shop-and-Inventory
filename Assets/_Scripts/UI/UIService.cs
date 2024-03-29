using ServiceLocator.Utilities;

namespace ServiceLocator.UI
{
    public class UIService : GenericMonoSingleton<UIService>
    {
        protected override void Awake()
        {
            base.Awake();
        }
    }
}