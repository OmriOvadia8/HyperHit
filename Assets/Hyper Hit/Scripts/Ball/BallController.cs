using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BatController bat;
    [SerializeField] float speed = 10f;
    [SerializeField] float speedIncrease;

    private void Start() => rb.velocity = Vector2.zero;

    public void Hit()
    {
        bat.DidHit = true;
        float angle = Random.Range(90f, 270f);
        Vector2 direction = new(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.velocity = direction * speed;
        speed += speedIncrease;
        bat.HitsAmount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bat"))
        {
            if (bat != null && bat.IsAbleToHit && !bat.DidHit)
            {
                if (bat.ShouldPauseAnimation())
                {
                    StartCoroutine(HitPause());
                }

                else
                {
                    Hit();
                }
            }

            else
            {
                Debug.Log("LOSE");
            }
        }
    }

    private IEnumerator HitPause()
    {
        rb.velocity = Vector2.zero;
        bat.BatAnimator.speed = 0;
        yield return new WaitForSeconds(1);
        bat.BatAnimator.speed = 1;
        Hit();
    }
}
