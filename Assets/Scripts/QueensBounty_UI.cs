using UnityEngine;
using System.Collections;

public enum eQB_PlayEndEventState
{
	None = ePlayEndEventState.None,

	EventStart = ePlayEndEventState.EventStart,
	EventStartDelay = ePlayEndEventState.EventStartDelay,

	SecEventStart = ePlayEndEventState.SecEventStart,
	SecEventStartDelay = ePlayEndEventState.SecEventStartDelay,

	End = ePlayEndEventState.End,
	EndDelay = ePlayEndEventState.EndDelay,

    QueenEvent,             // 퀸즈만의 상태값
    QueenEventDelay,
}

public class QueensBounty_UI : SlotterParent 
{
    public float m_fQBEventDelayTime = 3.0f;

    override public void Awake()
    {
        Debug.Log("QB Awake!!");
        SetPlayEndEventState((int)eQB_PlayEndEventState.EventStart);
    }

    // Update is called once per frame
    override public void Update () 
	{
		switch ((eQB_PlayEndEventState)GetPlayEndEventState()) 
		{
		case eQB_PlayEndEventState.None:				
			break;

		case eQB_PlayEndEventState.EventStart:
			UpdateEventStart ();
			break;

		case eQB_PlayEndEventState.EventStartDelay:
			UpdateEventStartDelay ();
			break;

        case eQB_PlayEndEventState.QueenEvent:
            UpdateQueenEvent();
            break;

        case eQB_PlayEndEventState.QueenEventDelay:
            UpdateQueenEventDelay();
            break;

        case eQB_PlayEndEventState.End:
            UpdateEnd();
            break;

        case eQB_PlayEndEventState.EndDelay:
            UpdateEndDelay();
            break;
        }
	}




    override public void UpdateEventStart()
    {
        Debug.Log("QB UpdateEventStart...");
        SetPlayEndEventState((int)eQB_PlayEndEventState.EventStartDelay);
    }

    override public void UpdateEventStartDelay()
    {
        m_fUpdateTime += Time.deltaTime;
        if (m_fUpdateTime >= m_fEventStartDelayTime)
        {
            Debug.Log("QB UpdateEventStartDelay...");
            m_fUpdateTime = 0.0f;
            SetPlayEndEventState((int)eQB_PlayEndEventState.QueenEvent);
        }
    }





    public void UpdateQueenEvent()
    {
        Debug.Log("QB QueenEvent...");
        SetPlayEndEventState((int)eQB_PlayEndEventState.QueenEventDelay);
    }

    public void UpdateQueenEventDelay()
    {
        m_fUpdateTime += Time.deltaTime;
        if (m_fUpdateTime >= m_fQBEventDelayTime)
        {
            Debug.Log("QB QueenEventDelay...");
            m_fUpdateTime = 0.0f;
            SetPlayEndEventState((int)eQB_PlayEndEventState.End);
        }
    }





    override public void UpdateEnd()
    {
        Debug.Log("QB UpdateEnd...");
        SetPlayEndEventState((int)eQB_PlayEndEventState.EndDelay);
    }

    override public void UpdateEndDelay()
    {
        m_fUpdateTime += Time.deltaTime;
        if (m_fUpdateTime >= m_fEndDelayTime)
        {
            Debug.Log("QB UpdateEndDelay...");
            m_fUpdateTime = 0.0f;
            SetPlayEndEventState((int)eQB_PlayEndEventState.None);
        }
    }
}
