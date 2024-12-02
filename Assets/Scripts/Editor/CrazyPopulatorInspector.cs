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
        private class SerializedPropertyGroup
        {
            public string Name { get; set; }
            public SerializedProperty SpritePath { get; set; }
            public SerializedProperty DataPath { get; set; }
            public SerializedProperty ContentType { get; set; }

            public ContentType ContentTypeValue => ContentType.objectReferenceValue as ContentType;

            public bool IsValid { get; private set; }

            public SerializedPropertyGroup(string name, SerializedObject serializedObject)
            {
                Name = name;
                var spritePathPropName = $"{name}SpritesPath";
                SpritePath = serializedObject.FindProperty(spritePathPropName);
                DataPath = serializedObject.FindProperty($"{name}DataPath");
                ContentType = serializedObject.FindProperty($"{name}ContentType");
                IsValid = true;

                ValidateFields();
            }

            private void ValidateFields()
            {
                if (string.IsNullOrEmpty(Name))
                {
                    IsValid = false;
                    Debug.LogError("Name is not set.");
                }

                if (SpritePath == null)
                {
                    IsValid = false;
                    Debug.LogError("SpritePath is not set.");
                }

                if (DataPath == null)
                {
                    IsValid = false;
                    Debug.LogError("DataPath is not set.");
                }

                if (ContentType == null)
                {
                    IsValid = false;
                    Debug.LogError("ContentType is not set.");
                }
            }
        }

        #region properties

        private SerializedPropertyGroup _skins;
        private SerializedPropertyGroup _colors;
        private SerializedPropertyGroup _wheels;
        private SerializedPropertyGroup _accessories;
        private SerializedPropertyGroup _bumpers;
        private SerializedPropertyGroup _spoilers;

        private SerializedProperty _rarityPath;

        #endregion

        private void OnEnable()
        {
            #region properties

            _skins = new SerializedPropertyGroup("skins", serializedObject);
            _colors = new SerializedPropertyGroup("colors", serializedObject);
            _wheels = new SerializedPropertyGroup("wheels", serializedObject);
            _accessories = new SerializedPropertyGroup("accessories", serializedObject);
            _bumpers = new SerializedPropertyGroup("bumpers", serializedObject);
            _spoilers = new SerializedPropertyGroup("spoilers", serializedObject);
            _rarityPath = serializedObject.FindProperty("rarityPath");

            #endregion
        }

        public override void OnInspectorGUI()
        {
            if (!CheckFields()) return;

            if (GUILayout.Button("Populate All"))
            {
                PopulateAssets<SkinData>(_skins);
                PopulateAssets<ColorData>(_colors);
                PopulateAssets<WheelData>(_wheels);
                PopulateAssets<AccessoriesData>(_accessories);
                PopulateAssets<BumperData>(_bumpers);
                PopulateAssets<SpoilerData>(_spoilers);
            }

            DrawLine();
            DrawLine();
            DrawLine();

            BuildArea<SkinData>(_skins);
            BuildArea<ColorData>(_colors);
            BuildArea<WheelData>(_wheels);
            BuildArea<AccessoriesData>(_accessories);
            BuildArea<BumperData>(_bumpers);
            BuildArea<SpoilerData>(_spoilers);

            EditorGUILayout.LabelField("Rarity", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_rarityPath);

            serializedObject.ApplyModifiedProperties();
        }

        public bool CheckFields() => _skins.IsValid && _colors.IsValid && _wheels.IsValid && _accessories.IsValid && _bumpers.IsValid && _spoilers.IsValid;

        private void BuildArea<T>(SerializedPropertyGroup group) where T : ItemData
        {
            CrazyPopulator populator = (CrazyPopulator)target;

            ValidateFolder(group.SpritePath.stringValue);
            ValidateFolder(group.DataPath.stringValue);

            EditorGUILayout.LabelField(group.Name, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(group.SpritePath);
            EditorGUILayout.PropertyField(group.DataPath);
            EditorGUILayout.PropertyField(group.ContentType);

            if (GUILayout.Button("Populate"))
            {
                PopulateAssets<T>(group);
            }

            DrawLine();
        }

        private void PopulateAssets<T>(SerializedPropertyGroup group) where T : ItemData
        {
            var items = AssetDatabase.FindAssets("", new[] { group.SpritePath.stringValue })
                .Select(asset => Path.GetFileNameWithoutExtension(AssetDatabase.GUIDToAssetPath(asset)));

            var rarityAssets = AssetDatabase.FindAssets("t:RarityData", new[] { "Assets" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<RarityData>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray();

            foreach (var item in items)
            {
                foreach (var rarityData in rarityAssets)
                {
                    var targetName = $"{group.DataPath.stringValue}/{item.CapitalizeDataName()}-{rarityData.name}.asset";

                    if (AssetDatabase.LoadAssetAtPath<T>(targetName) == null)
                    {
                        CreateAsset<T>(targetName, AssetDatabase.LoadAssetAtPath<Texture2D>($"{group.SpritePath.stringValue}/{item}.png"), rarityData,
                            group.ContentTypeValue);
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

        T CreateAsset<T>(string path, Texture2D image, RarityData rarity, ContentType contentType) where T : ItemData
        {
            T asset = ScriptableObject.CreateInstance<T>();
            asset.SetImage(image);
            asset.SetRarity(rarity);
            asset.SetContentType(contentType);

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