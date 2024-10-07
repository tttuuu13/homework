using System.Text;
using System.Text.Json;

namespace ClassLibrary;

/// <summary>
/// Extends Hero[] functionality.
/// </summary>
public static class HeroesExtensions
{
    
    /// <summary>
    /// Sorts heroes by specified field.
    /// </summary>
    /// <param name="heroes">Passed automatically.</param>
    /// <param name="field">Field to be sorted by.</param>
    /// <returns></returns>
    public static Hero[] Sort(this Hero[] heroes, HeroFields field)
    {
        switch (field)
        {
            case HeroFields.hero_id: heroes = heroes.OrderBy(hero => hero.hero_id).ToArray();
                break;
            case HeroFields.hero_name: heroes = heroes.OrderBy(hero => hero.hero_name).ToArray();
                break;
            case HeroFields.level: heroes = heroes.OrderBy(hero => hero.level).ToArray();
                break;
            case HeroFields.faction: heroes = heroes.OrderBy(hero => hero.faction).ToArray();
                break;
        }

        return heroes;
    }
    
    /// <summary>
    /// Updates specified field in all bosses with the same id.
    /// </summary>
    /// <param name="heroes">Passed automatically.</param>
    /// <param name="id">An updated boss id.</param>
    /// <param name="field">Field that's value should be updated.</param>
    /// <param name="value">A new value.</param>
    public static void UpdateBoss(this Hero[] heroes, string id, BossFields field, object value)
    {
        foreach (var hero in heroes)
        {
            foreach (var boss in hero.bosses_slayed)
            {
                if (boss.boss_id == id)
                {
                    boss.Update(field, value);
                }
            }
        }

        if (field == BossFields.experience)
        {
            RecalculateLevels(heroes);
        }
    }

    /// <summary>
    /// Recalculates levels for all heroes.
    /// </summary>
    /// <param name="heroes">Passed automatically.</param>
    private static void RecalculateLevels(this Hero[] heroes)
    {
        foreach (var hero in heroes)
        {
            double level = 0;
            foreach (var boss in hero.bosses_slayed)
            {
                double killers = 0;
                foreach (var h in heroes)
                {
                    if ((from b in h.bosses_slayed select b.boss_id).Contains(boss.boss_id))
                    {
                        killers += 1;
                    }
                }

                level += boss.experience / killers / 100;
            }
            hero.Update(HeroFields.level, Math.Round(level, 1));
        }
    }

    /// <summary>
    /// Prints an array of objects to the console.
    /// </summary>
    /// <param name="heroes">Passed automatically.</param>
    public static void Render(this Hero[] heroes)
    {
        foreach (var hero in heroes)
        {
            Console.WriteLine(hero);
        }
    }
    
    /// <summary>
    /// Converts array to a JSON-like string.
    /// </summary>
    /// <param name="heroes"></param>
    /// <returns></returns>
    public static string ToJson(this Hero[] heroes)
    {
        return JsonSerializer.Serialize(heroes);
    }
}