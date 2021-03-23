using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject cubic;
    [SerializeField] private bool pointerdown;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerdown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Res();
    }
    public void Res()
    {
        pointerdown = false;
    }
    private void Update()
    {
        if (pointerdown)
        {
            switch (gameObject.name)
            {
                case "Verx":
                    cubic.GetComponent<PlayerControl>().OnButtonVerx();
                    break;
                    
                    case "Vniz":
                    cubic.GetComponent<PlayerControl>().OnButtonVniz();

                    break;
                    case "Left":
                    cubic.GetComponent<PlayerControl>().OnButtonVlevo();

                    break;
                    case "Right":
                    cubic.GetComponent<PlayerControl>().OnButtonVpravo();

                    break;
            }
        }
    }
}
