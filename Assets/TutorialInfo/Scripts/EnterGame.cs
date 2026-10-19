using UnityEngine;

public class EnterGame : MonoBehaviour
{
    private bool hasEntered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasEntered) return;

        if (collision.gameObject.CompareTag("Player")) 
        {
            hasEntered = true;

            // Tự động tìm GameManager trong scene và gọi hàm bật menu
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ShowMenu();
            }
            else
            {
                Debug.LogError("Không tìm thấy GameManager trong Scene!");
            }

            // Dừng máy bay
            AirplaneMover mover = collision.gameObject.GetComponent<AirplaneMover>();
            if (mover != null)
            {
                mover.StopMoving();
            }

            // Khóa Rigidbody lại cho đứng im
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; 
            }
        }
    }
}