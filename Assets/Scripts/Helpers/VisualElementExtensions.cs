using UnityEngine.UIElements;

namespace Helpers
{
    public static class VisualElementExtensions
    {
        public static VisualElement CreateChild(this VisualElement visualElement, string name, params string[] classList) =>
            CreateChild<VisualElement>(visualElement, name, classList);

        public static T CreateChild<T>(this VisualElement visualElement, string name, params string[] classList) where T : VisualElement, new()
        {
            var child = new T { name = name };

            foreach (var className in classList)
            {
                if (!string.IsNullOrEmpty(className))
                    child.AddToClassList(className);
            }

            visualElement.Add(child);

            return child;
        }
    }
}