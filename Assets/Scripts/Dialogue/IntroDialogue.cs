using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public DialogueManager dm;

    void Start()
    {
        StartIntro();
    }

    void StartIntro()
    {
        List<string> lines = new List<string>()
        {
            "[Player]: (My car has no battery and there is no one in sight.)",
            "[Player]: (I should probably ask someone for help.)",
            "[Player]: (All of this is very weird...)"
        };

        dm.StartDialogue(lines); // no choices yet
    }
}