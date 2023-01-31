using UnityEngine;

public class GamePauser : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
        }
    }
}
