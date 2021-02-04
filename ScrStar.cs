using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrStar : MonoBehaviour
{
    public string property;

    private void Start()
    {
        if (PlayerPrefs.GetInt(property) == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject controller = GameObject.FindGameObjectWithTag("Controller");
            GameObject infoPanel = controller.GetComponent<ScrLevelController>().infoPanel;
            infoPanel.GetComponent<ScrInfoPanel>().star.sprite = infoPanel.GetComponent<ScrInfoPanel>().starSprite;
            GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayStarSound();
        }
    }
}
