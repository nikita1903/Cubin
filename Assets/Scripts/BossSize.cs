using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSize : MonoBehaviour
{
    public int schet = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("abc");
    }

    public IEnumerator abc()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1f);
            if (!PlayerControl.konec && schet <= 25) 
            {
                schet++;
                gameObject.transform.localScale = new Vector3(0.5f + (schet*0.02f),0.5f + (schet*0.02f),0.5f + (schet*0.02f));
                
            }
        }
    }
}
