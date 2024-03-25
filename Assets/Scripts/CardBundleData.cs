using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 52)]
public class CardBundleData : ScriptableObject
{
    [field: SerializeField] public CardData[] CardData { get; private set; }
}
