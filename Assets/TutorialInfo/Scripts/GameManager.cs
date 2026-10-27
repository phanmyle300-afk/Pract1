using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas GameMenu;
    private bool isShowingMenu = false;

    public TMP_Text Title;
    public TMP_Text Message;
    public Button ContinueButton;
    public Button RestartButton;

    void Start()
    {
        if (GameMenu != null) GameMenu.enabled = isShowingMenu;

        if (Title != null) Title.text = "Welcome to Unity!";
        if (Message != null) Message.text = "Do you want continue?";
        
        if (ContinueButton != null)
        {
            var btnText = ContinueButton.GetComponentInChildren<TMP_Text>();
            if (btnText != null) btnText.text = "Enter";
        }
        
        if (RestartButton != null)
        {
            var btnText = RestartButton.GetComponentInChildren<TMP_Text>();
            if (btnText != null) btnText.text = "Restart";
        }
    }

    // Hàm này dùng để bật menu lên khi máy bay đụng tường
    public void ShowMenu()
    {
        isShowingMenu = true;
        if (GameMenu != null)
        {
            GameMenu.enabled = true;
            Debug.Log("Đã bật GameMenu thành công qua GameManager!");
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("scene_01"); 
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}