using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcedure : Procedure {
	private static DayorNight currentTimeState;
	public static DayorNight CurrentTimeState{
		get{ 
			return currentTimeState;
		}
		set{ 
			if(value == DayorNight.Day)
			{
				
				Debug.Log ("白天");
			}
			else{
				Debug.Log ("黑夜");
			}
			currentTimeState = value;
		}
	}

	private Transform currentGameUI;
		
	private float dayNightTimeCounter;
	private float autoIncreaseTimeCounter;
	public int DayNightInterval = 5;
	public int autoIncreaseInterval = 1;

	public override void OnProcedureEnter ()
	{
		base.OnProcedureEnter ();
		dayNightTimeCounter = 0;
		autoIncreaseTimeCounter = 0;
		CurrentTimeState = DayorNight.Day;

		GameController.Instance.level = GameController.Instance.level + 1;
		InitGame ();

		currentGameUI.GetComponent<CanvasGroup> ().alpha = 1;
		currentGameUI.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
	public override void OnProcedureExit ()
	{
		base.OnProcedureExit ();
		currentGameUI.GetComponent<CanvasGroup> ().alpha = 0;
		currentGameUI.GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}
	public override void OnProcedureUpdate ()
	{
		base.OnProcedureUpdate ();





		dayNightTimeCounter += Time.deltaTime;
		autoIncreaseTimeCounter += Time.deltaTime;
		if (dayNightTimeCounter >= DayNightInterval) {
			changeTimeState ();
			dayNightTimeCounter = 0;
		}


		if (autoIncreaseTimeCounter >= autoIncreaseInterval) {
			GameController.Instance.Energy = GameController.Instance.Energy + GameController.Instance.TotalIncrease;
			autoIncreaseTimeCounter = 0;
		}

	}
	void changeTimeState(){
		if (CurrentTimeState == DayorNight.Day) {
			CurrentTimeState = DayorNight.Night;	
		} else {
			CurrentTimeState = DayorNight.Day;
		}
	}

	void InitGame(){

		currentGameUI = GameObject.Find ("Level1").transform;
	}
}
