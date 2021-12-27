using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(UniversalAnimationSettings))]
public class UniversalSettings_Editor : PropertyDrawer
{
    private int _lines;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var style = new GUIStyle(GUI.skin.box);
        style.normal.background = EditorExtensions.MakeTex(2, 2);

        var delay = property.FindPropertyRelative("_delay");
        var timeScale = property.FindPropertyRelative("_timeScale");
        var timeScaleDuration = property.FindPropertyRelative("_timeScaleDuration");
        var invert = property.FindPropertyRelative("_invert");
        var easeMode = property.FindPropertyRelative("_easeMode");
        var useCurve = property.FindPropertyRelative("_useCurve");
        var curve = property.FindPropertyRelative("_curve");

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
            Rect delayRect = EditorExtensions.CreateNewLine(position, position.y);
            _lines++;

            EditorGUI.PropertyField(delayRect, delay);

            Rect timeScaleRect = EditorExtensions.CreateNewLine(position, delayRect.y);
            timeScaleRect.width /= 2;
            _lines++;

            var labelWidth = defaultLabelWidth - labelSpace;
            labelWidth = Mathf.Clamp(labelWidth, 50, 200);
            EditorGUIUtility.labelWidth -= labelWidth;

            EditorGUI.PropertyField(timeScaleRect, timeScale);

            Rect timeScaleDurationRect = timeScaleRect;
            timeScaleDurationRect.x = timeScaleRect.xMax + spaceBetweenColumns;
            
            if (timeScale.floatValue != 1)
            {
                EditorGUI.PropertyField(timeScaleDurationRect, timeScaleDuration);
            }

            Rect useCurveRect = EditorExtensions.CreateNewLine(position, timeScaleRect.y);
            useCurveRect.width /= 2;
            _lines++;

            EditorGUI.PropertyField(useCurveRect, useCurve);

            Rect easeModeRect = useCurveRect;
            easeModeRect.x = useCurveRect.xMax + spaceBetweenColumns;

            if (useCurve.boolValue)
            {
                EditorGUI.PropertyField(easeModeRect, curve, GUIContent.none);
            }
            else
            {
                EditorGUI.PropertyField(easeModeRect, easeMode, GUIContent.none);
            }
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * _lines + EditorExtensions.GetStandardVerticalSpacing(3) * (_lines - 1) + 10;
    }

}
