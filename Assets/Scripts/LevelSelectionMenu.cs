using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public Button level1Buttons;
    public Button level2Buttons;
    public Button level3Buttons;
    public Button backButton;

    void Start()
    {
        level1Buttons.onClick.AddListener(() => LoadLevel(2));
        level2Buttons.onClick.AddListener(() => LoadLevel(3));
        level3Buttons.onClick.AddListener(() => LoadLevel(4));
        backButton.onClick.AddListener(BackToMainMenu);
    }

    void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
