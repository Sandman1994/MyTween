using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
	//��������
	public abstract class Tweener
	{
		private float m_Duration;           // ��ʱ��
		private float m_ElapsedTime;        // ����ʱ��
		private EaseType m_EaseType;        // ��������
		private bool m_IsComplete;          // �����
		private Action m_CompleteCallback;  // ��ɻص�

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

		// ����
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

		// ���û�������
		public Tweener Ease(EaseType easeType)
		{
			EaseType = easeType;
			return this;
		}

		// ע����ɻص�
		public Tweener OnComplete(Action callback)
		{
			CompleteCallback = callback;

			return this;
		}

		// ���
		protected void DoComplete()
		{
			CompleteCallback?.Invoke();

			IsComplete = true;
		}
	}

}
