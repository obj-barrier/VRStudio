using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct Score
{
    public float time;
    public float dPosition;
    public float dRotation;

    public override string ToString()
    {
        return "Time: " + time + "   dPosition:" + dPosition + "   dRotation:" + dRotation + "\n";
    }
}

public class TestScore : MonoBehaviour
{
    public TestState testState;
    public Transform phone;
    public TextMeshProUGUI scoreText;
    public static Score[] scores;

    private bool timing;
    private float time;
    private Vector3 phonePos;
    private Quaternion phoneRot;

    private void Start()
    {
        scores = new Score[testState.tasks.Length];
    }

    private void Update()
    {
        if (timing)
        {
            time += Time.deltaTime;
        }
    }

    public void TimerStart()
    {
        timing = true;
    }

    public void TimerPause()
    {
        timing = false;
        phonePos = phone.position;
        phoneRot = phone.rotation;
    }

    public void TaskFinish()
    {
        timing = false;
        int currTaskID = TestState.currTaskID;
        scores[currTaskID].time = time;

        GameObject currTask = testState.tasks[currTaskID];
        if (currTask.CompareTag("PhotoTask"))
        {
            scores[currTaskID].dPosition = Vector3.Distance(phonePos, currTask.transform.position);
            scores[currTaskID].dRotation = Quaternion.Angle(phoneRot, currTask.transform.rotation);
        }

        time = 0f;
        TimerStart();
    }

    public void SendScore()
    {
        foreach (Score score in scores)
        {
            scoreText.text += score.ToString();
        }
    }
}
