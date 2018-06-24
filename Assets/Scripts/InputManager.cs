using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

    public DirectionButton buttonLeft;
    public DirectionButton buttonRight;

    [HideInInspector]
    public float dir;

    public Action<float> move;
    public Action action;
    public static InputManager instance;

    void Awake ()
    {
        instance = this;

        buttonLeft.move = Move;
        buttonRight.move = Move;
    }

    void Move(float dir)
    {
        move(dir);
    }
    
    void Update ()
    {
        dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0)
        {
            move(dir);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            action();
        }
    }
}
