using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {


	public static GameController Instance;


	public  Level level = Level.zero;
	[HideInInspector]
	public  int TotalIncrease 
	{
		get{ 
			int temp = 1;
			if (currentAnimalDict.Count == 0) {
				return temp;
			} else {
				foreach (KeyValuePair<int,Animal> anm in currentAnimalDict) {
					temp += anm.Value.growth;
				}
				return temp;
			}
		}
	}
	public Dictionary<int,Animal> currentAnimalDict = new Dictionary<int, Animal> ();
	[HideInInspector]
	public Slider slider1;
	[HideInInspector]
	public Slider slider2;
	private int energy = 0;
	public  int Energy{
		
		get{ 
			return energy;
		}
		set{ 
			energy = value;
			slider1.value = ((float)energy%1000)/1000;
			slider2.value =((float)energy%1000)/1000;
			Debug.Log (energy);
			Debug.Log (GameController.Instance.level);
			switch (level) {
			case Level.level1:
				if (energy < 0 || energy >= 1000) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}	
				break;
			case Level.level2:
				if (energy <= 1000 || energy >= 2000) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}	
				break;
			case Level.level3:
				if (energy <= 2000 || energy >= 3000) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}
				break;
			}
		}

	}

	// Use this for initialization
	void Start () {
		Instance = this;
		InfoMgr.Instance.Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
