using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BatController bat;
    [SerializeField] float speed = 10f;
    [SerializeField] float speedIncrease;
    [SerializeField] int hitsAmount;

    public void Hit()
    {
        rb.velocity = new Vector2(-speed, 0);
        speed += speedIncrease;
        hitsAmount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bat"))
        {
            if (bat != null && bat.IsAbleToHit)
            {
                Hit();

                if(hitsAmount >= 10)
                {
                    StartCoroutine(HitPause());
                }
            }


            else
            {
                Debug.Log("LOSE");
            }
        }
        else if (collision.CompareTag("Wall"))
        {
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                Debug.LogError("Rigidbody2D (rb) is not assigned on BallController");
            }
        }
    }

    private IEnumerator HitPause()
    {
        // effects
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        Hit();

    }
}
