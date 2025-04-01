using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    
    public ParticleSystem explosion;
    
    public float respawnTime = 3f;
    
    public float respawnInvulnerabilityTime = 3f;
    
    public int lives = 3;
    
    public int _score = 0;
    
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _gameOverText;
    
    public string levelSelectionSceneName = "LevelSelection";
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75f)
        {
            _score += 100;
        }
        else if (asteroid.size < 1.0f)
        {
            _score += 50;
        }
        else
        {
            _score += 25;
        }

        UpdateScoreText();

    }
    
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        
        this.lives--;

        UpdateLivesText();

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this._score = 0;

        UpdateLivesText();
        UpdateScoreText();
        
        _gameOverText.gameObject.SetActive(true);
        Invoke(nameof(LoadLevelSelection), 3f);
    }

    private void LoadLevelSelection()
    {
        SceneManager.LoadScene(levelSelectionSceneName);
    }

    private void UpdateLivesText()
    {
        livesText.text = lives.ToString();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }
}
