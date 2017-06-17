using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace WTF.TreeGame.EffectComponent
{
    public class BreatheEffect : GeneralShowEffect{

        //private Animator _animator;
        private Sequence s; 

        public void Start()
        {
            StartEffect();
        }

        public override void StartEffect()
        {
            //_animator = GetComponent<Animator>();
            //Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            //_animator.SetTrigger("Start");
            if (s == null)
            {
                s = DOTween.Sequence();
                Vector3 tempScale = transform.localScale;
                s.Append(transform.DOScale(tempScale * 1.05f, 3.3f).SetEase(Ease.OutQuart));
                s.Append(transform.DOScale(tempScale, 2.7f));
                s.SetLoops(-1);
            }
            else
            {
                s.Restart(); 
            }


        }

        public override void PauseEffect()
        {
            //Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            //_animator.SetTrigger("Pause");
            if (s != null && s.IsPlaying())
                s.Pause();
        }

        public override void StopEffect()
        {
            //Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            //_animator.SetTrigger("Stop");
            if (s != null && s.IsPlaying())
                s.Kill();
        }
    }
}

