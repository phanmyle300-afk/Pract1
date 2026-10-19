using UnityEngine;

public class AirplaneMover : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoving = true; // Cờ kiểm soát việc bay

    void Update()
    {
        if (isMoving)
        {
            // Tiến về phía trước theo không gian thế giới
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
    }

    // Hàm gọi để dừng máy bay lại hẳn
    public void StopMoving()
    {
        isMoving = false;
    }
}