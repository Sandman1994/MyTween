using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
	// 位移缓动
	public class MoveTweener : Tweener
	{
		private Transform m_Transform;
		private Vector3 m_StartPos;
		private Vector3 m_EndPos;

		public float TweenScale { get => Mathf.Clamp01(ElapsedTime / Duration); }
		public MoveTweener(Transform transform, Vector3 endPos, float duration) : base(duration)
		{
			m_Transform = transform;
			m_StartPos = transform.position;
			m_EndPos = endPos;
		}
		public override void DoUpdate(float dt)
		{
			if (IsComplete) return;

			// 缓动逻辑
			ElapsedTime += dt;
			float t = EaseFunc.func(this.EaseType, TweenScale);
			m_Transform.position = Vector3.LerpUnclamped(m_StartPos, m_EndPos, t);

			// 完成
			if (TweenScale >= 1) DoComplete();
		}
	}

}
