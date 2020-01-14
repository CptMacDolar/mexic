using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Control[] gameObjects;

    public Button jump_button;
    public VariableJoystick variableJoystick;

    private Control currentControl;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        currentControl = Instantiate(gameObjects[0]);
        currentControl.jump_button = jump_button;
        currentControl.variableJoystick = variableJoystick;
    }

    private void CharacterDied()
    {
        currentControl.isControlActive = false;
    }
}
