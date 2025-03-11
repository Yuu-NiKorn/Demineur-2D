using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Tile : MonoBehaviour
{
    public bool isBomb;
    [HideInInspector]
    public Grid_Manager grid_Manager;
    public int x;
    public int y;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField, Space]
    private GameObject numberPrefabs;
    [SerializeField]
    private GameObject bombPrefab, redFlagPrefab;
    public bool Game = true;
    private bool isClicked = false;
    [SerializeField] private Sprite[] sprites;
    public int spriteIndex = 0;


    public void RefreshVisual()
    {
        if (isBomb)
        {
            if (Game == false)
            {
                //spriteRenderer.color = Color.magenta;
                spriteRenderer.sprite = sprites[1];
            }
        }
        else
        {
            if (isClicked)
            {
                spriteIndex = grid_Manager.GetBombCountAroundCoord(x, y) + 2;
                //spriteRenderer.color = Color.blue;
                switch (spriteIndex)
                {
                    case 2:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 3:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 4:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 5:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 6:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 7:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 8:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 9:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                    case 10:
                        spriteRenderer.sprite = sprites[spriteIndex];
                        break;
                }
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log(grid_Manager.GetBombCountAroundCoord(x, y), gameObject);
        isClicked = true;
        if (isBomb)
        {
            Game = false;
            grid_Manager.GameOver();
        }
        else
        {
            RefreshVisual();
        }
    }

    public void Scream()
    {
        Debug.Log(this + " is screaming !!!");
    }

    //void OAsButton()
    //{
    //    Debug.Log(Grid_Manager.RedFlag);
    //}
}



