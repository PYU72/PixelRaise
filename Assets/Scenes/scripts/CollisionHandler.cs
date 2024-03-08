using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private MoveObject moveObjectScript;

    void Start()
    {
        // 이 스크립트가 부착된 게임 오브젝트에서 MoveObject 스크립트를 찾습니다.
        moveObjectScript = GetComponent<MoveObject>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 발생: " + collision.collider.name); // 충돌한 오브젝트의 이름을 로그로 출력

        if (collision.collider.CompareTag("Boundary"))
        {
            // 충돌 시 움직임을 멈추기 위해 버튼 누름 상태를 false로 설정합니다.
            moveObjectScript.OnRightButtonUp();
            moveObjectScript.OnLeftButtonUp();
        }
    }
}

