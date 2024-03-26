using DG.Tweening;
using UnityEngine;

public class BounceOnStart : MonoBehaviour
{
    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = transform.localScale;
        BounceApear();
    }

    private void BounceApear()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0, 0));
        sequence.Append(transform.DOScale(_defaultScale * 1.1f, 0.6f));
        sequence.Append(transform.DOScale(_defaultScale * 0.95f, 0.2f));
        sequence.Append(transform.DOScale(_defaultScale * 1.05f, 0.2f));
        sequence.Append(transform.DOScale(_defaultScale * 1.0f, 0.2f));
    }
}
