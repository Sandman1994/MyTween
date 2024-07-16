using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
	// ���Ż���
	public class ScaleTweener : Tweener
	{
		private Transform m_Transform;
		private Vector3 m_StartScale;
		private Vector3 m_EndScale;

		public float TweenScale { get => Mathf.Clamp01(ElapsedTime / Duration); }
		public ScaleTweener(Transform transform, Vector3 endScale, float duration) : base(duration)
		{
			m_Transform = transform;
			m_StartScale = transform.localScale;
			m_EndScale = endScale;
		}
		public override void DoUpdate(float dt)
		{
			if (IsComplete) return;

			// �����߼�
			ElapsedTime += dt;
			float t = EaseFunc.func(this.EaseType, TweenScale);
			m_Transform.localScale = Vector3.LerpUnclamped(m_StartScale, m_EndScale, t);

			// ���
			if (TweenScale >= 1) DoComplete();
		}
	}

}
