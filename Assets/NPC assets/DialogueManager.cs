using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    static string[] BodyPartDialogue =
     {"???????", "What is This ?", "Hope Thats not Human"};

    static string[] FoodDialogue =
      {"Finaly", "Something to eat"};

    static string[] QuestItemDialogue =
     {"Hmm", "This might be useful"};

    static string[] DefaultDialogue =
     {"Nice"};

    static string[] MonsterDialogue =
     {"Its not moving","I should probably get out of here"};
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
            default:
                return null;
        }

    }
}
