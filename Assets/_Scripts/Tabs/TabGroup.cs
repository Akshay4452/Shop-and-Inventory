using ServiceLocator.Events;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private Color activeTabColor;
    [SerializeField] public List<TabButton> tabButtons;
    private int activeTabIndex;
    private int prevActiveTabIndex;
    private int defaultActiveTabIndex;

    private void OnEnable()
    {
        EventService.Instance.OnTabSelected.AddListener(SetActiveTab);
    }
    void Start()
    {
        activeTabIndex = -1;
        prevActiveTabIndex = -1;
        defaultActiveTabIndex = 0; // Materials tab being the default tab
        if (tabButtons == null) 
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons[defaultActiveTabIndex].GetComponent<Image>().color = activeTabColor; // Making default tab active
    }

    public int GetDefaultActiveTabIndex() { return defaultActiveTabIndex; }

    private void SetActiveTab(int idx)
    {
        if (idx != activeTabIndex)
        {
            if (prevActiveTabIndex == -1)
                prevActiveTabIndex = defaultActiveTabIndex;
            else
                prevActiveTabIndex = activeTabIndex;

            tabButtons[idx].GetComponent<Image>().color = activeTabColor;
            activeTabIndex = idx;
            if (prevActiveTabIndex != activeTabIndex)
                tabButtons[prevActiveTabIndex].GetComponent<Image>().color = Color.white;
        }
        else
        {
            return;
        }
    }

    private void OnDisable()
    {
        EventService.Instance.OnTabSelected.RemoveListener(SetActiveTab);
    }
}
