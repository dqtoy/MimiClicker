using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(EnemyMaster))]
	public class EnemyMasterEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			EnemyMaster s = target as EnemyMaster;
			EnemyMasterRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Name", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Name );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_HP", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._HP );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_ATK", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._ATK );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_DEF", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._DEF );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Explain", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Explain );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Model", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Model );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}