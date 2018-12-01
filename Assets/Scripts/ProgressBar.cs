using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    public Slider progressBar;
    public GameObject levelStart;
    public GameObject player;
    public GameObject levelEnd;

    float distance;

    private void Awake()
    {
        MeasureDistance();
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
