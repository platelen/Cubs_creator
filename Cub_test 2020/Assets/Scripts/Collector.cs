using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject lostGame;
    [SerializeField] private GameObject victoryGame;

    private GameObject _startPosition;
    private GameObject _player;
    private int heightCub;

    void Start()
    {
        _player = GameObject.Find("Player");
        _startPosition = GameObject.Find("StartPosition");
    }

    void Update()
    {
        _player.transform.position = new Vector3(transform.position.x, heightCub + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -heightCub, 0);
    }

    public void RemoveCubs()
    {
        heightCub--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Check finish");
            victoryGame.SetActive(true);
            pauseMenu.Pause();
        }

        if (other.gameObject.tag == "Enemy" && heightCub == 0)
        {
            lostGame.SetActive(true);
            pauseMenu.Pause();

        }

        if (other.gameObject.tag != "Neutral" ||
            other.gameObject.GetComponent<Collected>().GetCollected() != false) return;
        heightCub += 1;
        other.gameObject.GetComponent<Collected>().Joint();
        other.gameObject.GetComponent<Collected>().IndexCubs(heightCub);
        other.gameObject.transform.parent = _player.transform;
        other.gameObject.GetComponentInChildren<Renderer>().material.color =
            _player.GetComponent<Renderer>().material.color;
    }
}
