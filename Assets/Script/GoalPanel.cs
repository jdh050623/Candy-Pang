using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoalPanel : MonoBehaviour
{
    public Image thisImage;
    public Image thisHumanImage;
    public Sprite thisSprite;
    public Text thisText;
    public string thisString;
    public string matchValue;
    public int numNeeded;//ªÁ≈¡ ∏Ò«•ƒ°
    public int numCollected;//ªÁ≈¡ ∏Ò«• ¥ﬁº∫∑¸
    public GameObject Goal;

    private SoundManager soundManager;
    private TopUIManager topUIManager;

    [Header("customer")]
    public List<string> c_matchValue;
    public List<Sprite> c_sprite;
    public List<Sprite> HumanSprite;

    public GameObject text;

    private bool thief;
    private bool badCustomer;
    private bool customer;

   [Header("Timer")]
    public Slider timerSlider;
    public float setGameTime;
    public float getGameTime;
    public bool stopTimer;
    private float startTime;
    public float time;
    private float getTime;
    private bool vitalityStop;
    // Start is called before the first frame update


    public void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        topUIManager = FindObjectOfType<TopUIManager>();
        getTime = setGameTime;
        setGameTime = getTime;
        order();
        StartTimer();
        StartCoroutine(PreventionLifeBugging());
    }

    void StartTimer()
    {
        
        getGameTime = setGameTime;
        stopTimer = false;
        timerSlider.maxValue = getGameTime;
        timerSlider.value = getGameTime;
        
    }

    void order()
    {
        customer = false;
        badCustomer = false;
        thief = false;
        //¡÷πÆº≠ ªÃ±‚
        int i = Random.Range(0, 6);
        matchValue = c_matchValue[i];
        thisImage.sprite = c_sprite[i]; ;
        thisText.text = thisString;

        //º’¥‘ ªÃ±‚
        int j1 = Random.Range(0, 10);//º’¥‘ ªÃ±‚
        int j2 = Random.Range(0, 3);//º’¥‘ ª˝±Ëªı (µµµœ ¡¶ø‹)

        if (j1 >= 0 && j1<= 7) //¿œπ›º’¥‘
        {
            thisHumanImage.sprite = HumanSprite[j2];
            customer = true;
        }

        if(j1 == 8) // ¡¯ªÛ º’¥‘
        {
            thisHumanImage.sprite = HumanSprite[j2];
            badCustomer = true;
        }

        if (j1 == 9) //µµµœ
        {
            matchValue = null;
            thisImage.sprite = c_sprite[6];
            thisHumanImage.sprite = HumanSprite[3];
            thief = true;
            setGameTime = 3f;
        }
    }

    public void Update()
    {
        UpdateGoals();
        UpdateTimer();
        if (thief)
        {
            text.SetActive(false);
        }

        if (!thief)
        {
            text.SetActive(true);
        }
    }

    public void CompareGoal(string goalToCompare)
    {
        if (goalToCompare == matchValue)
        {
            numCollected++;
        }
    }

    public void UpdateGoals()
    {
        thisText.text = "" + numCollected + " / " + numNeeded;
        if (numCollected >= numNeeded)
        {
            thisText.text = "" + numNeeded + " / " + numNeeded;
            topUIManager.IncreaseScore(1);
            Debug.Log("¡°ºˆ∞° ø¿∏ß");
            evicting();
        }    
    } 

    void UpdateTimer()
    {  
        time = Time.time - startTime;
        if (time >= getGameTime)
        {
            stopTimer = true;
        }

        if(stopTimer == true)
        {
            //if (topUIManager.gameStop == false)
            //{
                Debug.Log("Ω√∞£√ ∞˙");
                stopTimer = false;
                evicting();
                if(vitalityStop == true)
                {
                    topUIManager.RemoveVitality(1);
                }

            //} 
        }

        if (stopTimer == false)
        {
            timerSlider.value = time;
        }

        /*if (topUIManager.gameStop == true)
        {
            timerSlider.value = 0;
        }*/

    }

    public void evicting()
    {
        //if (topUIManager.gameStop == false)
        //{
            numCollected = 0;
            setGameTime = getTime;
            order();
            StartTimer();            
            numNeeded = 5;
            startTime = Time.time;
            soundManager.PlayButtonSound();
            StartCoroutine(CollectedInitialization());
        //}
        
    }

    IEnumerator PreventionLifeBugging()
    {
        yield return new WaitForSeconds(0.5f);
        vitalityStop = true;
    }

    IEnumerator CollectedInitialization()
    {
        yield return new WaitForSeconds(0.0001f);
        numCollected = 0;
    }
}
