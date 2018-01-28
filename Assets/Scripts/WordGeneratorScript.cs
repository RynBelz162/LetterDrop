using UnityEngine;
using UnityEngine.UI;

public class WordGeneratorScript : MonoBehaviour
{

    // Use this for initialization
    public static string wordToSpell;
    private Text wordToSpellTextbox;

    void Awake()
    {
        wordToSpell = GetRandomWord();
    }
    void Start()
    {
        DisplayWordToSpell();
    }

    private string GetRandomWord()
    {
        var words = new string[] { "Cat", "Dog", "Mom", "Dad" };
        var randomizer = new System.Random();
        int index = randomizer.Next(1, words.Length);
        return words[index];
    }

    private void DisplayWordToSpell()
    {
        wordToSpellTextbox = GameObject.Find("WordToSpell").GetComponent<Text>();
        wordToSpellTextbox.transform.position = new Vector3(CameraScript.minX * .8f, CameraScript.maxY, 0);
        wordToSpellTextbox.text = wordToSpell;
    }
}
