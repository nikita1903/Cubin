using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI l1;
    [SerializeField] private TextMeshProUGUI l2;
    [SerializeField] private TextMeshProUGUI l3;
    [SerializeField] private TextMeshProUGUI l5;
    [SerializeField] private TextMeshProUGUI l6;
    private int lev;
    private int lev1;
    private void Start()
    {
        if (PlayerPrefs.GetInt("bilo") == 0)
        {
            PlayerPrefs.SetInt("level", 5);
            PlayerPrefs.SetInt("bilo", 1);
        }
        if (l1)
        {
            lev = PlayerPrefs.GetInt("level");
            Ustan(lev);
        }
        if (l5)
        {
            lev1 = PlayerPrefs.GetInt("uprav");
            Ustan1(lev1);
        }

    }
    public void going()
    {
        SceneManager.LoadScene(1);
    }
    public void mazad()
    {
        SceneManager.LoadScene(0);
    }
    public void SwitchLevel(int level)
    {
        if (level == 1) level = 4;
        if (level == 2) level = 5;
        if (level == 3) level = 6;

        PlayerPrefs.SetInt("level", level);
        Ustan(level);
    }
    private void Ustan(int level)
    {
        l1.GetComponent<TextMeshProUGUI>().color = Color.white;
        l2.GetComponent<TextMeshProUGUI>().color = Color.white;
        l3.GetComponent<TextMeshProUGUI>().color = Color.white;
        if (level == 4) l1.GetComponent<TextMeshProUGUI>().color = Color.green;
        if (level == 5) l2.GetComponent<TextMeshProUGUI>().color = Color.green;
        if (level == 6) l3.GetComponent<TextMeshProUGUI>().color = Color.green;
    }
    public void SwitchUpravlenie(int upr)
    {
        PlayerPrefs.SetInt("uprav", upr);
        Ustan1(upr);
    }
    private void Ustan1(int upr)
    {
        l5.GetComponent<TextMeshProUGUI>().color = Color.white;
        l6.GetComponent<TextMeshProUGUI>().color = Color.white;
        if (upr == 0) l5.GetComponent<TextMeshProUGUI>().color = Color.green;
        if (upr == 1) l6.GetComponent<TextMeshProUGUI>().color = Color.green;
    }
}
