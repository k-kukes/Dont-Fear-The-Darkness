using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    static string[] BodyPartDialogue =
     {"[Player]:???????", "[Player]: What is This ?", "[Player]: Hope Thats not Human"};
    static string[] TooDark =
    {"[Player]: The Cave is too dark I need more light to see this"};


    static string[] Note2 =
    {"To whom it may concern", "Proceed with caution as the darkness in this cave will drive even the bravest man mad", " My fate is sealed so I have left you the last of my belongings", "a single battery", "There may be others in this cave", "Find the clues and the door","and you may have hope of escape"};

    static string[] Note3 =
    {"I lie between the stars and in the deepest earth beneath."};

    static string[] Note4 =
    {"I am the hearts of murderers and the maw behind the teeth."};

    static string[] Note5 =
    {"I am all that will come after and all that came before."};
    static string[] ExitLvl2 =
    {"Enter The code to exit"};


    static string[] Note1 =
    {"Story text: ...", "Go to the Cabin ...", "The trap door will lead you to the tunnel", "Be careful there is  a monster"};
    static string[] FoodDialogue =
      {"[Player]:Finaly", "[Player]: Something to eat"};

    static string[] QuestItemDialogue =
     {"[Player]: Hmm", "[Player]:This might be useful"};

    static string[] DefaultDialogue =
     {"[Player]: Nice"};

    static string[] MonsterDialogue =
     {"[Player]: Its not moving","[Player]: I should probably get out of here"};

    static string[] ForestExplorer =
    {"[Explorer]: Welcome Traveler", "[Player]: Who are you?","[Explorer]: Thats not important", "[Explorer]: Take this", "   (He hands you a key)","[Explorer]: If your going to find Alice you'll need it","[Explorer]: Go to the top of the hill you will find more there","[Player]: Wait how do you know about Alice !??","   (The man has gone silent)" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static string[] setDialogue(string itemName)
    {
        switch (itemName)
        {

            case "Body_Parts":
                ResourceManager.isFood = false;
                return BodyPartDialogue;
            case "food":
                ResourceManager.isFood = true;
                return FoodDialogue;
            case "rust_key":
                ResourceManager.isFood = false;
                return QuestItemDialogue;
            case "MonsterMutant2":
                return MonsterDialogue;
            case "ForestExplorer":
                ChestManager.instance.hasChestKey = true;
                return ForestExplorer;
            case "Note#1":

                return Note1;
            case "Note-2":

                    return Note2;
            case "Note-3":
                if (FlashlightController.IsFlashlightOn())
                {
                    return Note3;
                }
                return TooDark;
            case "Note-4":
                if (FlashlightController.IsFlashlightOn())
                {
                    return Note4;
                }
                return TooDark;
             case "Note-5":
                if (FlashlightController.IsFlashlightOn())
                {
                    return Note5;
                }
                return TooDark;
            case "Exit":
                return ExitLvl2;
            default:
                return null;
        }

    }
}
