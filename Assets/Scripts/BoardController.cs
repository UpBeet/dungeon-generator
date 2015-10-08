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
	protected Tile[] tiles;
	
	/// <summary>
	/// Indexer that gets a Tile from the one-dimensional array via two-dimensional coordinates.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public Tile this[int x, int y] {
		get {
			int index = y * this.Width + x;
			return tiles[index];
		}
		set {
			int index = y * this.Width + x;
			tiles[index] = value;
		}
	}

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
	/// The width of the board.
	/// </summary>
	public int Width { get; private set; }

	/// <summary>
	/// The height of the board.
	/// </summary>
	public int Height { get; private set; }

	/// <summary>
	/// Reference to the definition for this board.
	/// </summary>
	private BoardDefinition definition;

	/// <summary>
	/// Loads the board given the definition and the tile prefab.
	/// </summary>
	/// <param name="definition">Definition.</param>
	public void LoadBoard (BoardDefinition definition, TileController tilePrefab) {
		
		// Cache the board dimensions.
		this.Width = definition.Width;
		this.Height = definition.Height;
		
		// Instantiate new tiles layer.
		GameObject tilesLayerObject = new GameObject ("Tiles");
		tilesLayerObject.transform.SetParent (transform);
		
		// Calculate tile dimensions.
		BoxCollider2D bounds = tilePrefab.transform.FindChild ("Sprite").GetComponent<BoxCollider2D> ();
		float tileWidth = bounds.size.x;
		float tileHeight = bounds.size.y;
		
		// Initialize the tiles on the board.
		for (int x = 0; x < this.Width; x++) {
			for (int y = 0; y < this.Width; y++) {
				
				// Instantiate tile GameObject.
				TileController tile = Instantiate (tilePrefab) as TileController;
				tile.transform.SetParent (tilesLayerObject.transform);

				// Initialize and position the tile.
				tile.Initialize (definition [x, y], tileWidth, tileHeight);
			}
		}
	}
}
