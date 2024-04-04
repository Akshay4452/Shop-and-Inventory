using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.ShopService;
using ServiceLocator.UI;

public class GameService : GenericMonoSingleton<GameService>
{
    public ShopService shopService { get; private set; }

    //[SerializeField] private UIService uIService;
    //public UIService uiService => uIService; // public getter function for UI Service

    private void Start()
    {
        shopService = new ShopService();
    }
}
