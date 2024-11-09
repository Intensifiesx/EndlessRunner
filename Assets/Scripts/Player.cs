using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput inputActions;
    private Rigidbody2D rb;  

    public float jumpForce = 10f;

    private void Awake()
    {
        inputActions = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.Shoot.performed += _ => Shoot();
        inputActions.Gameplay.Jump.performed += _ => Jump();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  // Apply jump force
        print("Jumped");
    }

    private void Shoot()
    {
        
        print("Shoot");
    }
}
