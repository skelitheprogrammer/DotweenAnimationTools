using System.Collections.Generic;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(SingleDoTweenAnimation))]
public class SimpleDoTweenAnimation_Editor : Editor
{
    private SerializedProperty _useCustomData;
    private SerializedProperty _animationData;
    private SerializedProperty _customData;

    private SerializedProperty _isLoopable;
    private SerializedProperty _loopCount;
    private SerializedProperty _loopType;

    protected virtual void OnEnable()
    {
        _useCustomData = serializedObject.FindProperty(nameof(_useCustomData));
        _animationData = serializedObject.FindProperty(nameof(_animationData));
        _customData = serializedObject.FindProperty(nameof(_customData));
        _isLoopable = serializedObject.FindProperty(nameof(_isLoopable));
        _loopCount = serializedObject.FindProperty(nameof(_loopCount));
        _loopType = serializedObject.FindProperty(nameof(_loopType));

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
/*        List<string> isLoopableExcluded = new List<string>();

        if (!_isLoopable.boolValue)
        {
            isLoopableExcluded.Add(nameof(_loopCount));
            isLoopableExcluded.Add(nameof(_loopType));
        }

        List<string> customDataExcluded = new List<string>();
       
        if (_useCustomData.boolValue)
        {
            customDataExcluded.Add(nameof(_animationData));
        }
        else
        {
            customDataExcluded.Add(nameof(_customData));
        }

        string[] finalArray = isLoopableExcluded
            .Concat(customDataExcluded).ToArray();

        serializedObject.Update();

        DrawPropertiesExcluding(serializedObject, finalArray);

        serializedObject.ApplyModifiedProperties();*/

    }
}
