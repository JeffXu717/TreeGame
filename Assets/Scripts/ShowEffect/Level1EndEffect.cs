using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace WTF.TreeGame.EffectComponent
{
    public class Level1EndEffect : GeneralShowEffect
    {

        public override void StartEffect()
        {
            
            transform.Find("Text2").GetComponent<Text>().DOFade(1, 2).SetDelay(3.8f);
            StartCoroutine(startgameIE());
        }

        IEnumerator startgameIE()
        {
            yield return new WaitForSeconds(8f);

            ProcedureController.Instance.ChangeProcedure(GameObject.Find("GameController").GetComponent<GameProcedure>());

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
