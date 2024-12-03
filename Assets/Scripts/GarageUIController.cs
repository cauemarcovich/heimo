using System.Collections.Generic;
using System.Linq;
using Containers;
using ScriptableObjects;
using ScriptableObjects.Data;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GarageUIController : MonoBehaviour
{
    [SerializeField] private ItemDatabase database;

    private UIDocument _documentComponent;
    private VisualElement _root;

    private SideTabsContainer _tabsContainer;
    private ShowcaseContainer _previewContainer;
    private ContentContainer _contentContainer;

    void Start()
    {
        if (database == null)
        {
            Debug.LogError("Database is not assigned! Please assign the database in the inspector.");
            enabled = false;
            return;
        }

        _documentComponent = GetComponent<UIDocument>();
        _root = _documentComponent.rootVisualElement;

        SetupContainers();
        
        _tabsContainer.SelectFirst();
        _previewContainer.SelectFirst();
    }

    void SetupContainers()
    {
        _contentContainer = new ContentContainer(_root.Q("content-container"), database);

        _tabsContainer = new SideTabsContainer(_root.Q("tabs-container"));
        _tabsContainer.RegisterContentContainer(_contentContainer);

        //maybe change this to a different class
        _previewContainer = new ShowcaseContainer(_root.Q("showcase-container"));
        _previewContainer.TemporarySetup();
        //----------------------------
    }
}