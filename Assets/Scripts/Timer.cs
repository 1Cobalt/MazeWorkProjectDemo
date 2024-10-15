using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text time, bestTime;
  private int timeLimit = 300000; //5 minutes in miliseconds
  private TimeSpan ts;
  private string curr;
  private float startTime;
  private bool isWork;
  public bool finishIsAvailable = false;

  public GameObject player, textStart, textFinish, textTimeIsOver;

  private void Start()
  {
    Init();
  }

  public void Init()
  {
      isWork = true;

      curr = "00:00:00";
      time.text = curr;
      startTime = Time.time * 1000;
      PlayerPrefs.SetInt("currentTime", 0);
  }

  private void Update()
  {
    if (isWork)
    {
      if (!player.activeInHierarchy)
      {
        PlayerPrefs.SetInt("currentTime", (int)ts.TotalMilliseconds);
        isWork = false;
        return;
      }
      
      if ((PlayerPrefs.GetInt("currentTime") - timeLimit) >= 0)
      {
        Debug.Log("time limit is over");
        isWork = false;
        textTimeIsOver.SetActive(true);
        player.SetActive(false);
        player.GetComponent<ControlBall>().GetComponent<Rigidbody>().velocity = Vector3.zero;
        textStart.SetActive(true);
        return;
      }

      float t = Time.time * 1000 - startTime;
      ts = TimeSpan.FromMilliseconds((int)t);
      PlayerPrefs.SetInt("currentTime", (int)t);
      curr = ts.Minutes + ":" + ts.Seconds + ":" + ts.Milliseconds;
      time.text = curr;
    }
  }



  private void OnTriggerEnter(Collider other) //Timer is a script, that attached to finish zone
  {
        if (other.tag == "Player" && finishIsAvailable)
        {
            player.SetActive(false);
            player.GetComponent<ControlBall>().GetComponent<Rigidbody>().velocity = Vector3.zero;
            textStart.SetActive(true);
            textFinish.SetActive(true);
        }
  }
}
