using TMPro;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskText;
    private CardData _cardData;

    private void Start()
    {
        int totalCards = transform.childCount;
        int randomCard = Random.Range(0, totalCards);
        _cardData = transform.GetChild(randomCard).GetComponent<CardData>();
        _taskText.text = "Find: " + _cardData.Identifier;

    }


}
