using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace WTF.TreeGame.EffectComponent
{
public class StartfirstEffect : GeneralShowEffect {

		public override void StartEffect()
		{
			transform.Find ("Text1").GetComponent<Text> ().DOFade (1, 2).OnComplete (() => {
				transform.Find ("Text1").DOLocalMoveY (13, 2);
			});
			transform.Find ("Text2").GetComponent<Text> ().DOFade (1, 2).SetDelay (3.8f);
			StartCoroutine (startgameIE ());

		}

	// Use this for initialization
	void Start () {
			
	}
	
		IEnumerator startgameIE(){
			yield return new WaitForSeconds (10);

			ProcedureController.Instance.ChangeProcedure (GameObject.Find("GameController").GetComponent<GameProcedure>());

		}
	// Update is called once per frame
	void Update () {
		
	}
}
}
