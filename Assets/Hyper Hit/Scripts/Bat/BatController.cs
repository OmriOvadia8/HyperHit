using UnityEngine;

public class BatController : MonoBehaviour, IBat
{
    [SerializeField] private Animator animator;
    private bool isAbleToHit = true;
    public bool IsAbleToHit
    {
        get { return isAbleToHit; }
        private set { isAbleToHit = value; }
    }

    public void CantHit() => IsAbleToHit = false;

    public void CanHit() => IsAbleToHit = true;

    public void HideBat() => gameObject.SetActive(false);

    public bool CanItHit()
    {
        return IsAbleToHit;
    }

    public void BatHit()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("Hit");
    }
}
