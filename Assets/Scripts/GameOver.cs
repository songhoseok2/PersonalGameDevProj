using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Button retryButton;
    public Button quitButton;

    public AudioClip playerDeathSound;
    public AudioClip defeatSound;

    // Use this for initialization
    void Start ()
    {
        UnityEngine.Cursor.visible = true;

        retryButton.onClick.AddListener(retryListener);
        quitButton.onClick.AddListener(quitListener);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position);
        StartCoroutine(defeatMessage());
    }

    IEnumerator defeatMessage()
    {
        yield return new WaitForSeconds(2);
        AudioSource.PlayClipAtPoint(defeatSound, Camera.main.transform.position);
    }

    public void retryListener()
    {
        Application.LoadLevel("level 1");
    }

    public void quitListener()
    {
        Application.Quit();
    }
}
