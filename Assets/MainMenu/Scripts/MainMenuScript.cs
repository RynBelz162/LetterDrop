using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Texture backGroundTexture;
	public GUIStyle buttonStyle;
    void OnGUI()
    {
        //Display backGroundTexture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backGroundTexture);
        //Displays Button
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .2f, Screen.height * .05f), "Play Game",buttonStyle))
        {
			SceneManager.LoadScene("Game");
        }

		if (GUI.Button(new Rect(Screen.width * .55f, Screen.height * .5f, Screen.width * .2f, Screen.height * .05f), "Options", buttonStyle))
        {

        }
    }
}
