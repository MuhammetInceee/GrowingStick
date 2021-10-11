using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instace
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is NULL");
            return _instance;
        }
    }

    [SerializeField] private GameObject _player;
    
    [Header("GroundsSpawn")]
    public GameObject _firstSpawnedGround;
    public GameObject _spawnedGround;
    private Vector3 _nextGroundLocation;

    [Header("Prefabs")]
    [SerializeField] private GameObject _growingPartPrefab;
    [SerializeField] private List<GameObject> _nextGround;

    [Header("Sticks")]
    [SerializeField] private GameObject _growingSpawnTransform;
    private GameObject firstGrownStick;
    public GameObject othersGrownStick;

    [Header("Bools")]
    public bool _ungrow;
    public bool _holding;
    public bool _isStickSpawned;
    public bool _isGroundSpawned;

    private void Awake()
    {
        _nextGroundLocation = new Vector3(Random.Range(_player.transform.localPosition.x + 1.5f, _player.transform.localPosition.x + 3.5f), -3.523f, 0);
        
        _instance = this;
    }
    private void Start()
    {
        _firstSpawnedGround = Instantiate(_nextGround[Random.Range(0, 4)], _nextGroundLocation, Quaternion.identity);
        
        
        _isStickSpawned = false;
        firstGrownStick = Instantiate(_growingPartPrefab, _growingSpawnTransform.
            transform.position, Quaternion.identity);
    }
    private void Update()
    {
        _nextGroundLocation = new Vector3(Random.Range(_player.transform.localPosition.x + 1.5f, _player.transform.localPosition.x + 3.5f), -3.523f, 0);


        //Stick
        if (SuccesCheck._isArrived && !SuccesCheck._playerMove && !_isStickSpawned)
        {
            Destroy(firstGrownStick);
            othersGrownStick = Instantiate(_growingPartPrefab, _growingSpawnTransform.
                transform.position, Quaternion.identity);
            _isStickSpawned = true;
        }

        //Ground
        if(!SuccesCheck._playerMove && SuccesCheck._isArrived && !_isGroundSpawned)
        {
            _spawnedGround = Instantiate(_nextGround[Random.Range(0, 4)], _nextGroundLocation, Quaternion.identity);
            _isGroundSpawned = true;
        }
    }



    // Events
    public void StartHolding()
    {
        if (!_ungrow)
            _holding = true;
    }
    public void StopHolding()
    {
        _ungrow = true;
        _holding = false;
        GrowingPart.Instace.Rotating();
    }
}
