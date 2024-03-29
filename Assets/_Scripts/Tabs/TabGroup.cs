using ServiceLocator.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private Color activeTabColor;
    [SerializeField] public List<TabButton> tabButtons;
    private int activeTabIndex;
    private int prevActiveTabIndex;

    private void OnEnable()
    {
        EventService.Instance.OnTabSelected.AddListener(SetActiveTab);
    }
    void Start()
    {
        activeTabIndex = -1;
        prevActiveTabIndex = -1;
        if (tabButtons == null) 
        {
            tabButtons = new List<TabButton>();
        }
    }

    private void SetActiveTab(int idx)
    {
        if (idx != activeTabIndex)
        {
            prevActiveTabIndex = activeTabIndex;
            tabButtons[idx].GetComponent<Image>().color = activeTabColor;
            activeTabIndex = idx;
            if (prevActiveTabIndex != activeTabIndex && prevActiveTabIndex != -1)
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
