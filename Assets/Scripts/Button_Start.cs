using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Start : MonoBehaviour
{
    public Button button_start;
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //LALALALALAALAA 
    /*public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("GLORIOUS EVOLUTION HAHAHAHA");
    }
*/
    void Start()
    {
        if (button_start != null)
        {
            button_start.onClick.AddListener(LoadScene);
            Debug.Log("GLORIOUS EVOLUTION HAHAHAHA");
        }
    }
}
