using ServiceLocator.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGroup : MonoBehaviour
{
    [SerializeField] public List<Page> pages;
    private int activePageIndex;
    private int prevActivePageIndex;

    private void OnEnable()
    {
        EventService.Instance.OnTabSelected.AddListener(SetActivePage);
    }

    private void SetActivePage(int idx) 
    {
        if(idx != activePageIndex)
        {
            prevActivePageIndex = activePageIndex;
            pages[idx].gameObject.SetActive(true);
            activePageIndex = idx;
            if(prevActivePageIndex != activePageIndex && prevActivePageIndex != -1)
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
