using System;
using System.Collections.Generic;
using System.Text;

namespace project_les_1
{
    public class Responses
    {
        public string Item { get; set; }
        public string Boss { get; set; }
        public List<object[]> ResponseOptions { get; set; }
    }


    public class ResponseHandeler
    {
        // choosing through a randomizer what to response
        private object[] choosingResp(string I, string B)
        {
            object[] returning = new object[1];
            foreach (Responses x in MobResponses())
            {
                if (x.Item.ToLower() == I.ToLower())
                {
                    if (x.Boss.ToLower() == B.ToLower())
                    {
                        Random Rand = new Random();
                        int randomizer = Rand.Next(x.ResponseOptions.Count);
                        foreach (Responses z in MobResponses())
                        {
                            returning = x.ResponseOptions[randomizer];
                        }
                    }
                }
            }
            return returning;
        }
        // returning the string with the bool outcome (true = alive, false = dead) from all the types of 
        // responses that are possible for the fight;
        public object[] Response(string I, string B)
        {
            return choosingResp(I, B);

        }

        // creating all response types for the bosses
        public List<Responses> MobResponses()
        {
            List<Responses> Resp = new List<Responses>();
            // bear
            Resp.Add(
                new Responses
                {
                    Item = "Sword",
                    Boss = "Bear",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "You defeated the animal, but its a close call, be carefull next time.", true, 10 },
                        new object[3] { "You managed to successfully defeat the animal, appearantly the sword did its work.", true, 0 },
                        new object[3] { "The animal overpowered you and defeated you.", false, 0 }
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Shard",
                    Boss = "Bear",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "the shard exploded in your hand as it became unstable due to rapid movement", false, 0 },
                        new object[3] { "the shard got stuck into the bear and started glowing really bright, eventually\nexploded the shard", true, 0 },
                        new object[3] { "okay so you threw a shard at him... that didn't really work. you died", false, 0 }
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Fists",
                    Boss = "Bear",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "foolish idea to use your fists, the bear bit one of your hands off and ate you alive", false, 0 },
                        new object[3] { "appearantly you killed it with your fists... impressive..", true, 0 },
                        new object[3] { "The animal overpowered you and defeated you.", false, 0 }
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Staff",
                    Boss = "Bear",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "you pointed the staff at the bear and it suddenly started to emmit a bright light. once the brightness became less the animal has dissapeared", true, 0 },
                        new object[3] { "the bear approached and you used the staff to defend yourself, the bear broke the staff into 2 generating a huge explosion killing both you and\n the bear", false, 0 },
                        new object[3] { "as you pointed the staff at the bear the staff didn't do anything. you threw it at the bear and the staff pierced him leaving the\nstaff heavily damaged", true, 50 }
                    }
                }
            );

            // witch
            Resp.Add(
                new Responses
                {
                    Item = "Sword",
                    Boss = "Witch",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "You defeated the witch, but merely. your sword damaged a bit due to her magic.", true, 20 },
                        new object[3] { "You managed to successfully defeat the witch.", true, 0 },
                        new object[3] { "The Witch turned your sword into ashes and killed you", false, 0 },
                        new object[3] { "The witch turned your sword into ashes, you managed to flee from her but sadly your sword has been destroyed.", true, 100}
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Fists",
                    Boss = "Witch",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "You defeated the witch... oddly enough? i guess she was lazy or some sort and thought you'd be easy.", true, 0 },
                        new object[3] { "The witch burned you to death.", false, 0 },
                        new object[3] { "After a long fight the witch got you trapped, no direction to go with one fatal outcome\nshe killed you.", false, 0 }
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Shard",
                    Boss = "Witch",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "yeah... it's just a shard it didn't do anything to her. you died", false, 0 },
                        new object[3] { "The witch catched the shard and merged with it. she became stronger and killed you", false, 0 },
                        new object[3] { "the shard trapped the witch in it. Appearantly the shard can be used as some sort of capture device", true, 0 }
                    }
                }
            );
            Resp.Add(
               new Responses
               {
                   Item = "Staff",
                   Boss = "Witch",
                   ResponseOptions = new List<object[]>{
                        new object[3] { "whilst aiming the staff at the witch and captured her power, leaving her drained and more humane", true, 0 },
                        new object[3] { "as soon as you moved your hand towards your staff she tore it out of your hands. killing you with the\nenormous power channeled through the staff, towards you.", false, 0 },
                        new object[3] { "you grabbed your staff and slammed the bottom of the handle on the ground leaving a huge aftershock killing\nall magical creatures in a close radius but due to the magic used to preform this the staff damages a bit", true, 20 }
                   }
               }
           );
            // Goblin
            Resp.Add(
                new Responses
                {
                    Item = "Sword",
                    Boss = "Goblin",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "the goblin defended itself and dodging some of your attacks. making you hit the ground, rocks and tree quite\noften. eventually you managed the kill the goblin.", true, 20 },
                        new object[3] { "while the goblin screeched you pierced him with your sword", true, 0 },
                        new object[3] { "The goblin ate your sword and killed you", false, 0 },
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Fists",
                    Boss = "Goblin",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "you punched the goblin as soon he came closer, apperantly it got really frustrated and ran away", true, 0 },
                        new object[3] { "the goblin approached you but without you noticing another goblin comming from the back. you were the \nmain course in their meal", false, 0 },
                        new object[3] { "the goblin ran up to you and ate your hand off as soon you tried to punch it. You died", false, 0 }
                    }
                }
            );
            Resp.Add(
                new Responses
                {
                    Item = "Shard",
                    Boss = "Goblin",
                    ResponseOptions = new List<object[]>{
                        new object[3] { "ehm... it's a shard i guess? it's not really doing anything... the goblin killed you.", false, 0 },
                        new object[3] { "the goblin catched the shard and used it as knive. You died.", false, 0 },
                        new object[3] { "the shard trapped the Goblin in it.", true, 0 }
                    }
                }
            );
            Resp.Add(
               new Responses
               {
                   Item = "Staff",
                   Boss = "Goblin",
                   ResponseOptions = new List<object[]>{
                        new object[3] { "you shot an magical beam towards the goblin, making it vanish into thin air", true, 0 },
                        new object[3] { "as soon as you got your staff in your hand the goblin bit it into 2 pieces, you can clearly see \nthe staff losing its magic. the goblin killed you", false, 0 },
                        new object[3] { "you shot a huge fireball at the goblin. the goblin burned to death and you can now safely pass", true, 20 }
                   }
               }
           );

            return Resp;
        }
    }
}
