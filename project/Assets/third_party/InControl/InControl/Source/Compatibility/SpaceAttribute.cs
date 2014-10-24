﻿#if UNITY_4_3 && UNITY_EDITOR
using System.Collections;
using UnityEditor;
using UnityEngine;


namespace InControl
{
	public class SpaceAttribute : PropertyAttribute
	{
		public int space;
		
		public SpaceAttribute( int space )
		{
			this.space = space;
		}
	}
	
	
	[CustomPropertyDrawer(typeof(SpaceAttribute))]
	public class SpaceDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
		{
			var spaceAttribute = attribute as SpaceAttribute;
			return EditorGUI.GetPropertyHeight( property, label ) + spaceAttribute.space;
		}
		
		
		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			var spaceAttribute = attribute as SpaceAttribute;
			position.y += spaceAttribute.space;
			position.height -= spaceAttribute.space;
			EditorGUI.PropertyField( position, property, label );
		}
	}
}
#endif

