using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuManager : MonoBehaviour
{
    public void PlayBtn()
    {
        // Load scene with index 1
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private string rateUsUrl = "https://play.google.com/store/apps/details?id=com.miHoYo.GenshinImpact";
    
    public void RateUsBtn()
    {
        Application.OpenURL(rateUsUrl);
    }

    public void FeedbackBtn()
    {
        string email = "s32220100@student.ubm.ac.id";
        string subject = Uri.EscapeDataString("Feedback");
        string body = Uri.EscapeDataString("Your feedback here");
        
        string mailtoUrl = $"mailto:{email}?subject={subject}&body={body}";
        Application.OpenURL(mailtoUrl);
    }
}
