using System;
using System.Collections.Generic;
namespace project_les_1
{
    public class TextAdventure : Inv
    {
        defeatedMobs Def = new defeatedMobs();
        public void textNquest(int level) // objects ( = x )
        {
            var writer = new TextWriter();
            string story = "";
            bool choosing = false;
            object[] option1 = new object[2];
            object[] option2 = new object[2];

            Dictionary<string, string> dict = new Dictionary<string, string>();
            // text adventure per level
            if (level == 1)
            {
                story = "while walking through the woods you stumble over a rock. while you lay there you take a glance at the rock. it seems to\nglow and a piece of it shattered off probably because you hit it too hard.\nwill you [1] put together the stone or [2] take the broken piece and continue walking";
                dict.Add("1", "\b \nthe stone started glowing really bright and formed a sword");
                dict.Add("2", "\b \nyou decided to pick up the piece and continue to walk");
                option1.SetValue("Sword", 0);
                option1.SetValue(100, 1);

                option2.SetValue("Shard", 0);
                option2.SetValue(1, 1);
            }
            else if (level == 2)
            {
                story = "you see an bright light and approach it. once you reach out for it you see its a staff, you do not know how it works. in the distance is another being. will you [1] pick up the staff or [2] leave it there and continue";
                dict.Add("1", "\b \nyou picked up the staff and continued your journey");
                dict.Add("2", "\b \nyou left the staff behind");
                option1.SetValue("staff", 0);
                option1.SetValue(100, 1);

                option2.SetValue("", 0);
                option2.SetValue(0, 1);
            }

            // writing
            Console.Clear();
            writer.Writer(story);

            choosing = true;
            while (choosing)
            {
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    writer.Writer(dict["1"]);
                    if (option1[0].ToString() != "")
                    {
                        Create(new Item() { Name = option1[0].ToString(), Amount = option1[1].ToString()});
                        choosing = false;
                        Console.ReadKey();
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.D2)
                {
                    writer.Writer(dict["2"]);
                    if (option2[0].ToString() != "")
                    {
                        Create(new Item() { Name = option2[0].ToString(), Amount = option2[1].ToString() });
                        choosing = false;
                        Console.ReadKey();
                    }

                }

            }
        }

        public void objective(int level) // objective ( = *)
        {
            var writer = new TextWriter();
            var MR = new MobRandomizer();
            ResponseHandeler resp = new ResponseHandeler();
            bool choosing = false;
            bool selecting = false;
            bool looping = true;
            Mob mob;
            var M = MR.Returning();
            if (Def.get().Count > 0)
            {
                while (looping)
                {
                    mob = Def.get().Find(x => x.MobName.Contains(M._B));

                    if (Def.get().Contains(mob))
                    {
                        M = MR.Returning();
                    }
                    else
                    {
                        looping = false;
                    }
                }
            }
            selecting = true;
            // writing
            Console.Clear();
            
            writer.Writer(M.Story);
            choosing = true;
            string currentchosen = "";
            while (choosing)
            {
                ConsoleKeyInfo z = Console.ReadKey();
                if (z.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    writer.Writer(M._RESP["1"].ToString());
                    int selected = 0;
                    if (selecting)
                    {
                        while (choosing)
                        {
                            Console.Clear();
                            Console.WriteLine(M._RESP["1"].ToString());
                            string I = "";
                            int current = 0;
                            foreach (Item x in ReturnInv())
                            {
                                if (selected == current)
                                {
                                    I = I + "> " + x.Name + " - [Amount: " + x.Amount + "] < \n";
                                    currentchosen = x.Name;
                                }
                                else
                                {
                                    I = I + x.Name + " - [Amount: " + x.Amount + "]\n";
                                }
                                current = current + 1;
                            }
                            Console.WriteLine(I);
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.UpArrow)
                            {
                                selected = selected - 1;
                                if (selected < 0)
                                {
                                    selected = ReturnInv().Count - 1;
                                }
                            }
                            else if (key.Key == ConsoleKey.DownArrow)
                            {
                                selected = selected + 1;
                                if (selected > ReturnInv().Count - 1)
                                {
                                    selected = 0;
                                }
                            }
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                choosing = false;
                                object[] responsing = resp.Response(currentchosen, M._B);
                                Console.Clear();
                                writer.Writer(responsing[0].ToString());
                                Console.ReadKey();
                                if (!Convert.ToBoolean(responsing[1]))
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Def.set(M._B);
                                }
                                Subtract(currentchosen, Convert.ToInt32(responsing[2]));
                            }
                        }
                    }
                }
                else if (z.Key == ConsoleKey.D2)
                {
                    Random x = new Random();

                    switch (x.Next(0, 2))
                    {
                        case 1:
                            Console.Clear();
                            writer.Writer(M._RESP["2"].ToString());
                            Console.ReadKey();
                            break;
                        default:
                            Console.Clear();
                            writer.Writer("The "+M._B+" caught you. You died");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                    choosing = false;
                }
                
            }
        }
    }
}
