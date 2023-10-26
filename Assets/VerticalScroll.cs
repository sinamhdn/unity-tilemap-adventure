using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip("Game units per second")]
    [SerializeField] float scrollRate = 0.2f;

    // Update is called once per frame
    void Update()
    {
        float yTransform = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yTransform));
    }
}
