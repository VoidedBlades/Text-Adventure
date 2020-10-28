using System;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace project_les_1 
{
    public class ResponseoptionsB
    {
        public string _B { get; set; }
        public string Story { get; set; }
        public ListDictionary _RESP { get; set; }
    }
    public class BList
    {
        public List<ResponseoptionsB> B_RESP { get; set; }
    }
    class MobRandomizer : BList
    {
        private void Create()
        {
            B_RESP = new List<ResponseoptionsB>();
            B_RESP.Add(
                new ResponseoptionsB
                {
                    _B = "Bear",
                    Story = "while walking you bumped into a large animal, he turned around slowly\nwill you [1] fight or [2] flee?",
                    _RESP = new ListDictionary{
                        { "1", "\nyou decided to fight the bear and kill it but with what item?\n" },
                        { "2", "\nyou fleed like a wuss" }
                    }
                }
            );
            B_RESP.Add(
               new ResponseoptionsB
               {
                   _B = "Witch",
                   Story = "you have encountered a witch. she doesn't seem like to be the friendliest\nwill you [1] fight or [2] flee?",
                   _RESP = new ListDictionary{
                        { "1", "\nyou decided to fight the witch and kill it but with what item?\n" },
                        { "2", "\nyou fleed like a wuss" }
                   }
               }
           );
           B_RESP.Add(
               new ResponseoptionsB
               {
                   _B = "Goblin",
                   Story = "you are facing a goblin. It seems hungry and ready to kill for it's food\nwill you [1] fight or [2] flee?",
                   _RESP = new ListDictionary{
                        { "1", "\nyou decided to fight the Goblin and kill it but with what item?\n" },
                        { "2", "\nyou fleed like a wuss" }
                   }
               }
           );
        }
        public ResponseoptionsB Returning()
        {
            Create();
            Random R = new Random();
            int RD = R.Next(0, B_RESP.Count);
            return B_RESP[RD];
        }
    }
}
