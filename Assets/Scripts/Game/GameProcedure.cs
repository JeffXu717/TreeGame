﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameProcedure : Procedure {
	private static DayorNight currentTimeState;
	public static DayorNight CurrentTimeState{
		get{ 
			return currentTimeState;
		}
		set{ 
			if(value == DayorNight.Day)
			{
				changeToDay ();

				Debug.Log ("白天");
			}
			else{
				changeToNight ();
				Debug.Log ("黑夜");
			}
			currentTimeState = value;
		}
	}

	public static  Transform currentGameUI;

	private float dayNightTimeCounter;
	private float autoIncreaseTimeCounter;
	public int DayNightInterval = 5;
	public float autoIncreaseInterval = 1;

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

		GameController.Instance.enviromentIncrease = 0;
	}
	public override void OnProcedureUpdate ()
	{
		if (isPause) {
			return;
		}

		base.OnProcedureUpdate ();

		dayNightTimeCounter += Time.deltaTime;
		autoIncreaseTimeCounter += Time.deltaTime;
		if (dayNightTimeCounter >= DayNightInterval) {
			changeTimeState ();
			dayNightTimeCounter = 0;
		}


		if (autoIncreaseTimeCounter >= autoIncreaseInterval) {
			
			if (GameController.Instance.currentAnimalDict.Count > 1) {
				foreach (KeyValuePair<int,Animal> kp in GameController.Instance.currentAnimalDict) {

					if (currentTimeState == DayorNight.Day) {
						
						for (int i = 0; i < kp.Value.species_id.Count; i++) {

							if (GameController.Instance.currentAnimalDict.ContainsKey (kp.Value.species_id[i])) {
								
								kp.Value.number = kp.Value.number + kp.Value.species_relationship [i];
							}

						}

					}
					else{
						for (int i = 0; i < kp.Value.black_species_id.Count; i++) {
							if (GameController.Instance.currentAnimalDict.ContainsKey (kp.Value.black_species_id[i])) {
								kp.Value.number = kp.Value.number + kp.Value.black_species_relationship [i];
							}

						}
					}
				}
			}



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

		currentGameUI.GetComponent<WTF.TreeGame.EffectComponent.GeneralShowEffect> ().StartEffect ();


		GameController.Instance.slider1 = currentGameUI.Find("Line").Find ("Slider1").GetComponent<Slider> ();
		GameController.Instance.slider2 = currentGameUI.Find("Line").Find ("Slider2").GetComponent<Slider> ();

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
		animal.growth = animalInfo.growth;
	}
	static void  changeToDay(){
		GameObject.Find ("BackImage").GetComponent<Image> ().DOColor(Color.white,2.5f);
		foreach (Slot ts in FindObjectsOfType<Slot>()) {
			ts.GetComponent<Image>().DOColor(Color.white,2.5f);
			ts.transform.Find("Image").GetComponent<Image>().DOColor(Color.black,2.5f);
		}
		foreach (DragItem ts in FindObjectsOfType<DragItem>()) {
			ts.GetComponent<Image>().DOColor(Color.black,2.5f);

		}
		if (currentGameUI == null)
			return;
		currentGameUI.Find ("Tree").GetComponent<Image> ().DOColor(Color.black,2.5f);
	
	}
	static void changeToNight(){
		GameObject.Find ("BackImage").GetComponent<Image> ().DOColor(Color.black,2.5f);
		foreach (Slot ts in FindObjectsOfType<Slot>()) {
			ts.GetComponent<Image>().DOColor(Color.black,2.5f);
			ts.transform.Find("Image").GetComponent<Image>().DOColor(Color.white,2.5f);
		}
		foreach (DragItem ts in FindObjectsOfType<DragItem>()) {
			ts.GetComponent<Image>().DOColor(Color.white,2.5f);
		}
		if (currentGameUI == null)
			return;
		currentGameUI.Find ("Tree").GetComponent<Image> ().DOColor(Color.white,2.5f);
	}

}
