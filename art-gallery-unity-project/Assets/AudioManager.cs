using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip woodFootstep;
    public AudioClip concreteFootstep;
    public AudioClip carpetFootstep;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        CheckMaterialUnderPlayer();
    }

    private void CheckMaterialUnderPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            if (hit.collider.CompareTag("RoomMaterial"))
            {
                string materialTag = hit.collider.gameObject.tag;
                audioManager.PlayFootstepSound(materialTag);
            }
        }
    }
}

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip woodFootstep;
    public AudioClip concreteFootstep;
    public AudioClip carpetFootstep;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound(string materialTag)
    {
        switch (materialTag)
        {
            case "Wood":
                PlayWoodFootstep();
                break;
            case "Concrete":
                PlayConcreteFootstep();
                break;
            case "Carpet":
                PlayCarpetFootstep();
                break;
            // Add more cases for other materials
            default:
                break;
        }
    }

    private void PlayWoodFootstep()
    {
        audioSource.clip = woodFootstep;
        audioSource.Play();
        Debug.Log("Helll90");
    }

    private void PlayConcreteFootstep()
    {
        audioSource.clip = concreteFootstep;
        audioSource.Play();
    }

    private void PlayCarpetFootstep()
    {
        audioSource.clip = carpetFootstep;
        audioSource.Play();
    }
}




// The PlayerFootsteps class is responsible for detecting the material under the player and triggering footstep sounds.
// The AudioManager class manages the footstep sounds and plays the appropriate sound based on the material.

