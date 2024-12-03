using Helpers;
using ScriptableObjects;
using UnityEngine.UIElements;

namespace UIToolkit.CustomControls.DataButtons
{
    [UxmlElement]
    public partial class PreviewButton : TabButton //we should refactor this to inherit from DataButton
    {
        protected override void Build()
        {
            base.Build();
            AddToClassList("preview-type");
        }
    }
}