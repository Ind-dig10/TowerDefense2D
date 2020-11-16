using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnClickStart);
        exitButton.onClick.AddListener(OnClickExit);
    }

    private void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    private void OnClickExit()
    {
        Application.Quit();
    }

}
