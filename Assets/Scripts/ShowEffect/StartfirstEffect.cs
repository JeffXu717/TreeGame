using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace WTF.TreeGame.EffectComponent
{
public class StartfirstEffect : GeneralShowEffect {

        private Image _leftLine;
        private Image _rightLine;
        private Transform _transTree;

		public override void StartEffect()
		{
            _leftLine = transform.Find("LeftLine").GetComponent<Image>();
            _rightLine = transform.Find("RightLine").GetComponent<Image>();
            _transTree = transform.Find("Tree");

            StartCoroutine(_fillLineImage(_leftLine, 3f));
            StartCoroutine(_fillLineImage(_rightLine, 3f));

            Tween tempTween = _transTree.DOMoveY(65, 3f).SetEase(Ease.InCirc).SetRelative() ;

            tempTween.OnComplete(() =>
            {
                transform.Find("Text1").GetComponent<Text>().DOFade(1, 2).OnComplete(() =>
                {
                    transform.Find("Text1").DOLocalMoveY(13, 2);
                });
                transform.Find("Text2").GetComponent<Text>().DOFade(1, 2).SetDelay(3.8f);
                StartCoroutine(startgameIE());
            });

		}

        private IEnumerator _fillLineImage(Image image, float fPreriod)
        {
            image.fillAmount = 0;
            float rate = 1 / fPreriod;
            float t = 0;
            while (t < 1)
            {
                image.fillAmount = Mathf.Lerp(0, 1f, t);
                t += Time.deltaTime;
                yield return null;
            }
        }
	
		IEnumerator startgameIE(){
			yield return new WaitForSeconds (8f);

			ProcedureController.Instance.ChangeProcedure (GameObject.Find("GameController").GetComponent<GameProcedure>());

		}
	// Update is called once per frame
	void Update () {
		
	}
}
}
