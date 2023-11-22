using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float speed = 10f;
    [SerializeField] float speedIncrease;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        rb.velocity = new Vector2(-speed, 0);
        speed += speedIncrease;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            Hit();
        }
    }
}
