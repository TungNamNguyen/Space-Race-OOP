using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class FallingObjectmanager
    {
        private List<FallingObject> fallingobjectlist;
        private int _minionlimit;
        private int _bosslimit;
        private int _abilitylimit;
        private int _heartlimit;
        public FallingObjectmanager()
        {
            fallingobjectlist = new List<FallingObject>();
            _minionlimit = 8;
            _bosslimit = 2;
            _abilitylimit = 2;
            _heartlimit = 1;

        }
        public void AddFallingObject(FallingObject fallingobject)
        {
            if (fallingobject.Name == "boss")
            { 
                if (BossAddCondition())
                {
                    fallingobjectlist.Add(fallingobject);
                }
            }
            else if (fallingobject.Name == "heart")
            { 
                if (HeartAddCondtion())
                {
                    fallingobjectlist.Add(fallingobject);
                }
            }
            else if (fallingobject.Name == "minion")
            {
                if (MinionAddCondition())
                {
                    fallingobjectlist.Add(fallingobject);
                }
            }
            else if (fallingobject.Name == "ability")
            {
                if (AbilityAddCondition())
                {
                    fallingobjectlist.Add(fallingobject);
                }

            }

        }

        private bool BossAddCondition()
        {
            int boss_count = 0;
            foreach (FallingObject fallingobject in fallingobjectlist )
            {
                if (fallingobject.Name == "boss")
                {
                    boss_count += 1;
                }
            }
            return boss_count < _bosslimit;
        }
        private bool HeartAddCondtion()
        {
            int heart_count = 0;
            foreach (FallingObject fallingobject in fallingobjectlist)
            {
                if (fallingobject.Name == "heart")
                {
                    heart_count += 1;
                }
            }
            return heart_count < _heartlimit;
        }
        private bool AbilityAddCondition()
        {
            int ability_count = 0;
            foreach (FallingObject fallingobject in fallingobjectlist)
            {
                if (fallingobject.Name == "ability")
                {
                    ability_count += 1;
                }
            }
            return ability_count < _abilitylimit;
        }
        private bool MinionAddCondition()
        {
            int minion_count = 0;
            foreach (FallingObject fallingobject in fallingobjectlist)
            {
                if (fallingobject.Name == "minion")
                {
                    minion_count += 1;
                }
            }
            return minion_count < _minionlimit;
        }
        public void RemoveFallingObject(FallingObject fallingobject)
        {
            fallingobjectlist.Remove(fallingobject);
        }
        public List<FallingObject> FallingObjectList
        {
            get { return fallingobjectlist; }
            set { fallingobjectlist = value; }
        }
    }
    
    

    
}
