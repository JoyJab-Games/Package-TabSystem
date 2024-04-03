namespace JoyJab.TabSystem {
    public class TabSystemChildren : TabSystem {
        public override int TotalTabs => transform.childCount;
        protected override void SwitchToTabInternal(int activeTab) {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(i == activeTab);
            }
        }
    }
}