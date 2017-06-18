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
		itemIDList.Add (1);
		itemIDList.Add (4);
		itemIDList.Add (10);
		itemIDList.Add (8);
		itemIDList.Add (15);
		levelDict.Add (Level.level1, itemIDList);
		List<int> itemIDList2 = new List<int> ();
		itemIDList2.Add (1);
		itemIDList2.Add (2);
		itemIDList2.Add (3);
		itemIDList2.Add (4);
		itemIDList2.Add (5);
		itemIDList2.Add (6);
		itemIDList2.Add (7);
		itemIDList2.Add (8);
		itemIDList2.Add (9);
		itemIDList2.Add (10);
		itemIDList2.Add (11);
		itemIDList2.Add (12);
		itemIDList2.Add (13);
		itemIDList2.Add (14);
		itemIDList2.Add (15);
		levelDict.Add (Level.level2, itemIDList2);
		List<int> itemIDList3 = new List<int> ();
		itemIDList3.Add (1);
		itemIDList3.Add (2);
		itemIDList3.Add (3);
		itemIDList3.Add (4);
		itemIDList3.Add (5);
		itemIDList3.Add (6);
		itemIDList3.Add (7);
		itemIDList3.Add (8);
		itemIDList3.Add (9);
		itemIDList3.Add (10);
		itemIDList3.Add (11);
		itemIDList3.Add (12);
		itemIDList3.Add (13);
		itemIDList3.Add (14);
		itemIDList3.Add (15);
		itemIDList3.Add (16);
		itemIDList3.Add (17);
		itemIDList3.Add (18);
		itemIDList3.Add (19);
		itemIDList3.Add (20);
		itemIDList3.Add (21);
		itemIDList3.Add (22);
		itemIDList3.Add (23);
		itemIDList3.Add (24);
		itemIDList3.Add (25);
		itemIDList3.Add (26);
		itemIDList3.Add (27);
		itemIDList3.Add (28);
		itemIDList3.Add (29);
		itemIDList3.Add (30);
		levelDict.Add (Level.level3, itemIDList3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
