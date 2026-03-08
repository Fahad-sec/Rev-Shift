using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 localOffset = new Vector3(0, height, -distance);
            Vector3 desiredPosition = target.TransformPoint(localOffset);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime );
            transform.LookAt(target.position + (Vector3.up * 1.5f));
        }
    }
}
