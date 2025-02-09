using TMPro;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int number;
    public TMP_Text textNumber;
    
    void Start()
    {
        SetNumber(number);
    }

    public void SetNumber(int n)
    {
        number = n;
        textNumber.text = number.ToString();
    }

    private void OnMouseDown()
    {
        Debug.Log($"Clicou na peça {number}");
    }
}
