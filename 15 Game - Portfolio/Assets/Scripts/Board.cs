using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject[,] piece;
    public GameObject piecePrefab;
    public int side;
    public float slideTime;
    public bool inSlide;
    
    void Start()
    {
        StartBoard(side);
    }


    public void StartBoard(int side)
    {
        piece = new GameObject[side,side];
        int qtdPieces = side*side;
        
        int countLabel = 1;
        for(int i = 0; i < side; i++)
        {
            for(int j = 0; j < side; j++)
            {
                if(countLabel < qtdPieces)
                {
                    GameObject p = Instantiate(piecePrefab);
                    p.transform.position = transform.position + new Vector3(j, -i, 0);
                    p.transform.parent = transform;
                    p.GetComponent<Piece>().SetNumber(countLabel);
                    p.GetComponent<Piece>().SetIndex(i, j);
                    p.GetComponent<Piece>().SetBoard(GetComponent<Board>());

                    piece[i,j] = p;
                }
                else
                {
                    piece[i,j] = null;
                }
                countLabel++;
            }
            
        }
    }

    public void SetColorHoverAdjacentEnable(int row, int col)
    {
        if(OutOfRange(row-1, col) == false)
        {
            if(piece[row-1, col] != null)
                piece[row-1, col].GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if(OutOfRange(row+1, col) == false)
        {
            if(piece[row+1, col] != null)
                piece[row+1, col].GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if(OutOfRange(row, col+1) == false)
        {
            if(piece[row, col+1] != null)
                piece[row, col+1].GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if(OutOfRange(row, col-1) == false)
        {
            if(piece[row, col-1] != null)
                piece[row, col-1].GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
    public void SetColorHoverAdjacentDisable(int row, int col)
    {
        if(OutOfRange(row-1, col) == false)
        {
            if(piece[row-1, col] != null)
                piece[row-1, col].GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(OutOfRange(row+1, col) == false)
        {
            if(piece[row+1, col] != null)
                piece[row+1, col].GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(OutOfRange(row, col+1) == false)
        {
            if(piece[row, col+1] != null)
                piece[row, col+1].GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(OutOfRange(row, col-1) == false)
        {
            if(piece[row, col-1] != null)
                piece[row, col-1].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void SlidePiece(int row, int col)
    {
        if(!inSlide)
        {
            Vector2Int nullIndex = CheckAdjacentNull(row, col);
            if(nullIndex.x != -1)
            {
                StartCoroutine(SlideCoroutine(r, c, r+(int)(dir.y), c+(int)(dir.x), dir));
            }
        }
    }

    IEnumerator SlideCoroutine(int fromR, int fromC, int toR, int toC, Vector2 dir)
    {
        // inSlide = true;

        // Vector2 initialPosition = piece[fromR, fromC].transform.position;
        // Vector2 finalPosition = initialPosition+dir;

        // float currentTime = 0.0f;
        // while(currentTime < slideTime)
        // {
        //     currentTime += Time.deltaTime;
        //     piece[fromR, fromC].transform.position = Vector3.Lerp(initialPosition, finalPosition, currentTime/slideTime);
            yield return null;
        // }
        // piece[fromR, fromC].transform.position = finalPosition;

        // GameObject aux = piece[fromR, fromC];
        // piece[fromR, fromC] = piece[toR, toC];
        // piece[toR, toC] = aux;
        // piece[fromR, fromC] = null;
        // piece[toR, toC].GetComponent<Piece>().SetIn(toR, toC);

        // inSlide = false;
    } 

    private Vector2Int CheckAdjacentNull(int r, int c)
    {
        if(OutOfRange(r-1, c) == false)
        {
            if(piece[r-1,c] == null) return new Vector2Int(r-1,c);
        }
        if(OutOfRange(r+1, c) == false)
        {
            if(piece[r+1,c] == null) return new Vector2Int(r+1,c);
        }
        if(OutOfRange(r, c-1) == false)
        {
            if(piece[r,c-1] == null) return new Vector2Int(r,c-1);
        }
        if(OutOfRange(r, c+1) == false)
        {
            if(piece[r,c+1] == null) return new Vector2Int(r,c+1);
        }
        return new Vector2Int(-1,-1);
    }

    private Vector2 CheckAdjacent(int indice)
    {
        // if(OutOfRange(r-1, c) == false)
        // {
        //     if(piece[r-1, c] == null) return Vector2.up;
        // }
        // if(OutOfRange(r+1, c) == false)
        // {
        //     if(piece[r+1, c] == null) return Vector2.down;
        // }
        // if(OutOfRange(r, c-1) == false)
        // {
        //     if(piece[r, c-1] == null) return Vector2.left;
        // }
        // if(OutOfRange(r, c+1) == false)
        // {
        //     if(piece[r, c+1] == null) return Vector2.right;
        // }
        return Vector2.zero;
    }

    private bool OutOfRange(int r, int c)
    {
        if ((r < 0) || (c < 0) || (r >= side) || (c >= side)) return true;
        else return false;
    }
}
