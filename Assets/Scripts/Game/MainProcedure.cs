using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcedure : Procedure 
{
	

	Transform currentGameUI;

	public override void OnProcedureEnter ()
	{
		base.OnProcedureEnter ();
	
		switch (GameController.Instance.level) {
		case Level.level1:
			if (GameController.Instance.Energy >= 1000) {
			//胜利
				currentGameUI = GameObject.Find("Level1WinUI").transform;
			} else {
            //失败
				currentGameUI = GameObject.Find("LoseUI").transform;
			}
			break;
		case Level.level2:
			if (GameController.Instance.Energy >= 2000) {
				//胜利
				currentGameUI = GameObject.Find("Level2WinUI").transform;
			} else {
				//失败
				currentGameUI = GameObject.Find("LoseUI").transform;
			}
			break;
		case Level.level3:
			if (GameController.Instance.Energy >= 3000) {
				//胜利
				currentGameUI = GameObject.Find("Level3WinUI").transform;
			} else {
				//失败
				currentGameUI = GameObject.Find("LoseUI").transform;
			}
			break;
		default:
			
			Debug.Log ("开始了");


			currentGameUI = GameObject.Find ("StartUI").transform;

			break;
		}
		currentGameUI.GetComponent<CanvasGroup> ().alpha = 1;
		currentGameUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
		currentGameUI.SetAsLastSibling ();
		currentGameUI.GetComponent<WTF.TreeGame.EffectComponent.GeneralShowEffect> ().StartEffect ();
	}
	public override void OnProcedureExit ()
	{
		currentGameUI.GetComponent<CanvasGroup> ().alpha = 0;
        currentGameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public override void OnProcedureUpdate ()
	{
		base.OnProcedureUpdate ();
	}


}
