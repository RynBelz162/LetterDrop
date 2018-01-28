using System.Linq;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float speed = 2f;
    private float maxLeft;
    private float maxRight;
    private Rigidbody2D _playerBody;

    // Use this for initialization
    void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        maxLeft = CameraScript.minX;
        maxRight = CameraScript.maxX;
        SetStartingLetter();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimerScript.gameOver)
        {
            var spritePosition = _playerBody.position;
            var cantMoveLeft = CantMoveLeft(spritePosition);
            var cantMoveRight = CantMoveRight(spritePosition);

            KeyboardControls(spritePosition, cantMoveLeft, cantMoveRight);
            TouchControls(spritePosition, cantMoveLeft, cantMoveRight);
        }
        else
        {
            _playerBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void SetStartingLetter()
    {
        var initialLetter = WordGeneratorScript.wordToSpell[0];
        var startingLetter = WordSpawnerScript.letterSprites.FirstOrDefault(x => x.name == "greyLetters_" + initialLetter);
        gameObject.GetComponent<SpriteRenderer>().sprite = startingLetter;
    }

    public void KeyboardControls(Vector2 spritePosition, bool cantMoveLeft, bool cantMoveRight)
    {
        //If key left try to move left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (cantMoveLeft)
            {
                _playerBody.velocity = Vector2.zero;
            }
            else
            {
                MoveLeft();
            }
        }
        //If key right try to move right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (cantMoveRight)
            {
                _playerBody.velocity = Vector2.zero;
            }
            else
            {
                MoveRight();
            }
        }
    }

    public void TouchControls(Vector2 spritePosition, bool cantMoveLeft, bool cantMoveRight)
    {
        // Touch Controls(wont work on pc)
        // foreach (var touch in Input.touches)
        // {
        //     if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
        //     {
        //         var touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //         if (touchPosition.x < spritePosition.position.x)
        //         {
        //             if (cantMoveLeft)
        //             {
        //                 _rigidBody.velocity = Vector2.zero;
        //             }
        //             else
        //             {
        //                 _rigidBody.AddForce(Vector2.left * speed);
        //             }
        //         }
        //         else
        //         {
        //             if (cantMoveRight)
        //             {
        //                 _rigidBody.velocity = Vector2.zero;
        //             }
        //             else
        //             {
        //                 _rigidBody.AddForce(Vector2.right * speed);
        //             }
        //         }
        //     }
        // }

        //Debugging with mouse controls
        var aTouch = Input.GetMouseButton(0);
        var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //When there is no touch gotta check if moving
        if (!aTouch)
        {
            //Moving left and cant move left when no touch
            if ((_playerBody.velocity.x < 0) && cantMoveLeft)
            {
                _playerBody.velocity = Vector2.zero;
            }
            //Moving right and cant move right when no touch
            if ((_playerBody.velocity.x > 0) && cantMoveRight)
            {
                _playerBody.velocity = Vector2.zero;
            }
        }

        if (aTouch)
        {
            //If currently moving left and cant move left stop
            if (_playerBody.velocity.x > 0 && cantMoveRight)
            {
                _playerBody.velocity = Vector2.zero;
            }

            //If currently moving right and cant move right stop
            if (_playerBody.velocity.x < 0 && cantMoveLeft)
            {
                _playerBody.velocity = Vector2.zero;
            }

            //If touch is on left try to move left
            if (touchPosition.x < spritePosition.x)
            {
                if (cantMoveLeft)
                {
                    _playerBody.velocity = Vector2.zero;
                }
                else
                {
                    MoveLeft();
                }
            }
            //If touch is on right try to move right
            else if (touchPosition.x > spritePosition.x)
            {
                if (cantMoveRight)
                {
                    _playerBody.velocity = Vector2.zero;
                }
                else
                {
                    MoveRight();
                }
            }
        }
    }

    private bool CantMoveLeft(Vector2 spritePosition)
    {
        return (spritePosition.x == maxLeft || spritePosition.x < maxLeft);
    }

    private bool CantMoveRight(Vector2 spritePosition)
    {
        return (spritePosition.x == maxRight || spritePosition.x > maxRight);
    }

    private void MoveLeft()
    {
        _playerBody.AddForce(Vector2.left * speed);
    }

    private void MoveRight()
    {
        _playerBody.AddForce(Vector2.right * speed);
    }
}
