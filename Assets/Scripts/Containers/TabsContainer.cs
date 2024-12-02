using System.Collections.Generic;
using System.Linq;
using UIToolkit.CustomControls.DataButtons;
using UnityEngine.UIElements;

namespace Containers
{
    public class SideTabsContainer : TabsContainer<UIToolkit.CustomControls.DataButtons.TabButton>
    {
        public SideTabsContainer(VisualElement container) : base(container) { }
    
        public void RegisterContentContainer(ContentContainer contentContainer)
        {
            foreach (var tab in Tabs)
                tab.OnTagSelected += contentContainer.SetContent;
        }
    }

    public class ShowcaseContainer : TabsContainer<PreviewButton>
    {
        public ShowcaseContainer(VisualElement container) : base(container) { }

        public void TemporarySetup()
        {
            //disable driver
        }
    }

    public abstract class TabsContainer<TDataButton> where TDataButton : DataButton
    {
        public VisualElement Container { get; private set; }
        protected List<TDataButton> Tabs;
    
        public TabsContainer(VisualElement container)
        {
            Container = container;
        
            Tabs = Container.Query<TDataButton>().ToList();
        
            foreach (var tab in Tabs)
            {
                tab.RegisterCallback<ClickEvent>(evt =>
                {
                    DeselectAllTabs();
                    tab.Select();
                });
            }
        }
 
        private void DeselectAllTabs()
        {
            for (int i = 0; i < Tabs.Count; i++)
                Tabs[i].Deselect();
        }

        public void SelectFirst()
        {
            Tabs?.FirstOrDefault()?.Select();
        }
    }
}