using System;
using TMPro;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private int number;
    public TMP_Text textNumber;
    private int row;
    private int column;
    private Board board;

    public void SetNumber(int n)
    {
        number = n;
        textNumber.text = number.ToString();
    }

    public void SetBoard(Board b)
    {
        board = b;
    }

    public void SetIndex(int r, int c)
    {
        row = r;
        column = c;
    }

    private void OnMouseDown()
    {
        Debug.Log($"Piece: {number} | Row: {row} | Column: {column}");
        board.SlidePiece(row, column);
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        board.SetColorHoverAdjacentEnable(row, column);
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        board.SetColorHoverAdjacentDisable(row, column);
    }
}
