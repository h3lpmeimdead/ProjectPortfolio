using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private float _moveHorizontalSpeed;
    [SerializeField] private float _moveVerticalSpeed;
    [SerializeField] private RawImage _image;
    private void Update()
    {
        MoveBackground();
    }
    private void MoveBackground()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_moveHorizontalSpeed, _moveVerticalSpeed) * Time.deltaTime, _image.uvRect.size);
    }

    public void PlatformerButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BoidButton()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

}
