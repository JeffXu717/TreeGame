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

		GameController.Instance.currentAnimalDict.Clear ();

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
		if (GameController.Instance.currentAnimalDict.Count > 1) {
			

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

		currentGameUI = GameObject.Find (GameController.Instance.level.ToString()).transform;

		Transform itemList = currentGameUI.transform.Find ("Scroll").Find ("AnimalList");
		List<int> _itemlist;
		DataController.Instance.levelDict.TryGetValue (GameController.Instance.level,out _itemlist);
		foreach (int id in _itemlist) {
			GameObject _dragitem = Instantiate ((GameObject)Resources.Load ("DragItem"),itemList, false);
			_dragitem.tag = "Out";

			WTF.TreeGame.Info.AnimalInfoAnalized aia;
			InfoMgr.Instance.IDandAnimalInfoMap.TryGetValue (id, out aia);

			InitInfo(_dragitem.GetComponent<DragItem> ().itemAnimal,aia);
		}





	}

	void InitInfo(Animal animal,WTF.TreeGame.Info.AnimalInfoAnalized animalInfo){
		animal.name = animalInfo.name;
		animal.id = animalInfo.id;
		animal.picture_id =animalInfo.picture_id;
		animal.number = animalInfo.number;
		animal.location = animalInfo.location;
		animal.species_id = animalInfo.species_id;
		animal.species_relationship = animalInfo.species_relationship;
		animal.black_species_id = animalInfo.black_species_id;
		animal.black_species_relationship = animalInfo.black_species_relationship;
	}
}
