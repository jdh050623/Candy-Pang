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
    public GameObject goalGameParent;//�׽�Ʈ��

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
            //goalIntroParent ��ġ�� �� ��ǥ �г��� ����ϴ�.
            GameObject goal = Instantiate(goalPrefab, goalGameParent.transform.position, Quaternion.identity);
            goal.transform.SetParent(goalIntroParent.transform);
            //��ǥ�� �̹����� �ؽ�Ʈ ����
            GoalPanel panel = goal.GetComponent<GoalPanel>(); // goal -> goalPrefab
            panel.thisSprite = levelGoals[i].goalSprite;
            panel.thisString = "0 / " + levelGoals[i].numberNeeded;

            //goalGameParent ��ġ�� �� ��ǥ �г��� ����ϴ�.
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
        if(goalsCompleted >= levelGoals.Length)
        {
            Debug.Log("�̰Թ���");
        }
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
