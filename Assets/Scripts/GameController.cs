using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Control[] gameObjects;

    public Button jump_button;
    public Button die_button;
    public VariableJoystick variableJoystick;
    public Sprite dead;
    public SpriteRenderer spriteRenderer;
    int index = 0;

    private Control currentControl;

    private void Awake()
    {
        Spawn();
    }

    private void Update()
    {
        if (currentControl.kill)
            CharacterDied();
    }

    private void Spawn()
    {
        if(index < 3)
        {
            currentControl = Instantiate(gameObjects[index]);
            currentControl.jump_button = jump_button;
            currentControl.die_button = die_button;
            currentControl.variableJoystick = variableJoystick;
            currentControl.dead = dead;
            //currentControl.spriteRenderer = gameObjects[index].spriteRenderer;
    index++;
        }
    }

    public void CharacterDied()
    {
        currentControl.rb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        currentControl.isControlActive = false;
        Spawn();
    }
}
