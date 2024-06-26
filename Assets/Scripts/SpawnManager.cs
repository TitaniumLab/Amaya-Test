using System;
using TMPro;
using UnityEngine;

namespace Test1
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GridData _gridData;
        [SerializeField] private int _nextLevel = 0;
        public static Action OnLevelComplete = delegate { };


        private void Awake()
        {
            OnLevelComplete += CreateNewGrid;
            CreateNewGrid();
        }

        private void OnDestroy()
        {
            OnLevelComplete -= CreateNewGrid;
        }

        public void CreateNewGrid()
        {
            if (_nextLevel == _gridData.LevelGridSize.Length)
            {
                UIManager.GameOver();
                return;
            }
            Vector2Int gridSize = _gridData.LevelGridSize[_nextLevel];
            Vector2 cellSize = _gridData.CellSize;
            Vector2 cellGap = _gridData.CellGap;
            Vector2 fieldSize = gridSize * cellSize + (gridSize + Vector2Int.one) * cellGap;
            float xHalfOffset = gridSize.x % 2 == 0 ? (cellGap.x + cellSize.x) / 2 : (cellGap.x + cellSize.x);
            float yHalfOffset = gridSize.y % 2 == 0 ? (cellGap.y + cellSize.y) / 2 : (cellGap.y + cellSize.y);

            SpriteRenderer fieldSR = Instantiate(_gridData.FieldPrefab);
            fieldSR.size = fieldSize;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    SpriteRenderer cellSR = Instantiate(_gridData.CellPrefab, fieldSR.transform);
                    cellSR.transform.localScale = cellSize;
                    float xTotelOffset = (cellGap.x * x + cellSize.x * x) - gridSize.x / 2 * xHalfOffset;
                    float yTotalOffset = (cellGap.y * y + cellSize.y * y) - gridSize.y / 2 * yHalfOffset;
                    cellSR.transform.localPosition = new Vector3(xTotelOffset, yTotalOffset);
                }
            }
            _nextLevel++;


        }
    }
}
