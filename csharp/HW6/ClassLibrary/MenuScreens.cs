using static ClassLibrary.Styling;
namespace ClassLibrary;

/// <summary>
/// Different menu screens used in app's UI.
/// </summary>
public static class MenuScreens
{
    /// <summary>
    /// Menu for sorting.
    /// </summary>
    /// <param name="heroes"></param>
    public static void SortingMenu(ref Hero[] heroes)
    {
        Menu fieldsMenu = new Menu(new[] { "hero_id", "hero_name", "faction", "level" },
            "Выберите поле для сортировки:");
        switch (fieldsMenu.Open())
        {
            case 0:
                heroes = heroes.Sort(HeroFields.hero_id);
                break;
            case 1:
                heroes = heroes.Sort(HeroFields.hero_name);
                break;
            case 2:
                heroes = heroes.Sort(HeroFields.faction);
                break;
            case 3:
                heroes = heroes.Sort(HeroFields.level);
                break;
        }
    }

    /// <summary>
    /// Menu for editing.
    /// </summary>
    /// <param name="heroes"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void EditingMenu(ref Hero[] heroes)
    {
        Menu chooseHeroMenu = new Menu((from hero in heroes select hero.ToString()).ToArray(),
            "Выберите героя для редактирования:");
        int heroIndex = chooseHeroMenu.Open();
        Menu heroEditMenu = new Menu(new[] { "hero_name", "faction", "bosses_slayed" },
            "Выберите поле для редактирования:");
        HeroFields heroFieldToEdit = new []
            {HeroFields.hero_name, HeroFields.faction, HeroFields.bosses_slayed}[heroEditMenu.Open()];
        Console.Clear();
        if (heroFieldToEdit != HeroFields.bosses_slayed)
        {
            Console.Write("Введите значение: ");
            while (true)
            {
                string? newValue = Console.ReadLine();
                if (!string.IsNullOrEmpty(newValue))
                {
                    heroes[heroIndex].Update(heroFieldToEdit, newValue);
                    break;
                }
                Console.Write($"{Red("[X]Некорректное значение!")} Попробуйте еще раз: ");
            }
        }
        else
        {
            Menu chooseBossMenu = new Menu((from boss in heroes[heroIndex].bosses_slayed select boss.ToString()).ToArray(),
                "Выберите босса для редактирования:");
            int bossIndex = chooseBossMenu.Open();
            Menu bossEditMenu = new Menu(new[] { "boss_name", "expirience", "current_location" },
                "Выберите поле для редактирования:");
            BossFields bossFieldToEdit = new []
                {BossFields.boss_name, BossFields.experience, BossFields.current_location}[bossEditMenu.Open()];
            Console.Write("Введите значение: ");
            while (true)
            {
                object? newValue = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty((string?)newValue)) throw new ArgumentException("Значение равно null.");
                    if (bossFieldToEdit == BossFields.experience)
                    {
                        newValue = int.Parse((string)newValue);
                    }
                    heroes.UpdateBoss(heroes[heroIndex].bosses_slayed[bossIndex].boss_id, bossFieldToEdit, newValue);
                    break;
                }
                catch (FormatException)
                {
                    Console.Write($"{Red("[X]Некорректный тип данных.")} Попробуйте еще раз: ");
                }
                catch (Exception e)
                {
                    Console.Write($"{Red($"[X]{e.Message}")} Попробуйте еще раз: ");
                }
            }
        }
    }
}