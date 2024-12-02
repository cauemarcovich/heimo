using Helpers;
using ScriptableObjects.Data;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls
{
    [UxmlElement]
    public partial class Card : VisualElement
    {
        private ItemData _itemData;
        [UxmlAttribute]
        public ItemData ItemData
        {
            get => _itemData;
            set
            {
                if(_itemData == value) return;
                _itemData = value;
                if (_itemData != null)
                {
                    _rarityTag.SetRarity(_itemData.Rarity);
                    _contentImage.style.backgroundImage = new StyleBackground(_itemData.Image);
                }
                else
                {
                    _rarityTag.SetRarity(null);
                }
            }
        }
        
        private bool _isEquipped;
        public bool IsEquipped
        {
            get => _isEquipped;
            set
            {
                if (_cardFooter != null)
                {
                    _isEquipped = value;
                    
                    if(_isEquipped) _cardFooter.AddToClassList("card-footer--item-equipped");
                    else _cardFooter.RemoveFromClassList("card-footer--item-equipped");
                }
            }
        }

        private RarityTag _rarityTag;
        private VisualElement _contentImage;
        private VisualElement _cardFooter;
        private Button _footerButton;

        public Card()
        {
            AddToClassList("card");

            _rarityTag = new RarityTag();
            Add(_rarityTag);

            var cardContent = this.CreateChild("card-content", "card-content");
            _contentImage = cardContent.CreateChild("img_item", "card-content__image");

            _cardFooter = this.CreateChild("card-footer", "card-footer");
            _cardFooter.CreateChild<Label>("lbl_equipped", "card-footer__label").text = "EQUIPPED";
            _footerButton = _cardFooter.CreateChild<Button>("btn_equip", "card-footer__button");
            _footerButton.text = "EQUIP";
            _footerButton.clickable.clicked += () => IsEquipped = !IsEquipped;
        }
    }
}