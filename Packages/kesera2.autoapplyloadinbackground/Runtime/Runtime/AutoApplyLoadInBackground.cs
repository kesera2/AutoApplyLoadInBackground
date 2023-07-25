// Copyright (c) 2023 kesera2
// BOOTH: https://kesera2.booth.pm/
// All rights reserved.
// Licensed under the MIT license.

using UnityEditor;
using UnityEngine;

namespace mochimochi_mart
{
    public class AutoApplyLoadInBackground : AssetPostprocessor
    {
        // This function will be called every time an asset is imported
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var importedAsset in importedAssets)
            {
                // Check if the imported asset is an AudioClip
                if (AssetImporter.GetAtPath(importedAsset) is AudioImporter audioImporter)
                {
                    // Check if the Load In Background option is already applied
                    if (!audioImporter.loadInBackground)
                    {
                        // Apply the Load In Background option
                        audioImporter.loadInBackground = true;

                        // Apply the modification to the audio importer
                        AssetDatabase.WriteImportSettingsIfDirty(importedAsset);

                        // Display the importedAsset and the applied option on the Unity console
                        if (Application.systemLanguage == SystemLanguage.Japanese)
                        {
                            Debug.Log($"{importedAsset}にLoad In Backgroundを適用しました。");
                        }
                        else if (Application.systemLanguage == SystemLanguage.English)
                        {
                            Debug.Log($"{importedAsset}. Load In Background applied.");
                        }
                    }
                }
            }
        }
    }
}