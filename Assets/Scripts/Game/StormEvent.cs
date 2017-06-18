using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StormEvent : EventClass {

	public int enviroment = -10;

	public List<Transform> fireList = new List<Transform> ();
	public GameObject water;
	public float WaterTimeInterval =0.5f;
	private float waterTimeTemp =0;
	private bool isRain = false;
	public override void EnterEvent(){

		isTrigger = true;
		ProcedureController.Instance.currentProcedure.isPause = true;
		transform.GetComponent<CanvasGroup> ().alpha = 1;
		transform.GetComponent<CanvasGroup>().blocksRaycasts=true;
		transform.Find("EventUI").GetComponent<CanvasGroup> ().alpha = 1;
		transform.Find("EventUI").GetComponent<CanvasGroup>().blocksRaycasts=true;
		foreach (Fire fire in transform.GetComponentsInChildren<Fire>()) {
			fireList.Add (fire.transform);

		}
		StartCoroutine (resumeGameIE ());

	}
	IEnumerator resumeGameIE(){
		yield return new WaitForSeconds (5);



		transform.Find("EventUI").GetComponent<CanvasGroup>().blocksRaycasts=false;
		transform.Find ("EventUI").GetComponent<CanvasGroup> ().DOFade (0, 1);

		ProcedureController.Instance.currentProcedure.isPause = false;
		GameController.Instance.enviromentIncrease =enviroment;
		isRain = true;

	}






	public override void ExitEvent(){
		isRain = false;
		transform.GetComponent<CanvasGroup> ().alpha = 0;
		transform.GetComponent<CanvasGroup>().blocksRaycasts=false;

	}

	void Update(){
		if (!isRain) {
			return;
		}

		waterTimeTemp += Time.deltaTime;
		if (waterTimeTemp > WaterTimeInterval) {
			waterTimeTemp = 0;
			GameObject _water =	Instantiate (water, transform, false);
			float _t = Random.Range (-450, 450);
			_water.transform.localPosition = new Vector3 (_t, 410, 0);
			_water.transform.localScale = Vector3.one;
			_water.GetComponent<Button> ().onClick.AddListener (OnWaterClicked);

		}

	}
	public void OnWaterClicked(){
		
		Transform temp = fireList [0];
		fireList.RemoveAt (0);
		temp.DOScale (0, 1.5f).SetEase (Ease.InBack).OnComplete (() => {
			Destroy (temp.gameObject);
		});

		if (fireList.Count <= 0) {
			GameController.Instance.enviromentIncrease = 0;
			ExitEvent ();
		}
	}
}
