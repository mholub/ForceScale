using UnityEngine;
using UnityEditor;
using System.Collections;

namespace MH.ForceScale {
public class ForceScaleEditorWindow : EditorWindow {
	[MenuItem("Assets/Force Scale Settings")]
	public static void OpenWindow() {
		EditorWindow.GetWindow<ForceScaleEditorWindow>().Show();
	}

	void OnGUI() {
		GUILayout.BeginVertical();
		ForceScaleForAllModelsInFolder.GlobalScale = EditorGUILayout.FloatField("Global scale", ForceScaleForAllModelsInFolder.GlobalScale);
		EditorGUILayout.Space();
		ForceScaleForAllModelsInFolder.ForceScaleFolderName = EditorGUILayout.TextField("Path should contain", ForceScaleForAllModelsInFolder.ForceScaleFolderName);
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("You need to reimport assets after settings changed");
		GUILayout.EndVertical();
	}
}
}
