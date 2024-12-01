using Helpers;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls
{
    [UxmlElement]
    public partial class CustomTab : VisualElement
    {
        [UxmlAttribute]
        public VectorImage Image
        {
            get => _icon?.style.backgroundImage.value.vectorImage;
            set
            {
                if (_icon != null)
                    _icon.style.backgroundImage = new StyleBackground(value);
            }
        }

        [UxmlAttribute]
        public string Title
        {
            get => _title != null ? _title.text : "Title is not assigned...";
            set
            {
                if (_title != null)
                    _title.text = value;
            }
        }

        private VisualElement _icon;
        private Label _title;
        private Label _alert;

        public CustomTab()
        {
            AddToClassList("garage-tab");
            
            _icon = this.CreateChild("img_icon", "garage-tab__icon");
            _title = this.CreateChild<Label>("lbl_title", "garage-tab__title");
            _alert = this.CreateChild<Label>("alert", "garage-tab__alert");
            _alert.visible = false;
        }
    }
}