using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject cub;
    [SerializeField] private GameObject mina;
    [SerializeField] private GameObject brevno;
    [SerializeField] private GameObject money;

    [SerializeField] private GameObject pol;
    private GameObject vrem;
    private GameObject vrem2;
    private GameObject etot;
    public GameObject etot2;
    private bool den = false;

    public bool bilo = false;

    private int dlBrev = 0;

    public float pribav = 3;

    public static bool isTrue;

    public static int[] numbers = new int[999];

    public bool mon = false;

    private void Awake()
    {
        pribav = 2;
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(pribav);
            if (den == false) dengi();
            if (PlayerControl.konec) StopAllCoroutines();
            den = true;
            int randoms = Random.Range(0, 4);
            int rands = Random.Range(0, 400);
            vrem = SpawnObj.eti[rands];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = rands;
                    break;
                }
            }

            if (vrem != PlayerControl.NaKakom)
            {
                if (randoms == 0)
                {
                    etot = Instantiate(mina, new Vector3(vrem.transform.GetChild(0).position.x + 0.35f, 0.2f, vrem.transform.GetChild(0).position.z + 0.15f), Quaternion.identity);
                    EnemySpawnHelper(etot,"en",true);
                    this.gameObject.GetComponent<AudioSource>().Play();
                    etot.transform.SetParent(this.gameObject.transform, true);
                }
                if (randoms == 1)
                {
                    etot = Instantiate(Enemy1, gameObject.transform.position, Quaternion.identity);
                    Vector3 spawnPosition = new Vector3(vrem.transform.GetChild(0).position.x, 0.21f, vrem.transform.GetChild(0).position.z);
                    etot.transform.position = spawnPosition;
                    etot.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    EnemySpawnHelper(etot,"en",false);
                    etot.transform.GetChild(0).gameObject.GetComponent<ColControl>().Enemy1 = etot.transform.GetChild(0).gameObject;
                    etot.transform.GetChild(0).gameObject.GetComponent<ColControl>().cub = cub;
                    etot.transform.SetParent(this.gameObject.transform, true);
                }
            }
            if (randoms == 2 && !bilo) { pol.GetComponent<EnemysDva>().StartCor(); bilo = true; }
            if (randoms == 3)
            {
                if (dlBrev == 0)
                {
                    vrem = SpawnObj.DlyaBrevna[Random.Range(0, 6)];
                    etot = Instantiate(brevno, new Vector3(vrem.transform.GetChild(0).position.x + 0.3f, 1.1f, vrem.transform.GetChild(0).position.z + 12.15f), Quaternion.identity);
                    etot.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    EnemySpawnHelper(etot,"en3",true);
                    etot.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().useGravity = false;
                    etot.transform.SetParent(this.gameObject.transform, true);
                    dlBrev++;
                }
                else
                {
                    dlBrev = 0;
                }
            }

            if (pribav > 0.5f)
            {
                pribav -= 0.05f;
            }

        }
    }
    private void EnemySpawnHelper(GameObject _etot, string teg, bool isContr)
    {
        _etot.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
        if (isContr) _etot.transform.GetChild(0).gameObject.AddComponent<ColContr>();
        else _etot.transform.GetChild(0).gameObject.AddComponent<ColControl>();
        _etot.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        _etot.transform.GetChild(0).gameObject.tag = teg;
        _etot.transform.SetParent(this.gameObject.transform, true);
    }


    public void dengi()
    {
        int rands = Random.Range(0, 174);
        if (rands % 2 == 1)
        {

            vrem2 = SpawnObj.eti[rands];
            if (vrem2 == PlayerControl.NaKakom)
            {
                dengi();
            }
            etot2 = Instantiate(money, new Vector3(vrem2.transform.GetChild(0).position.x + 0.4f, 0.2f, vrem2.transform.GetChild(0).position.z + 0.15f), Quaternion.identity);
            etot2.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
            etot2.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = true;
            etot2.transform.GetChild(0).gameObject.AddComponent<ColContr>();
            etot2.transform.GetChild(0).gameObject.tag = "en2";
        }
        else
        {
            dengi();
        }
    }
}
