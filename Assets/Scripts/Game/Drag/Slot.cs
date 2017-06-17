using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler{
	
	public void OnDrop(PointerEventData data)
	{
		if (data.pointerDrag != null)
		{
			Debug.Log ("Dropped object was: "  + data.pointerDrag);
		}
	}
}
