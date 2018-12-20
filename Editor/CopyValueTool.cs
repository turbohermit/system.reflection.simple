using UnityEditor;
using UnityEngine;
using System.Reflection.Simple;

//An editor window for ValueCopyTool Makes all fields selectable from a pop-up list and adds a button to invoke the copy.
public class CopyValueTool : EditorWindow
{
    private int copyFieldIndex;
    private int pasteFieldIndex;
    private MonoBehaviour copyTargetComponent;
    private MonoBehaviour pasteTargetComponent;

    [MenuItem("Window/Reflection/Copy Value Tool")]
    static void Init()
    {
        CopyValueTool window = (CopyValueTool)GetWindow(typeof(CopyValueTool));
        window.titleContent = new GUIContent("Copy Value Tool");
        window.minSize = new Vector2(300, 100);
        window.maxSize = new Vector2(300, 100);
        window.Show();
    }

    void OnGUI()
    {
        copyTargetComponent = (MonoBehaviour)EditorGUILayout.ObjectField("Copy Script", copyTargetComponent, typeof(MonoBehaviour), true);
        if (copyTargetComponent != null)
        {
            copyFieldIndex = EditorGUILayout.Popup("Copy Field", copyFieldIndex, Reflection.GetAllFieldNames(copyTargetComponent));
        }

        pasteTargetComponent = (MonoBehaviour)EditorGUILayout.ObjectField("Paste Script", pasteTargetComponent, typeof(MonoBehaviour), true);
        if (pasteTargetComponent != null)
        {
            pasteFieldIndex = EditorGUILayout.Popup("Paste Field", pasteFieldIndex, Reflection.GetAllFieldNames(pasteTargetComponent));
        }

        if (GUILayout.Button("Copy values"))
        {
            CopyValues();
        }
    }

    public void CopyValues()
    {
        Reflection.SetValue(pasteTargetComponent, pasteFieldIndex, Reflection.GetValue(copyTargetComponent, copyFieldIndex));
    }
}