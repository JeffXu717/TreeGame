using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler {
	
	public Animal itemAnimal;

	public static Action<Transform> Onbegindrag;
	public static Action<Transform,Transform>Onenddrag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnBeginDrag(PointerEventData eventData){

		if (eventData.button == PointerEventData.InputButton.Left) {

			Onbegindrag (transform);
		}

	}
	public void OnDrag (PointerEventData eventData){

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (eventData.pointerEnter == null) {
				Onenddrag (null,transform);
			} else {
				Onenddrag (eventData.pointerEnter.transform,transform);
			}
		}
	}
	public void SetLocalPosition(Vector2 position){

		transform.localPosition = position;
	}
	public void Hide(){

		gameObject.SetActive (false);
	}
	public void Show(){

		gameObject.SetActive (true);
	}
}
