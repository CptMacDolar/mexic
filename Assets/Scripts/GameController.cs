using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Control[] gameObjects;

    public Button jump_button;
    public Button restart_button;
    public Button next_level;
    public Button die_button;
    public Button esc_button;
    public VariableJoystick variableJoystick;
    public Sprite dead;
    public Sprite front;
    public Sprite right;
    public Sprite left;
    public GameObject win_screen;
    public Text counter;
    private int counter_int;
    int index = 0;

    private Control currentControl;

    private void Awake()
    {
        Spawn();
        counter_int = gameObjects.Length - 1;
        counter.text = counter_int.ToString();
    }

    private void Update()
    { 
        if (currentControl.kill)
            CharacterDied();

        if (currentControl.win)
            win_screen.SetActive(true);
    }

    private void Spawn()
    {
        if(index < gameObjects.Length)
        {
            currentControl = Instantiate(gameObjects[index]);
            currentControl.jump_button = jump_button;
            currentControl.die_button = die_button;
            currentControl.restart_button = restart_button;
            currentControl.esc_button = esc_button;
            currentControl.variableJoystick = variableJoystick;
            currentControl.dead = dead;
            currentControl.front = front;
            currentControl.right = right;
            currentControl.left = left;
            currentControl.next_level = next_level;
            index++;
        }
    }

    public void CharacterDied()
    {
        currentControl.rb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        currentControl.isControlActive = false;
        if (counter_int > 0)
        {
            counter_int--;
            counter.text = counter_int.ToString();
            Spawn();
        }
        
    }
}
