using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ContentType", menuName = "HeimoData/ContentType")]
    public class ContentType : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public VectorImage Icon { get; private set; }
    }
}