using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private CircleCollider2D cc2D;
    public float thrust = 5.0f;
    private Vector2 startPosition;
    private Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        cc2D = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
                //rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endPosition = touch.position;

                Vector2 movementVector = startPosition - endPosition;

                if (cc2D.IsTouchingLayers(LayerMask.GetMask("GroundCollisions")))
                {
                    rb2D.AddForce(movementVector * 0.07f, ForceMode2D.Impulse);
                }
            }
        }

        /*BoxCollider2D leftWall = (BoxCollider2D) GameObject.Find("LeftWallCollider").GetComponent(typeof(BoxCollider2D));
        BoxCollider2D rightWall = (BoxCollider2D) GameObject.Find("RightWallCollider").GetComponent(typeof(BoxCollider2D));

        if (cc2D.IsTouching(leftWall))
        {
            rb2D.transform.position = new Vector2(2.3f, gameObject.transform.position.y);
        }

        if (cc2D.IsTouching(rightWall))
        {
            rb2D.transform.position = new Vector2(-2.3f, gameObject.transform.position.y);
        }*/
    }
}
