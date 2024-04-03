using System.Collections.Generic;
using UnityEngine;

namespace JoyJab.TabSystem {
    public class TabSystemModular : TabSystem {
        
        public override int TotalTabs => _tabs.Count;
        [SerializeReference, SubclassSelector] private List<IOnOffHandler> _tabs = new();

        protected override void SwitchToTabInternal(int activeTab) {
            for (int i = 0; i < _tabs.Count; i++) {
                _tabs[i]?.SetActive(i == activeTab);
            }
        }
    }
}