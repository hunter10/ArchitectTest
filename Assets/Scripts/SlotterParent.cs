using UnityEngine;
using System.Collections;

public enum ePlayEndEventState
{
	None,

	EventStart,
	EventStartDelay,

	SecEventStart,
	SecEventStartDelay,

	End,
	EndDelay,
}

public class SlotterParent : MonoBehaviour {

	[HideInInspector]
	public int m_ePlayEndEventState = (int)ePlayEndEventState.None;

	[HideInInspector]
	public float m_fUpdateTime = 0.0f;

	public float m_fEventStartDelayTime = 1.0f;
	public float m_fEndDelayTime = 2.0f;



	virtual public void Awake()
	{
		Debug.Log ("Awake!!");
        SetPlayEndEventState((int)ePlayEndEventState.EventStart);
    }

	virtual public int GetPlayEndEventState()
	{
		return m_ePlayEndEventState;
	}

	virtual public void SetPlayEndEventState(int iEventState)
	{
		m_ePlayEndEventState = iEventState;
	}

	virtual public void Update()
	{
		switch ((ePlayEndEventState)GetPlayEndEventState()) 
		{
			case ePlayEndEventState.None:				
				break;

			case ePlayEndEventState.EventStart:
				UpdateEventStart ();
				break;

			case ePlayEndEventState.EventStartDelay:
				UpdateEventStartDelay ();
				break;

			/*
			case ePlayEndEventState.SecEventStart:
				UpdateSecEventStart ();
				break;

			case ePlayEndEventState.SecEventStartDelay:
				UpdateSecEventStartDelay ();
				break;
			*/

			case ePlayEndEventState.End:
				UpdateEnd ();
				break;

			case ePlayEndEventState.EndDelay:
				UpdateEndDelay ();
				break;
		}
	}

	virtual public void UpdateEventStart()
	{
		Debug.Log ("UpdateEventStart...");
		SetPlayEndEventState ((int)ePlayEndEventState.EventStartDelay);
	}

	virtual public void UpdateEventStartDelay()
	{
		m_fUpdateTime += Time.deltaTime;
		if (m_fUpdateTime >= m_fEventStartDelayTime) 
		{
			Debug.Log ("UpdateEventStartDelay...");
			m_fUpdateTime = 0.0f;
			SetPlayEndEventState ((int)ePlayEndEventState.End);
		}
	}

	virtual public void UpdateEnd()
	{
		Debug.Log ("UpdateEnd...");
		SetPlayEndEventState ((int)ePlayEndEventState.EndDelay);
	}

	virtual public void UpdateEndDelay()
	{
		m_fUpdateTime += Time.deltaTime;
		if (m_fUpdateTime >= m_fEndDelayTime) 
		{
			Debug.Log ("UpdateEndDelay...");
			m_fUpdateTime = 0.0f;
            SetPlayEndEventState((int)ePlayEndEventState.None);
        }
	}

}
