using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragController : MonoBehaviour {

	public static DragController Instance;
	public DragItem tempDragitem;


	void Awake(){
		
		Instance = this;

		DragItem.Onbegindrag += DragItem_Onbegindrag;
		DragItem.Onenddrag += DragItem_Onenddrag;
	
		tempDragitem.Hide ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (GameObject.Find ("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
		tempDragitem.SetLocalPosition (position);
	}

	void DragItem_Onbegindrag(Transform _tsfrom){
		tempDragitem.Show ();
		tempDragitem.itemAnimal = _tsfrom.GetComponent<DragItem> ().itemAnimal;
		tempDragitem.GetComponent<Image> ().color = _tsfrom.GetComponent<Image> ().color;
		
	}
	void DragItem_Onenddrag(Transform _tsin,Transform _tsfrom){
		tempDragitem.Hide ();
	

		if (_tsin.tag == "Slot") {
			GameObject _dragitem = Instantiate ((GameObject)Resources.Load ("DragItem"), _tsin, false);
			_dragitem.tag = "Out";
			_dragitem.GetComponent<DragItem> ().itemAnimal = _tsfrom.GetComponent<DragItem> ().itemAnimal;
			_dragitem.GetComponent<Image> ().overrideSprite = _tsfrom.GetComponent<Image> ().overrideSprite;

			Destroy (_tsfrom.gameObject);
			GameController.Instance.currentAnimalDict.Remove (_tsfrom.GetComponent<DragItem> ().itemAnimal.id);


		} else if (_tsin.tag == "Gslot"&&_tsfrom.tag =="Out") {

			if (_tsin.childCount == 0) {
				if (_tsfrom.GetComponent<DragItem> ().itemAnimal.location == 1) {

					GameObject _dragitem = Instantiate ((GameObject)Resources.Load ("DragItem"), _tsin, false);
					_dragitem.tag = "In";
					_dragitem.GetComponent<DragItem> ().itemAnimal = _tsfrom.GetComponent<DragItem> ().itemAnimal;
					_dragitem.GetComponent<Image> ().overrideSprite = _tsfrom.GetComponent<Image> ().overrideSprite;
					GameController.Instance.currentAnimalDict.Add (_tsfrom.GetComponent<DragItem> ().itemAnimal.id, _dragitem.GetComponent<DragItem> ().itemAnimal);
					Destroy (_tsfrom.gameObject);
				}
			} 
		
		} else if (_tsin.tag == "Uslot"&&_tsfrom.tag =="Out") {
			if (_tsin.childCount == 0) {

				if (_tsfrom.GetComponent<DragItem> ().itemAnimal.location == 2) {

					GameObject _dragitem = Instantiate ((GameObject)Resources.Load ("DragItem"), _tsin, false);
					_dragitem.tag = "In";
					_dragitem.GetComponent<DragItem> ().itemAnimal = _tsfrom.GetComponent<DragItem> ().itemAnimal;
					_dragitem.GetComponent<Image> ().overrideSprite = _tsfrom.GetComponent<Image> ().overrideSprite;
					GameController.Instance.currentAnimalDict.Add (_tsfrom.GetComponent<DragItem> ().itemAnimal.id, _dragitem.GetComponent<DragItem> ().itemAnimal);
					Destroy (_tsfrom.gameObject);
				}

			}

		}else if(_tsin.tag=="In"&&_tsfrom.tag =="Out"){
			Animal _temp;
			_temp = _tsfrom.GetComponent<DragItem> ().itemAnimal;
			_tsfrom.GetComponent<DragItem> ().itemAnimal = _tsin.GetComponent<DragItem> ().itemAnimal;
			_tsin.GetComponent<DragItem> ().itemAnimal = _temp;
		}

		else if(_tsin.tag=="Out"&&_tsfrom.tag =="In"){
			Animal _temp;
			_temp = _tsfrom.GetComponent<DragItem> ().itemAnimal;
			_tsfrom.GetComponent<DragItem> ().itemAnimal = _tsin.GetComponent<DragItem> ().itemAnimal;
			_tsin.GetComponent<DragItem> ().itemAnimal = _temp;
		}
			



	}
}
