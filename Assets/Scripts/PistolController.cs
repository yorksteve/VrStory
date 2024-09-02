using UnityEngine;

public class PistolController : MonoBehaviour
{
    [SerializeField]
    GameObject _muzzleFlashPrefab, _hitPrefab;
    [SerializeField]
    Transform _rayOrigin;
    [SerializeField]
    Vector3 _muzzleFlashOffset;
    AudioSource _audio;
    //[SerializeField]
    //AudioClip _gunShotClip;

    [SerializeField]
    private int _maxAmmo;

    private int _currentAmmo;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _currentAmmo = _maxAmmo;
    }

    [ContextMenu("Test Fire")]
    public void TriggerPull()
    {
        if (_currentAmmo <= 0) return;
        _currentAmmo--;

        Instantiate(_muzzleFlashPrefab, _rayOrigin.position + _muzzleFlashOffset, Quaternion.identity);
        //if (_gunShotClip != null && _audio != null)
            //_audio.PlayOneShot(_gunShotClip);

        if (Physics.Raycast(_rayOrigin.position, _rayOrigin.forward, out RaycastHit hit, Mathf.Infinity) && hit.transform.CompareTag("Target"))
        {
            Instantiate(_hitPrefab, hit.point, Quaternion.identity);
        }
    }

    public void Reload()
    {
        _currentAmmo = _maxAmmo;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_rayOrigin.position, _rayOrigin.forward * 10);
    }
}
