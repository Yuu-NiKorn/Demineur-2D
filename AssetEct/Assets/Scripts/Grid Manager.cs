using UnityEngine;

public class Grid_Manager : MonoBehaviour


{
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    [SerializeField, Range(0, 1)]
    private float bombProbability;
    [SerializeField]
    public int width;

    [SerializeField]
    public int height;

    [SerializeField]
    private float tileSize;

    [SerializeField]
    public Tile[,] Tiles;

    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    private Tile RedFlag;

    public Sounds musicManager;

    private void Awake()
    {
        musicManager.PlaySFX(0);
        GenerateBoard();
    }

    // private void OnGUI()

    private void GenerateBoard()
    {
        Tiles = new Tile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                bool isBomb = Random.value < bombProbability;
                Tile tile = Instantiate(tilePrefab, GetPositionForCoordinates(i, j), Quaternion.identity);

                tile.x = i;
                tile.y = j;
                tile.isBomb = isBomb;
                tile.gridManager = this;

                tile.RefreshVisual();

                Tiles[i, j] = tile;
            }
        }
    }

    public Vector2 GetPositionForCoordinates(float x, float y)
    {
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
                        if (Tiles[i, j].isBomb && !isOrigin)
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
                currentTile = Tiles[i, j];
                currentTile.game = false;
                currentTile.RefreshVisual();
                musicManager.PlaySFX(4);
            }
        }
        gameOverScreen.SetActive(true);
    }
    public void CheckVictory()
    {
        {
            int remainingNonRevealedTiles = 0;
            int remainingBombs = 0;
            foreach (var tile in Tiles)
            {
                if (!tile.isClicked && !tile.isFlagged)
                {
                    remainingNonRevealedTiles++;

                    if (tile.isBomb)
                    {
                        remainingBombs++;
                    }
                }
            }
            if (remainingNonRevealedTiles == remainingBombs)
            {
                WinGame();
            }
        }

        foreach (var tile in Tiles)
        {
            if (!tile.isClicked && !tile.isFlagged)
            {
                if (!tile.isBomb)
                {
                    return;
                }
            }

        }


        WinGame();
    }

    private void WinGame()
    {
        victoryScreen.SetActive(true);
    }
}
