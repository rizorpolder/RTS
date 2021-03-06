﻿namespace MyProject
{
    public abstract class BaseController
    {
        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(BaseObjectScene obj = null)
    {
        IsActive = true;
    }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        public abstract void MyUpdate();
        
    }
}
