using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;

public class CombatMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    bool inputLeft = false;
    bool inputRight= false;

    bool movingLeft = false;
    bool movingRight = false;

    bool canMoveLeft = true;
    bool canMoveRight= true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputLeft = true;

            if (canMoveLeft)
            {
                movingLeft = true;
                canMoveRight = false;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputRight = true;

            if (canMoveRight)
            {
                movingRight = true;
                canMoveLeft = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            inputLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            inputRight= false;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -6.5)
        {
            rb.velocity = rb.velocity * 0f;
        }
        if (transform.position.x > 6.5)
        {
            rb.velocity = rb.velocity * 0f;
        }

        if (movingLeft && inputRight || movingRight && inputLeft || inputLeft && inputRight)
        {
            if (TrainSpeed > 1)
            {
                TrainSpeed -= TrainAcc;
            }

            rb.velocity = rb.velocity * 0.85f;

            if (rb.velocity.x < 0.05f && rb.velocity.x > -0.05f)
            {
                TrainSpeed = 1;

                movingLeft = false;
                movingRight = false;

                canMoveLeft = true;
                canMoveRight = true;
            }
        }
        else if (movingLeft && inputLeft && transform.position.x > -7)
        {
            rb.velocity = new Vector2(-TrainSpeed, 0);

            if (TrainSpeed < MaxTrainSpeed)
            {
                TrainSpeed += TrainAcc;
            }
        }
        else if (movingRight && inputRight && transform.position.x < 7)
        {
            rb.velocity = new Vector2(TrainSpeed, 0);

            if (TrainSpeed < MaxTrainSpeed)
            {
                TrainSpeed += TrainAcc;
            }
        }
        else if (!inputLeft && !inputRight)
        {
            if (TrainSpeed > 1)
            {
                TrainSpeed -= TrainAcc;
            }

            rb.velocity = rb.velocity * 0.97f;

            if (rb.velocity.x < 0.05f && rb.velocity.x > -0.05f)
            {
                TrainSpeed = 1;

                movingLeft = false;
                movingRight = false;

                canMoveLeft = true;
                canMoveRight = true;
            }
        }
    }
}
