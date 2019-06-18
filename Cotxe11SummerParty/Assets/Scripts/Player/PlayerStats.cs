using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int HP = 3;
    public float time_controlls_inverted = 5.0f;
    public float time_extra_speed = 5.0f;

    public float extra_speed = 40.0f;
    public float extra_angular_speed = 10.0f;

    [HideInInspector]
    public bool controlls_inverted = false;
    [HideInInspector]
    public bool speed_increased = false;
    [HideInInspector]
    public float timer_inverted_controlls = 0.0f;
    [HideInInspector]
    public float timer_extra_speed = 0.0f;

    private float original_speed = 5.0f;
    private float original_angular_speed = 5.0f;

    //UI elements
    public GameObject UI_invert_debuff;
    public GameObject UI_invert_text;
    private Text invert_text;
    public GameObject UI_run_debuff;
    public GameObject UI_run_text;
    private Text run_text;



    // MODS
    public enum MOD_STATS
    {
        ANY = 0,
        BLESSED_BY_GOD
    }
    MOD_STATS mod_stats = MOD_STATS.ANY;
    private bool modActived = false;
    private float modTimer = 0.0f;
    public float modTimerMax = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        timer_inverted_controlls = 0.0f;
        timer_extra_speed = 0.0f;
        original_speed = gameObject.GetComponent<PlayerController>().speed;
        original_angular_speed = gameObject.GetComponent<PlayerController>().angular_speed;


        //UI
        invert_text = UI_invert_text.GetComponent<Text>();
        run_text = UI_run_text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            AddMod(MOD_STATS.BLESSED_BY_GOD);
        //Invert Controlls
        if (controlls_inverted == true)
        {
            timer_inverted_controlls += Time.deltaTime;
            invert_text.text = (time_controlls_inverted - timer_inverted_controlls).ToString("F0");
                

            if (timer_inverted_controlls >= time_controlls_inverted)
            {
                InvertControlls();
            }
        }
        //Extra Speed
        if (speed_increased == true)
        {
            timer_extra_speed += Time.deltaTime;
            run_text.text = (time_extra_speed - timer_extra_speed).ToString("F0");

            if (timer_extra_speed >= time_extra_speed)
            {
                ResetSpeed();
            }
        }

        modTimer += Time.deltaTime;
        if (modTimer < modTimerMax)
        {
            switch (mod_stats)
            {
                case MOD_STATS.BLESSED_BY_GOD:
                    extra_speed = 40;
                    GiveExtraSpeed();
                    break;
            }
        }
        else
        {
            if (modActived)
            {
                modActived = false;
                // Desactivar tots els stats bonus
                ResetSpeed();
            }
        }
    }

    public void InvertControlls()
    {
        if (gameObject.GetComponent<PlayerController>().key_left == "a")
        {
            gameObject.GetComponent<PlayerController>().key_left = "d";
            gameObject.GetComponent<PlayerController>().key_right = "a";
            controlls_inverted = true;
            UI_invert_debuff.SetActive(true);
            UI_invert_text.SetActive(true);

            timer_inverted_controlls = 0.0f;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().key_left = "a";
            gameObject.GetComponent<PlayerController>().key_right = "d";
            controlls_inverted = false;
            UI_invert_debuff.SetActive(false);
            UI_invert_text.SetActive(false);

            timer_inverted_controlls = 0.0f;
        }
    }

    public void ResetSpeed()
    {
        gameObject.GetComponent<PlayerController>().speed = original_speed;
        gameObject.GetComponent<PlayerController>().angular_speed = original_angular_speed;
        speed_increased = false;
        UI_run_debuff.SetActive(false);
        UI_run_text.SetActive(false);

        timer_extra_speed = 0.0f;
    }

    public void GiveExtraSpeed()
    {
        gameObject.GetComponent<PlayerController>().speed = extra_speed;
        gameObject.GetComponent<PlayerController>().angular_speed = extra_angular_speed;
        speed_increased = true;
        UI_run_debuff.SetActive(true);
        UI_run_text.SetActive(true);

        timer_extra_speed = 0.0f;
    }

    public void AddMod(MOD_STATS newStat)
    {
        mod_stats = newStat;
        modActived = true;
        modTimer = 0.0f;
    }

}
