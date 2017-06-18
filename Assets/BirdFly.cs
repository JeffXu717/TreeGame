using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DOLocalMoveX (700, 5).OnComplete (() => {
			Destroy (gameObject);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
