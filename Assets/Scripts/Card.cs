using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] private CardBundleData _cardBundleData;
    private CardData _cardData;
    public CardData CardData { get { return _cardData; } }
    [SerializeField] private SpriteRenderer _spriteIcon;

    private void Start()
    {
        int randData = Random.Range(0, _cardBundleData.CardData.Length);
        _cardData = _cardBundleData.CardData[randData];
        _spriteIcon.size = GetComponent<SpriteRenderer>().size;
        _spriteIcon.sprite = _cardData.SpriteIcon;
    }


}
