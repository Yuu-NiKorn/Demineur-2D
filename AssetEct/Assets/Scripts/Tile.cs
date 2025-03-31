using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;


public class Tile : MonoBehaviour
{
    public bool isBomb;
    public Grid_Manager gridManager;
    public int x;
    public int y;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public bool game = true;
    public bool isClicked;
    public bool isFlagged;
    [SerializeField] private Sprite[] sprites;
    public int spriteIndex;


    public void RefreshVisual()
    {
        if (isBomb)
        {
            if (game == false)
            {
                spriteRenderer.sprite = sprites[1];
                SFX(3);
            }
        }
        else
        {
            if (isClicked)
            {
                spriteIndex = gridManager.GetBombCountAroundCoord(x, y) + 2;
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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isFlagged == false)
            {
                spriteRenderer.sprite = sprites[11];
                isFlagged = true;
                gridManager.CheckVictory();
                SFX(2);
            }
            else
            {
                if (!isClicked)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                RefreshVisual();
                isFlagged = false;
                gridManager.CheckVictory();
                RefreshVisual();
            }
        }
    }

    void OnMouseDown()
    {
        RecursiveClear();
        gridManager.CheckVictory();
        SFX(1);
    }

    private void SFX(int index)
    {
        gridManager.musicManager.PlaySFX(index);
    }
    private void TileClick()
    {
        if (isFlagged) return;
        Debug.Log(gridManager.GetBombCountAroundCoord(x, y), gameObject);
        isClicked = true;
        if (!game) return;
        if (isBomb)
        {
            game = false;
            gridManager.GameOver();
        }
        else
        {
            RefreshVisual();
        }
    }

    private void RecursiveClear()
    {
        if (isClicked) return;
        TileClick();
        if (gridManager.GetBombCountAroundCoord(x, y) > 0) return;

        int[][] directions =
        {
            new[] {-1, -1}, new[] {-1, 0}, new[] {-1, 1},
            new[] { 0, -1},                  new[] { 0, 1},
            new[] { 1, -1}, new[] { 1, 0}, new[] { 1, 1}
        };

        foreach (var dir in directions)
        {
            int newX = x + dir[0];
            int newY = y + dir[1];
            if (newX >= 0 && newX < gridManager.width &&
                newY >= 0 && newY < gridManager.height)
            {
                Tile neighbor = gridManager.Tiles[newX, newY];

                neighbor.RecursiveClear();
            }
        }
    }


    public void Scream()
    {
        Debug.Log(this + " AAAAAAAH !!!");
    }


}



