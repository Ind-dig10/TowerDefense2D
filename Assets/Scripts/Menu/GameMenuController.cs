using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    private void Start()
    {
        exitButton.onClick.AddListener(ExitButton);
    }

    private void ExitButton()
    {
        SceneManager.LoadScene(0);
    }


}
