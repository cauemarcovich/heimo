using System.Collections.Generic;
using System.IO;
using System.Linq;
using Helpers;
using ScriptableObjects;
using ScriptableObjects.Data;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [UnityEditor.CustomEditor(typeof(CrazyPopulator))]
    public class CrazyPopulatorInspector : UnityEditor.Editor
    {
        #region properties

        private SerializedProperty _carsSpritePath;
        private SerializedProperty _carsDataPath;
        private SerializedProperty _wheelsSpritePath;
        private SerializedProperty _wheelsDataPath;
        private SerializedProperty _colorsSpritePath;
        private SerializedProperty _colorsDataPath;
        private SerializedProperty _accessoriesSpritePath;
        private SerializedProperty _accessoriesDataPath;
        private SerializedProperty _bumpersSpritePath;
        private SerializedProperty _bumpersDataPath;
        private SerializedProperty _spoilersSpritePath;
        private SerializedProperty _spoilersDataPath;
        private SerializedProperty _rarityPath;

        #endregion

        private void OnEnable()
        {
            #region properties

            _carsSpritePath = serializedObject.FindProperty("carsSpritesPath");
            _carsDataPath = serializedObject.FindProperty("carsDataPath");
            _wheelsSpritePath = serializedObject.FindProperty("wheelsSpritesPath");
            _wheelsDataPath = serializedObject.FindProperty("wheelsDataPath");
            _colorsSpritePath = serializedObject.FindProperty("colorsSpritesPath");
            _colorsDataPath = serializedObject.FindProperty("colorsDataPath");
            _accessoriesSpritePath = serializedObject.FindProperty("accessoriesSpritesPath");
            _accessoriesDataPath = serializedObject.FindProperty("accessoriesDataPath");
            _bumpersSpritePath = serializedObject.FindProperty("bumpersSpritesPath");
            _bumpersDataPath = serializedObject.FindProperty("bumpersDataPath");
            _spoilersSpritePath = serializedObject.FindProperty("spoilersSpritesPath");
            _spoilersDataPath = serializedObject.FindProperty("spoilersDataPath");
            _rarityPath = serializedObject.FindProperty("rarityPath");

            #endregion
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Populate All"))
            {
                PopulateAssets<CarData>(_carsSpritePath.stringValue, _carsDataPath.stringValue);
                PopulateAssets<WheelData>(_wheelsSpritePath.stringValue, _wheelsDataPath.stringValue);
                PopulateAssets<ColorData>(_colorsSpritePath.stringValue, _colorsDataPath.stringValue);
                PopulateAssets<AccessoriesData>(_accessoriesSpritePath.stringValue, _accessoriesDataPath.stringValue);
                PopulateAssets<BumperData>(_bumpersSpritePath.stringValue, _bumpersDataPath.stringValue);
                PopulateAssets<SpoilerData>(_spoilersSpritePath.stringValue, _spoilersDataPath.stringValue);
            }
            
            DrawLine();
            DrawLine();
            DrawLine();
            
            BuildArea<CarData>("Cars", _carsSpritePath, _carsDataPath);
            BuildArea<WheelData>("Wheels", _wheelsSpritePath, _wheelsDataPath);
            BuildArea<ColorData>("Colors", _colorsSpritePath, _colorsDataPath);
            BuildArea<AccessoriesData>("Accessories", _accessoriesSpritePath, _accessoriesDataPath);
            BuildArea<BumperData>("Bumpers", _bumpersSpritePath, _bumpersDataPath);
            BuildArea<SpoilerData>("Spoilers", _spoilersSpritePath, _spoilersDataPath);
            
            EditorGUILayout.LabelField("Rarity", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_rarityPath);
        }

        private void BuildArea<T>(string labelName, SerializedProperty spriteProperty, SerializedProperty dataProperty) where T : ItemData
        {
            CrazyPopulator populator = (CrazyPopulator)target;
            ValidateFolder(spriteProperty.stringValue);
            ValidateFolder(dataProperty.stringValue);

            EditorGUILayout.LabelField(labelName, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(spriteProperty);
            EditorGUILayout.PropertyField(dataProperty);

            if (GUILayout.Button("Populate"))
            {
                PopulateAssets<T>(spriteProperty.stringValue, dataProperty.stringValue);
            }

            DrawLine();
        }

        private void PopulateAssets<T>(string spritesPath, string dataPath) where T : ItemData
        {
            var items = AssetDatabase.FindAssets("", new[] { spritesPath })
                .Select(asset => Path.GetFileNameWithoutExtension(AssetDatabase.GUIDToAssetPath(asset)));

            var rarityAssets = AssetDatabase.FindAssets("t:RarityData", new[] { "Assets" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<RarityData>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray();

            foreach (var item in items)
            {
                foreach (var rarityData in rarityAssets)
                {
                    var targetName = $"{dataPath}/{item.CapitalizeDataName()}-{rarityData.name}.asset";

                    if (AssetDatabase.LoadAssetAtPath<T>(targetName) == null)
                    {
                        CreateAsset<T>(targetName, AssetDatabase.LoadAssetAtPath<Texture2D>($"{spritesPath}/{item}.png"), rarityData);
                    }
                    
                }
            }
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        void ValidateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log($"Folder {folder} created.");
            }
        }

        T CreateAsset<T>(string path, Texture2D image, RarityData rarity) where T : ItemData
        {
            T asset = ScriptableObject.CreateInstance<T>();
            asset.SetImage(image);
            asset.SetRarity(rarity);

            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return asset;
        }

        void DrawLine()
        {
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), Color.grey);
        }
    }
}