using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class BlankGoal
{
    public int numberNeeded;
    public int numberCollected;
    public Sprite goalSprite;
    public string matchValue;
}

public class GoalManager : MonoBehaviour
{
    public BlankGoal[] levelGoals;
    public List<GoalPanel> currentGoals = new List<GoalPanel>();
    public GameObject goalPrefab; 
    public GameObject goalIntroParent;
    public GameObject goalGameParent;//테스트중

    [Header("customer")]
    public List<Sprite> c_sprite;
    public List<string> c_numNeeded;
    

    // Start is called before the first frame update
    void Start()
    {
        //SetupGoals();
    }

    void SetupGoals()
    {
       /* for(int i = 0; i < levelGoals.Length; i++)
        {
            //goalIntroParent 위치에 새 목표 패널을 만듭니다.
            GameObject goal = Instantiate(goalPrefab, goalGameParent.transform.position, Quaternion.identity);
            goal.transform.SetParent(goalIntroParent.transform);
            //목표의 이미지와 텍스트 설정
            GoalPanel panel = goal.GetComponent<GoalPanel>(); // goal -> goalPrefab
            panel.thisSprite = levelGoals[i].goalSprite;
            panel.thisString = "0 / " + levelGoals[i].numberNeeded;

            //goalGameParent 위치에 새 목표 패널을 만듭니다.
            GameObject gameGoal = Instantiate(goalPrefab, goalGameParent.transform.position, Quaternion.identity);
            gameGoal.transform.SetParent(goalGameParent.transform);
            panel = gameGoal.GetComponent<GoalPanel>();
            currentGoals.Add(panel);
            panel.thisSprite = levelGoals[i].goalSprite;
            panel.thisString = "0 / " + levelGoals[i].numberNeeded;

        }*/
    }

    public void UpdateGoals()
    {
        int goalsCompleted = 0;
        for(int i = 0; i < levelGoals.Length; i++)
        {
            currentGoals[i].thisText.text = "" + levelGoals[i].numberCollected + "/" + levelGoals[i].numberNeeded;
            if(levelGoals[i].numberCollected >= levelGoals[i].numberNeeded)
            {
                goalsCompleted++;
                currentGoals[i].thisText.text = "" + levelGoals[i].numberNeeded + "/" + levelGoals[i].numberNeeded;
            }
        }
        /*if(goalsCompleted >= levelGoals.Length)
        {
            
        }*/
    }

    public void CompareGoal(string goalToCompare)
    {
        for(int i = 0; i < levelGoals.Length; i++)
        {
            if(goalToCompare == levelGoals[i].matchValue)
            {
                levelGoals[i].numberCollected++;
            }
        }
    }
}
