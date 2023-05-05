using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombeGirlController : MonoBehaviour
{
    int pcoin;

    public bool vertical;
    public float changeTime = 6.0f;
    public float speed = 0.4f;

    float timer;
    Vector2 directionX = new Vector2(1, 0);
    Vector2 directionY = new Vector2(0, 1);
    public Vector2 posP;
    bool isPos = false;

    public int maxHealth = 170;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 0.5f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;

    Animator animator;

    bool isAtack = false;
    public float timeAttack = 1.5f;
    float timerAttack;

    bool isHurt = false;
    public float timeHurt = 0.5f;
    float timerHurt;

    public float timeDead = 1.0f;
    float timerDead;
    public bool isDead = false;

    public bool cham = false;
    int damage = 10;
    public int damageReceived;

    public Image maskEnemy;
    float originalSize;

    int randomSkill;// = Random.Range(1,3);
    int skill;
    float timeSkill = 1.5f;
    float timerSkill;
    bool attack;

    int randomScore;// = Random.Range(10, 20);
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        timer = changeTime;

        originalSize = maskEnemy.rectTransform.rect.width;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPos)
        {
            timer += Time.deltaTime;

            if (timer >= changeTime)
            {
                directionX = -directionX;
                timer = 0.0f;
            }
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

        if (!attack)
        {

            timerSkill += Time.deltaTime;

            if (timerSkill >= timeSkill)
            {
                timerSkill = 0.0f;
                randomSkill = Random.Range(1, 3);
                attack = true;
            }
        }

        if (isDead)
        {
            timerDead += Time.deltaTime;
            if (timerDead >= timeDead)
            {
                Destroy(gameObject);
                timerDead = 0;
            }
        }
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, directionX, 1.0f, LayerMask.GetMask("Character"));
        if (hit.collider != null)
        {
            if (attack)
            {
                isAtack = true;
                randomSkill = Random.Range(1, 3);
                FireController character = hit.collider.GetComponent<FireController>();

                if (character != null)
                {
                    if (randomSkill == 1)
                    {
                        animator.SetTrigger("Attack1");
                        character.damageReceived = damage;
                        character.cham = true;
                        attack = false;
                    }
                    else if (randomSkill == 2)
                    {
                        animator.SetTrigger("Attack2");
                        character.damageReceived = damage + 5;
                        character.cham = true;
                        attack = false;
                    }
                }
            }
        }

        if (cham)
        {
            ChangeHealth(-damageReceived);
        }
    }

    void FixedUpdate()
    {
        if (!isAtack && !isHurt && !isDead)
        {
            Vector2 position = rigidbody2d.position;

            if (!isPos)
            {
                position.x = position.x + Time.deltaTime * speed * directionX.x;
                animator.SetFloat("Move X", directionX.x);
                animator.SetFloat("Move Y", 0);
            }
            else
            {
                GameObject pp = GameObject.FindGameObjectWithTag("Player");
                if (pp != null)
                {
                    FireController posp = pp.GetComponent<FireController>();
                    if (posp != null)
                    {
                        posP = posp.pos;
                        if (position.x < posP.x)
                        {
                            directionX.x = 1;
                            position.x = position.x + Time.deltaTime * 2 * speed * directionX.x;
                        }
                        else
                        {
                            directionX.x = -1;
                            position.x = position.x + Time.deltaTime * 2 * speed * directionX.x;
                        }
                        if (position.y < posP.y)
                        {
                            directionY.y = 1;
                            position.y = position.y + Time.deltaTime * 2 * speed * directionY.y;
                        }
                        else
                        {
                            directionY.y = -1;
                            position.y = position.y + Time.deltaTime * 2 * speed * directionY.y;
                        }
                        animator.SetFloat("Move X", directionX.x);
                        animator.SetFloat("Move Y", directionY.y);
                    }
                }
            }

            rigidbody2d.MovePosition(position);
        }
    }

    void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            //PlaySound(hitSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            pcoin = Random.Range(13, 20);
            GameObject PC = GameObject.FindGameObjectWithTag("PlayCoins");
            if (PC != null)
            {
                PlayCoins playCoins = PC.GetComponent<PlayCoins>();
                if (playCoins != null)
                {
                    playCoins.tcoin = pcoin;
                    playCoins.isCoin = true;
                }
            }
            Dead();
            isDead = true;
        }
        else
        {
            isHurt = true;
            animator.SetTrigger("Hurt");
            isPos = true;
        }

        SetValue(currentHealth / (float)maxHealth);
    }
    void SetValue(float value)
    {
        maskEnemy.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
    void Dead()
    {
        GameObject z = GameObject.FindGameObjectWithTag("Win");
        if (z != null)
        {
            Victory vtr = z.GetComponent<Victory>();
            if (vtr != null)
            {
                vtr.zom += 1;
            }
        }
    }
}
