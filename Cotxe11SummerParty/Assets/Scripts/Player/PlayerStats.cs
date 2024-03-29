﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int HP = 3;
    public float time_controlls_inverted = 5.0f;
    public float time_extra_speed = 5.0f;
    public float time_stain = 5.0f;

    public float extra_speed = 40.0f;
    public float extra_angular_speed = 10.0f;

    private float player_original_pos = 0.0f;
    [HideInInspector]
    public float distance_done = 0.0f;

    [HideInInspector]
    public bool dead = false;
    [HideInInspector]
    public bool controlls_inverted = false;
    [HideInInspector]
    public bool speed_increased = false;
    [HideInInspector]
    public bool stain_active = false;
    [HideInInspector]
    public float timer_inverted_controlls = 0.0f;
    [HideInInspector]
    public float timer_extra_speed = 0.0f;
    [HideInInspector]
    public float timer_stain = 0.0f;

    private float original_speed = 5.0f;
    private float original_angular_speed = 5.0f;
    public Text distance_text;

    //UI elements
    //Desabilities
    public GameObject UI_invert_debuff;
    public GameObject UI_invert_text;
    private Text invert_text;
    public GameObject UI_run_debuff;
    public GameObject UI_run_text;
    private Text run_text;
    public GameObject UI_ink_debuff;
    public GameObject UI_ink_text;
    private Text ink_text;

    //Life
    public GameObject life_saver_1;
    public GameObject life_saver_2;
    public GameObject life_saver_3;
    public GameObject smoke_particle;
    public GameObject fire_particle;

    //Stains
    public GameObject stain1 = null;
    public GameObject stain2 = null;
    public GameObject stain3 = null;
    public GameObject stain4 = null;
    public GameObject stain5 = null;
    private GameObject current_stain = null;


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

    // Audio
    public AudioSource source;
    public AudioClip run_debuff_clip;
    public AudioClip invert_debuff_clip;
    public AudioClip ink_debuff_clip;

    // Start is called before the first frame update
    void Start()
    {
        timer_inverted_controlls = 0.0f;
        timer_extra_speed = 0.0f;
        timer_stain = 0.0f;
        original_speed = gameObject.GetComponent<PlayerController>().speed;
        original_angular_speed = gameObject.GetComponent<PlayerController>().angular_speed;

        player_original_pos = transform.position.z;

        //UI
        invert_text = UI_invert_text.GetComponent<Text>();
        run_text = UI_run_text.GetComponent<Text>();
        ink_text = UI_ink_text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            AddMod(MOD_STATS.BLESSED_BY_GOD);

        //Distance
        distance_done = player_original_pos - transform.position.z;
        distance_text.text = distance_done.ToString("F0") + "m";

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

        //Stain
        if (stain_active == true)
        {
            timer_stain += Time.deltaTime;
            ink_text.text = (time_stain - timer_stain).ToString("F0");

            if (timer_stain >= time_stain)
            {
                DesactivateStain();
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

            //UI
            UI_invert_debuff.SetActive(true);
            UI_invert_text.SetActive(true);

            //SFX
            source.PlayOneShot(invert_debuff_clip);

            timer_inverted_controlls = 0.0f;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().key_left = "a";
            gameObject.GetComponent<PlayerController>().key_right = "d";
            controlls_inverted = false;

            //UI
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

        //UI
        UI_run_debuff.SetActive(false);
        UI_run_text.SetActive(false);

        timer_extra_speed = 0.0f;
    }

    public void GiveExtraSpeed()
    {
        gameObject.GetComponent<PlayerController>().speed = extra_speed;
        gameObject.GetComponent<PlayerController>().angular_speed = extra_angular_speed;
        speed_increased = true;

        //UI
        UI_run_debuff.SetActive(true);
        UI_run_text.SetActive(true);

        //SFX
        source.PlayOneShot(run_debuff_clip);

        timer_extra_speed = 0.0f;
    }

    public void AddMod(MOD_STATS newStat)
    {
        mod_stats = newStat;
        modActived = true;
        modTimer = 0.0f;
    }

    public void LoseHP()
    {
        HP--;

        //UI
        if (HP == 2)
        {
            life_saver_1.SetActive(false);
            smoke_particle.SetActive(true);
        }  
        if (HP == 1)
        {
            life_saver_2.SetActive(false);
            smoke_particle.SetActive(false);
            fire_particle.SetActive(true);
        }
        if (HP == 0)
        {
            life_saver_3.SetActive(false);
            fire_particle.SetActive(false);
            dead = true;
        }
    }

    public void Die()
    {
        HP = 0;
        life_saver_1.SetActive(false);
        life_saver_2.SetActive(false);
        life_saver_3.SetActive(false);
        dead = true;
    }

    public void Spawnstains()
    {
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            stain1.SetActive(true);
            current_stain = stain1;
        }
        else if (random == 2)
        {
            stain2.SetActive(true);
            current_stain = stain2;
        }
        else if (random == 3)
        {
            stain3.SetActive(true);
            current_stain = stain3;
        }
        else if (random == 4)
        {
            stain4.SetActive(true);
            current_stain = stain4;
        }
        else
        {
            stain5.SetActive(true);
            current_stain = stain5;
        }
        stain_active = true;

        //UI
        UI_ink_debuff.SetActive(true);
        UI_ink_text.SetActive(true);

        //SFX
        source.PlayOneShot(ink_debuff_clip);

        timer_stain = 0.0f;
    }

    public void DesactivateStain()
    {
        current_stain.SetActive(false);
        stain_active = false;

        //UI
        UI_ink_debuff.SetActive(false);
        UI_ink_text.SetActive(false);

        timer_stain = 0.0f;
    }

}
