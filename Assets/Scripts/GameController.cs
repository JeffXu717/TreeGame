using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;

    void Awake()
    {
        instance = this;
        InfoMgr.Instance.Load();
    }

    void Update()
    {

    }
}


