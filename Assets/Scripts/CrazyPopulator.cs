using System.IO;
using ScriptableObjects.Data;
using UnityEditor;
using UnityEngine;

public class CrazyPopulator : MonoBehaviour
{
    [SerializeField] private string carsSpritesPath = "Assets/Sprites/GameItems/Cars";
    [SerializeField] private string carsDataPath = "Assets/Data/Cars";
    [SerializeField] private string colorsSpritesPath = "Assets/Sprites/GameItems/Colors";
    [SerializeField] private string colorsDataPath = "Assets/Data/Colors";
    [SerializeField] private string wheelsSpritesPath = "Assets/Sprites/GameItems/Wheels";
    [SerializeField] private string wheelsDataPath = "Assets/Data/Wheels";
    [SerializeField] private string accessoriesSpritesPath = "Assets/Sprites/GameItems/Accessories";
    [SerializeField] private string accessoriesDataPath = "Assets/Data/Accessories";
    [SerializeField] private string bumpersSpritesPath = "Assets/Sprites/GameItems/Bumpers";
    [SerializeField] private string bumpersDataPath = "Assets/Data/Bumpers";
    [SerializeField] private string spoilersSpritesPath = "Assets/Sprites/GameItems/Spoilers";
    [SerializeField] private string spoilersDataPath = "Assets/Data/Spoilers";
    
    [SerializeField] private string rarityPath = "Assets/Data_Rarity";
}