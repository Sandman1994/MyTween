using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
    public class TweenManager
    {
        // ��ʱ�ĵ���
        private static TweenManager m_Instance = null;
        public static TweenManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TweenManager();
                }
                return m_Instance;
            }
        }

        private List<Tweener> m_TweenerList;

        public void Init()
        {
            m_TweenerList = new List<Tweener>();
        }

        public void DoUpdate(float dt)
        {
            for (int i = m_TweenerList.Count - 1; i >= 0; i--)
            {
                m_TweenerList[i].DoUpdate(dt);

                // ɾ������ɵĻ���
                if (m_TweenerList[i].IsComplete)
                {
                    m_TweenerList.RemoveAt(i);
                }
            }
        }

        // Transform�ƶ�
        public Tweener DOMove(Transform transform, Vector3 endPos, float duration)
        {
            var tweener = new MoveTweener(transform, endPos, duration);
            m_TweenerList.Add(tweener);
            return tweener;
        }

        // Transform����
        public Tweener DOScale(Transform transform, Vector3 endScale, float duration)
        {
            var tweener = new ScaleTweener(transform, endScale, duration);
            m_TweenerList.Add(tweener);
            return tweener;
        }

    }

}
