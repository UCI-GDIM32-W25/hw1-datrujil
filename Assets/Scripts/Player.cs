using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        // Initiate starting UI values
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        // Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= _speed * Time.deltaTime;
        }

        // Player Actions
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if there are available seeds to plant
            if (_numSeedsLeft > 0)
            {
                // Instantiate Plant Prefab
                Instantiate(_plantPrefab, new Vector3(pos.x, pos.y, 2), Quaternion.identity);

                PlantSeed();
            }
            
        }

        transform.position = pos;
    }

    public void PlantSeed ()
    {
        // Update UI values
        _numSeedsLeft--;
        _numSeedsPlanted++;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }
}
