using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Test1
{
    public class CardSelector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _taskText;
        public CardData CardData { get; private set; }
        private float _setDataDelay = 0.01f;
        public static Action On—orrectAnswer = delegate { };


        private void Start()
        {
            Invoke(nameof(SetData), _setDataDelay);
            On—orrectAnswer += SelfDistruction;
        }

        private void OnDestroy()
        {
            On—orrectAnswer -= SelfDistruction;
        }

        private void SetData()
        {
            int totalCards = transform.childCount;
            int randomCard = Random.Range(1, totalCards);
            CardData = transform.GetChild(randomCard).GetComponent<Card>().CardData;
            _taskText.text = "Find: " + CardData.Identifier;
        }

        private void SelfDistruction()
        {
            SpawnManager.OnLevelComplete();
            Destroy(gameObject);
        }
    }
}
