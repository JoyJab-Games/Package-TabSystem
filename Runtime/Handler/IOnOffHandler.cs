﻿namespace JoyJab.TabSystem {
    public interface IOnOffHandler {

        public void SetActive(bool active) {
            if(active) Activate();
            else Deactivate();
        }
        
        public void Activate();
        public void Deactivate();
    }
}