using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BossControl : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject turel1;
    [SerializeField] private bool turelCheck;
    [SerializeField] private GameObject patr;
    private GameObject[] puli = new GameObject[999];
    private int schet = 0;
    private void OnCollisionEnter(Collision collision)
    {
        var CG = collision.gameObject.tag;
        if (gameObject.CompareTag("boss"))
        {
            if (CG == "en3" || CG == "en")
            {
                Destroy(collision.transform.gameObject);
                return;
            }
            if (CG == "patron")
            {
                Destroy(collision.gameObject);
            }
        }
        
    }
    private void Start()
    {
        if (!gameObject.CompareTag("boss"))
        {
            StartCoroutine("abc");
        }
    }
    public IEnumerator abc()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(5f);
            if (!PlayerControl.konec)
            {
                GameObject thiss;
                var ito = gameObject.transform.position;
                thiss = Instantiate(patr, new Vector3(ito.x + 3f, ito.y + 0.75f, ito.z), Quaternion.identity); thiss.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
                puli[schet] = thiss;
                schet++;
            }
            else
            {
                for(int i = 0;i<puli.Length;i++){
                    Destroy(puli[i]);
                }
            }
        }
    }
    private void Update()
    {
        if(!gameObject.CompareTag("boss"))
        {
            if(turelCheck)
            gameObject.transform.LookAt(Cube.transform);
        }
    }
}
