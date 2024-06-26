﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace JoyJab.TabSystem {
    
    [Serializable]
    public class OnOffEvent : IOnOffHandler {
        
        [SerializeField] private UnityEvent _onActivate = new();
        [SerializeField] private UnityEvent _onDeactivate = new();

        public void Activate() => _onActivate.Invoke();
        public void Deactivate() => _onDeactivate.Invoke();
    }
}