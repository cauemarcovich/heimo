using Helpers;
using ScriptableObjects;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls.DataButtons
{
    [UxmlElement]
    public partial class FilterButton : DataButton
    {
        private RarityData _rarity;
        [UxmlAttribute]
        public RarityData Rarity
        {
            get => _rarity;
            set
            {
                _rarity = value;
                _title.text = value != null ? value.Title : "ALL";
            }
        }
        
        private Label _title;

        protected override void Build()
        {
            AddToClassList("content-filter");
            
            _title = this.CreateChild<Label>("lbl_title", "content-filter__title");
            if(_rarity == null)
                _title.text = "ALL";
            
            OnSelected += _ => AddToClassList("content-filter--selected");
            OnDeselected += _ => RemoveFromClassList("content-filter--selected");
        }
    }
}