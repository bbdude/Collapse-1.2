using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class MasterCommandWindow : EditorWindow {
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;
	[SerializeField]
	GameObject masterCommand;
	
	// Add menu named "My Window" to the Window menu
	[MenuItem ("Window/Level Generator")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		MasterCommandWindow window = (MasterCommandWindow)EditorWindow.GetWindow (typeof (MasterCommandWindow));
		window.Show();
	}
	
	void OnGUI () {
		GUILayout.Label ("Level Options", EditorStyles.boldLabel);
		//GUI.Label(Rect.MinMaxRect(0,0,100,100),"Level Options");
		EditorGUILayout.HelpBox("\nThis Object will control the generation on the level." +
		                        "\nIt also will hold several important scripts." +
		                        "\nThis needs to be an empty Gameobject",
		                        MessageType.Info, true);
		GUILayout.Label ("Master Command Object", EditorStyles.miniLabel);
		masterCommand = (GameObject)  EditorGUILayout.ObjectField(masterCommand, typeof(GameObject),true);
		//if (masterCommand)

			//EditorUtility.SetDirty(masterCommand);
		//if (GUI.changed)
		//	EditorUtility.SetDirty(masterCommand);
		//myString = EditorGUILayout.TextField ("Text Field", myString);
		//masterCommand = EditorGUILayout.ObjectField(
		//masterCommand = (GameObject) EditorGUI.ObjectField(new Rect(10,40,5,20), "Find Master Command", masterCommand, typeof(GameObject));
		///if (masterCommand)
     	//	if (GUI.Button(new Rect(3, 25, position.width, 20), "Check Dependencies"))
		//		Selection.objects = EditorUtility.CollectDependencies(new GameObject[] {masterCommand});
        //                                 
        // else
        //     EditorGUI.LabelField(new Rect(3, 25, position.width - 6, 20), "Missing:", "Select an object first");
		//
		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		//myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		//myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		if(GUI.changed)
		{
			EditorUtility.SetDirty( masterCommand );
        }
    }
}