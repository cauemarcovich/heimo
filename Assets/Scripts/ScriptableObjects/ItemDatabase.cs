using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Data;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "HeimoData/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [field: SerializeField] public ItemData[] DataList { get; private set; }

        public IEnumerable<ItemData> GetItemsByType(ContentType contentType)
        {
            foreach (var item in DataList)
                if (item.ContentType == contentType)
                    yield return item;
        }

#if UNITY_EDITOR
        [ContextMenu("Capture All Data")]
        public void CaptureAllData()
        {
            DataList = AssetDatabase.FindAssets("t:ItemData")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<ItemData>)
                .ToArray();
        }

        [ContextMenu("Shuffle")]
        public void Shuffle()
        {
            DataList = DataList.OrderBy(x => Random.value).ToArray();
        }
#endif
    }
}