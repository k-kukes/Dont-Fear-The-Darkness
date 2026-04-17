using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    static string[] BodyPartDialogue =
     {"???????", "What is This ?", "Hope Thats not Human"};

    static string[] FoodDialogue =
      {"Finaly", "Something to eat"};

    static string[] QuestItemDialogue =
     {"Hmm", "This might be useful"};

    static string[] DefaultDialogue =
     {"Nice"};
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
            default:
                return null;
        }

    }
}
