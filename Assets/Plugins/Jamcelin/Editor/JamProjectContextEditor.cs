﻿using Jamcelin.Runtime.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Jamcelin.Editor
{
    [CustomEditor(typeof(JamProjectContext))]
    public class JamProjectContextEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var result = new VisualElement();
            result.Add(new PropertyField(serializedObject.FindProperty("_scope"), "Scope"));
            return result;
        }
    }
}