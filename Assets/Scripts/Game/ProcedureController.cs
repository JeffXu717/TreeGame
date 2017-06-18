using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureController : MonoBehaviour {

	private static ProcedureController instance;
	public static ProcedureController Instance{

		get{ return instance;
		}
	}
	
	Procedure currentProcedure;


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

    public void ChangeProcedureFromCover()
    {
        //JeffXu
        //通过封面进入第一关的动画阶段
        GameController.Instance.IsFromCover = true;
        ChangeProcedure (GameObject.Find("GameController").GetComponent<MainProcedure>());
    }
}
