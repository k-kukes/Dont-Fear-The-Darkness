using Mono.Cecil.Cil;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToLvl3 : MonoBehaviour
{
    public TMP_InputField code;
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkCode()
    {
        if (code.text.Equals("black"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("Wrong Password");
        }
    }

    public void close()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
