using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Data;

public static class PlayerData
{
    public static IDictionary<ContentType, ItemData> Items = new Dictionary<ContentType, ItemData>();

    public static ItemData GetByContentType(ContentType contentType)
    {
        if (Items.TryGetValue(contentType, out var itemData))
            return itemData;

        return null;
    }

    public static void SetData(ItemData itemData)
    {
        Items[itemData.ContentType] = itemData;
    }
}