using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    abstract public class Skill
    {
        protected bool isActive;

        abstract public void Run();


        virtual protected void coolDown() { }
        virtual protected bool isActivated() { return true; }
    }

    public class Skill1 : Skill
    {
        public Skill1()
        {
            isActive = true;
        }

        override public void Run()
        {

        }


        override protected void coolDown()
        {
        }

        override protected bool isActivated()
        {
            if (!base.isActivated()) { return false; }

            return true;
        }
    }

}
