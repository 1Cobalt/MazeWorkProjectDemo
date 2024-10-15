using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasButton : MonoBehaviour
{
  public GameObject gameController;

  //For not it's separated script just for R = Restart
  //TODO: Add pause on ESC button
  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      RestartGame();
    }

  }
  public void RestartGame()
  {
    gameController.GetComponent<BuildMaze>().RerunMaze();
  }
}
