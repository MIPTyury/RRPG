using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Ссылки на компоненты игрока
    public PlayerController playerController;
    public PlayerStats playerStats;
    public PlayerSkills playerSkills;
    public Inventory inventory;
    public PlayerUI playerUI;
    public SkillManager skillManager;

    private void Start()
    {
        // Инициализация компонентов при старте игры
        playerController = GetComponent<PlayerController>();
        playerStats = GetComponent<PlayerStats>();
        playerSkills = GetComponent<PlayerSkills>();
        inventory = GetComponent<Inventory>();
        playerUI = GetComponent<PlayerUI>();
        skillManager = GetComponent<SkillManager>();
    }

    private void Update()
    {
        // Пример использования компонентов в Update (можно изменить под свои нужды)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSkills.CastSpell();
        }
    }

    // Другие методы и функции для управления игроком
}
