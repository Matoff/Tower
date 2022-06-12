using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private BoxCollider2D m_Collider2D;
    public float jumpForce;
    public float gravity;
    private bool grounded = false;
    void Awake()
    {
        m_Collider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded)
        {
            transform.position += Vector3.down * Time.deltaTime * gravity;
        }

        //Debug.Log(Physics2D.gravity.y);
        var groundLeft = new Vector3(transform.position.x - m_Collider2D.size.x /2, transform.position.y - m_Collider2D.size.y / 2);
        Debug.DrawRay(groundLeft, Vector3.down, Color.cyan);
        var groundRight = new Vector3(transform.position.x + m_Collider2D.size.x / 2, transform.position.y - m_Collider2D.size.y / 2);
        Debug.DrawRay(groundRight, Vector3.down, Color.cyan);

        var layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(groundLeft, Vector2.down, 1.0f, layerMask);
        if (hitGroundLeft.collider != null)
        {
            float distance = Mathf.Abs(hitGroundLeft.point.y - groundLeft.y);
            float distance2 = hitGroundLeft.point.y - groundLeft.y;
            Debug.Log(distance2);
            if (distance > 0.01)
            {
                //Debug.Log(grounded);
                grounded = false;
            }
            else
            {
                //Debug.Log(grounded);
                grounded = true;
                if(distance == 0)
                {
                    transform.position += Vector3.up * Time.deltaTime * gravity;
                }
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
        if(context.performed)
        {

        }
        if (context.canceled)
        {

        }
    }

    private Vector2 GetBaseColider(BoxCollider2D collider2D)
    {

        RaycastHit2D hit = Physics2D.Raycast(collider2D.size, -Vector2.up);
       // collider2D.size;
        return Vector2.one;
    }




}
