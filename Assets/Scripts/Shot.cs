using UnityEngine;

public class Shot : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private bool visible;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void OnEnable()
    {
      
        _lineRenderer.enabled = true;
        visible = true;
    }

    void FixedUpdate()
    {
        if (visible)
        {
            visible = false;
        }
        else
        {
            
            ShotPool.Instance.ReturnShot(this);
        }
    }

    public void Show(Vector3 from, Vector3 to)
    {
        if (!_lineRenderer) _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.SetPositions(new Vector3[] { from, to });
        _lineRenderer.enabled = true;  
        visible = true;
        gameObject.SetActive(true);
    }

    void OnDisable()
    {
       
        if (_lineRenderer != null)
            _lineRenderer.enabled = false;
    }
}
