using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TattooInteract : MonoBehaviour
{
    [SerializeField] Transform controllerTransform;
    [SerializeField] bool isHoldingTattoo;
    [SerializeField] LayerMask bodyLayer;
    [SerializeField] DecalProjector projector;
    [SerializeField, Min(0f)] float surfaceOffset = 0.1f;

    RaycastHit hit;

    public void TattooStartInteract()
    {
        isHoldingTattoo = true;
        Debug.Log("Tattoo interacted");
    }

    public void TattooStopInteract()
    {
        Debug.Log("Tattoo stop interacted");
        if (hit.collider != null && hit.transform.CompareTag("Body"))
        {
            Debug.Log("Tattoo placed");
        }

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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, bodyLayer))
        {
            projector.enabled = true;
            projector.transform.position = hit.point + hit.normal * surfaceOffset;
            projector.transform.forward = -hit.normal;
            projector.transform.rotation = controllerTransform.rotation;
        }
        else
        {
            projector.enabled = false;
        }
    }
}