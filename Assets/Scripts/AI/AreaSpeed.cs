using UnityEngine;

public class AreaSpeed : MonoBehaviour
{
    [SerializeField] private float multiplier = 1.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            var ctrl = other.GetComponent<FallAgent>();
            if (ctrl != null) ctrl.SetSpeedMultiplier(multiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            var ctrl = other.GetComponent<FallAgent>();
            if (ctrl != null) ctrl.SetSpeedMultiplier(1f); 
        }
    }
}
