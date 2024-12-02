using UnityEngine;

namespace ScriptableObjects.Data
{
    public abstract class ItemData : ScriptableObject
    {
        [field: SerializeField] public ContentType ContentType { get; private set; }
        [field: SerializeField] public Texture2D Image { get; private set; }
        [field: SerializeField] public RarityData Rarity { get; private set; }

        public void SetImage(Texture2D image)
        {
            Image = image;
        }

        public void SetRarity(RarityData rarity)
        {
            Rarity = rarity;
        }

        public void SetContentType(ContentType contentType)
        {
            ContentType = contentType;
        }
    }
}