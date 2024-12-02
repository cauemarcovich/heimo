using ScriptableObjects.Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "HeimoData/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [field: SerializeField] public CarData[] Cars { get; private set; }
        [field: SerializeField] public ColorData[] Colors { get; private set; }
        [field: SerializeField] public WheelData[] Wheels { get; private set; }
        [field: SerializeField] public AccessoriesData[] Accessories { get; private set; }
        [field: SerializeField] public BumperData[] Bumpers { get; private set; }
        [field: SerializeField] public SpoilerData[] Spoilers { get; private set; }
    }
}