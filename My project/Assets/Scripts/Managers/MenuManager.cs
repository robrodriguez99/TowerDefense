using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public enum UnityScenes

{
  [Description("Menu")]
  Menu,
  [Description("Level1")]
  Level1,
  [Description("EndGame")]
    EndGame,
}

public class MenuManager : MonoBehaviour
{
    public void ActionPlay() => SceneManager.LoadScene(UnityScenes.Level1.ToString());
    public void ActionConfig() => SceneManager.LoadScene("Config");
    public void ActionExit() => Application.Quit();

}
