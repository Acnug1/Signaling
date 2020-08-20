using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeChanger))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    
    private VolumeChanger _volumeChanger;

    private void Awake()
    {
        _volumeChanger = GetComponent<VolumeChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _reached?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _volumeChanger.StartVolumeChanger(false);
        }
    }
}
