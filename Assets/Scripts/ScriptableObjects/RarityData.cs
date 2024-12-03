using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRarity", menuName = "HeimoData/ItemData/Rarity")]
    public class RarityData : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public VectorImage Icon { get; private set; }
        [field: SerializeField] public Color TagColor { get; private set; } = Color.black;
        [field: SerializeField] public Color BackgroundColor { get; private set; } = Color.white;
        [field: SerializeField] public Color TextColor { get; private set; } = Color.white;
    }
}