using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TopUIManager : MonoBehaviour
{
    public TextMeshProUGUI topScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI vitalityText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI maxScoreText;
    private SoundManager soundManager;

    public static int maxScore;
    public int score;
    public int vitality;

    public GameObject gameOver;
    public GameObject menu;
    public bool gameStop;

    public List<GameObject> SoundOnOFF;
    public static bool BGM = true;
    public static bool soundEffect = true;
    public List<Sprite> soundBtSprite;
    public List<Image> soundBtImg;
    // Start is called before the first frame update


    private void Start()
    {
        Time.timeScale = 1;
        soundManager = FindObjectOfType<SoundManager>();

        if (vitality != 3)
        {
            vitality = 4;
        }
        if (!PlayerPrefs.HasKey("TOP_Score"))
        {
            PlayerPrefs.SetInt("TOP_Score", 0);
        }
        else
        {
            maxScore = PlayerPrefs.GetInt("TOP_Score");
        }
    }
    // stopTimer == true
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt("TOP_Score", 0);
        }
        Sound();

        if (maxScore < score)
        {
            maxScore = score;
            PlayerPrefs.SetInt("TOP_Score", maxScore);
        }

        if (vitality <= 0)
        {
            gameOver.SetActive(true);
            gameStop = true;
            vitalityText.text = "× " + 0;
            Time.timeScale = 0;
        }

        topScoreText.text = "Top : " + maxScore + "점";
        scoreText.text = score + "점";
        vitalityText.text = "× " + vitality;
        gameOverScoreText.text = "점수 : " + score;
        maxScoreText.text = "최고 점수 : " + maxScore;
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
    }

    public void RemoveVitality(int removeVitality)
    {
        vitality -= removeVitality;
    }

    public void Re()
    {
        soundManager.PlayButtonSound();
        SceneManager.LoadScene(0);
    }

    public void MenuBT()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        gameStop = true;
    }

    public void OutMenuBT()
    {
        Time.timeScale = 1;
        gameStop = false;
        menu.SetActive(false);
    }

    public void BGMBT()
    {
        if (!BGM)
        {
            BGM = true;
            SoundOnOFF[0].SetActive(true);
        }
        else
        {
            BGM = false;
            SoundOnOFF[0].SetActive(false);
        } 
    }

    public void SoundEffect()
    {
        if (!soundEffect)
        {
            soundEffect = true;
            SoundOnOFF[1].SetActive(true);          
        }
        else
        {
            soundEffect = false;
            SoundOnOFF[1].SetActive(false);           
        }
    }
    public void Sound()
    {
        if (BGM)
        {
            SoundOnOFF[0].SetActive(true);
            soundBtImg[0].sprite = soundBtSprite[0];
        }
        else
        {
            SoundOnOFF[0].SetActive(false);
            soundBtImg[0].sprite = soundBtSprite[1];
        }

        if (soundEffect)
        {
            SoundOnOFF[1].SetActive(true);
            soundBtImg[1].sprite = soundBtSprite[2];
        }
        else
        {
            SoundOnOFF[1].SetActive(false);
            soundBtImg[1].sprite = soundBtSprite[3];
        }
    }
}
