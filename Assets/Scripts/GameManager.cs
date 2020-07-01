using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true; // 플레이어의 움직임 제어
    public static bool keydownEsc = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!keydownEsc)
            {
                keydownEsc = true;
                Pause();
            }
            else
            {
                keydownEsc = false;
                Restart();
            }
     
        }
    }

    private void Pause()
    {
        if (keydownEsc)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canPlayerMove = false;
        }
    }
    private void Restart()
    {
        if (!keydownEsc)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canPlayerMove = true;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
