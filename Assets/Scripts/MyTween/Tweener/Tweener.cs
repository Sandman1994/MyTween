using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
	//缓动基类
	public abstract class Tweener
	{
		private float m_Duration;           // 总时间
		private float m_ElapsedTime;        // 已用时间
		private EaseType m_EaseType;        // 缓动类型
		private bool m_IsComplete;          // 已完成
		private Action m_CompleteCallback;  // 完成回调

		public float Duration { get => m_Duration; protected set => m_Duration = value; }
		public float ElapsedTime { get => m_ElapsedTime; protected set => m_ElapsedTime = value; }
		public bool IsComplete { get => m_IsComplete; private set => m_IsComplete = value; }
		public EaseType EaseType { get => m_EaseType; protected set => m_EaseType = value; }
		public Action CompleteCallback { get => m_CompleteCallback; protected set => m_CompleteCallback = value; }

		public Tweener(float duration)
		{
			Duration = Mathf.Max(duration, 0.01f);
			ElapsedTime = 0;
			EaseType = EaseType.Linear;
			IsComplete = false;
			CompleteCallback = null;
		}
		public abstract void DoUpdate(float dt);

		// 结束
		public void Kill(bool complete = false)
		{
			if (complete)
			{
				DoComplete();
			}
			else
			{
				IsComplete = true;
			}
		}

		// 设置缓动函数
		public Tweener Ease(EaseType easeType)
		{
			EaseType = easeType;
			return this;
		}

		// 注册完成回调
		public Tweener OnComplete(Action callback)
		{
			CompleteCallback = callback;

			return this;
		}

		// 完成
		protected void DoComplete()
		{
			CompleteCallback?.Invoke();

			IsComplete = true;
		}
	}

}
