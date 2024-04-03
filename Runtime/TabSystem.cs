using System;
using System.Collections.Generic;
using UnityEngine;

namespace JoyJab.TabSystem {

    public class TabSystem : MonoBehaviour {

        public event Action<int> OnTabActive;

        public int TotalTabs => _tabs.Count;
        [SerializeReference, SubclassSelector] private List<IOnOffHandler> _tabs = new();
        
        public int ActiveTab => _activeTab;
        [SerializeField] protected int _activeTab;
        
        [SerializeField] private int _firstActive;
        [SerializeField] private bool _resetOnEnable;

        private void Start() => SwitchToTab(_firstActive);
        private void OnEnable() {
            if(_resetOnEnable) SwitchToTab(_firstActive);
        }

        private void OnValidate() {
            _firstActive = Mathf.Clamp(_firstActive, 0, _tabs.Count - 1);
            _activeTab = Mathf.Clamp(_activeTab, 0, _tabs.Count - 1);
            SwitchToTabInternal(_activeTab);
        }

        private void SwitchToTabInternal(int activeTab) {
            for (int i = 0; i < _tabs.Count; i++) {
                _tabs[i]?.SetActive(i == activeTab);
            }
        }

        public void SwitchToTab(int target) {
            
            // test bounds
            if (target < 0 || _tabs.Count <= target) {
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