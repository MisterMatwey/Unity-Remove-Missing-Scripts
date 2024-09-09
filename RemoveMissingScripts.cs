using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts : EditorWindow
{
    [MenuItem("Tools/Remove Missing Scripts")]
    public static void ShowWindow()
    {
        GetWindow(typeof(RemoveMissingScripts));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Remove Missing Scripts from selected GameObjects"))
        {
            RemoveFromSelected();
        }

        if (GUILayout.Button("Remove Missing Scripts from all GameObjects in the scene"))
        {
            RemoveFromAll();
        }
    }

    private static void RemoveFromSelected()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        foreach (GameObject go in selectedObjects)
        {
            RemoveMissingScriptsInGameObject(go);
        }
    }

    private static void RemoveFromAll()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            RemoveMissingScriptsInGameObject(go);
        }
    }

    private static void RemoveMissingScriptsInGameObject(GameObject go)
    {
        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
        foreach (Transform child in go.transform)
        {
            RemoveMissingScriptsInGameObject(child.gameObject);
        }
    }
}
