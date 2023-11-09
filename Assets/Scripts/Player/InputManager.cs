using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Movement mover;
    private Shooting shooter;
    void Start()
    {
        mover = GetComponent<Movement>();
        shooter = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        mover.ProcessPlayerInput(Input.GetAxis("Horizontal"));
        shooter.ProcessPlayerInput(Input.GetKey(KeyCode.Space));
    }
}
