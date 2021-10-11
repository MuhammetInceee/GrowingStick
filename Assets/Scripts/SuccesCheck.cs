using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccesCheck : MonoBehaviour
{
    public static bool _isArrived;
    public static bool _playerMove;



    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Success"))
        {
            _isArrived = true;
            _playerMove = true;

        }
        else if (collision.CompareTag("Player"))
        {
            _playerMove = false;
            GameManager.Instace._ungrow = false;
            GameManager.Instace._isStickSpawned = false;
            GameManager.Instace._isGroundSpawned = false;
            Destroy(GameManager.Instace.othersGrownStick);
            Destroy(GameManager.Instace._firstSpawnedGround, 10f);
            Destroy(GameManager.Instace._spawnedGround, 10f);
        }
        else if (collision.CompareTag("Lose"))
        {
            Time.timeScale = 0;
            UIManager.Instance._gameOverScreen.SetActive(true);
        }
    }
}
