using UnityEngine;

public class DirectionHelper : MonoBehaviour
{
    public Transform target;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite upRight;
    public Sprite upLeft;
    public Sprite down;
    public Sprite downRight;
    public Sprite downLeft;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ShowDirection(Transform target)
    {
        gameObject.SetActive(true);
        this.target = target;
    }
    public void HideDirection()
    {
        gameObject.SetActive(false);
        target = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            var direction = target.position - gameObject.transform.position;
            direction = direction.normalized;
            if (direction.x > 0 && direction.y > 0)
            {
                if (direction.x > 0.8)
                    spriteRenderer.sprite = right;
                else if (direction.y > 0.8)
                    spriteRenderer.sprite = up;
                if (direction.x <= 0.8 && direction.x >= 0.2)
                    spriteRenderer.sprite = upRight;
            }
            else if (direction.x < 0 && direction.y > 0)
            {
                if (direction.x < -0.8)
                    spriteRenderer.sprite = left;
                else if(direction.y > 0.8)
                    spriteRenderer.sprite = up;
                if(direction.x >= -0.8 && direction.x <= -0.2)
                    spriteRenderer.sprite = upLeft;
            }
            else if (direction.x > 0 && direction.y < 0)
            {
                if (direction.x > 0.8)
                    spriteRenderer.sprite = right;
                else if (direction.y < -0.8)
                    spriteRenderer.sprite = down;
                if (direction.x <= 0.8 && direction.x >= 0.2)
                    spriteRenderer.sprite = downRight;
            }
            else if (direction.x < 0 && direction.y < 0)
            {
                if (direction.x < -0.8)
                    spriteRenderer.sprite = left;
                else if (direction.y < -0.8)
                    spriteRenderer.sprite = down;
                if (direction.x >= -0.8 && direction.x <= -0.2)
                    spriteRenderer.sprite = downLeft;
            }
        }
        else
        {
            HideDirection();
        }
    }
}
