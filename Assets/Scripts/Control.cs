using System;
using System.Collections;
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
    public Button esc_button;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public Sprite dead;
    public Sprite front;
    public Sprite right;
    public Sprite left;


    public bool isControlActive;
    public bool kill;
    public bool win;
    private bool had_collision;

    void Start()
    {
        win = false;
        kill = false;
        isControlActive = true;
        jump_button.onClick.AddListener(Jump);
        esc_button.onClick.AddListener(Esc);
        die_button.onClick.AddListener(Die);
        restart_button.onClick.AddListener(Restart);
    }
    void Update()
    {
        if (!isControlActive)
            return;
     
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
        if (Input.GetKey(KeyCode.RightArrow))
            velocity.x = speedX;
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity.x = -speedX;
        GetComponent<Rigidbody2D>().velocity = velocity;

        if (Input.GetKey(KeyCode.Space))
            Jump();
        if(Input.GetKeyDown(KeyCode.LeftShift))
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Salt" || collision.gameObject.name == "Salt1")
        {
            changeSprites();
            kill = true;
        }
        had_collision = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Flag_empty")
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
        if (Time.time >= next_jump_time && had_collision)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = speedY;
            GetComponent<Rigidbody2D>().velocity = velocity;
            next_jump_time = Time.time + cooldown_time;
            had_collision = false;
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
        //SceneManager.LoadScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Esc()
    {
        if (SceneManager.GetActiveScene().name == "ChooseLevel")
            Application.Quit();
        else
            SceneManager.LoadScene("ChooseLevel");
    }





}
