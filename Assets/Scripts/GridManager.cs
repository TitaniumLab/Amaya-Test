using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private CardBundleData _cardBundleData;

    private void Start()
    {
        SpriteRenderer fieldSR = Instantiate(_gridData.FieldPrefab);
        fieldSR.size = _gridData.LevelGridSize[1] * _gridData.CellSize + (_gridData.LevelGridSize[1] + Vector2Int.one) * _gridData.CellGap;
        for (int x = 0; x < _gridData.LevelGridSize[1].x; x++)
        {
            for (int y = 0; y < _gridData.LevelGridSize[1].y; y++)
            {
                SpriteRenderer cellSR = Instantiate(_gridData.CellPrefab, fieldSR.transform);
                cellSR.size = _gridData.CellSize;
                float xHalfOffset = _gridData.LevelGridSize[1].x % 2 == 0 ? (_gridData.CellGap.x + _gridData.CellSize.x) / 2 : (_gridData.CellGap.x + _gridData.CellSize.x);
                float yHalfOffset = _gridData.LevelGridSize[1].y % 2 == 0 ? (_gridData.CellGap.y + _gridData.CellSize.y) / 2 : (_gridData.CellGap.y + _gridData.CellSize.y);
                float xTotelOffset = (_gridData.CellGap.x * x + _gridData.CellSize.x * x) - _gridData.LevelGridSize[1].x / 2 * xHalfOffset;
                float yTotalOffset = (_gridData.CellGap.y * y + _gridData.CellSize.y * y) - _gridData.LevelGridSize[1].y / 2 * yHalfOffset;
                cellSR.transform.localPosition = new Vector3(xTotelOffset, yTotalOffset);

                cellSR.sprite = _cardBundleData.CardData[x].SpriteIcon;
            }
        }
    }

    private void CreateNewGr
}
