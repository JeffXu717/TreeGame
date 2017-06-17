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

	}
	public override void OnProcedureExit ()
	{
		base.OnProcedureExit ();
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
}
