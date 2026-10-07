using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TattooPicker : MonoBehaviour
{
    public Material butterfly;
    public Material cat;
    public DecalProjector projector;
    public TMP_Dropdown dropdown;

    public void UpdateTattoo()
    {
        switch (dropdown.value)
        {
            case 0:
                projector.material = butterfly;
                break;
            case 1:
                projector.material = cat;
                break;
            default:
                projector.material = butterfly;
                break;
        }
    }
}