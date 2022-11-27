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

    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentGameState == GameState.Combat)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (transform.position.x + 1 > mousePosition.x)
            {
                inputLeft = true;

                if (canMoveLeft)
                {
                    movingLeft = true;
                    canMoveRight = false;
                }

            }
            if (transform.position.x - 1 < mousePosition.x)
            {
                inputRight = true;

                if (canMoveRight)
                {
                    movingRight = true;
                    canMoveLeft = false;
                }
            }

            if (transform.position.x < mousePosition.x)
            {
                inputLeft = false;
            }
            if (transform.position.x > mousePosition.x)
            {
                inputRight = false;
            }
        }
    }

        private void FixedUpdate()
    {
        if (CurrentGameState != GameState.Combat)
        {
            rb.velocity = rb.velocity * 0f;
            inputLeft = false;
            inputRight = false;

            movingLeft = false;
            movingRight = false;

            canMoveLeft = true;
            canMoveRight = true;
        }
        if (transform.position.x < -9)
        {
            rb.velocity = rb.velocity * 0f;
        }
        if (transform.position.x > 10)
        {
            rb.velocity = rb.velocity * 0f;
        }

        if (movingLeft && inputRight || movingRight && inputLeft || inputLeft && inputRight)
        {
            if (TrainSpeed > 1)
            {
                TrainSpeed = 1;
            }

            rb.velocity = rb.velocity * 0.9f;

            if (rb.velocity.x < 0.5f && rb.velocity.x > -0.5f)
            {
                TrainSpeed = 1;

                movingLeft = false;
                movingRight = false;

                canMoveLeft = true;
                canMoveRight = true;
            }
        }
        else if (movingLeft && inputLeft && transform.position.x > -4)
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
                TrainSpeed = 1;
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
