using UnityEngine;
using TMPro;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    public Text text;
    public float speed;

    public string[] lines;
    private int index;

    public GameObject OptionsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        text.text = "working";

    }


    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(index);
        Debug.Log(index <= lines.Length - 1);

        if (Input.GetMouseButtonDown(0))
        {

            if (text.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];

            }

        }



    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    void nextLine()
    {
        if (index <= lines.Length - 1)
        {
            index++;
            text.text = String.Empty;
            StartCoroutine(TypeLine());
        }

        if (index > lines.Length - 1)
        {
            this.gameObject.SetActive(false);
            OptionsMenu.SetActive(true);
        }

    }

    void OnEnable()
    {
        text.text = String.Empty;
        StartDialogue();
    }

    void OnDisable()
    {
        lines = null;
    }
}
