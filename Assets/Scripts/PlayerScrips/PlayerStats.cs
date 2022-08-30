/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    [SerializeField]
    private float experience = 0;
    public float Experience
    {
        get { return Experience; }
        set { Experience = value; }
    }
    private float maxExperience = 0;
    public float MaxExperience
    {
        get { return maxExperience; }
        set { maxExperience = value; }
    }

    [SerializeField]
    private float health = 100;
    public float Health { 
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float maxHealth = 100;
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    [SerializeField]
    private float movementSpeed = 5f;
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    [SerializeField]
    private float dashSpeed = 2f;
    public float DashSpeed
    {
        get { return dashSpeed; }
        set { dashSpeed = value; }
    }
    [SerializeField]
    private float dashLength = 2f;
    public float DashLength
    {
        get { return dashLength; }
        set { dashLength = value; }
    }
    [SerializeField]
    private float dashCooldown = 1f;
    public float DashCooldown
    {
        get { return dashCooldown; }
        set { dashCooldown = value; }
    }
    [SerializeField]

    private GameObject PlayerUI;


    private BaseBar HP;
    private BaseBar XP;

    private void Start()
    {
        PlayerUI = GameObject.Find("PlayerUI");
        XP = PlayerUI.transform.Find("XP").transform.Find("Bar").GetComponent<BaseBar>();
        HP = PlayerUI.transform.Find("HP").transform.Find("Bar").GetComponent<BaseBar>();
    }
    private void Update()
    {
        HP.SetSize(health/maxHealth);
        XP.SetSize(experience/maxExperience);
    }
    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
