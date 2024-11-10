using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput inputActions;
    private Rigidbody2D rb;  
    [SerializeField] GameObject jetpack;
    public float jumpForce = 10f;
    private bool isJumping;

    private void Awake()
    {
        inputActions = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.Shoot.performed += _ => Shoot();

        // when jump is started, set isJumping to true
        inputActions.Gameplay.Jump.started += _ => {
            isJumping = true;
            jetpack.SetActive(true);  // Activate jetpack
        };

        // when jump is released, deactivate jetpack and set isJumping to false
        inputActions.Gameplay.Jump.canceled += _ => 
        {
            isJumping = false;
            jetpack.SetActive(false);  // Deactivate jetpack
        };
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        // Keep calling Jump() if the jump button is held down
        if (isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);  // Apply jump force
    }

    private void Shoot()
    {
    }
}
