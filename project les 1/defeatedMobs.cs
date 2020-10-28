using System;
using System.Collections.Generic;

namespace project_les_1
{
    [Serializable]
    public class Mob
    {
        public string MobName { get; set; }
    }
    class defeatedMobs
    {
        private List<Mob> defeated;
        public List<Mob> Defeated
        {
            get
            {
                return defeated;
            }
            set { defeated = value; }
        }
        public defeatedMobs()
        {
            defeated = new List<Mob>();
        }
        public void set(string I)
        {
            Defeated.Add(new Mob { MobName = I} );
        }
        public List<Mob> get()
        {
            return Defeated;
        }
    }
}
