using UnityEngine;

public class BatController : MonoBehaviour, IBat
{
    public Animator BatAnimator;
    [SerializeField] private Collider2D batCollider;
    [SerializeField] private int effectMilestone;
    [SerializeField] private int pauseMilestone;

    public int HitsAmount;
    public bool IsAbleToHit { get; private set; } = true;
    public bool IsAbleToSwing { get; private set; } = true;
    public bool DidHit = false;

    public void MoveBat(Vector3 newPosition)
    {
        if (IsAbleToSwing)
        {
            transform.position = newPosition;
            BatHit();
        }
    }

    public void StartOfHitting() // this is executed via the unity animation event (specific frame)
    {
        CanHit();
        DisableSwing();
        EnableCollider();
        ResetHit();
    }

    public void MiddleOfHitting() // this is executed via the unity animation event (specific frame)
    {
        DisableHit();
        DisableSwing();
        DisableCollider();
    }

    public void EndOfHitting() // this is executed via the unity animation event (specific frame)
    {
        CanHit();
        EnableSwing();
        HideBat();
    }

    public void ResetHit() => DidHit = false;
    public void DisableHit() => IsAbleToHit = false;
    public void CanHit() => IsAbleToHit = true;
    public void DisableCollider() => batCollider.enabled = false;
    public void EnableCollider() => batCollider.enabled = true;
    public void EnableSwing() => IsAbleToSwing = true;
    public void DisableSwing() => IsAbleToSwing = false;
    public void HideBat() => gameObject.SetActive(false);

    private void BatHit()
    {
        gameObject.SetActive(true);
        BatAnimator.SetTrigger("Hit");
    }

    public bool ShouldPauseAnimation() => HitsAmount >= pauseMilestone;
    public bool ShouldEffectsAnimation() => effectMilestone >= HitsAmount && effectMilestone < pauseMilestone;
}
