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
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    public bool isControlActive;

    void Start()
    {
        isControlActive = true;
        jump_button.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if (!isControlActive)
            return;

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = variableJoystick.Horizontal * speedX;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void TaskOnClick()
    {
        if (!isControlActive)
            return;

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.y = speedY;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
