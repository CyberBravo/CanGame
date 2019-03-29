using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>
{
    /* -------------- 	Game specific sounds --------------- */
    public AudioClip levelUpSound;
    // Done
    public AudioClip buttonClickSound;
	public AudioClip CanFire;
	
	public AudioClip LoseSound;
	public AudioClip PointScoredSound;
	public AudioClip SparkleSound;

		public GameObject musicON;
		public GameObject musicOFF;
	
    // with menus
    public AudioClip menuBGSound;
    // Done
    public AudioClip gamePlayBGSound;
    // Done
    public AudioClip levelCompleteSound;
    // Done
    public AudioClip levelFailSound;
   

   
    /* Audio Source */
    public AudioSource gamePlayEffectsSource;
    public AudioSource BackgroundSoundSource;






    public bool isDualSound = false;
    private bool isGamePlaySound = false;

    void Start()
    {
		
       // DontDestroyOnLoad(this);
		
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }

		MusicONOFF(PlayerPrefs.GetString("music", "ON"));
    }
	public void MusicONOFF(string str)
	{
		if (str == "ON") 
		{
			UnMuteMusic();
			UnMuteSound();
			//musicON.gameObject.SetActive(true);
			//musicOFF.gameObject.SetActive(false);

		


		} 
		else if (str == "OFF")
		{
			MuteMusic();
			MuteSound();
			//musicON.gameObject.SetActive(false);
			//musicOFF.gameObject.SetActive(true);
			


		}
	}
  
	public void ButtonClickSound()
    {
        gamePlayEffectsSource.PlayOneShot(buttonClickSound);
    }

	#region Mute/UnMute_Handling
    public void MuteSound()
    {
				gamePlayEffectsSource.volume = 0;
    }

    public void UnMuteSound()
    {
				gamePlayEffectsSource.volume = 1;
    }

    public void MuteMusic()
    {
        GetComponent<AudioSource>().mute = true;
				MuteSound ();
    }

    public void UnMuteMusic()
    {
        GetComponent<AudioSource>().mute = false;
				UnMuteSound ();
    }
	#endregion
    public  void PlayMenuBGSound()
    {
        this.GetComponent<AudioSource>().clip = menuBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.7f;
       // CarEnvSound.Play();
    }

    public void PlayGamePlaySound()
    {
        this.GetComponent<AudioSource>().clip = gamePlayBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.4f;
       // CarEnvSound.Play();
    }


    
	public void buttonClick()
    {

		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
    }
	public void clockTickTick()
	{
		//gamePlayEffectsSource.GetComponent<AudioSource>().clip = clockTick;
		//gamePlayEffectsSource.GetComponent<AudioSource>().Play();
	}



	public void GameEndSound()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(LoseSound);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}

	public void PointsScored()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(PointScoredSound);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}
	public void Sparkle()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(SparkleSound);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}

	public void menuBG()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = menuBGSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void levelComplete()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelCompleteSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void levelFail()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelFailSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void CanFireSound()
	{
		//gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (CanFire);
	}


	
}