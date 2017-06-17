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
				foreach (KeyValuePair<string,Animal> anm in currentAnimalDict) {
					temp += anm.Value.Influence;
				}
				return temp;
			}
		}
	}
	public Dictionary<string,Animal> currentAnimalDict = new Dictionary<string, Animal> ();

	private Slider slider;
	private int energy = 0;
	public  int Energy{
		
		get{ 
			return energy;
		}
		set{ 
			energy = value;
			slider.value  = (float)energy/100;
			Debug.Log (energy);

			switch (level) {
			case Level.one:
				if (energy < 0 || energy >= 100) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}	
				break;
			case Level.two:
				if (energy <= 100 || energy >= 200) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}	
				break;
			case Level.three:
				if (energy <= 200 || energy >= 300) {
					ProcedureController.Instance.ChangeProcedure (GetComponent<MainProcedure>());
				}
				break;
			}
		}

	}

	// Use this for initialization
	void Start () {
		Instance = this;
		slider = GameObject.Find ("Slider").GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
