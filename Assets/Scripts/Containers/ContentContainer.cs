using System.Collections.Generic;
using System.Linq;
using Helpers;
using ScriptableObjects;
using ScriptableObjects.Data;
using UIToolkit.CustomControls;
using UIToolkit.CustomControls.DataButtons;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class ContentContainer
{
    private ItemDatabase _database;

    public VisualElement Container { get; private set; }
    public VisualElement FilterContainer { get; private set; }
    public VisualElement CardsContainer { get; private set; }

    //Current Data
    private List<Card> _cards = new List<Card>();


    private ContentType _currentContentType;
    private RarityData _currentRarity;

    public ContentContainer(VisualElement container, ItemDatabase itemDatabase)
    {
        _database = itemDatabase;

        Container = container;
        FilterContainer = Container.Q("content-filter-container");
        CardsContainer = Container.Q("content-scroll-view").Q("unity-content-container");

        ConfigFiltersBehaviour();
    }

    public void ConfigFiltersBehaviour()
    {
        var filters = FilterContainer.Query<FilterButton>().ToList();
        foreach (var filter in filters)
        {
            filter.Deselect();

            filter.RegisterCallback<ClickEvent>(evt =>
            {
                _currentRarity = filter.Rarity;
                UpdateContent();
            });
        }
    }

    public void SetContent(ContentType contentType)
    {
        if (_currentContentType == contentType) return;

        _currentContentType = contentType;
        UpdateContent();
    }

    private void UpdateContent()
    {
        ClearCardContainer();

        var items = _database.GetItemsByType(_currentContentType);
        if (_currentRarity != null)
            items = items.Where(_ => _.Rarity == _currentRarity);

        foreach (var item in items)
        {
            var card = CreateCard(item);
            _cards.Add(card);
        }
    }

    private Card CreateCard(ItemData itemData)
    {
        var card = CardsContainer.CreateChild<Card>($"card_{itemData.name.ToLower()}");
        card.ItemData = itemData;

        return card;
    }

    private void ClearCardContainer()
    {
        CardsContainer.Clear();
        _cards.Clear();
    }
}