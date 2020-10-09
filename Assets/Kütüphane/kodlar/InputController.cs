using UnityEngine;

public class InputController : MonoBehaviour
{
    GameManager gameManager;
    public float Hareket_Hizi = 2;
    private bool isMoving = false;
    private Animator moving_anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        moving_anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (gameManager.IsGameStarted == false || gameManager.IsPousedInputHandler)
            return;
        Vector3 transformVector = new Vector3();
        isMoving = false;
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y < 15)
        {
            isMoving = true;
            transformVector = new Vector3(0, 1, 0);
            moving_anim.SetInteger("status", 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y > -15)
        {
            isMoving = true;
            transformVector = new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x > -15)
        {
            isMoving = true;
            spriteRenderer.flipX = true;
            transformVector += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < 15)
        {
            isMoving = true;
            spriteRenderer.flipX = false;
            transformVector += new Vector3(1, 0, 0);
        }
        if (isMoving)
        {
            gameObject.transform.Translate(transformVector * Time.deltaTime * Hareket_Hizi);
            moving_anim.SetInteger("status", 1);
        }
        else
        {
            moving_anim.SetInteger("status", 0);
        }
    }
}
