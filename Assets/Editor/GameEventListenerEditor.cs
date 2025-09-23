using UnityEditor;

[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}