using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    //Drag the pause menu canvas you want to use.  Menu should be disabled to begin in inspector
    public Canvas pause_menu;

    //The amount of time in seconds for effects to play before changing the level
    public float time_before_level_load = 3;

    //This keeps track if the game is paused or not, defaut to not
    public bool is_paused = false;

    //You can use this function by passing in the name of the level as a string that you want to change it to
    public void Level_Change(string level)
    {
        StartCoroutine(Level_Effects(level));
    }

    //This is called to let you play effects befor transition scenes
    public IEnumerator Level_Effects(string level)
    {
        //TODO:  Level Change effects will go in here, probably call another coroutine to fade out, or start the animation or whatever
        yield return new WaitForSeconds(time_before_level_load);
        //TODO:  Find out which version of Unity everyone is using and if we can switch to scene manager
        Application.LoadLevel(level);
    }

    //This is a public function so you can call it from where you want it, which is also why there is no input in this script
    public void Pause_Game()
    {
        is_paused = !is_paused;
        if (is_paused)
        {
            Time.timeScale = 0;
            pause_menu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause_menu.gameObject.SetActive(false);
        }
    }

    //Initializations
    void Start()
    {
        pause_menu.gameObject.SetActive(false);
    }
}
