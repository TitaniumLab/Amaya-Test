using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test1
{
    public class Card : MonoBehaviour
    {

        [SerializeField] private CardBundleData _cardBundleData;
        private CardData _cardData;
        private CardData _answer;
        [SerializeField] private float _correctAnimTime = 0.4f;
        [SerializeField] private float _incorrectAnimTime = 0.4f;
        [SerializeField] private float _squeezeAnimTime = 0.4f;
        private static List<CardData> _bannedCards = new List<CardData>();
        private BounceAnim _bounceAnim;
        public CardData CardData { get { return _cardData; } }
        [SerializeField] private SpriteRenderer _spriteIcon;


        private void Start()
        {
            _cardData = GetRandomCard();
            _spriteIcon.sprite = _cardData.SpriteIcon;
            _spriteIcon.transform.rotation = Quaternion.Euler(0, 0, _cardData.SpriteRotarion);
            _bounceAnim = GetComponent<BounceAnim>();
            UIManager.GameOver += ClearBannedList;
        }



        private static void ClearBannedList()
        {
            _bannedCards.Clear();
        }

        private CardData GetRandomCard()
        {
            while (_bannedCards.Count != _cardBundleData.CardData.Length)
            {
                int randData = Random.Range(0, _cardBundleData.CardData.Length);
                CardData data = _cardBundleData.CardData[randData];
                if (!_bannedCards.Contains(data))
                    return data;
            }
            return null;
        }

        private void OnMouseDown()
        {
            _answer = GetComponentInParent<CardSelector>().CardData;
            if (_answer.Identifier == _cardData.Identifier)
            {
                _bounceAnim.CorrectAnswer(_correctAnimTime);
                GetComponent<Collider2D>().enabled = false;
                Invoke(nameof(—orrectAnswer), _correctAnimTime);
            }
            else
            {
                _bounceAnim.IncorrectAnswer(_incorrectAnimTime);
            }
        }

        private void —orrectAnswer()
        {
            _bounceAnim.SqueezeAnim(_squeezeAnimTime);
            _bannedCards.Add(_cardData);
            StartCoroutine(StartDestroy());
        }

        private IEnumerator StartDestroy()
        {
            yield return new WaitForSeconds(_squeezeAnimTime);
            CardSelector.On—orrectAnswer();
        }
    }
}
