using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;
using WTF.TreeGame.Info;

public class InfoMgr : Singleton<InfoMgr> {

    private bool _bLoaded = false;

    private List<TestInfo> _testInfoList = new List<TestInfo>();

    public List<TestInfo> TestInfoList { get { return _testInfoList; } }

    public void Load()
    {
        if (_bLoaded) return;
        _bLoaded = true;

        var strJson = Resources.Load<TextAsset>("Info/TeamMember").text;
        _testInfoList = JsonReader.Deserialize<List<TestInfo>>(strJson);
        Debug.Log(_testInfoList.Count);
    }

}
