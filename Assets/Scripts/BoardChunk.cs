using UnityEngine;

/// <summary>
/// Board chunk definition, logic passed between client and server.
/// </summary>
public class BoardChunkDefinition : BoardDefinition {

	/// <summary>
	/// The number of exits on this board.
	/// </summary>
	public int Exits {
		get { return exits; }
		private set { exits = value; }
	}
	private int exits;

	/// <summary>
	/// Instantiates a new BoardChunkDefinition object.
	/// </summary>
	/// <param name="width">Width of the board chunk.</param>
	/// <param name="height">Height of the board chunk.</param>
	public BoardChunkDefinition (int width, int height) : base (width, height) {

		// Count the number of exits in the chunk.
		exits = 0;
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				// If the tile is an exit, increment exits.
				if (this [x, y].IsExit) {
					exits++;
				}
			}
		}
	}
}

/// <summary>
/// Board chunk component. Exists only on the client, to interface between
/// the Unity scene and the server's logical definition.
/// </summary>
public class BoardChunk : MonoBehaviour {

	/// <summary>
	/// Reference to the board chunk definition.
	/// </summary>
	private BoardChunkDefinition definition;
}
