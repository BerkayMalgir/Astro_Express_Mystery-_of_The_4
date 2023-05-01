using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkMove = 0f;
    public float walkSpeed = 20f;

    public Sprite minion1Sprite;
    public Sprite minion2Sprite;
    public CharacterController2D controller;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HorizontalMove();
    }

    private void HorizontalMove()
    {
        walkMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        controller.Anim(walkMove != 0);

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = minion1Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = minion2Sprite;
        }

        if (walkMove < 0)
        {
            transform.localScale = new Vector3(-12, 12, 1);
        }
        else if (walkMove > 0)
        {
            transform.localScale = new Vector3(12, 12, 1);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(walkMove * Time.deltaTime);
    }
}
