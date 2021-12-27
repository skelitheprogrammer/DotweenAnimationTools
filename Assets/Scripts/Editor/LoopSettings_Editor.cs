using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LoopSettings))]
public class LoopSettings_Editor : PropertyDrawer
{
    private int _lines;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var style = new GUIStyle(GUI.skin.box);
        style.normal.background = EditorExtensions.MakeTex(2, 2);

        var loop = property.FindPropertyRelative("_loop");
        var loopCount = property.FindPropertyRelative("_loopCount");
        var loopType = property.FindPropertyRelative("_loopType");

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
            Rect loopRect = EditorExtensions.CreateNewLine(position, position.y);
            loopRect.width /= 3;
            _lines++;

            EditorGUIUtility.labelWidth = loopRect.xMax - loopRect.x * 2;
            EditorGUI.PropertyField(loopRect, loop);

            if (loop.boolValue)
            {

                Rect loopCounterRect = loopRect;
                loopCounterRect.x = loopRect.xMax + spaceBetweenColumns;

                var labelWidth = defaultLabelWidth - labelSpace;
                labelWidth = Mathf.Clamp(labelWidth, 50, 280);
                EditorGUIUtility.labelWidth -= labelWidth;

                EditorGUI.PropertyField(loopCounterRect, loopCount);

                Rect loopTypeRect = loopCounterRect;
                loopTypeRect.x = loopCounterRect.xMax + spaceBetweenColumns;

                EditorGUI.PropertyField(loopTypeRect, loopType);
            }

        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * _lines + EditorExtensions.GetStandardVerticalSpacing(3) * (_lines - 1) + 10;
    }
}
