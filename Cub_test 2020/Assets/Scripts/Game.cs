using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] Transform StartPosition;

    private GameObject _player;
    void Start()
    {
        _player = Instantiate(PlayerPrefab, StartPosition.transform.position, StartPosition.transform.rotation);
    }
}
