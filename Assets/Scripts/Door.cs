using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _siren;
    [SerializeField] private float _slewRate;

    private bool _isEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rogue>())
        {
            if (!_isEnter)
                _isEnter = true;

            else if (_isEnter)
                _isEnter = false;

            if (_isEnter)
            {
                _siren.volume = 0;
                _siren.Play();
            }
        }
    }

    private void Update()
    {
        if (_siren.isPlaying && _isEnter)
        {
            _siren.volume += _slewRate * Time.deltaTime;
        }

        if (_siren.isPlaying  && !_isEnter)
        {
            _siren.volume -= _slewRate * Time.deltaTime;

            if (_siren.volume == 0)
            {
                _siren.Stop();
            }

        }
    }
}