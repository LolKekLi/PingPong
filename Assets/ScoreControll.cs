using UnityEngine;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour
{
    public GameObject left;
    public Text score;
    private int leftsc;
    private int rightsc;

    void Start()
    {
       
        Triger.trigger += Trigger_trigger;
        score.text = leftsc + " " + rightsc;
    }


    void Trigger_trigger(string s)
    {
        if (s == left.name)
        {
            leftsc += 1;
            score.text = leftsc + " " + rightsc;
        }
        else
        {
            rightsc += 1;
            score.text = leftsc + " " + rightsc;
        }
    }
}


