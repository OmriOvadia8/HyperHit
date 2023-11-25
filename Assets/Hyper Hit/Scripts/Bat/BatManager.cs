using System.Collections;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    [SerializeField] private BatController batController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && batController.IsAbleToSwing)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = batController.transform.position.z;
            batController.MoveBat(mouseWorldPosition);
        }
    }
}
