using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    //Наш объект.
    public Rigidbody Cubic;
    public bool a;
    private int napr;
    private float kolX = 0;
    private float kolY = 0;
    private float kolZ = 0;
    private int score = 0;
    public GameObject scoreT;
    public GameObject Record;

    private AudioSource mon;
    private AudioSource expl;
    public static GameObject NaKakom;

    [SerializeField] private GameObject patron;

    private GameObject thiss;

    private int naprav = 0;// счётчик узнать направление

    private bool kon = false;//узнать конец

    public static bool skin = false;

    [SerializeField] private Button Menu;
    [SerializeField] private Button Again;
    [SerializeField] private GameObject Korona;
    [SerializeField] private GameObject Vrag;
    public static float time = 1;
    public float check;
    public int naX = 31;
    public int naZ = 6;
    Vector3 hitPoint;

    [SerializeField] private GameObject flag;

    public static bool konec;

    public Joystick joy;
    public float moveIn;
    public Vector2 iax;
    public Vector3 moven;

    public GameObject[] knopki;

    [SerializeField] private GameObject shield;

    [SerializeField] private GameObject EnemyController;
    [SerializeField] private static GameObject _EnemyController;

    private void Awake()
    {
        konec = false;
        time = 1;
        Cubic = GetComponent<Rigidbody>();
        expl = transform.GetChild(0).GetComponent<AudioSource>();
        mon = GetComponent<AudioSource>();

    }
    private void Start()
    {
        var g = Cubic.transform.position;
        Cubic.transform.position = new Vector3(g.x + 8f, g.y, 6f);
        if (PlayerPrefs.GetInt("uprav") == 1)
        {
            knopki[0].SetActive(false);
            knopki[1].SetActive(false);
            knopki[2].SetActive(false);
            knopki[3].SetActive(false);
            joy.gameObject.SetActive(true);
        }
        naX = 31;
        Record.GetComponent<TextMeshPro>().text = "Record: " + PlayerPrefs.GetInt("MaxScore");
        _EnemyController = EnemyController;
    }
    private void Update()
    {
        RaycastHit hit;
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        //пускаем луч
        Physics.Raycast(ray, out hit);
        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            NaKakom = hit.collider.gameObject.transform.parent.gameObject;
        }
    }
    public void OnButtonVerx()
    {
        ButtonHelper(0, 0, 8);

    }
    public void OnButtonVniz()
    {
        ButtonHelper(2, 0, -8);

    }
    public void OnButtonVlevo()
    {
        ButtonHelper(3, -8, 0);

    }
    public void OnButtonVpravo()
    {
        ButtonHelper(1, 8, 0);
    }
    private void ButtonHelper(int direct, int iks, int zed)
    {
        if (a == false)
        {
            naprav = direct;
            StartCoroutine(Lerpp(1f / time, iks, zed));
            a = true;
        }
    }
    private IEnumerator Lerpp(float duration, float kolax, float kolze)
    {
        if (kon) StopAllCoroutines();
        kolX = kolax;
        kolZ = kolze;
        var av = Cubic.transform.position;
        var endPos = new Vector3(av.x + kolX, av.y + kolY, av.z + kolZ);
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            if (kon == false)
            {
                Cubic.transform.position = Vector3.Lerp(av, new Vector3(av.x + kolX, av.y + kolY, av.z + kolZ), timeElapsed / duration);
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        if (naprav == 0)
            naZ += 8;
        if (naprav == 1)
            naX += 8;
        if (naprav == 2)
            naZ -= 8;
        if (naprav == 3)
            naX -= 8;
        if (kon == false)
        {
            Cubic.gameObject.transform.position = new Vector3(naX, Cubic.transform.position.y, naZ);
        }
        if (time <= PlayerPrefs.GetInt("level"))
            time += 0.05f;
        check = time;
        a = false;
    }
    public void OnButtonVverx()
    {
        if (a || kon) return;
        var ito = gameObject.transform.position;
        if (naprav == 0) { FireHelper(ito.x, ito.y + 0.75f, ito.z + 3f, 0, 0, 1); }
        if (naprav == 1) { FireHelper(ito.x + 3f, ito.y + 0.75f, ito.z, 1, 0, 0); }
        if (naprav == 2) { FireHelper(ito.x, ito.y + 0.75f, ito.z - 3f, 0, 0, -1); }
        if (naprav == 3) { FireHelper(ito.x - 3f, ito.y + 0.75f, ito.z, -1, 0, 0); }
    }
    private void FireHelper(float _x, float _y, float _z, int d1, int d2, int d3)
    {
        thiss = Instantiate(patron, new Vector3(_x, _y, _z), Quaternion.identity);
        thiss.GetComponent<Rigidbody>().velocity = new Vector3(d1, d2, d3) * 99f;
    }
    private void FixedUpdate()
    {
        moveIn = Mathf.Atan2(joy.Vertical, joy.Horizontal) * Mathf.Rad2Deg;
        if (joy.Horizontal != 0 && joy.Vertical != 0)
        {
            if (joy.Vertical > 0.5 || joy.Horizontal > 0.5 || joy.Vertical < -0.5f || joy.Horizontal < -0.5f)
            {
                if (moveIn < 55 && moveIn > -55)
                    OnButtonVpravo();
                if (moveIn < -155)
                    OnButtonVlevo();
                if (moveIn > 155)
                    OnButtonVlevo();
                if (moveIn > 55 && moveIn < 155)
                    OnButtonVerx();
                if (moveIn < 55 && moveIn > -155)
                    OnButtonVniz();
            }
        }
        iax = joy.Direction;
        if (kon) return;
        var av1 = Cubic.transform.position;
        Vrag.transform.position = Vector3.Lerp(Vrag.transform.position, new Vector3(av1.x, av1.y, av1.z), Time.deltaTime * 0.2f * time);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (kon) return;
        if (collision.gameObject.name == "Zona (1)")
        {
            ColHelper(collision);

        }
        if (collision.gameObject.tag == "en")
        {

            if (collision.gameObject.name == "default1")
            {
                ColHelper(collision);

            }
            else
            {
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.tag == "en3")
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            ColHelper(collision);

        }
        if (collision.gameObject.CompareTag("boss"))
        {
            ColHelper(collision);

        }
        if (collision.gameObject.CompareTag("patron"))
        {
            ColHelper(collision);

            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "en2")
        {
            Destroy(other.transform.parent.gameObject);
            mon.Play();
            score++;
            scoreT.GetComponent<TextMeshPro>().text = "Score: " + score.ToString();
            EnemyController.GetComponent<Enemys>().dengi();
        }
    }
    public static void Money(){
        _EnemyController.GetComponent<Enemys>().dengi();
    }
    private void ColHelper(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 posit = contact.point;
        var g = Instantiate(flag, new Vector3(posit.x + 2f, 1f, posit.z - 1f), Quaternion.Euler(0, 0, 0));
        die();
    }
    private void die()
    {
        if (score > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);

        expl.Play();
        Cubic.isKinematic = true;
        kon = true;
        konec = true;
        Menu.gameObject.SetActive(true);
        Again.gameObject.SetActive(true);
        Korona.gameObject.SetActive(true);
    }

}