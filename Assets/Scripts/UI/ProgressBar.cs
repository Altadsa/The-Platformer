using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    [SerializeField]
    Slider progressBar;

    GameObject levelStart;
    GameObject player;
    GameObject levelEnd;

    float distance;

    private void Awake()
    {
        FindGOs();
        MeasureDistance();
    }

    private void FindGOs()
    {
        levelStart = FindObjectOfType<LevelStart>().gameObject;
        levelEnd = FindObjectOfType<LevelEnd>().gameObject;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        progressBar.value = MeasureProgress();
    }

    private void MeasureDistance()
    {
        float xStart = levelStart.transform.position.x;
        float xEnd = levelEnd.transform.position.x;
        distance = Mathf.Abs(xEnd - xStart);
    }

    private float MeasureProgress()
    {
        float progress;
        float playerPosition = player.transform.position.x;
        progress = Mathf.Clamp((playerPosition / distance), 0, 1);
        return progress;
    }
}
