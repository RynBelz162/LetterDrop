using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject projectile;
    // Use this for initialization
    void Start()
    {
        projectile = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckProjectilePosition(projectile);
    }

    private void CheckProjectilePosition(GameObject projectile)
    {
        if (projectile.transform.position.y < CameraScript.minY)
        {
            Destroy(projectile);
            WordSpawnerScript.spawnedLetters.Remove(projectile);
        }
    }
}
