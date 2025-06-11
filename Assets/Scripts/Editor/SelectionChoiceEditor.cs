using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//[CustomPropertyDrawer(typeof(SelectionChoice))]
public class SelectionChoiceEditor : PropertyDrawer
{
    //public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //{
    //    var container = new VisualElement();

    //    var transformField = new PropertyField(property.FindPropertyRelative("Choice"));
    //    var stateField = new PropertyField(property.FindPropertyRelative("Action"));

    //    container.Add(transformField);
    //    container.Add(stateField);

    //    return container;
    //}

    //public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //{
    //    EditorGUI.BeginProperty(position, label, property);

    //    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    //    var indent = EditorGUI.indentLevel;
    //    EditorGUI.indentLevel = 0;

    //    var selectionRect = new Rect(position.x, position.y, position.width/2 - 2.5f, position.height);
    //    var stateRect = new Rect(position.x + position.width/2 + 5f, position.y, position.width/2 - 2.5f, position.height);

    //    EditorGUI.PropertyField(selectionRect, property.FindPropertyRelative("Choice"), GUIContent.none);
    //    EditorGUI.PropertyField(stateRect, property.FindPropertyRelative("Action"), GUIContent.none);

    //    EditorGUI.indentLevel = indent;

    //    EditorGUI.EndProperty();
    //}
}
