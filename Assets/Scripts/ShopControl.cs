using TMPro;
using UnityEngine;
public class ShopControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Scire;
    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    [SerializeField] private GameObject Cube3;
    [SerializeField] private GameObject Cube4;
    private bool On = false;
    void Start()
    {
        if (Scire)
            Scire.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        if (!Scire && Cube1)
        {
            var aw = gameObject.GetComponent<Transform>().position;
            switch (PlayerPrefs.GetInt("Cube").ToString())
            {
                case "1":
                    SmenaSkina(Cube1);
                    break;
                case "2":
                    SmenaSkina(Cube2);
                    break;
                case "3":
                    SmenaSkina(Cube3);
                    break;
                case "4":
                    SmenaSkina(Cube4);
                    break;
            }
        }
    }
    void SmenaSkina(GameObject cubik)
    {
        var aw = gameObject.GetComponent<Transform>().position;
        gameObject.GetComponent<MeshFilter>().mesh = cubik.GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<Transform>().position = new Vector3(aw.x, aw.y, -2.02f);
        PlayerControl.skin = true;
        Destroy(gameObject.GetComponent<BoxCollider>());
        gameObject.AddComponent<BoxCollider>();
    }
    public void Pokupka()
    {
        if (On == false)
        {
            On = true;
            OnPokupka(On);
            return;
        }
        if (On == true)
        {
            On = false;
            OnPokupka(On);
        }
    }
    private void OnPokupka(bool isCan)
    {
        Cube1.SetActive(isCan);
        Cube2.SetActive(isCan);
        Cube3.SetActive(isCan);
        Cube4.SetActive(isCan);
    }
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Score") >= 30)
        {
            switch (gameObject.transform.parent.name)
            {
                case "Cube1":
                    ShopHelper(1);
                    break;
                case "Cube2":
                    ShopHelper(2);
                    break;
                case "Cube3":
                    ShopHelper(3);
                    break;
                case "Cube4":
                    ShopHelper(4);
                    break;
            }
            Scire.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
    private void ShopHelper(int NumCube)
    {
        PlayerPrefs.SetInt("Cube", NumCube);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 30);
    }
}
