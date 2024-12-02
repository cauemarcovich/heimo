using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRarity", menuName = "HeimoData/ItemData/Rarity")]
    public class RarityData : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public VectorImage Icon { get; private set; }
    }
}