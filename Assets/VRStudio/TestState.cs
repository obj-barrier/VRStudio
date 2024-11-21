using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public enum Scheme { Old, New }
public enum Mode { Camera, Object }

public class TestState : MonoBehaviour
{
    public static int currTaskID = -1;
    public static Scheme scheme;
    public static Mode mode = Mode.Camera;

    public Camera photoCam;
    public GameObject modeIndicator;
    public GameObject phone;
    public GameObject monitor;
    public GameObject refMonitor;
    public GameObject userInput;
    public TestScore testScore;

    public GameObject modeIndCam;
    public GameObject modeIndObj;
    public TextMeshProUGUI sizeInd;
    public GameObject panel;
    public GameObject startMenu;
    public GameObject tutorial;
    public GameObject preview;
    public GameObject objectTaskStart;
    public GameObject objectTaskFinish;
    public GameObject testFinish;

    public GameObject[] tasks;

    private int photoTime;

    public bool IsLastTask()
    {
        return currTaskID == tasks.Length - 1;
    }

    public void SchemeSelected(int scheme)
    {
        TestState.scheme = (Scheme)scheme;
        startMenu.SetActive(false);
        tutorial.SetActive(true);
        modeIndicator.SetActive(true);
        phone.SetActive(true);
        userInput.SetActive(true);
    }

    public void ModeSwitch()
    {
        mode = 1 - mode;
        if (mode == Mode.Camera)
        {
            modeIndCam.SetActive(true);
            modeIndObj.SetActive(false);
        }
        else
        {
            modeIndCam.SetActive(false);
            modeIndObj.SetActive(true);
        }
    }

    public void UpdateSize(float size)
    {
        sizeInd.text = "Size: " + size.ToString("#0.0") + "X";
    }
    
    public void NextTask()
    {
        if (currTaskID >= 0)
        {
            tasks[currTaskID].SetActive(false);
        }
        currTaskID++;
        tasks[currTaskID].SetActive(true);
        if (tasks[currTaskID].CompareTag("PhotoTask"))
        {
            testScore.TimerStart();
            if (scheme == Scheme.Old)
            {
                monitor.SetActive(true);
            }
            refMonitor.SetActive(true);
            panel.SetActive(false);
        }
        else if (tasks[currTaskID].CompareTag("ObjectTask"))
        {
            objectTaskStart.SetActive(true);
        }
    }

    public void PhotoTaskCheck()
    {
        if (panel.activeSelf)
        {
            return;
        }
        if (tasks[currTaskID].CompareTag("ObjectTask") ||
            tasks[currTaskID].GetComponentInChildren<MeshRenderer>().enabled)
        {
            return;
        }

        testScore.TimerPause();
        photoCam.enabled = true;
        photoTime = Time.frameCount;

        monitor.SetActive(false);
        preview.SetActive(true);
        panel.SetActive(true);
    }

    public void PhotoTaskDiscard()
    {
        if (scheme == Scheme.Old)
        {
            monitor.SetActive(true);
        }
    }

    private void Update()
    {
        if (Time.frameCount == photoTime + 1)
        {
            photoCam.enabled = false;
        }
    }

    public void ObjectTaskCheck()
    {
        testScore.TimerPause();
        objectTaskFinish.SetActive(true);
        panel.SetActive(true);
    }

    public void TaskFinish()
    {
        testScore.TaskFinish();

        if (IsLastTask())
        {
            testScore.SendScore();
            testFinish.SetActive(true);
            panel.SetActive(true);
            return;
        }
        NextTask();
    }

    public void EndTest()
    {
        Application.Quit();
    }
}
