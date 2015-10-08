using UnityEngine;

/// <summary>
/// Board definition, logic passed between client and server.
/// </summary>
public class BoardDefinition {

	/// <summary>
	/// The width of the board.
	/// </summary>
	public int Width { get; private set; }

	/// <summary>
	/// The height of the board.
	/// </summary>
	public int Height { get; private set; }

	/// <summary>
	/// Array of tile definitions.
	/// </summary>
	private Tile[] tiles;

	/// <summary>
	/// Instantiates a new BoardDefinition object.
	/// </summary>
	/// <param name="width">Width of the board.</param>
	/// <param name="height">Height of the board.</param>
	public BoardDefinition (int width, int height) {

		// Copy dimensions.
		this.Width = width;
		this.Height = height;

		// Allocate memory for the tiles.
		tiles = new Tile[width * height];

		// Initialize each tile.
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [y * width + x] = new Tile (x, y);
			}
		}
	}
}

/// <summary>
/// Board component. Exists only on the client, to interface between
/// the Unity scene and the server's logical definition.
/// </summary>
public class BoardController : MonoBehaviour {

	/// <summary>
	/// Reference to the definition for this board.
	/// </summary>
	private BoardDefinition definition;
}
