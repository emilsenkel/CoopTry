using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        // Subscribe to all players
        foreach (var player in FindObjectsOfType<Player>())
        {
            player.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        }
        PlayerInputManager.instance.onPlayerJoined += (PlayerInput pi) =>
        {
            var player = pi.GetComponent<Player>();
            player.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        };
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
