using UnityEngine;

public class PopUp : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
}
