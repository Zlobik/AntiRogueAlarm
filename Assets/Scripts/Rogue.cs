using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _slewRateVolume;
    [SerializeField] private AudioSource _siren;
    [SerializeField] private SpriteRenderer _render;

    private bool _isEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 currentPosition;

        if (collision.GetComponent<EnterTrigger>())
        {
            currentPosition = transform.position;

            transform.position = new Vector3(currentPosition.x, currentPosition.y, 1);

            _siren.volume = 0;
            _siren.Play();

            _isEnter = true;

            _speed /= 3;
        }

        if (collision.GetComponent<OutTrigger>())
        {
            _isEnter = false;

            currentPosition = transform.position;
            transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
            _render.flipX = true;

            _speed *= -5;
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (_siren.isPlaying)
        {
            if (_isEnter)
            {
                _siren.volume += _slewRateVolume * Time.deltaTime;
            }
            else if (!_isEnter)
            {
                _siren.volume -= _slewRateVolume * Time.deltaTime;

                if (_siren.volume == 0)
                    _siren.Stop();
            }
        }
    }
}
