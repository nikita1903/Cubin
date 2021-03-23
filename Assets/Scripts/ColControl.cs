using UnityEngine;

public class ColControl : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject cub;
    public void Start()
    {
        Invoke("ChangeName", 1f);
    }
    public void ChangeName()
    {
        this.gameObject.name = this.gameObject.name + "1";
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Zona (1)":
                Destroy(transform.parent.gameObject);
                break;
            case "mina(Clone)":
                Destroy(transform.parent.gameObject);
                break;
        }
        switch (collision.gameObject.tag)
        {
            case "en":
                Destroy(transform.parent.gameObject);
                break;
            case "en2":
                PlayerControl.Money();
                Destroy(transform.parent.gameObject);
                break;
            case "patron":
                Destroy(transform.parent.gameObject);
                collision.gameObject.GetComponent<AudioSource>().Play();
                Destroy(collision.gameObject);
                break;
        }
    }
    private void FixedUpdate()
    {
        if (PlayerControl.konec) return;
        var av = Enemy1.transform.position;
        var av1 = PlayerControl.time;
        Enemy1.transform.position = Vector3.Lerp(av, new Vector3(av.x, av.y, av.z - 2f), Time.fixedDeltaTime * av1);
    }
}
