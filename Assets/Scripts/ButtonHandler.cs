using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject uiBox; // Assign the UI box GameObject in the Inspector
    public Vector2 uiBoxPosition; // Assign the position of the UI box in the Inspector

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenUIBox);
    }

    void OpenUIBox()
    {
        uiBox.transform.position = uiBoxPosition; // Set the position of the UI box
        uiBox.SetActive(true);
    }
}
