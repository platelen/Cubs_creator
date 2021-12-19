using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector3 offset;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        offset = transform.position - _player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 playerPos = _player.transform.position;
        transform.position = new Vector3(playerPos.x, 0, playerPos.z) + offset;

    }
}
