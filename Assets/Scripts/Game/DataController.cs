using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
	public static DataController Instance = null;

	public Dictionary<Level,List<int>> levelDict = new Dictionary<Level, List<int>>();
	// Use this for initialization
	void Start () {
		Instance = this;
		List<int> itemIDList = new List<int> ();
		itemIDList.Add (4);

		itemIDList.Add (6);

		levelDict.Add (Level.level1, itemIDList);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
