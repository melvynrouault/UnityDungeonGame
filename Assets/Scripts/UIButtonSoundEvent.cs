using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip mouseEnterSound, mouseExitSound;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(mouseEnterSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // _audioSource.PlayOneShot(mouseExitSound);
    }
}
