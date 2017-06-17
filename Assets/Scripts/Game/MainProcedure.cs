﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcedure : Procedure 
{
	ProcedureController PC;

	Transform currentUI;

	public override void OnProcedureEnter ()
	{
		base.OnProcedureEnter ();
		Debug.Log (GameController.Instance.level);
		switch (GameController.Instance.level) {
		case Level.level1:
			if (GameController.Instance.Energy >= 100) {
			//胜利
			} else {
            //失败
			}
			break;
		case Level.level2:
			if (GameController.Instance.Energy >= 200) {
				//胜利
			} else {
				//失败
			}
			break;
		case Level.level3:
			if (GameController.Instance.Energy >= 300) {
				//胜利
			} else {
				//失败
			}
			break;
		default:
			
			Debug.Log ("开始了");
			PC = GetComponent<ProcedureController> ();

			currentUI = GameObject.Find ("StartUI").transform;

			break;
		}
		currentUI.GetComponent<CanvasGroup> ().alpha = 1;
		currentUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
		currentUI.SetAsLastSibling ();
	}
	public override void OnProcedureExit ()
	{
		currentUI.GetComponent<CanvasGroup> ().alpha = 0;
        currentUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public override void OnProcedureUpdate ()
	{
		base.OnProcedureUpdate ();
	}

	public void StartGame(){
		PC.ChangeProcedure (GetComponent<GameProcedure> ());

	}

}
