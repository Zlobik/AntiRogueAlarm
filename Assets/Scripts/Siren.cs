using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _soundRiseStrenght;

    private bool _isEnter = false;
    private AudioSource _sirenSound;

    private void Start()
    {
        _sirenSound = GetComponent<AudioSource>();
        _sirenSound.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rogue>())
        {
            if (!_isEnter)
                _isEnter = true;
            else if (_isEnter)
                _isEnter = false;

            if (_sirenSound.isPlaying == false)
                _sirenSound.Play();
        }
    }

    private void Update()
    {
        if (_sirenSound.isPlaying)
        {
            if (_isEnter)
            {
                if (_sirenSound.volume != 1)
                    _sirenSound.volume += _soundRiseStrenght * Time.deltaTime;
            }
            if (!_isEnter)
            {
                if (_sirenSound.volume != 0)
                    _sirenSound.volume -= _soundRiseStrenght * Time.deltaTime;

                if (_sirenSound.volume == 0)
                    _sirenSound.Stop();
            }
        }
    }
}
