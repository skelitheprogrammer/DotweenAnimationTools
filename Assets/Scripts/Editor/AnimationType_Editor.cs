using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AnimationType))]
public class AnimationType_Editor : PropertyDrawer
{
    private int _lines;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var style = new GUIStyle(GUI.skin.box);
        style.normal.background = EditorExtensions.MakeTex(2, 2);

        var animationType = property.FindPropertyRelative("_animationType");
        var duration = property.FindPropertyRelative("_duration");
        var useFrom = property.FindPropertyRelative("_useFrom");
        var fromValue = property.FindPropertyRelative("_fromValue");
        var toValue = property.FindPropertyRelative("_toValue");

        var labelSpace = 200;
        var defaultLabelWidth = EditorGUIUtility.labelWidth;
        var spaceBetweenColumns = 3;

        _lines = 0;

        EditorGUI.BeginProperty(position, label, property);

        Rect rectFoldout = EditorExtensions.CreateStartingLine(position);
        _lines++;

        GUI.Box(rectFoldout, GUIContent.none, style);

        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);

        if (property.isExpanded)
        {

            Rect durationRect = EditorExtensions.CreateNewLine(position, position.y);
            durationRect.size = new Vector2((durationRect.size.x / 2) - spaceBetweenColumns, durationRect.size.y);
            _lines++;

            var labelWidth = defaultLabelWidth - labelSpace;
            labelWidth = Mathf.Clamp(labelWidth, 50, 400);
            EditorGUIUtility.labelWidth -= labelWidth;

            EditorGUI.PropertyField(durationRect, duration);

            Rect animationTypeRect = durationRect;
            animationTypeRect.x = durationRect.xMax + spaceBetweenColumns; 

            EditorGUI.PropertyField(animationTypeRect, animationType);

            Rect useFromBoolRect = EditorExtensions.CreateNewLine(position, durationRect.y);
            useFromBoolRect.size = new Vector2((useFromBoolRect.size.x / 2) - spaceBetweenColumns, useFromBoolRect.size.y);
            _lines++;

            EditorGUI.PropertyField(useFromBoolRect, useFrom);

            Rect valueBoxRect = useFromBoolRect;
            valueBoxRect.x = useFromBoolRect.xMax + spaceBetweenColumns;

            EditorGUIUtility.labelWidth -= 50;

            if (useFrom.boolValue)
            {
                EditorGUI.PropertyField(valueBoxRect, fromValue);
            }
            else
            {
                EditorGUI.PropertyField(valueBoxRect, toValue);
            }
        }

        EditorGUI.EndProperty();

        EditorGUIUtility.labelWidth = defaultLabelWidth;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * _lines + EditorExtensions.GetStandardVerticalSpacing(3) * (_lines - 1) + 10;
    }

}
