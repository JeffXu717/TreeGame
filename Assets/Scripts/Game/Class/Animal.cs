using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animal  {
	
	public int id;
	public string name;
	public int picture_id;
	public int number;
	public int growth;
	public int location;
	public List<int> species_id;
	public List<int> species_relationship;
	public List<int> black_species_id;
	public List<int> black_species_relationship;

}
