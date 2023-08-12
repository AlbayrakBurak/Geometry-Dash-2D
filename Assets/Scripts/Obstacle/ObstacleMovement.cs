using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Engelin hızı

    private void Update()
    {
        // Engelin sola doğru hareketini yönet
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Engelin ekran dışına çıkıp çıkmadığını kontrol et
        if (transform.position.x < -10f)
        {
            Destroy(gameObject); // Engeli yok et veya yeniden konumlandırabilirsiniz
        }
    }

    public void Initialize()
    {
        // Engeli başlangıç konumuna yerleştirme veya başka özellikleri ayarlama işlemleri burada yapılabilir
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Engel oyuncuya çarptı!");
        }
    }
}
