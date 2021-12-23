using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LoopSettings))]
public class LoopSettings_Editor : PropertyDrawer
{
    private int lines;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var loop = property.FindPropertyRelative("_loop");
        var loopCount = property.FindPropertyRelative("_loopCount");
        var loopType = property.FindPropertyRelative("_loopType");

        var defaultLabelWidth = EditorGUIUtility.labelWidth;

        EditorGUI.BeginProperty(position, label, property);

        Rect rectFoldout = new Rect(position.min.x, position.min.y, position.width, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
        
        lines = 1;
        
        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;

            Rect loopRect = new Rect(position.min.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);

            EditorGUIUtility.labelWidth = defaultLabelWidth - 120;
            EditorGUI.PropertyField(loopRect, loop);

            if (loop.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUIUtility.labelWidth = defaultLabelWidth - 120;

                Rect loopDropDownRect = new Rect(position.x, position.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);

                loopDropDownRect.width = (loopDropDownRect.width - 120) / 2;

                EditorGUI.PropertyField(loopDropDownRect, loopCount);

                loopDropDownRect.x += loopDropDownRect.width - 30;

                EditorGUI.PropertyField(loopDropDownRect, loopType);

                EditorGUIUtility.labelWidth = defaultLabelWidth;
                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * lines + EditorGUIUtility.standardVerticalSpacing * (lines - 1);
    }
}
