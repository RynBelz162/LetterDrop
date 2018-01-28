using UnityEngine;

public class LetterCollisionScript : MonoBehaviour
{
    private Rigidbody2D _playerBody;
    private char currentChar;
    private int wordToSpellIndex = 1;

    // Use this for initialization
    void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        currentChar = WordGeneratorScript.wordToSpell[wordToSpellIndex];
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        ConnectLetters(collider);
    }

    private void ConnectLetters(Collision2D collider)
    {
        Vector3 contactPoint = collider.contacts[0].point;
        var topY = collider.collider.bounds.center.y - collider.collider.bounds.extents.y;


        if (contactPoint.y < topY)
        {
            //get the colling letter's rigidbody
            var colliderBody = collider.gameObject.GetComponent<Rigidbody2D>();

            if (currentChar.ToString().Equals(collider.gameObject.tag, System.StringComparison.InvariantCultureIgnoreCase))
            {
                //set new connected letter's physics
                colliderBody.gravityScale = 0;
                colliderBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                //Attach hinge for connection
                _playerBody.gameObject.AddComponent<HingeJoint2D>();
                var hinge = _playerBody.GetComponent<HingeJoint2D>();
                hinge.connectedBody = colliderBody;

                //Add remove scripts
                collider.gameObject.AddComponent<LetterCollisionScript>();
                Destroy(_playerBody.gameObject.GetComponent<LetterCollisionScript>());

                //set next character in wordToSpell
                currentChar = WordGeneratorScript.wordToSpell[wordToSpellIndex++];
            }
        }
    }
}
