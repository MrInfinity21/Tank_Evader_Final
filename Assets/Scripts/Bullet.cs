using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500f;
    
    public float maxLifetime = 10f;
    private Rigidbody2D _rigidbody;

    private AudioClip shootSFX;
    private AudioSource _audioSource;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Project(Vector2 direction)
    {
        if (_audioSource != null && shootSFX != null)
        {
            _audioSource.PlayOneShot(shootSFX);
        }
        _rigidbody.AddForce(direction * this.speed);
        
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
