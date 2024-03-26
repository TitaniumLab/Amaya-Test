using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] private CardBundleData _cardBundleData;
    private CardData _cardData;
    private CardData _answer;
    public CardData CardData { get { return _cardData; } }
    [SerializeField] private SpriteRenderer _spriteIcon;


    private void Start()
    {
        int randData = Random.Range(0, _cardBundleData.CardData.Length);
        _cardData = _cardBundleData.CardData[randData];
        //_spriteIcon.size = transform.localScale;
        _spriteIcon.sprite = _cardData.SpriteIcon;
    }

    private void OnMouseDown()
    {
        _answer = GetComponentInParent<CardSelector>().CardData;
        if (_answer.Identifier == _cardData.Identifier)
        {
            float animDuration = 0.4f;
            GetComponent<BounceAnim>().CorrectAnswer(animDuration);
            GetComponent<Collider2D>().enabled = false;
            Invoke(nameof(DestroyAnimCall), animDuration);
        }
        else
        {

        }
    }

    private void DestroyAnimCall()
    {
        CardSelector.On—orrectAnswer();
    }

}
