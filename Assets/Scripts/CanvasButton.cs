using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasButton : MonoBehaviour
{
  public GameObject gameController;

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
