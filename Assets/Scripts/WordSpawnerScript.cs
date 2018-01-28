using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordSpawnerScript : MonoBehaviour
{
    public float spawnTime = 2f;
    public static List<Sprite> letterSprites;
    public static List<GameObject> spawnedLetters;

    void Awake()
    {
        letterSprites = Resources.LoadAll<Sprite>("greyLetters 1").ToList();
    }

    // Use this for initialization
    void Start()
    {
        spawnedLetters = new List<GameObject>();
        //Five instances of spawners
        for (int i = 0; i <= 4; i++)
        {
            InvokeRepeating("SpawnLetter", (float)i, spawnTime);
        }
    }

    private void SpawnLetter()
    {
        if (!TimerScript.gameOver)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(CameraScript.minX, CameraScript.maxX), CameraScript.maxY + .5f, 0);
            GameObject letter = Instantiate(Resources.Load("Letter"), spawnPoint, Quaternion.identity) as GameObject;
            AssignLetter(letter);
        }
        else
        {
            CancelInvoke();
        }
    }

    public void AssignLetter(GameObject letter)
    {
        var randomizer = new System.Random(System.Guid.NewGuid().GetHashCode());
        int index = randomizer.Next(1, 33);
        var letterChar = ((LettersEnum)index).ToString();
        var letterSprite = letterSprites.FirstOrDefault(x => x.name == "greyLetters_" + letterChar);
        letter.GetComponent<SpriteRenderer>().sprite = letterSprite;
        letter.tag = letterChar.Length > 1 ? "SpecialChar" : letterChar;
        spawnedLetters.Add(letter);
    }
}
