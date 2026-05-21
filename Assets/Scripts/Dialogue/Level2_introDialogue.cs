using System.Collections.Generic;
using UnityEngine;

public class Scene2Dialogue : MonoBehaviour
{
    public DialogueManager dm;

    void Start()
    {
        StartScene2();
    }

    void StartScene2()
    {
        List<string> lines = new List<string>()
        {
            "[Player]: This is where the first note led me...",
            "[Player]: These caves... I've never seen anything like them.",
            "[Player]: If the note was right, the rest should be hidden somewhere inside.",
            "[Player]: Alice... why would you leave clues instead of calling for help?",
            "[Player]: Something must have scared you. Something bad.",
            "[Player]: I need to find the other notes. They're the only way to reach you.",
            "[Player]: ...And whatever was following me out there...",
            "[Player]: It hasn't stopped. I can feel it watching me.",
            "[Player]: I need to move. Now."
        };

        dm.StartDialogue(lines);
    }
}