using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        FindAnyObjectByType<GameInput>().OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();

        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Move_Right);
        keyInteractText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Pause);
        keyGamepadInteractText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = FindAnyObjectByType<GameInput>().GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
