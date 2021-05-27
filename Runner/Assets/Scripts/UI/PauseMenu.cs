using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    private float lastTimeScale = 1;
    public void OnPauseButtonClicked()
    {
        if (GameManager.Instance.gameStarted)
        {
            Animator animator = this.transform.GetComponentInChildren<Animator>();
            bool state = GameManager.Instance.gamePaused;
            if (state)
            {
                animator.SetTrigger("UnPause");
                GameManager.Instance.UnPauseGame(lastTimeScale);
            }
            else
            {
                animator.SetTrigger("Pause");
                lastTimeScale = Time.timeScale;
                GameManager.Instance.PauseGame();
            }

            for (int i = 0; i < this.transform.childCount - 1; ++i)
            {
                this.transform.GetChild(i).gameObject.SetActive(!state);
            }
        }
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
