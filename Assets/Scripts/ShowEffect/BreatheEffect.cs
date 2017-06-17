using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WTF.TreeGame.EffectComponent
{
    public class BreatheEffect : GeneralShowEffect{

        private Animator _animator;

        public override void StartEffect()
        {
            _animator = GetComponent<Animator>();
            Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            _animator.SetTrigger("Start");
        }

        public override void PauseEffect()
        {
            Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            _animator.SetTrigger("Pause");
        }

        public override void StopEffect()
        {
            Debug.Assert(_animator != null, "Error: BreatheEffect lacks of Animator..");
            _animator.SetTrigger("Stop");
        }
    }
}

