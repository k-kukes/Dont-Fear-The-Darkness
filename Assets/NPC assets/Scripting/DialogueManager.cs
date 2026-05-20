using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    static string[] BodyPartDialogue =
     {"You:???????", "You: What is This ?", "You: Hope Thats not Human"};

    static string[] FoodDialogue =
      {"You:Finaly", "You: Something to eat"};

    static string[] QuestItemDialogue =
     {"You: Hmm", "You: This might be useful"};

    static string[] DefaultDialogue =
     {"You: Nice"};

    static string[] MonsterDialogue =
     {"You: Its not moving","You: I should probably get out of here"};
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
