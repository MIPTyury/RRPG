using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text healthText; // Ссылка на компонент TextMeshPro для отображения здоровья игрока
    public TMP_Text manaText;   // Ссылка на компонент TextMeshPro для отображения маны игрока

    private PlayerStats playerStats; // Ссылка на компонент PlayerStats для получения данных о здоровье и мане игрока

    void Start()
    {
        // Получаем ссылку на компонент PlayerStats, который должен быть на том же объекте, что и этот скрипт
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        // Обновляем текстовые компоненты каждый кадр
        UpdateUI();
    }

    // Метод для обновления текстовых компонентов здоровья и маны
    void UpdateUI()
    {
        // Проверяем, существуют ли ссылки на компоненты TextMeshPro
        if (healthText != null && manaText != null && playerStats != null)
        {
            // Обновляем текст компонента здоровья
            healthText.text = "Health: " + playerStats.currentHealth + " / " + playerStats.maxHealth;
            // Обновляем текст компонента маны
            manaText.text = "Mana: " + playerStats.currentMana + " / " + playerStats.maxMana;
        }
        else
        {
            // Если какие-то из компонентов отсутствуют, выводим сообщение об ошибке в консоль
            Debug.LogError("One or more UI components or PlayerStats component is missing!");
        }
    }
}
