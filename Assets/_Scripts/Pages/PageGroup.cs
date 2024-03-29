using ServiceLocator.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGroup : MonoBehaviour
{
    [SerializeField] public List<GameObject> pages;
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
            pages[idx].SetActive(true);
            activePageIndex = idx;
            if(prevActivePageIndex != activePageIndex && prevActivePageIndex != -1)
                pages[prevActivePageIndex].SetActive(false);
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
