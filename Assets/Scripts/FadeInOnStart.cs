using UnityEngine;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private float _fadeDuration = 0.7f;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        FadeIn();
    }

    public void FadeIn()
    {
        _textMeshPro.DOFade(1, _fadeDuration);
    }

    public void FadeOut()
    {
        _textMeshPro.DOFade(0, _fadeDuration);
    }

}


