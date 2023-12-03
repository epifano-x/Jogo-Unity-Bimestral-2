using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject objectToShow;

    public void OnButtonClick()
    {
        // Oculta o objeto que está visível
        if (objectToHide != null)
            objectToHide.SetActive(false);

        // Torna o objeto desejado visível
        if (objectToShow != null)
            objectToShow.SetActive(true);
    }
}
