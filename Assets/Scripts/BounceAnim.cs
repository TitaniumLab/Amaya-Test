using DG.Tweening;
using UnityEngine;

public class BounceAnim : MonoBehaviour
{
    public void CorrectAnswer(float animDuration)
    {
        transform.DOShakeScale(animDuration, Vector3.one, 1, 50, true, ShakeRandomnessMode.Harmonic);
    }

    public void SqueezeAnimation(float animDuration)
    {
        float squeezeDuration = 0.7f;
        transform.DOScale(0, squeezeDuration);
    }
}
