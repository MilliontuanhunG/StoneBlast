using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class Shape : MonoBehaviour,IPointerClickHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public GameObject squareShapeImage;
    [HideInInspector]
    public ShapeData currentShapeData;
    private List<GameObject> currentShapeSquares = new List<GameObject>();
    public Vector3 shapeSelectedScale;
    private int GetNumberOfSquares(ShapeData shapeData)
    {
        int count = 0;
        foreach (var row in shapeData.board)
        {
            foreach (var active in row.column)
            {
                if (active)
                {
                    count++;
                }
            }
        }
        return count;
    }
    public float GetXPositionForShapeSquare(ShapeData shapeData, int column, Vector2 moveDistance) {
        int totalColumns = shapeData.columns;
        float centerColumn = (totalColumns - 1) / 2f;
        float offsetFromCenter = column - centerColumn;
        return offsetFromCenter * moveDistance.x;
    }
    public float GetYPositionForShapeSquare(ShapeData shapeData, int row, Vector2 moveDistance)
    {
        int totalRows = shapeData.rows;
        float centerRow = (totalRows - 1) / 2;
        float offsetFromCenter = centerRow - row;
        return offsetFromCenter * moveDistance.y;
    }
    public void CreateShape(ShapeData shapeData)
    {
        currentShapeData = shapeData;
        var totalSquares = GetNumberOfSquares(shapeData);
        while(currentShapeSquares.Count <= totalSquares)
        {
            var newSquare = Instantiate(squareShapeImage,transform); 
            currentShapeSquares.Add(newSquare);
        }
        foreach(var square in currentShapeSquares)
        {
            square.gameObject.transform.position = Vector3.zero;
            square.gameObject.SetActive(false);
        }
        var squareRect = squareShapeImage.GetComponent<RectTransform>();
        var moveDistance = new Vector2(squareRect.rect.width * squareRect.localScale.x, squareRect.rect.height * squareRect.localScale.y);
        int currentSquareIndex = 0;
        for (int row = 0; row < shapeData.rows; row++)
        {
            for (int col = 0; col < shapeData.columns; col++)
            {
                if (shapeData.board[row].column[col])
                {
                    var square = currentShapeSquares[currentSquareIndex];
                    square.gameObject.SetActive(true);
                    square.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(GetXPositionForShapeSquare(shapeData, col, moveDistance), GetYPositionForShapeSquare(shapeData, row, moveDistance));
                    currentSquareIndex++;
                }    
            }
        }
    }
    public void RequestNewShape(ShapeData shapeData)
    {
        CreateShape(shapeData);
    }
    void Start()
    {
        if (currentShapeData != null)
        {
            RequestNewShape(currentShapeData);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}


