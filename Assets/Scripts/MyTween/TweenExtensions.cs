using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
    public static class TweenExtensions
    {
        public static Tweener DOMove(this Transform transform, Vector3 endPos, float duration)
        {
            return TweenManager.Instance.DOMove(transform, endPos, duration);
        }

        public static Tweener DOScale(this Transform transform, Vector3 endScale, float duration)
        {
            return TweenManager.Instance.DOScale(transform, endScale, duration);
        }
    }
}

