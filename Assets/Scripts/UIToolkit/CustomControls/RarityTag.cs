using System;
using Helpers;
using ScriptableObjects;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls
{
    [UxmlElement]
    public partial class RarityTag : VisualElement
    {
        [UxmlAttribute]
        public VectorImage RarityIcon
        {
            get => _rarityIcon?.style.backgroundImage.value.vectorImage;
            set
            {
                if (_rarityIcon != null)
                {
                    _rarityIcon.style.backgroundImage = new StyleBackground(value);
                    if (value == null) _rarityIcon.AddToClassList("card-rarity-tag__icon--disabled");
                    else _rarityIcon.RemoveFromClassList("card-rarity-tag__icon--disabled");
                }
            }
        }

        [UxmlAttribute]
        public string RarityTitle
        {
            get => _rarityText != null ? _rarityText.text : "Title is not assigned...";
            set
            {
                if (_rarityText != null)
                    _rarityText.text = value;
            }
        }

        private VisualElement _rarityIcon;
        private Label _rarityText;

        public RarityTag()
        {
            AddToClassList("card-rarity-tag");
            name = "tag-rarity";

            _rarityIcon = this.CreateChild("icon", "card-rarity-tag__icon", "card-rarity-tag__icon--disabled");
            _rarityText = this.CreateChild<Label>("lbl-title", "card-rarity-tag__title");
        }

        public void SetRarity(RarityData rarity)
        {
            RarityIcon = rarity != null ? rarity.Icon : null;
            RarityTitle = rarity != null ? rarity.Title : "";
        }
    }
}