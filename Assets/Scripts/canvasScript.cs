using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{

    public Slider boosterBarSlider;  //reference for slider
    public Text currentAmmoText;
    public Text pauseText;
    public Button quitButton;
    private GameObject player;

    [HideInInspector]public bool paused;

    void Start()
    {
        player = GameObject.Find("player");
        paused = false;
        pauseText.GetComponent<Text>().enabled = paused;

        quitButton.onClick.AddListener(quitListener);
    }

    // Update is called once per frame
    void Update()
    {

        boosterBarSlider.value = 1f *
        (player.GetComponent<PlayerControl>().remainingBooster /
        player.GetComponent<PlayerControl>().maxBooster);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            UnityEngine.Cursor.visible = paused;
            //why aren't these two working????????????????????????????
            //pauseText.GetComponent<Text>().enabled = paused;
            //quitButton.GetComponent<Button>().interactable = paused;
            quitButton.gameObject.SetActive(paused);

            //why need BOTH for text????
            pauseText.GetComponent<Text>().enabled = paused;
            pauseText.gameObject.SetActive(paused);

            if (paused)
            {
                Time.timeScale = 0.0f;
                player.GetComponent<shootBullet>().aimLine.SetActive(false);
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }

        if (!player.GetComponent<shootBullet>().reloading)
        {
            currentAmmoText.text = player.GetComponent<shootBullet>().currentAmmo.ToString();
        }
        else
        {
            currentAmmoText.text = "Reloading...";
        }
    }

    public void quitListener()
    {
        Application.Quit();
    }
}