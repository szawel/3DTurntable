using UnityEngine;

public class OffsetTilingByTime : MonoBehaviour
{
    public float speed = 1.0f; // Speed at which the texture will be offset
    private Material mat;      // The material of the object

    private void Start()
    {
        // Assuming the object this script is attached to has a renderer
        if (GetComponent<Renderer>() && GetComponent<Renderer>().material)
        {
            // Create a new instance of the material to prevent modifying other references
            mat = GetComponent<Renderer>().material = new Material(GetComponent<Renderer>().material);
        }
        else
        {
            Debug.LogWarning("No Renderer or Material found on this object.");
            this.enabled = false;  // Disable the script
        }
    }

    private void Update()
    {
        if (mat != null)
        {
            float offset = Time.time * speed;
            Vector2 currentOffset = mat.mainTextureOffset;
            mat.mainTextureOffset = new Vector2(offset, currentOffset.y);
        }
    }

    // Ensure we clean up the cloned material instance to prevent memory leaks
    private void OnDestroy()
    {
        if (mat != null)
        {
            Destroy(mat);
        }
    }
}
