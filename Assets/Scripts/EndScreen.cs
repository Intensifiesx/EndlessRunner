using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] UpdateUI updateUI;

    public void Respawn()
    {
        endScreen.SetActive(false);
        updateUI.SetBestDistance();
        Time.timeScale = 0.6f;
        // loop to increment the timeScale by 0.05f every 0.1 seconds
        StartCoroutine(IncreaseTimeScale());
        foreach (GameObject trap in GameObject.FindGameObjectsWithTag("Trap"))
        {
            trap.GetComponent<BoxCollider2D>().enabled = false;
            trap.GetComponent<SpriteRenderer>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1f);
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator IncreaseTimeScale()
    {
        while (Time.timeScale < 1)
        {
            yield return new WaitForSeconds(0.2f);
            Time.timeScale += 0.05f;
        }
        Time.timeScale = 1;
    }
}
