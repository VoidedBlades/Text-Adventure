/*
 Ter disclaimer:    vond dit leuk er bij te zetten mocht ik het programma ooit aan iemand geven zodat die persoon er
                    zelf ook wat mee kan rond werken en dingen van kan leren.
 
  want to make your own levels, items and mob responses? just follow this simple guide.



                                                =[ Items ]=
  
    to create a new item you'll need to open the file named "TextAdventure.cs" in the solution explorer.
    to make an extra item in a level (only 1 item per level) you simply script an else if statement containing
    the level you're making. so if its your first level you'll want to do the following undernearth the last
    finger bracket of level 2
    ==========================================================================================================

    else if (level == 3) 
    {
        story = "" // give a story with 2 options;
        dict.Add("1", ""); // the response if you choose option 1
        dict.Add("2", ""); // the response if you choose option 2
        option1.SetValue("", 0); // the first item (edit the string that is empty)
        option1.SetValue(100, 1); // durability / amount of the item

        option2.SetValue("Shard", 0); // second item (leave empty if you want the person not to obtian something
        option2.SetValue(1, 1); // durability / amount
    }

    ===========================================================================================================

    note that if you create a new item you'll need to make a new response to all the current mobs containing the
    exact (capital sensitive) item name which makes me c ome to the next part of the guide note that this is easier
    to do after you created the boss.




                                                =[ responses ]=

    to create a item response open the "itemResponses.cs" file in the solution explorer.
    making an item have a response towards a specific mob isn't that complicated. you'll need to make sure that
    ALL the mobs get a reponse for this item this is due to the mob randomizer. to do so you'll simply edit the
    following code lines into your desired response for that mob and put it in the List type named: 
                                                            List<Responses> Resp = new List<Responses>();
    
    this can be done easily by just reading whats in it already. to add a respose for a mob edit this code stack
    ============================================================================================================

    Resp.Add(
                new Responses
                {
                    Item = "", // the item's name (capital sensitive)
                    Boss = "", // the boss name (capital sensitive to the created boss's name)
                    ResponseOptions = new List<object[]>{
                        new object[3] { "response 1", true, 10 },
                        new object[3] { "response 2", true, 0 },
                        new object[3] { "response 3", false, 0 }
                    }
                }
            );

    =============================================================================================================

    you can ad as many responses as you'd like. the object's order goes as follwing:
    Response[string], Alive?(if so set it to true)[bool], Damage to the object [int].




                                              =[ mob creating ]=
    
    in order to make a item response work you'll need to create a mob. this is probably the second easiest part of 
    editing the game. open in the Solution Explorer the file named "MobRandomizer.cs" and find the function called 
    Create() make below line 20 a new ResponseOptionB into the B_RESP list. this is done as following:
    =============================================================================================================
    
    B_RESP.Add(
                new ResponseoptionsB
                {
                    _B = "", // boss name
                    Story = "", //story shown when you encounter it (use [1] and [2] to show what the options are)
                    _RESP = new ListDictionary{
                        { "1", "" }, // fight response when pressed 1
                        { "2", "\nyou fleed like a wuss" } // flee response when pressed 2
                    }
                }
            );

    =============================================================================================================

    finally but not least. the map creating

                                                  =[ maps ]=
    i am pretty convident that this is the easiest part of editing the game since its only changing an multiline
    string. open up the file named "Levels.cs" in the Solution Explorer and take a look at how it's made. there
    are some simple requirements in the string needed in order to make the game work properly.
    # = border
    X = object
    * = objective
    V = previous level
    ^ = next level
    R = Returning position (usually close near ^ due to going back one level)
    S = starting position (usually close near V due to going to the next level)
    W = Finish game (usually only set at the last level)

    in order to make the character not bug out of the game you need to make each string line the same lenght. do
    this as the following example into the levels script.
    =============================================================================================================

    public string Level3()
            {
                string map = @"


            ####################################################################################################
            v                                                                                                  #
            v S                                             X                                                  #
            v                                                                                                  #
            #######################################################   ##########################################
                                                                  #   #                                         
                                                                  #   #                                         
                                                                  #   #                                         
                                                                  #   #                                         
                                                                  #   ##########################################
                                                                  #        #                                   ^
                                                                  #         *                                R ^
                                                                  #          #                                 ^
                                                                  ##############################################";
                return map;
            }

    =============================================================================================================

    all the accessable places are the exact same lenght to prevent bugging out the character. make sure this is
    done otherwise the whole game would turn out pretty weird. now open up the file named "Levelcheck.cs" and put
    the following code under the else if(lvl == 2)'s finger brackets to create a third level.
    =============================================================================================================

     else if (lvl == 3)
            {
                map = level.Level3();

            }

    =============================================================================================================

    that's all you've gotta do. be creative
 */