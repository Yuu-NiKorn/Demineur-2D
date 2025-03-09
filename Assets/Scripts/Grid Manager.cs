using UnityEngine;

public class Grid_Manager : MonoBehaviour


{
    //public Cube_Grid board;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField, Range(0, 1)]
    private float bombProbability;
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private float tileSize;

    [SerializeField]
    private Tile[,] tiles;

    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    private Tile RedFlag;


    private void Awake()
    {

        GenerateBoard();

    }

    // private void OnGUI()

    private void GenerateBoard()
    {
        tiles = new Tile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                bool isBomb = Random.value < bombProbability;
                Tile tile = Instantiate(tilePrefab, GetPositionForCoordinates(i, j), Quaternion.identity);

                tile.x = i;
                tile.y = j;
                tile.isBomb = isBomb;
                tile.grid_Manager = this;

                tile.RefreshVisual();

                tiles[i, j] = tile;
            }
        }
    }

    public Vector2 GetPositionForCoordinates(float x, float y)
    {
        //Formule pour transformer une coordonnée en position
        float xPos = x * tileSize + tileSize / 2;
        float yPos = y * tileSize + tileSize / 2;

        return new Vector2(xPos - (height / 2), yPos - (width / 2) - 1);
    }

    public int GetBombCountAroundCoord(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i >= 0 && i < width)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (j >= 0 && j < height)
                    {
                        bool isOrigin = i == x && j == y;
                        if (tiles[i, j].isBomb && !isOrigin)
                            count++;
                    }
                }
            }
        }

        return count;
    }

    public void GameOver()
    {
        Tile currentTile;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                currentTile = tiles[i, j];
                currentTile.Game = false;
                currentTile.RefreshVisual();
            }
        }
    }
}
