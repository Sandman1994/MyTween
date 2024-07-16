using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyTween;

public class Test : MonoBehaviour
{
    public Transform cube;
    public Button btnMove;
    public Button btnScale;
    public Dropdown dropdown;

    private bool m_Move;
    private bool m_Scale;

    private Tweener m_MoveTweener;
    private Tweener m_ScaleTweener;
    void Start()
    {
        TweenManager.Instance.Init();
        btnMove.onClick.AddListener(OnClickMove);
        btnScale.onClick.AddListener(OnClickScale);
    }

    void Update()
    {
        // 更新
        float dt = Time.deltaTime;
        TweenManager.Instance.DoUpdate(dt);

    }

    private void OnClickMove()
	{
        m_Move = !m_Move;

        // kill正在运行的缓动
        if (m_MoveTweener != null && !m_MoveTweener.IsComplete)
        {
            m_MoveTweener.Kill(true);
            m_MoveTweener = null;
        }

        var easeType = (EaseType)dropdown.value;
        m_MoveTweener = cube.DOMove(Vector3.right * (m_Move ? 1f : -1f), 1f).Ease(easeType).OnComplete(() => { Debug.Log("MoveComplete"); });
    }

    private void OnClickScale()
    {
        m_Scale = !m_Scale;

        // kill正在运行的缓动
        if (m_ScaleTweener != null && !m_ScaleTweener.IsComplete)
        {
            m_ScaleTweener.Kill(true);
            m_ScaleTweener = null;
        }

        var easeType = (EaseType)dropdown.value;
        m_ScaleTweener = cube.DOScale(Vector3.one * (m_Scale ? 0.5f : 2f), 1f).Ease(easeType).OnComplete(() => { Debug.Log("ScaleComplete"); });
    }
}
