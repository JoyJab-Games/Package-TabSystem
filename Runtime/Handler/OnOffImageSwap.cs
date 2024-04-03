using System;
using UnityEngine;
using UnityEngine.UI;

namespace JoyJab.TabSystem {
    
    [Serializable]
    public class OnOffImageSwap : IOnOffHandler {
        
        [SerializeField] private Image _target;
        [SerializeField] private Sprite _onSprite;
        [SerializeField] private Sprite _offSprite;
        
        public void Activate() {
            if(_target != null) _target.sprite = _onSprite;
        }

        public void Deactivate() {
            if(_target != null) _target.sprite = _offSprite;
        }
    }
}