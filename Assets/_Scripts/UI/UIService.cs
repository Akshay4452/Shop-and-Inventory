using ServiceLocator.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private Color activeTabColor;
        [Header("Tabs Section")]
        [SerializeField] private List<TabButton> tabsList;

        [Header("Pages Section")]
        [SerializeField] private List<Page> pagesList;

        private int activeTabIndex;
        private int prevActiveTabIndex;
        private int defaultActiveTabIndex;

        private int activePageIndex;
        private int prevActivePageIndex;
        private int defaultActivePageIndex;

        private void Start()
        {
            if (tabsList == null || pagesList == null) { Debug.LogError("Tab Group or Page Group component is missing in UI Service"); }
            activeTabColor = Color.red;
            InitializeTabsAndPages();
            SubscribeToEvents();
        }
        public void SubscribeToEvents()
        {
            EventService.Instance.OnTabSelected.AddListener(SetActiveTab);
            EventService.Instance.OnTabSelected.AddListener(SetActivePage);
        }

        private void InitializeTabsAndPages()
        {
            // Tab section
            activeTabIndex = -1;
            prevActiveTabIndex = -1;
            defaultActiveTabIndex = 0; // Materials tab being the default tab
            tabsList[defaultActivePageIndex].GetComponent<Image>().color = activeTabColor;

            // Page section
            activePageIndex = -1;
            prevActivePageIndex = -1;
            defaultActivePageIndex = GetDefaultActiveTabIndex();
            pagesList[defaultActivePageIndex].gameObject.SetActive(true);
        }
        public Color ActiveTabColor { get { return activeTabColor; } }
        public int GetDefaultActiveTabIndex() { return defaultActiveTabIndex; }
        private void SetActiveTab(int idx)
        {
            if (idx != activeTabIndex)
            {
                if (prevActiveTabIndex == -1)
                    prevActiveTabIndex = defaultActiveTabIndex;
                else
                    prevActiveTabIndex = activeTabIndex;

                tabsList[idx].GetComponent<Image>().color = GameService.Instance.UIService.ActiveTabColor;
                activeTabIndex = idx;
                if (prevActiveTabIndex != activeTabIndex)
                    tabsList[prevActiveTabIndex].GetComponent<Image>().color = Color.white;
            }
            else
            {
                return;
            }
        }

        private void SetActivePage(int idx)
        {
            if (idx != activePageIndex)
            {
                if (prevActivePageIndex == -1)
                    prevActivePageIndex = defaultActivePageIndex;
                else
                    prevActivePageIndex = activePageIndex;

                pagesList[idx].gameObject.SetActive(true);
                activePageIndex = idx;
                if (prevActivePageIndex != activePageIndex)
                    pagesList[prevActivePageIndex].gameObject.SetActive(false);
            }
            else
            {
                return;
            }

        }
        private void OnDisable()
        {
            EventService.Instance.OnTabSelected.RemoveListener(SetActiveTab);
            EventService.Instance.OnTabSelected.RemoveListener(SetActivePage);
        }
    }
}