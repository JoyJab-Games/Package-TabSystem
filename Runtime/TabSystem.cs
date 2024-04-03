using System;
using System.Collections.Generic;
using UnityEngine;

namespace JoyJab.TabSystem {

    public abstract class TabSystem : MonoBehaviour {

        public event Action<int> OnTabActive;

        public abstract int TotalTabs { get; }
        
        public int ActiveTab => _activeTab;
        [SerializeField] protected int _activeTab;
        
        [SerializeField] private int _firstActive;
        [SerializeField] private bool _resetOnEnable;

        private void Start() => SwitchToTab(_firstActive);
        private void OnEnable() {
            if(_resetOnEnable) SwitchToTab(_firstActive);
        }
        
        private void OnValidate() {
            _firstActive = Mathf.Clamp(_firstActive, 0, TotalTabs - 1);
            _activeTab = Mathf.Clamp(_activeTab, 0, TotalTabs - 1);
            SwitchToTabInternal(_activeTab);
        }

        protected abstract void SwitchToTabInternal(int activeTab);

        public void SwitchToTab(int target) {
            
            // test bounds
            if (target < 0 || TotalTabs <= target) {
                Debug.LogWarning("Trying to Switch to not existing Tab");
                return;
            }
            
            _activeTab = target;
            SwitchToTabInternal(target);
            OnTabActive?.Invoke(_activeTab);
        }

        public void SwitchToNextTab() => SwitchToTab(_activeTab + 1);
        public void SwitchToPreviousTab() => SwitchToTab(_activeTab - 1);
    }

}