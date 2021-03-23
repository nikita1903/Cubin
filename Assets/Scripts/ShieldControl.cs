using UnityEngine;

public class ShieldControl : MonoBehaviour
{
    public GameObject playerShield;
    public AudioSource aud;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            if (collision.gameObject.CompareTag("patron"))
                Destroy(collision.gameObject);
            Destroy(this.gameObject); 
            return;
        }
        playerShield.SetActive(true);
        aud.Play();
        Destroy(this.gameObject);
    }
}
