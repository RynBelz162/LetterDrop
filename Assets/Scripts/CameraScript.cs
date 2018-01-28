using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // Use this for initialization
    public static float minX;
    public static float maxX;
    public static float minY;
    public static float maxY;
    void Awake()
    {
        var camera = GetComponent<Camera>();
        CalculateScreenBounds(camera);
    }

    private void CalculateScreenBounds(Camera camera)
    {
        var size = camera.orthographicSize * 2;
        var width = size * (float)Screen.width / Screen.height;
        var height = size;

        minX = -width / 2;
        maxX = width / 2;
        minY = -height / 2;
        maxY = height / 2;
    }
}
