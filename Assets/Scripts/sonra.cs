using UnityEngine;
using UnityEngine.SceneManagement;

public class sonra : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int i = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(i);
        }
    }
}
