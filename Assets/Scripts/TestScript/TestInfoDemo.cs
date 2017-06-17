using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using WTF.TreeGame.Info;
using System.Text;

namespace WTF.TreeGame.Test
{
    public class TestInfoDemo : MonoBehaviour
    {

        public Text text;

        // Use this for initialization
        void Start()
        {
            List<TestInfo> list = InfoMgr.Instance.TestInfoList;
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append("name : ");
                sb.Append(item.name);
                sb.Append("; gender : ");
                sb.Append(item.gender);
            }
            text.text = sb.ToString();
        }
    }
}

