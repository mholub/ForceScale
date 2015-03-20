using UnityEngine;
using UnityEditor;
using System.Collections;

namespace MH.ForceScale {
  [InitializeOnLoad]
  public class ForceScaleForAllModelsInFolder : UnityEditor.AssetPostprocessor {
    private static string _forceScaleFolderName;
    private static float _globalScale;
    
    public static string ForceScaleFolderName {
      get {
        return _forceScaleFolderName;
      }
      set {
        if (_forceScaleFolderName != value) {
          _forceScaleFolderName = value;
          EditorPrefs.SetString("ForceScaleForAllModelsInFolder.ForceScaleFolderName", ForceScaleFolderName);
        }
      }
    }
    public static float GlobalScale {
      get {
        return _globalScale;
      }
      set {
        if (_globalScale != value) {
          _globalScale = value;
          EditorPrefs.SetFloat("ForceScaleForAllModelsInFolder.GlobalScale", GlobalScale);
        }
      }
    }
    
    static ForceScaleForAllModelsInFolder() {
      Debug.Log("init");
      ForceScaleFolderName = EditorPrefs.GetString("ForceScaleForAllModelsInFolder.ForceScaleFolderName", "ForceScale");
      GlobalScale = EditorPrefs.GetFloat("ForceScaleForAllModelsInFolder.GlobalScale", 1);
    }
    
    void OnPreprocessModel() {
      if (assetPath.Contains(ForceScaleFolderName)) {
        Debug.LogFormat("{0} global scale was changed to {1}", assetPath, GlobalScale);
        var modelImporter = assetImporter as ModelImporter;
        modelImporter.globalScale = GlobalScale;
      }
    }
  }
}