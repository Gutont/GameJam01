using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //-------------------------------------------------------\\
    [Header("Movimento")] 
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private float activeMoveSpeed;
    private Vector2 lastMovementDirection;
    //-------------------------------------------------------\\
    [Header("Dash")] 
    public float dashSpeed;
    public float dashLenght = .5f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    private Vector2 dashDirection;
    //-------------------------------------------------------\\
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
        lastMovementDirection = new Vector2(1, 0);
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(inputX, inputY).normalized;

        if (movementInput != Vector2.zero)
        {
            lastMovementDirection = movementInput;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLenght;

                if (movementInput == Vector2.zero)
                {
                    dashDirection = lastMovementDirection; 
                }
                else
                {
                    dashDirection = movementInput; 
                }
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {

        if (dashCounter > 0)
        {
            rb.linearVelocity = dashDirection * activeMoveSpeed;
        }
        else 
        {
            rb.linearVelocity = movementInput * activeMoveSpeed;
        }
    }
}