using UnityEngine;

public class Defence : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("en3") || other.gameObject.CompareTag("en") || other.gameObject.CompareTag("patron"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("boss"))
        {
            this.gameObject.SetActive(false);
        }

    }
}
