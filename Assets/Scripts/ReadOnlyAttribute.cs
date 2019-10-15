using UnityEngine;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Field, Inherited = true)]
public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
// Allows declare a public visible read only properties in unity editor.
[UnityEditor.CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyAttributeDrawer : UnityEditor.PropertyDrawer
{
    public override void OnGUI(Rect rect, UnityEditor.SerializedProperty prop, GUIContent label)
    {
        bool wasEnabled = GUI.enabled;
        GUI.enabled = false;
        UnityEditor.EditorGUI.PropertyField(rect, prop);
        GUI.enabled = wasEnabled;
    }
}
#endif