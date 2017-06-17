using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;
using WTF.TreeGame.Info;

public class InfoMgr : Singleton<InfoMgr> {

    private bool _bLoaded = false;

    //private List<TestInfo> _testInfoList = new List<TestInfo>();
    private Dictionary<int, AnimalInfoAnalized> _IDandAnimalInfoMap = new Dictionary<int, AnimalInfoAnalized>();

    //public List<TestInfo> TestInfoList { get { return _testInfoList; } }
    public Dictionary<int, AnimalInfoAnalized> IDandAnimalInfoMap { get { return _IDandAnimalInfoMap; } }

    public void Load()
    {
        if (_bLoaded) return;
        _bLoaded = true;

        //var strJson = Resources.Load<TextAsset>("Info/TeamMember").text;
        //_testInfoList = JsonReader.Deserialize<List<TestInfo>>(strJson);
        List<AnimalInfo> animalInfoList = new List<AnimalInfo>();
        var strJson = Resources.Load<TextAsset>("Info/Animal").text;
        animalInfoList = JsonReader.Deserialize<List<AnimalInfo>>(strJson);

        foreach (var item in animalInfoList)
        {
            AnimalInfoAnalized animalInfoAnalizedInstance = new AnimalInfoAnalized(item);

            animalInfoAnalizedInstance.species_id = _strToListInt(item.species_id); 
            animalInfoAnalizedInstance.species_relationship = _strToListInt(item.species_relationship); 
            animalInfoAnalizedInstance.black_species_id = _strToListInt(item.black_species_id); 
            animalInfoAnalizedInstance.black_species_relationship = _strToListInt(item.black_species_relationship);

            _IDandAnimalInfoMap.Add(item.id, animalInfoAnalizedInstance);
        }

    }

    private List<int> _strToListInt(string str)
    {
        List<int> tempIntList = new List<int>();

        string[] tempStrs = str.Split(',');
        int i;
        for (i = 0; i < tempStrs.Length; i++)
        {
            tempIntList.Add(int.Parse(tempStrs[i]));
        }
        return tempIntList;
    }

}
