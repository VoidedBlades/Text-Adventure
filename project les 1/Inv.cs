using System;
using System.Collections.Generic;

namespace project_les_1
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }

    public class Inv
    {
        private List<Item> inventory;
        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }
            set { inventory = value; }
        }

        // adds items to the inventory
        public void Create(Item itm)
        {
            Inventory.Add(itm);
        }

        public Inv()
        {
            inventory = new List<Item>();
        }

        // returns the inventory
        public List<Item> ReturnInv()
        {
            return Inventory;
        }
        public void Subtract(string item, int subtr) // removes items from the inventory
        {
            foreach(Item x in Inventory)
            {
                if (x.Name == item)
                {
                    if (x.Amount != "INF")
                    {
                        int amount = System.Convert.ToInt32(x.Amount);
                        if (amount - subtr <= 0)
                        {
                            Inventory.Remove(x);
                        }
                        else
                        {
                            x.Amount = System.Convert.ToString(amount - subtr);
                        }
                        break;
                    }
                }
            }
        }
    }
}
