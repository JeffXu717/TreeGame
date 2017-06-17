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

		Debug.Log (_tsin.tag);
		if (_tsin.tag != "Slot") {
			Debug.Log ("hihihihihi");
			return;

		}

		if (_tsin.childCount == 0) {

			GameObject _dragitem = Instantiate((GameObject)Resources.Load ("DragItem"),_tsin,false);
			_dragitem.GetComponent<DragItem>().itemAnimal = _tsfrom.GetComponent<DragItem> ().itemAnimal;
			_dragitem.GetComponent<Image> ().color = _tsfrom.GetComponent<Image> ().color;

			GameController.Instance.currentAnimalDict.Add (_tsfrom.GetComponent<DragItem> ().itemAnimal.Name, _tsfrom.GetComponent<DragItem> ().itemAnimal);

		} else {
		
		}

	}
}
