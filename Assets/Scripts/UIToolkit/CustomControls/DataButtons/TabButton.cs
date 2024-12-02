using Helpers;
using ScriptableObjects;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls.DataButtons
{
    [UxmlElement]
    public partial class TabButton : DataButton
    {
        private ContentType _contentType;
        [UxmlAttribute]
        public ContentType ContentType
        {
            get => _contentType;
            set
            {
                _contentType = value;
                _icon.style.backgroundImage = value != null ? new StyleBackground(value.Icon) : null;
                _title.text = value != null ? value.Title : string.Empty;
            }
        }
        
        private VisualElement _icon;
        private Label _title;
        private Label _alert;
        
        public event System.Action<ContentType> OnTagSelected = delegate { };
        
        protected override void Build()
        {
            AddToClassList("garage-tab");

            _icon = this.CreateChild("img_icon", "garage-tab__icon");
            _title = this.CreateChild<Label>("lbl_title", "garage-tab__title");
            _alert = this.CreateChild<Label>("alert", "garage-tab__alert");
            _alert.visible = false;
            
            OnSelected += _ => AddToClassList("garage-tab--selected");
            OnSelected += _ => OnTagSelected(_contentType);
            OnDeselected += _ => RemoveFromClassList("garage-tab--selected");
        }
    }
}