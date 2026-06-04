using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 6f;
    public float startFollowDistance = 4f;

    [Header("Dikey Takip")]
    public float verticalFollowSpeed = 2f;
    public float minY = 0f;

    [Header("Yatay Sýnýr")]
    public float minX = 0f;   // kamera bu X'in soluna gitmez

    private float startCameraX;
    private float fixedZ;
    private bool followStarted = false;

    void Start()
    {
        startCameraX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 cameraPosition = transform.position;

        if (!followStarted)
        {
            cameraPosition.x = startCameraX;
            if (target.position.x > startCameraX + startFollowDistance)
                followStarted = true;
        }
        else
        {
            float targetX = target.position.x - startFollowDistance;
            cameraPosition.x = Mathf.Lerp(cameraPosition.x, targetX, followSpeed * Time.deltaTime);
        }

        // Yatay sol sýnýr — kamera minX'in soluna geçemez
        cameraPosition.x = Mathf.Max(cameraPosition.x, minX);

        // Dikey takip + alt sýnýr
        float targetY = Mathf.Lerp(cameraPosition.y, target.position.y, verticalFollowSpeed * Time.deltaTime);
        cameraPosition.y = Mathf.Max(targetY, minY);

        cameraPosition.z = fixedZ;
        transform.position = cameraPosition;
    }
}