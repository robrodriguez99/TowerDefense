using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public enum UnityScenes

{
  [Description("MainMenu")]
  MainMenu,

  [Description("Level1")]
  Level1,

  [Description("Settings")]
  Settings,

  [Description("PauseMenu")]
  PauseMenu,

  [Description("EndGame")]
    EndGame,
}

public class MenuManager : MonoBehaviour
{
    public void ActionPlay() => SceneManager.LoadScene(UnityScenes.Level1.ToString());
    public void ActionSettings() => SceneManager.LoadScene(UnityScenes.Settings.ToString());
    public void ActionMenu() => SceneManager.LoadScene(UnityScenes.MainMenu.ToString());
    public void ActionResume() => SceneManager.LoadScene(UnityScenes.Level1.ToString());
    public void ActionPause() => SceneManager.LoadScene(UnityScenes.PauseMenu.ToString());
    public void ActionExit() => Application.Quit();

}
