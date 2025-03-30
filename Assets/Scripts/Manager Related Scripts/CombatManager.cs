//CombatManager.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatManager : MonoBehaviour
{
    private static CombatManager instance;
    public static CombatManager Instance { get { return instance; } }

    [Header("UI References")]
    [SerializeField] private GameObject attackPanel;
    [SerializeField] private Button basicAttackButton;
    [SerializeField] private Button skillsButton;
    [SerializeField] private TextMeshProUGUI combatText;

    [Header("Debug Settings")]
    [SerializeField] private bool showDebugLogs = true;

    private StateManager stateManager;
    private Player attackingPlayer;
    private Player defendingPlayer;
    private bool inCombat = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log("CombatManager starting...");
        stateManager = GameObject.FindFirstObjectByType<StateManager>();

        if (attackPanel == null)
        {
            Debug.LogError("Attack Panel not assigned in inspector!");
            return;
        }

        if (basicAttackButton == null)
        {
            Debug.LogError("Basic Attack Button not assigned in inspector!");
            return;
        }

        // Set up button listeners
        basicAttackButton.onClick.RemoveAllListeners();
        basicAttackButton.onClick.AddListener(() => {
            Debug.Log("Basic Attack button clicked");
            if (inCombat && attackingPlayer != null && defendingPlayer != null)
            {
                ExecuteBasicAttack();
            }
            else
            {
                Debug.LogWarning("Cannot execute attack - combat not properly initialized");
            }
        });

        attackPanel.SetActive(false);
        Debug.Log("CombatManager initialized successfully");
    }



    public void InitiateCombat(Player attacker, Player defender)
    {
        Debug.Log($"InitiateCombat called with attacker: {(attacker != null ? attacker.name : "null")} and defender: {(defender != null ? defender.name : "null")}");

        if (attacker == null || defender == null)
        {
            Debug.LogError("InitiateCombat called with null player reference");
            return;
        }

        if (attackPanel == null)
        {
            Debug.LogError("Attack Panel reference is missing!");
            return;
        }

        attackingPlayer = attacker;
        defendingPlayer = defender;
        inCombat = true;

        attackPanel.SetActive(true);
        Debug.Log("Combat panel activated");

        if (combatText != null)
        {
            combatText.text = $"{GetPlayerName(attacker)} is attacking {GetPlayerName(defender)}!";
            Debug.Log($"Combat text updated: {combatText.text}");
        }
        else
        {
            Debug.LogError("Combat Text component is missing!");
        }
    }

    private string GetPlayerName(Player player)
    {
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            string playerDataKey = $"Player{playerMove.PlayerId + 1}_Data";
            string playerDataJson = PlayerPrefs.GetString(playerDataKey);
            if (!string.IsNullOrEmpty(playerDataJson))
            {
                CharacterData charData = JsonUtility.FromJson<CharacterData>(playerDataJson);
                if (charData != null)
                {
                    return charData.characterName;
                }
            }
        }
        return $"Player {playerMove?.PlayerId + 1}";
    }

    public void ExecuteBasicAttack()
    {
        Debug.Log("Execute Basic Attack called");

        if (!inCombat || attackingPlayer == null || defendingPlayer == null)
        {
            Debug.LogWarning("Cannot execute attack - combat not properly initialized");
            return;
        }

        float hitChance = CalculateHitChance(attackingPlayer, defendingPlayer);
        bool isHit = Random.value <= hitChance;

        Debug.Log($"Attack roll - Hit Chance: {hitChance}, Result: {(isHit ? "Hit!" : "Miss!")}");

        if (isHit)
        {
            int damage = CalculateDamage(attackingPlayer, defendingPlayer);
            bool isCritical = IsCriticalHit(attackingPlayer);

            if (isCritical)
            {
                damage = (int)(damage * 1.5f);
                Debug.Log("Critical Hit!");
            }

            defendingPlayer.ModifyHealth(-damage);

            if (combatText != null)
            {
                string critText = isCritical ? "CRITICAL! " : "";
                combatText.text = $"{critText}{GetPlayerName(attackingPlayer)} hit {GetPlayerName(defendingPlayer)} for {damage} damage!";
            }

            Debug.Log($"{GetPlayerName(attackingPlayer)} hit {GetPlayerName(defendingPlayer)} for {damage} damage!");
        }
        else
        {
            if (combatText != null)
            {
                combatText.text = $"{GetPlayerName(attackingPlayer)}'s attack missed!";
            }
            Debug.Log($"{GetPlayerName(attackingPlayer)}'s attack missed!");
        }

        EndCombat();
    }

    private float CalculateHitChance(Player attacker, Player defender)
    {
        float baseChance = 0.7f; // 70% base hit chance
        float attackerAccuracy = attacker.properties.Dexterity * 0.02f; // 2% per point
        float defenderDodge = defender.properties.Agility * 0.015f; // 1.5% per point

        return Mathf.Clamp01(baseChance + attackerAccuracy - defenderDodge);
    }

    private int CalculateDamage(Player attacker, Player defender)
    {
        float baseDamage = attacker.properties.Strength * 1.5f;
        float defenseReduction = defender.properties.Defense * 0.5f;

        // Apply random variation (±20%)
        float variation = Random.Range(0.8f, 1.2f);

        int finalDamage = Mathf.Max(1, Mathf.RoundToInt((baseDamage - defenseReduction) * variation));
        return finalDamage;
    }

    private bool IsCriticalHit(Player attacker)
    {
        float critChance = attacker.properties.Luck * 0.01f; // 1% per luck point
        return Random.value <= critChance;
    }

    private void EndCombat()
    {
        if (attackPanel != null)
        {
            attackPanel.SetActive(false);
        }

        if (attackingPlayer != null)
        {
            PlayerMove attackerMove = attackingPlayer.GetComponent<PlayerMove>();
            if (attackerMove != null)
            {
                attackerMove.EndCombat();
            }
        }

        inCombat = false;
        attackingPlayer = null;
        defendingPlayer = null;

        // Let the state manager know combat is done
        stateManager.IsDoneAnimating = true;
    }
}