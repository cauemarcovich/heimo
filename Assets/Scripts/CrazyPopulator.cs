using ScriptableObjects;
using UnityEngine;

#pragma warning disable 414
public class CrazyPopulator : MonoBehaviour
{
    [SerializeField] private string skinsSpritesPath = "Assets/Sprites/GameItems/Skins";
    [SerializeField] private string skinsDataPath = "Assets/Data/Skins";
    [SerializeField] private ContentType skinsContentType;
    [SerializeField] private string colorsSpritesPath = "Assets/Sprites/GameItems/Colors";
    [SerializeField] private string colorsDataPath = "Assets/Data/Colors";
    [SerializeField] private ContentType colorsContentType;
    [SerializeField] private string wheelsSpritesPath = "Assets/Sprites/GameItems/Wheels";
    [SerializeField] private string wheelsDataPath = "Assets/Data/Wheels";
    [SerializeField] private ContentType wheelsContentType;
    [SerializeField] private string accessoriesSpritesPath = "Assets/Sprites/GameItems/Accessories";
    [SerializeField] private string accessoriesDataPath = "Assets/Data/Accessories";
    [SerializeField] private ContentType accessoriesContentType;
    [SerializeField] private string bumpersSpritesPath = "Assets/Sprites/GameItems/Bumpers";
    [SerializeField] private string bumpersDataPath = "Assets/Data/Bumpers";
    [SerializeField] private ContentType bumpersContentType;
    [SerializeField] private string spoilersSpritesPath = "Assets/Sprites/GameItems/Spoilers";
    [SerializeField] private string spoilersDataPath = "Assets/Data/Spoilers";
    [SerializeField] private ContentType spoilersContentType;
    
    [SerializeField] private string rarityPath = "Assets/Data_Rarity";
}