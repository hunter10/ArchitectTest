using UnityEngine;
using System.Collections;

public enum eQB_PlayEndEventState
{
	None,

	EventStart,
	EventStartDelay,

	SecEventStart,
	SecEventStartDelay,

	QueenEvent,				// 퀸즈만의 상태값
	QueenEventDelay,		

	End,
	EndDelay,
}

public class QueensBounty_UI : SlotterParent 
{

	// Update is called once per frame
	override public void Update () 
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
		}
	}
}
