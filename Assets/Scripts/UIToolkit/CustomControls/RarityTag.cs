using System;
using Helpers;
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

        public void SetRarity(Rarity rarity)
        {
            if (rarity == null)
                throw new ArgumentNullException(nameof(rarity));

            if (_rarityIcon != null)
                RarityIcon = rarity.Icon;
            if (_rarityText != null)
                RarityTitle = rarity.Title;
        }
    }

    public class Rarity
    {
        public VectorImage Icon { get; set; }
        public string Title { get; set; }

        public Rarity() { }

        public Rarity(VectorImage icon = null, string title = null)
        {
            Icon = icon;
            Title = title;
        }
    }
}