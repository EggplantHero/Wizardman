using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay;
    [SerializeField] float LevelExitSlowMoFactor;
    Collider2D myCollider;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        myCollider = this.GetComponent<Collider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            spriteRenderer.enabled = false;
            StartCoroutine(LoadNextScene(LevelLoadDelay));
        }
    }

    private IEnumerator LoadNextScene(float waitTime)
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}