using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 몬스터의 이동 속도

    private bool isDestroyed = false; // 몬스터가 파괴되었는지 여부를 추적

    void Update()
    {
        if (isDestroyed) // 이미 파괴된 경우 추가 처리를 하지 않음
            return;

        // 몬스터를 아래로 이동시키기
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MonsterBoundary")
        {
            Destroy(gameObject);
        }
    }
}

