using UnityEngine;
using UnityEngine.SceneManagement; // Thêm thư viện để quản lý scene

public class EnterGame : MonoBehaviour
{
    private bool hasEntered = false;
    private bool canPressEnter = false; // Biến kiểm tra xem đã được phép bấm Enter chưa

    private void OnCollisionEnter(Collision collision)
    {
        if (hasEntered) return;

        if (collision.gameObject.CompareTag("Player")) 
        {
            hasEntered = true;

            // 1. Tự động tìm GameManager trong scene và gọi hàm bật menu
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ShowMenu();
            }
            else
            {
                Debug.LogError("Không tìm thấy GameManager trong Scene!");
            }

            // 2. Dừng máy bay
            AirplaneMover mover = collision.gameObject.GetComponent<AirplaneMover>();
            if (mover != null)
            {
                mover.StopMoving();
            }

            // 3. Khóa Rigidbody lại cho đứng im
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; 
            }

            // 4. Cho phép người chơi bắt đầu được bấm phím Enter
            canPressEnter = true;
        }
    }

    private void Update()
    {
        // Nếu đã tông vào tường (được phép bấm Enter) và người chơi bấm phím Enter (Return) hoặc Return trên NumPad
        if (canPressEnter && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            // Tiến hành load sang scene mới
            SceneManager.LoadScene("scene_01");
        }
    }
}