using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[,] piece;
    public GameObject piecePrefab;
    public int boardRows;
    public int boardColumns;
    public float spacing;
    
    void Start()
    {
        StartBoard(boardRows, boardColumns);
    }


    public void StartBoard(int rows, int columns)
    {
        piece = new GameObject[rows,columns];
        int countLabel = 1;
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if((i+j) < rows+columns-2)
                {
                    piece[i,j] = Instantiate(piecePrefab);
                    piece[i,j].transform.position = transform.position + new Vector3(j*spacing, i*-spacing, 0);
                    piece[i,j].transform.parent = transform;
                    piece[i,j].GetComponent<Piece>().SetNumber(countLabel);
                }
                else
                {
                    piece[i,j] = null;
                }
                countLabel++;
            }
        }
    }
}
