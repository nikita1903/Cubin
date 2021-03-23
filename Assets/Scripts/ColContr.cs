using UnityEngine;

public class ColContr : MonoBehaviour
{
    public bool isTrue = false;
    public void Start()
    {
        Invoke("af", 1f);
    }
    public void af()
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
        }

        if (collision.gameObject.tag == "en3")
        {
            Destroy(transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "patron")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            if (gameObject.tag == "en2")
            {
                PlayerControl.Money();

            }
            Destroy(transform.parent.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag != "en3")
        {
            if (collision.gameObject.tag == "en2")
            {
                Destroy(transform.parent.gameObject);
            }
            if (collision.gameObject.tag == "en")
            {
                Destroy(transform.parent.gameObject);
            }
            if (collision.gameObject.tag == "zonishe")
            {
                if (gameObject.tag == "en2")
                {
                    PlayerControl.Money();


                    Destroy(transform.parent.gameObject);
                }
                if (gameObject.tag == "en")
                {
                    Destroy(transform.parent.gameObject);
                }

            }

            if (collision.gameObject.tag == "en2")
            {
                PlayerControl.Money();


                Destroy(transform.parent.gameObject);
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "patron")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            if (gameObject.tag == "en2")
            {
                PlayerControl.Money();

            }
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("en"))
        {
            PlayerControl.Money();


            Destroy(transform.parent.gameObject);
        }
        if (other.gameObject.tag == "boss")
        {
            PlayerControl.Money();


            Destroy(transform.parent.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (gameObject.CompareTag("en3") && PlayerControl.konec == false)
        {
            var av = gameObject.transform.position;
            var av1 = PlayerControl.time;
            gameObject.transform.position = Vector3.Lerp(av, new Vector3(av.x, av.y, av.z - 2f), Time.fixedDeltaTime * av1);
        }

    }
}
