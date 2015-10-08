using UnityEngine;

/// <summary>
/// Tile definition, logic passed between client and server.
/// </summary>
public class Tile {

	/// <summary>
	/// The X coordinate.
	/// </summary>
	public int X { get; private set; }

	/// <summary>
	/// The Y coordinate.
	/// </summary>
	public int Y { get; private set; }

	/// <summary>
	/// If set to true, this tile does not have an established definition.
	/// </summary>
	public bool Empty { get; private set; }

	/// <summary>
	/// If set to true, this tile is an exit tile.
	/// </summary>
	public bool IsExit { get; private set; }

	/// <summary>
	/// Instantiates a new Tile object.
	/// </summary>
	/// <param name="x">The X coordinate of the tile.</param>
	/// <param name="y">The Y coordinate of the tile.</param>
	public Tile (int x, int y) {
		this.X = x;
		this.Y = y;
		this.Empty = true;
		this.IsExit = false;
	}
}

/// <summary>
/// Tile component. Exists only on the client, to interface between
/// the Unity scene and the server's logical definition.
/// </summary>
public class TileController : MonoBehaviour {

	/// <summary>
	/// The X coordinate.
	/// </summary>
	public int X { get; private set; }

	/// <summary>
	/// The Y coordinate.
	/// </summary>
	/// <value>The y.</value>
	public int Y { get; private set; }

	/// <summary>
	/// If set to true, this tile is an empty part of the board.
	/// </summary>
	public bool Empty { get; private set; }

	/// <summary>
	/// Reference to the definition for this tile.
	/// </summary>
	private Tile tile;

	/// <summary>
	/// Initialize the TileController via a tile definition.
	/// </summary>
	/// <param name="tile">Tile.</param>
	public void Initialize (Tile tile, float tileWidth, float tileHeight) {
		this.tile = tile;
		this.X = tile.X;
		this.Y = tile.Y;
		this.Empty = tile.Empty;
		
		// Position
		float worldX = this.X * (tileWidth / 2) + this.Y * (tileWidth / 2);
		float worldY = this.Y * (tileHeight / 2) - this.X * (tileHeight / 2);
		transform.position = new Vector3 (worldX, worldY, 0);
	}
}
