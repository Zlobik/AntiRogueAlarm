using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedInHouse;
    [SerializeField] private SpriteRenderer _render;

    private float _outSpeed;
    private bool _isEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Siren>())
        {
            if (!_isEnter)
                _isEnter = true;
            else if (_isEnter)
                _isEnter = false;

            if (_isEnter)
            {
                _outSpeed = _speed;
                _speed = _speedInHouse;
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                _render.flipX = false;
            }
            else if (!_isEnter)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }

        if (collision.tag == "Trigger")
        {
            _render.flipX = true;
            _speed = -_outSpeed * 2;
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
