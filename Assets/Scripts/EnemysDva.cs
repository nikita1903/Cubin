using UnityEngine;
using System.Collections;

public class EnemysDva : MonoBehaviour
{
    [SerializeField] public static Material izchez;
    [SerializeField] public static Mesh izchez2;
    [SerializeField] public static Material normal;
    [SerializeField] public static Mesh normal2;

    private static bool smena = false;
    private static bool inizh = false;

    public static bool update = false;

    int kolvo = 0;

    private bool kon = false;
    private void Start()
    {
        izchez = this.gameObject.GetComponent<MeshRenderer>().material;
        izchez2 = this.gameObject.GetComponent<MeshFilter>().mesh;
    }
    public void StartCor(){
        StartCoroutine(abcd());
    }
    public IEnumerator abcd()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if(kon == true)
            {
                for (int i = 0; i < 34; i++)
                {
                     SpawnObj.udal[i].SetActive(true);
                    SpawnObj.udal[i].transform.position = new Vector3(SpawnObj.udal[i].transform.position.x + 0.2f, SpawnObj.udal[i].transform.position.y, SpawnObj.udal[i].transform.position.z);
                    smena = true;
                    
                }
                StopAllCoroutines();
            }
            for (int i = 0; i < 34; i++)
            {
                if (!inizh)
                {
                    normal = SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshRenderer>().material;
                    normal2 = SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshFilter>().mesh;
                    inizh = true;
                }
                if (!smena) { 
                SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = izchez;
                SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshFilter>().mesh = izchez2;
                SpawnObj.udal[i].transform.position = new Vector3(SpawnObj.udal[i].transform.position.x + 0.2f, SpawnObj.udal[i].transform.position.y, SpawnObj.udal[i].transform.position.z);
                    this.gameObject.GetComponent<AudioSource>().Play();
                     }
                if (smena)
                {
                    SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = normal;
                    SpawnObj.udal[i].transform.GetChild(0).GetComponent<MeshFilter>().mesh = normal2;
                    SpawnObj.udal[i].transform.position = new Vector3(SpawnObj.udal[i].transform.position.x - 0.2f, SpawnObj.udal[i].transform.position.y, SpawnObj.udal[i].transform.position.z);
                }
            }
            if (!smena) smena = true;
            else smena = false;
            kolvo++;
            if(kolvo == 6)
            {
                for (int i = 0; i < 34; i++)
                {
                    SpawnObj.udal[i].SetActive(false);
                    kon = true;
                }
                }
        }
    }

}
