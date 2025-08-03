using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    private Collider2D _collider;

    public bool IsTouchingLayer;
    
    private void Awake() => 
        _collider = GetComponent<Collider2D>();

    private void OnTriggerStay2D(Collider2D other) => 
        IsTouchingLayer = _collider.IsTouchingLayers(_layerMask);

    private void OnTriggerExit2D(Collider2D other) => 
        IsTouchingLayer = _collider.IsTouchingLayers(_layerMask);
}