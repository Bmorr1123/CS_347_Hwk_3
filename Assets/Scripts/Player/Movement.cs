using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Bounds")]
    public float leftXLimit;
    public float rightXLimit;
    [Header("Player Movement")]
    public float moveSpeed;
    Rigidbody playerRB;
    Transform playerTF;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerTF = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayerInput(float xInput)
    {
        playerRB.velocity = new Vector3(xInput * moveSpeed, 0, 0);

        if ((playerTF.position.x <= leftXLimit && xInput < 0) || (playerTF.position.x >= rightXLimit && xInput > 0))
        {
            playerRB.velocity = Vector3.zero;
        }
    }

    bool PlayerInLimits()
    {
        return playerTF.position.x > leftXLimit && playerTF.position.x < rightXLimit;
    }
}
