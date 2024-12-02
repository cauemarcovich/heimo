using Helpers;
using UIToolkit.CustomControls;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls
{
    [UxmlElement]
    public partial class Card : VisualElement
    {
        [UxmlAttribute]
        public string RarityIcon
        {
            get => _rarityTag?.RarityTitle;
            set => _rarityTag?.SetRarity(new Rarity(null, value));
        }
        
        [UxmlAttribute]
        public Texture2D ContentImage
        {
            get => _contentImage?.style.backgroundImage.value.texture;
            set
            {
                if (_contentImage != null)
                    _contentImage.style.backgroundImage = new StyleBackground(value);
            }
        }
        
        [UxmlAttribute]
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
        private bool _isEquipped;

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
        }
    }
}