﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public float speedX;
    public float speedY;

    public Button jump_button;
    public Button restart_button;
    public Button die_button;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public Sprite dead;
    public Sprite front;
    public Sprite right;
    public Sprite left;


    public bool isControlActive;
    public bool kill;
    public bool win;

    void Start()
    {
        win = false;
        kill = false;
        isControlActive = true;
        jump_button.onClick.AddListener(Jump);
        die_button.onClick.AddListener(Die);
        restart_button.onClick.AddListener(Restart);
    }

    void Update()
    {
        if (!isControlActive)
            return;
        //switch (variableJoystick.Horizontal)
        //{
        //    case 0:
        //        gameObject.GetComponent<SpriteRenderer>().sprite = front;
        //        break;
        //    case 1:
        //        gameObject.GetComponent<SpriteRenderer>().sprite = right;
        //        break;
        //    case -1:
        //        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        //        break;

        //}

        if(variableJoystick.Horizontal == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = front;
        }
        else if(variableJoystick.Horizontal < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = variableJoystick.Horizontal * speedX;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Salt")
        {
            changeSprites();
            kill = true;
        }
        if (collision.gameObject.name == "Platform_win")
        {
            changeSprites();
            win = true;
        }
    }
    public double cooldown_time = 0.10;
    private double next_jump_time;
    private void Jump()
    {
        if (!isControlActive)
            return;
        if (Time.time >= next_jump_time)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = speedY;
            GetComponent<Rigidbody2D>().velocity = velocity;
            next_jump_time = Time.time + cooldown_time;
        }
    }
    private void Die()
    {
        if (!isControlActive)
            return;
        kill = true;
        changeSprites();

    }
    private void changeSprites()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
    }
    private void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

 


}
