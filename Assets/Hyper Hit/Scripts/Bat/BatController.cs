using UnityEngine;

public class BatController : MonoBehaviour, IBat
{
    public Animator BatAnimator;
    private bool isAbleToHit = true;
    public bool IsAbleToSwing = true;
    public int HitsAmount;
    
    public bool IsAbleToHit
    {
        get { return isAbleToHit; }
        private set { isAbleToHit = value; }
    }

    public void MoveBat(Vector3 newPosition)
    {
        transform.position = newPosition;
        BatHit();
    }

    public void CantHit() => IsAbleToHit = false;

    public void CanHit() => IsAbleToHit = true;

    public void CanSwing() => IsAbleToSwing = true;
    public void CantSwing() => IsAbleToSwing = false;


    public void HideBat() => gameObject.SetActive(false);

    public bool CanItHit()
    {
        return IsAbleToHit;
    }

    public bool ShouldPauseAnimation()
    {
        return HitsAmount >= 3;
    }

    public void BatHit()
    {
        if (IsAbleToSwing)
        {
            gameObject.SetActive(true);
            BatAnimator.SetTrigger("Hit");
        }
    }
}
