using UnityEngine;

public class TattooInteract : MonoBehaviour
{
    [SerializeField] Transform controllerTransform;
    [SerializeField] bool isHoldingTattoo;
    [SerializeField] LayerMask bodyLayer;

    public void EnableTattooHoldBool()
    {
        isHoldingTattoo = true;
    }

    public void DisableTattooHoldBool()
    {
        isHoldingTattoo = false;
    }

    void Update()
    {
        if (!isHoldingTattoo) return;
        HandleTattooPlacement();
    }

    void HandleTattooPlacement()
    {
        Ray ray = new Ray(controllerTransform.position, controllerTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 5, bodyLayer))
        {
            
        }
    }
}
