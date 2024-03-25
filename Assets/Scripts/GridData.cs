using UnityEngine;

[CreateAssetMenu(fileName = "New GridData", menuName = "Grid Data", order = 51)]
public class GridData : ScriptableObject
{
    [field: SerializeField] public Vector2Int[] LevelGridSize { get; private set; }
    [field: SerializeField] public Vector2 CellSize { get; private set; }
    [field: SerializeField] public Vector2 CellGap { get; private set; }
    [field: SerializeField] public SpriteRenderer CellPrefab { get; private set; }
    [field: SerializeField] public SpriteRenderer FieldPrefab { get; private set; }
}
