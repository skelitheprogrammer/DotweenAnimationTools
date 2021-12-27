using UnityEditor;
using UnityEngine;

public static class EditorExtensions
{
    public static Rect CreateStartingLine(Rect position)
    {
        var rect = new Rect(position.x, position.y, position.size.x, EditorGUIUtility.singleLineHeight);

        return rect;
    }

    public static Rect CreateNewLine(Rect position, float y)
    {
        var rect = new Rect(position.min.x, y + EditorGUIUtility.singleLineHeight + GetStandardVerticalSpacing(3), position.size.x, EditorGUIUtility.singleLineHeight);

        return rect;

    }

    public static float GetStandardVerticalSpacing(float spacing)
    {
        return EditorGUIUtility.standardVerticalSpacing + spacing;
    }

    public static Texture2D MakeTex(int width, int height)
    {
        Color[] pix = new Color[width * height];
        
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = Color.white;
        }

        var result = new Texture2D(width, height);
        
        result.SetPixels(pix);
        result.Apply();
        
        return result;
    }
}
