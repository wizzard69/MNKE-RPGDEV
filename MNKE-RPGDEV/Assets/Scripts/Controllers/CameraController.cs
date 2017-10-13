using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        transform.LookAt(target);
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
        transform.LookAt(target.position);
    }
}
