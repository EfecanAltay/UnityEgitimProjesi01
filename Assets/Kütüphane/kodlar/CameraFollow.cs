using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.position = new Vector3(target.position.x, target.position.y, -15);
    }
}
