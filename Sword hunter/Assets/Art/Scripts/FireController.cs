using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    private string KEY_HEALTH = "health";
    private string KEY_DAMAGE = "damage";

    public float speed = 4.0f;

    public int maxHealth;
    int maxDamage;
    int damage;
    public int damageReceived;

    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public Vector2 pos;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    bool isAtack = false;
    public float timeAttack = 1.0f;
    float timerAttack;

    bool isHurt = false;
    public float timeHurt = 0.3f;
    float timerHurt;

    public float timeDead = 1.0f;
    float timerDead;
    public bool isDead = false;

    public Image skill2;
    public Image skill3;
    float originalSize3;
    float originalSize2;

    float timeSkill1 = 1.0f;
    float timerSkill1;
    float timeSkill2 = 2.0f;
    float timerSkill2;
    float timeSkill3 = 3.0f;
    float timerSkill3;
    bool attack1;
    bool can1;
    bool attack2;
    bool can2;
    bool attack3;
    bool can3;

    public bool isWin = false;

    public bool cham = false;

    public AudioClip skill1Sound;
    public AudioClip skill2Sound;
    public AudioClip skillSound;
    public AudioClip hitSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        string h = PlayerPrefs.GetString(KEY_HEALTH);
        maxHealth = int.Parse(h);
        string d = PlayerPrefs.GetString(KEY_DAMAGE);
        maxDamage = int.Parse(d);

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        dialogBox.SetActive(true);
        timerDisplay = displayTime;

        originalSize2 = skill2.rectTransform.rect.width;
        originalSize3 = skill3.rectTransform.rect.width;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        if (!isAtack && !isHurt && !isDead && !isWin)
        {
            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Move Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);
        }

        if (isInvincible)
        {
            cham = false;
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }

        if (isAtack)
        {
            timerAttack += Time.deltaTime;
            if (timerAttack >= timeAttack)
            {
                isAtack = false;
                timerAttack = 0.0f;
            }
        }

        if (isHurt)
        {
            timerHurt += Time.deltaTime;
            if (timerHurt >= timeHurt)
            {
                isHurt = false;
                timerHurt = 0.0f;
            }
        }

        if (isDead)
        {
            timerDead += Time.deltaTime;
            if (timerDead >= timeDead)
            {
                SceneManager.LoadSceneAsync(8);
            }
        }

        if (!attack1)
        {
            
            timerSkill1 += Time.deltaTime;
            if (timerSkill1 >= 0.7f)
            {
                can2 = true;
                can3 = true;
            }
            if (timerSkill1 >= timeSkill1)
            {
                timerSkill1 = 0.0f;
                attack1 = true;
            }
        }
        if (!attack2)
        {
            timerSkill2 += Time.deltaTime;
            SetValue2(timerSkill2 / timeSkill2);
            if (timerSkill2 >= 0.7f)
            {
                can1 = true;
                can3 = true;
            }
            if (timerSkill2 >= timeSkill2)
            {
                timerSkill2 = 0.0f;
                attack2 = true;
            }
        }
        if (!attack3)
        {
            timerSkill3 += Time.deltaTime;
            SetValue3(timerSkill3 / timeSkill3);
            if (timerSkill3 >= 0.7f)
            {
                can2 = true;
                can1 = true;
            }
            if (timerSkill3 >= timeSkill3)
            {
                timerSkill3 = 0.0f;
                attack3 = true;
            }
        }

        if (attack1 && can1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isAtack = true;
                can2 = false;
                can3 = false;
                animator.SetTrigger("Attack1");
                PlaySound(skillSound);
                damage = maxDamage;
                Vector2 x = new Vector2(1, 0);
                if (lookDirection == x || lookDirection == -x)
                {
                    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 2.0f, LayerMask.GetMask("Enemy"));
                    if (hit.collider != null)
                    {
                        WildController wild = hit.collider.GetComponent<WildController>();
                        if (wild != null)
                        {
                            wild.damageReceived = damage;
                            wild.cham = true;
                        }
                        ZombeManController zbm = hit.collider.GetComponent<ZombeManController>();
                        if (zbm != null)
                        {
                            zbm.damageReceived = damage;
                            zbm.cham = true;
                        }
                        ZombeGirlController zbg = hit.collider.GetComponent<ZombeGirlController>();
                        if (zbg != null)
                        {
                            zbg.damageReceived = damage;
                            zbg.cham = true;
                        }
                        WildNMController wildnm = hit.collider.GetComponent<WildNMController>();
                        if (wildnm != null)
                        {
                            wildnm.damageReceived = damage;
                            wildnm.cham = true;
                        }
                        ZombeManNMController zbmnm = hit.collider.GetComponent<ZombeManNMController>();
                        if (zbmnm != null)
                        {
                            zbmnm.damageReceived = damage;
                            zbmnm.cham = true;
                        }
                        ZombeGirlNMController zbgnm = hit.collider.GetComponent<ZombeGirlNMController>();
                        if (zbgnm != null)
                        {
                            zbgnm.damageReceived = damage;
                            zbgnm.cham = true;
                        }
                        ZombeManBossController zbmboss = hit.collider.GetComponent<ZombeManBossController>();
                        if (zbmboss != null)
                        {
                            zbmboss.damageReceived = damage;
                            zbmboss.cham = true;
                        }
                    }
                }
                attack1 = false;
                timerSkill1 = 0.0f;
            }
        }

        if (attack2 && can2)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isAtack = true;
                can1 = false;
                can3 = false;
                animator.SetTrigger("Attack2");
                PlaySound(skill1Sound);
                damage = maxDamage + (int)maxDamage / 4;
                Vector2 x = new Vector2(1, 0);
                if (lookDirection == x || lookDirection == -x)
                {
                    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 2.5f, LayerMask.GetMask("Enemy"));
                    if (hit.collider != null)
                    {
                        WildController wild = hit.collider.GetComponent<WildController>();
                        if (wild != null)
                        {
                            wild.damageReceived = damage;
                            wild.cham = true;
                        }
                        ZombeManController zbm = hit.collider.GetComponent<ZombeManController>();
                        if (zbm != null)
                        {
                            zbm.damageReceived = damage;
                            zbm.cham = true;
                        }
                        ZombeGirlController zbg = hit.collider.GetComponent<ZombeGirlController>();
                        if (zbg != null)
                        {
                            zbg.damageReceived = damage;
                            zbg.cham = true;
                        }
                        WildNMController wildnm = hit.collider.GetComponent<WildNMController>();
                        if (wildnm != null)
                        {
                            wildnm.damageReceived = damage;
                            wildnm.cham = true;
                        }
                        ZombeManNMController zbmnm = hit.collider.GetComponent<ZombeManNMController>();
                        if (zbmnm != null)
                        {
                            zbmnm.damageReceived = damage;
                            zbmnm.cham = true;
                        }
                        ZombeGirlNMController zbgnm = hit.collider.GetComponent<ZombeGirlNMController>();
                        if (zbgnm != null)
                        {
                            zbgnm.damageReceived = damage;
                            zbgnm.cham = true;
                        }
                        ZombeManBossController zbmboss = hit.collider.GetComponent<ZombeManBossController>();
                        if (zbmboss != null)
                        {
                            zbmboss.damageReceived = damage;
                            zbmboss.cham = true;
                        }
                    }
                }
                attack2 = false;
                timerSkill2 = 0.0f;
            }
        }

        if (attack3 &&  can3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAtack = true;
                can1 = false;
                can2 = false;
                animator.SetTrigger("Attack3");
                PlaySound(skill2Sound);
                damage = maxDamage + (int)maxDamage / 2;
                Vector2 x = new Vector2(1, 0);
                if (lookDirection == x || lookDirection == -x)
                {
                    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 4.0f, LayerMask.GetMask("Enemy"));
                    if (hit.collider != null)
                    {
                        WildController wild = hit.collider.GetComponent<WildController>();
                        if (wild != null)
                        {
                            wild.damageReceived = damage;
                            wild.cham = true;
                        }
                        ZombeManController zbm = hit.collider.GetComponent<ZombeManController>();
                        if (zbm != null)
                        {
                            zbm.damageReceived = damage;
                            zbm.cham = true;
                        }
                        ZombeGirlController zbg = hit.collider.GetComponent<ZombeGirlController>();
                        if (zbg != null)
                        {
                            zbg.damageReceived = damage;
                            zbg.cham = true;
                        }
                        WildNMController wildnm = hit.collider.GetComponent<WildNMController>();
                        if (wildnm != null)
                        {
                            wildnm.damageReceived = damage;
                            wildnm.cham = true;
                        }
                        ZombeManNMController zbmnm = hit.collider.GetComponent<ZombeManNMController>();
                        if (zbmnm != null)
                        {
                            zbmnm.damageReceived = damage;
                            zbmnm.cham = true;
                        }
                        ZombeGirlNMController zbgnm = hit.collider.GetComponent<ZombeGirlNMController>();
                        if (zbgnm != null)
                        {
                            zbgnm.damageReceived = damage;
                            zbgnm.cham = true;
                        }
                        ZombeManBossController zbmboss = hit.collider.GetComponent<ZombeManBossController>();
                        if (zbmboss != null)
                        {
                            zbmboss.damageReceived = damage;
                            zbmboss.cham = true;
                        }
                    }
                }
                attack3 = false;
                timerSkill3 = 0.0f;
            }
        }
        if (cham)
        {
            ChangeHealth(-damageReceived);
        }
    }
    void FixedUpdate()
    {
        if (!isAtack && !isHurt && !isDead && !isWin)
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            pos = position;
            rigidbody2d.MovePosition(position);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            PlaySound(hitSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            isDead = true;
        }
        else
        {
            isHurt = true;
            animator.SetTrigger("Hurt");
        }

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    void SetValue2(float value)
    {
        skill2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize2 * value);
    }
    void SetValue3(float value)
    {
        skill3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize3 * value);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
