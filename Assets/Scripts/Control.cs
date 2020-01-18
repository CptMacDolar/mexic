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
    public Button die_button;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public Sprite dead;
   // public SpriteRenderer spriteRenderer;

    public bool isControlActive;
    public bool kill;

    void Start()
    {
        kill = false;
        isControlActive = true;
        jump_button.onClick.AddListener(Jump);
        die_button.onClick.AddListener(Die);
    }

    void Update()
    {
        if (kill && spriteRenderer.sprite != dead)
            changeSprite();

        if (!isControlActive)
            return;

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = variableJoystick.Horizontal * speedX;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Salt")
            kill = true;
    }

    private void Jump()
    {
        if (!isControlActive)
            return;

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.y = speedY;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
    private void Die()
    {
        if (!isControlActive)
            return;
        kill = true;
    }

    public void changeSprite()
    {
        spriteRenderer.sprite = dead;
    }


}
