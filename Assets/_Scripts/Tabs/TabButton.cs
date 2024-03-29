using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Events;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    private Image buttonImage;
    private Button button;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(tabSelected);
    }

    private void tabSelected()
    {
        int indx = transform.GetSiblingIndex(); // active tab index
        EventService.Instance.OnTabSelected.InvokeEvent(indx);
    }
}
