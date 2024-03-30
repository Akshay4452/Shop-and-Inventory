using ServiceLocator.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageGroup : MonoBehaviour
{
    [SerializeField] private TabGroup tabGroup;
    [SerializeField] public List<Page> pages;
    private int activePageIndex;
    private int prevActivePageIndex;
    private int defaultActivePageIndex;

    private void OnEnable()
    {
        EventService.Instance.OnTabSelected.AddListener(SetActivePage);
    }

    private void Start()
    {
        activePageIndex = -1;
        prevActivePageIndex = -1;
        defaultActivePageIndex = tabGroup.GetDefaultActiveTabIndex();
        pages[defaultActivePageIndex].gameObject.SetActive(true);
    }

    private void SetActivePage(int idx) 
    {
        if(idx != activePageIndex)
        {
            if (prevActivePageIndex == -1)
                prevActivePageIndex = defaultActivePageIndex;
            else 
                prevActivePageIndex = activePageIndex;

            pages[idx].gameObject.SetActive(true);
            activePageIndex = idx;
            if(prevActivePageIndex != activePageIndex)
                pages[prevActivePageIndex].gameObject.SetActive(false);
        } 
        else
        {
            return;
        }

    }

    private void OnDisable()
    {
        EventService.Instance.OnTabSelected.RemoveListener(SetActivePage);
    }
}
