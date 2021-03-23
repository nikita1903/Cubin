using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField] private GameObject pol;
    private GameObject etot;
    public static GameObject[] eti = new GameObject[500];
    public static GameObject[] udal = new GameObject[100];
    public static GameObject[] DlyaBrevna = new GameObject[100];
    int a = 0;
    private void Start()
    {
        int randam = Random.Range(0, 24);
        for (int j = 1; j <= 17; j++)
        {
            for (int i = 0; i < 25; i++)
            {
                etot = Instantiate(pol, new Vector3((3f + j*4) -8.25f, 0.1f, -4f + i * 4), Quaternion.identity);
                etot.transform.SetParent(this.gameObject.transform, true);
                eti[i + 25 * (j - 1)] = etot;
                if(i == randam)
                {
                    udal[a] = etot;
                    a++;
                }
                if(i == randam + 1)
                {
                    udal[a] = etot ;
                    a++;
                }
                if(i == 24)
                {
                    DlyaBrevna[j - 1] = etot; 
                }
            }
        }
    }
}
