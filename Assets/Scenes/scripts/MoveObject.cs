using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 이동 속도 조절 가능
    private bool isButtonRightPressed = false;
    private bool isButtonLeftPressed = false;
    private bool isBlockedRight = false; // 오른쪽 이동 차단 상태
    private bool isBlockedLeft = false; // 왼쪽 이동 차단 상태

    void Update()
    {
        if (isButtonRightPressed && !isBlockedRight)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (isButtonLeftPressed && !isBlockedLeft)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void OnRightButtonDown()
    {
        isButtonRightPressed = true;
    }

    public void OnRightButtonUp()
    {
        isButtonRightPressed = false;
    }

    public void OnLeftButtonDown()
    {
        isButtonLeftPressed = true;
    }

    public void OnLeftButtonUp()
    {
        isButtonLeftPressed = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("트리거 충돌: " + collider.gameObject.name); // 트리거 충돌 로그

        if (collider.CompareTag("RightBoundary"))
        {
            isBlockedRight = true;
        }
        else if (collider.CompareTag("LeftBoundary"))
        {
            isBlockedLeft = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("RightBoundary"))
        {
            isBlockedRight = false;
        }
        else if (collider.CompareTag("LeftBoundary"))
        {
            isBlockedLeft = false;
        }
    }
}
