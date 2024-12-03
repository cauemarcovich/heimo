using System;
using Helpers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls
{
    [UxmlElement]
    public partial class RarityTag : VisualElement
    {
        private RarityData _rarity;
        [UxmlAttribute]
        public RarityData Rarity
        {
            get => _rarity;
            set
            {
                if(_rarity == value) return;
                
                _rarity = value;
                
                if(_rarity != null)
                {
                    _rarityIcon.style.backgroundImage = new StyleBackground(_rarity.Icon);
                    if (value.Icon == null) _rarityIcon.AddToClassList("card-rarity-tag__icon--disabled");
                    else _rarityIcon.RemoveFromClassList("card-rarity-tag__icon--disabled");
                    
                    _rarityText.text = _rarity.Title;
                    
                    style.backgroundColor = _rarity.TagColor;
                    _rarityText.style.color = _rarity.TextColor;
                }
                else
                {
                    _rarityIcon.style.backgroundImage = null;
                    _rarityIcon.AddToClassList("card-rarity-tag__icon--disabled");

                    _rarityText.text = "";
                    
                    style.backgroundColor = Color.black;
                }
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
    }
}