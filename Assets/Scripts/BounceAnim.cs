using DG.Tweening;
using System;
using UnityEngine;

namespace Test1
{
    public class BounceAnim : MonoBehaviour
    {
        private Vector3 _defaultScale;
        [SerializeField] private float _apearTime = 1f;
        private Tween _tween;
        public static Action<float> AllSqeeze = delegate { };


        private void Start()
        {
            _defaultScale = transform.localScale;
            AllSqeeze += SqueezeAnim;
            BounceApear();
        }

        private void OnDestroy()
        {
            AllSqeeze -= SqueezeAnim;
        }

        public void CorrectAnswer(float animTime)
        {
            GetComponent<ParticleSystem>().Play();
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(_defaultScale * 1.3f, animTime / 2).SetEase(Ease.InBounce));
            sequence.Append(transform.DOScale(_defaultScale, animTime / 2).SetEase(Ease.OutBounce));
        }

        public void IncorrectAnswer(float animTime)
        {
            _tween?.Kill(true);
            _tween = transform.DOShakePosition(animTime, Vector3.right, 10, 0, false, true, ShakeRandomnessMode.Harmonic);
        }

        public void SqueezeAnim(float animTime)
        {
            transform.DOScale(0, animTime).SetEase(Ease.InBounce);
        }


        public void BounceApear()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(_defaultScale, _apearTime).SetEase(Ease.InBounce);
        }
    }
}

