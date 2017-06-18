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
	[HideInInspector]
	public int imageNumber = 999;
	[HideInInspector]
	public Image image;
	[HideInInspector]
	public Text numberText;

    private UIEffect _uiEffect;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
        _uiEffect = GetComponent<UIEffect>();

		numberText = transform.Find ("Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (tag == "Out")
            return;

        if (numberText.text != itemAnimal.number.ToString ()) {
            
            int selfNumber = int.Parse(numberText.text);
            int animalNumber = int.Parse(itemAnimal.number.ToString());
            _uiEffect.enabled = true;

            if (selfNumber > animalNumber)
                _uiEffect.shadowColor = Color.red;
            else
                _uiEffect.shadowColor = Color.green;

			numberText.text = itemAnimal.number.ToString ();
			if (itemAnimal.number <= 0) {
				GameController.Instance.currentAnimalDict.Remove (itemAnimal.id);
				Destroy (gameObject);
			}

		}
		if (imageNumber != itemAnimal.picture_id) 
		{
			imageNumber = itemAnimal.picture_id;


			Texture2D texture = Resources.Load<Texture2D>("Image/" + imageNumber);
			Sprite sprite = Sprite.Create(
				texture,
				new Rect(0, 0, texture.width, texture.height),
				Vector2.one);
			image.overrideSprite = sprite;
		}
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
