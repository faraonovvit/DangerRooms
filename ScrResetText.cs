using UnityEngine;

public class ScrResetText : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
