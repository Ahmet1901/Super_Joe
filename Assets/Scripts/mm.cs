using UnityEngine;

using UnityEngine.SceneManagement;

public class mm : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ba()
    {
        int i = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(i);
    }
    public void q()
    {
        Application.Quit();
    }
    public void s()
    {
        SceneManager.LoadScene(0);
    }
    public void t()
    {

        SceneManager.LoadScene(0);
    }
}
