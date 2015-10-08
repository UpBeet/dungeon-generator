using UnityEngine;
using UnityEditor;

/// <summary>
/// This component is effectively used to mimic the server-side
/// generation of boards that will be sent to the client.
/// </summary>
public class BoardGenerator : MonoBehaviour {
}

/// <summary>
/// Inspector controls for the board generator.
/// </summary>
[CustomEditor (typeof (BoardGenerator))]
public class BoardGeneratorControls : Editor {

	/// <summary>
	/// The BoardGenerator this component inspector details.
	/// </summary>
	private BoardGenerator generator;

	/// <summary>
	/// Initialize this component inspector.
	/// </summary>
	void OnEnable () {

		// Cache a reference to the BoardGenerator.
		generator = target as BoardGenerator;
	}

	/// <summary>
	/// Render the GUI for this component inspector.
	/// </summary>
	public override void OnInspectorGUI () {

		// Draw the default inspect.
		DrawDefaultInspector ();

		// Draw the button to generate a new board.
		if (GUILayout.Button ("Generate Board")) {
			Debug.LogError ("Not implemented yet.");
		}
	}
}
