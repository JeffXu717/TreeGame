using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureController : MonoBehaviour {

	private static ProcedureController instance;
	public static ProcedureController Instance{

		get{ return instance;
		}
	}
	
	public	Procedure currentProcedure;


	// Use this for initialization
	void Start () {
		instance = this;
		currentProcedure = GetComponent<MainProcedure> ();
		currentProcedure.OnProcedureEnter ();
	}
	
	// Update is called once per frame
	void Update () {
		currentProcedure.OnProcedureUpdate ();
	}

	public void ChangeProcedure(Procedure _procedure){

		currentProcedure.OnProcedureExit ();
		currentProcedure = _procedure;
		currentProcedure.OnProcedureEnter ();

	}
}
