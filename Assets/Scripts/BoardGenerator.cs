using UnityEngine;
using UnityEditor;

/// <summary>
/// This component is effectively used to mimic the server-side
/// generation of boards that will be sent to the client.
/// </summary>
public class BoardGenerator : MonoBehaviour {

	/// <summary>
	/// Reference to the tile prefab for loading boards.
	/// </summary>
	[SerializeField] private TileController tilePrefab;

	/// <summary>
	/// Reference to the current board, or null if there isn't one.
	/// </summary>
	private BoardController board;

	/// <summary>
	/// Generates a new board.
	/// </summary>
	public void GenerateBoard () {

		// Base case: no tile prefab.
		if (tilePrefab == null) {
			Debug.LogError ("Missing reference to tile prefab.");
			return;
		}
		
		// Delete the old board object.
		if (board != null) {
			GameObject.DestroyImmediate (board.gameObject);
		}

		// Construct a board definition.
		BoardDefinition generatedBoardDefinition = new BoardDefinition (20, 20);

		// Construct the board GameObject.
		GameObject boardObject = new GameObject ("Generated Board");
		boardObject.transform.SetParent (transform);
		board = boardObject.AddComponent<BoardController> ();

		// Load the tiles onto the board.
		board.LoadBoard (generatedBoardDefinition, tilePrefab);
	}
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
			generator.GenerateBoard ();
		}
	}
}
