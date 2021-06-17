using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DeadMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTXT, bestScoreTXT;
    private void Update()
    {
        scoreTXT.text = Player.instance.playerStats.Score.ToString();
        bestScoreTXT.text = Player.instance.playerStats.GetHighScore().ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
