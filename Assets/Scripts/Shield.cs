using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public GameObject playerShield;
    public AudioSource aud;

    private bool mon = false;

    void Start()
    {
        StartCoroutine("abc");
    }

    public IEnumerator abc()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(10f);
            GameObject vrem;
            int rands = Random.Range(0, 400);
            vrem = SpawnObj.eti[rands];
            
            for(int i = 0;i<999;i++){
                if(rands == Enemys.numbers[i]){
mon = true;
                }
            }
            if((int)rands % 2 == 1 && !mon){
            GameObject etot;
            etot = Instantiate(shield, new Vector3(vrem.transform.GetChild(0).position.x + 0.35f, 0.2f, vrem.transform.GetChild(0).position.z + 0.15f), Quaternion.identity);
                        etot.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                        etot.transform.GetChild(0).gameObject.AddComponent<ShieldControl>();
                        etot.transform.GetChild(0).gameObject.GetComponent<ShieldControl>().playerShield = playerShield;
                        etot.transform.GetChild(0).gameObject.GetComponent<ShieldControl>().aud = aud;
                        etot.transform.SetParent(this.gameObject.transform, true);
            for(int i = 0;i<Enemys.numbers.Length;i++){
                if(Enemys.numbers[i] == 0){
 Enemys.numbers[i] = rands;
 break;
                }
            }
            }
            mon = false;
        }
    }
}
