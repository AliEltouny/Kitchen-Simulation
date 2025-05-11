using System;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour {



    private const string NUMBER_POPUP = "NumberPopup";


    [SerializeField] private TextMeshProUGUI countdownText;



    private Animator animator;
    private int previousCountdownNumber;


    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnstateChanged;

        Hide();
    }

    private void KitchenGameManager_OnstateChanged(object sender, EventArgs e) {
        if (KitchenGameManager.Instance.IsCountdownToStartGameActive()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Update() {
        int countdownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if (previousCountdownNumber != countdownNumber) {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}