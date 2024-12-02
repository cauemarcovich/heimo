using UnityEngine.UIElements;

namespace UIToolkit.CustomControls.DataButtons
{
    public abstract class DataButton : VisualElement
    {
        public event System.Action<DataButton> OnSelected = delegate { };
        public event System.Action<DataButton> OnDeselected = delegate { };
        public bool IsSelected { get; private set; }

        protected DataButton()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Build();
        }

        protected abstract void Build();

        public void Select()
        {
            IsSelected = true;
            OnSelected(this);
        }

        public void Deselect()
        {
            IsSelected = false;
            OnDeselected(this);
        }
    }
}