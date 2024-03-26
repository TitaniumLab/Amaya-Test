using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskText;
    public CardData CardData { get; private set; }
    private float _setDataDelay = 0.1f;
    public static Action On—orrectAnswer = delegate { };


    private void Start()
    {
        Invoke(nameof(SetData), _setDataDelay);
    }

    private void SetData()
    {
        int totalCards = transform.childCount;
        int randomCard = Random.Range(1, totalCards);
        Debug.Log(totalCards);
        CardData = transform.GetChild(randomCard).GetComponent<Card>().CardData;
        _taskText.text = "Find: " + CardData.Identifier;
    }

    private void OnDestroy()
    {
        SpawnManager.OnLevelComplete();
    }



}
