//TitleGenerator.cs
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.InputManagerEntry;
using UnityEditor.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.WSA;

public class TitleGenerator : MonoBehaviour
{
    // Race-based adjectives
    private Dictionary<string, string[]> raceAdjectives = new Dictionary<string, string[]>
    {
        { "Human", new string[] { "Noble", "Versatile", "Determined", "Ambitious", "Resourceful" } },
        { "Giant", new string[] { "Towering", "Mighty", "Colossal", "Mountain", "Titanic" } },
        { "Elf", new string[] { "Mystic", "Ancient", "Graceful", "Ethereal", "Starborn" } },
        { "Werewolf", new string[] { "Feral", "Moonlit", "Wild", "Savage", "Primal" } },
        { "Dwarf", new string[] { "Stout", "Stone", "Mountain", "Hardy", "Iron" } },
        { "Ogre", new string[] { "Brutal", "Massive", "Fierce", "Hulking", "Mighty" } },
        { "Triling", new string[] { "Tri-blessed", "Triple", "Three-fold", "Trinity", "Triadic" } },
        { "Morphling", new string[] { "Shifting", "Fluid", "Changing", "Formless", "Adaptive" } },
        { "Changeling", new string[] { "Deceptive", "Cunning", "Elusive", "Mysterious", "Shadow" } },
        { "Minotaur", new string[] { "Swift", "Galloping", "Wild", "Untamed", "Natural" } },
        { "Troll", new string[] { "Regenerating", "Tenacious", "Relentless", "Primordial", "Ancient" } },
        { "Undead", new string[] { "Spectral", "Necrotic", "Unholy", "Ghastly", "Deathless" } },
        { "Skeleton", new string[] { "Rattling", "Brittle", "Boneclad", "Hollow", "Withered" } },
        { "Ghoul", new string[] { "Feral", "Ravenous", "Pestilent", "Ghastly", "Decayed" } },
        { "Tiefling", new string[] { "Infernal", "Horned", "Fiery", "Sinister", "Hellborn" } },
        { "High Elf", new string[] { "Radiant", "Arcane", "Serene", "Celestial", "Exalted" } },
        { "Dark Elf", new string[] { "Shadowed", "Venomous", "Dusky", "Nocturnal", "Malevolent" } },
        { "Goblin", new string[] { "Cunning", "Sneaky", "Mischievous", "Vile", "Wily"} },
        { "Orc", new string[] { "Brawny", "Warlike", "Ferocious", "Savage", "Barbaric"} },
        { "Gnome", new string[] { "Ingenious", "Mystic", "Artful", "Clever", "Small"} },
        { "Halfling", new string[] { "Courageous", "Loyal", "Friendly", "Adventurous", "Jolly" } },
        { "Merfolk", new string[] { "Enchanting", "Graceful", "Mysterious", "Ancient", "Wise"} },
        { "Centaur", new string[] { "Majestic", "Wise", "Agile", "Swift", "Noble"} },
        { "Dragonborn", new string[] { "Fearsome", "Powerful", "Resilient", "Draconic", "Fiery"} },
        { "Kobold", new string[] { "Sneaky", "Mischievous", "Cunning", "Agile", "Reptilian" } },
        { "Vampire", new string[] { "Immortal", "Seductive", "Aristocratic", "Powerful", "Mysterious" } },
        { "Fairy", new string[] { "Magical", "Graceful", "Beautiful", "Ethereal", "Playful" } },
        { "Firbolg", new string[] { "Gentle", "Reclusive", "Nature-bound", "Towering", "Wise" } },
        { "Yuan-Ti", new string[] { "Serpentine", "Deceptive", "Venomous", "Sinister", "Cold" } },
        { "Kenku", new string[] { "Feathered", "Mimic", "Cunning", "Shadowy", "Flightless" } },
        { "Tabaxi", new string[] { "Feline", "Curious", "Agile", "Swift", "Prowling" } },
        { "Aasimar", new string[] { "Celestial", "Radiant", "Divine", "Blessed", "Seraphic" } },
        { "Genasi", new string[] { "Elemental", "Fiery", "Stormy", "Earthbound", "Fluid" } },
        { "Bugbear", new string[] { "Hulking", "Brutal", "Sneaky", "Fearsome", "Shaggy" } },
        { "Gnoll", new string[] { "Savage", "Hyena-like", "Ferocious", "Packbound", "Bloodthirsty" } },
        { "Satyr", new string[] { "Playful", "Horned", "Festive", "Charming", "Wild" } },
        { "Harpy", new string[] { "Winged", "Enchanting", "Clawed", "Shrill", "Soaring" } },


    };

    // Class-based titles
    private Dictionary<string, string[]> classTitles = new Dictionary<string, string[]>
    {
        { "Mage", new string[] { "Spellweaver", "Arcanist", "Conjurer", "Sorcerer", "Mystic" } },
        { "Knight", new string[] { "Defender", "Guardian", "Protector", "Sentinel", "Vanguard" } },
        { "Thief", new string[] { "Shadow", "Rogue", "Nightblade", "Phantom", "Trickster" } },
        { "Archer", new string[] { "Marksman", "Hunter", "Sharpshooter", "Ranger", "Scout" } },
        { "Cleric", new string[] { "Healer", "Priest", "Oracle", "Divine", "Prophet" } },
        { "Druid", new string[] { "Naturalist", "Shaman", "Wildkeeper", "Earthcaller", "Beastfriend" } },
        { "Fighter", new string[] { "Warrior", "Champion", "Gladiator", "Battler", "Brawler" } },
        { "Tracker", new string[] { "Pathfinder", "Wayfinder", "Guide", "Huntmaster", "Seeker" } },
        { "Warrior", new string[] { "Blade", "Soldier", "Commander", "Hero", "Veteran" } },
        { "Berserker", new string[] { "Brutal", "Savage", "Relentless", "Ferocious", "Wild" } },
        { "Twin Blade", new string[] { "Agile", "Swift", "Flurry", "Dual", "Whirlwind" } },
        { "Spear", new string[] { "Piercing", "Thrusting", "Sweeping", "Charging", "Impaling" } },
        { "Shield", new string[] { "Defensive", "Guardian", "Bulwark", "Fortified", "Unbreakable" } },
        { "Short Sword", new string[] { "Agile", "Precise", "Swift", "Accurate", "Deadly" } },
        { "Paladin", new string[] { "Holy", "Valorous", "Righteous", "Blessed", "Stalwart" } },
        { "Warlock", new string[] { "Eldritch", "Cursed", "Pactbound", "Shadowy", "Enigmatic" } },
        { "Bard", new string[] { "Melodic", "Charming", "Eloquent", "Witty", "Inspired" } },
        { "Ranger", new string[] { "Wild", "Keen", "Pathfinder", "Stealthy", "Rugged" } },
        { "Sorcerer", new string[] { "Arcane", "Innate", "Potent", "Charismatic", "Mystical" } },
        { "Monk", new string[] { "Serene", "Disciplined", "Swift", "Balanced", "Enlightened" } },
        { "Rogue", new string[] { "Cunning", "Swift", "Elusive", "Deadly", "Sly" } },
        { "Wizard", new string[] { "Arcane", "Scholarly", "Wise", "Mystical", "Erudite" } },
        { "Barbarian", new string[] { "Fierce", "Raging", "Untamed", "Brutal", "Primal" } },
        { "Artificer", new string[] { "Ingenious", "Crafty", "Mechanical", "Inventive", "Resourceful" } },
        { "Necromancer", new string[] { "Deathly", "Necrotic", "Grim", "Cursed", "Unholy" } },
        { "Samurai", new string[] { "Honorable", "Disciplined", "Bladebound", "Steadfast", "Resolute" } },
        { "Swashbuckler", new string[] { "Dashing", "Nimble", "Flamboyant", "Quick", "Roguish" } },
        { "Psion", new string[] { "Psychic", "Enigmatic", "Mindful", "Piercing", "Ethereal" } },
        { "Inquisitor", new string[] { "Zealous", "Relentless", "Inquisitive", "Stern", "Devout" } },
        { "Alchemist", new string[] { "Potent", "Clever", "Experimental", "Volatile", "Brewmaster" } },
        { "Gunslinger", new string[] { "Sharp", "Gritty", "Trigger-happy", "Deadly", "Precise" } },
        { "Blood Hunter", new string[] { "Grim", "Bloodied", "Relentless", "Cursed", "Fierce" } },
        { "Hexblade", new string[] { "Shadowy", "Hexed", "Bladecursed", "Mystical", "Dark" } },
        { "Summoner", new string[] { "Conjuring", "Bound", "Mystical", "Commanding", "Ethereal" } },




    };

    public string GenerateTitle(string characterName, string race, string characterClass)
    {
        if (!raceAdjectives.ContainsKey(race) || !classTitles.ContainsKey(characterClass))
        {
            return characterName;
        }

        string[] raceAdjs = raceAdjectives[race];
        string[] classNames = classTitles[characterClass];

        string randomRaceAdj = raceAdjs[Random.Range(0, raceAdjs.Length)];
        string randomClassTitle = classNames[Random.Range(0, classNames.Length)];

        return $"{characterName} the {randomRaceAdj} {randomClassTitle}";
    }

    public string GenerateRandomTitle(string characterName)
    {
        // Get random race
        string[] races = new string[] { "Human", "Giant", "Elf", "Werewolf", "Dwarf", "Ogre",
            "Triling", "Morphling", "Changeling", "Minotaur", "Troll", "Undead", "Skeleton", 
            "Ghoul", "Tiefling", "High Elf", "Dark Elf", "Goblin", "Orc", "Gnome", "Halfling",
            "Merfolk", "Centaur", "Dragonborn", "Kobold", "Vampire", "Fairy", "Firbolg", "Yuan-Ti",
            "Kenku", "Tabaxi", "Aasimar", "Genasi", "Bugbear", "Gnoll", "Satyr", "Harpy"};
        string randomRace = races[Random.Range(0, races.Length)];

        // Get random class
        string[] classes = new string[] { "Mage", "Knight", "Thief", "Archer", "Cleric",
            "Druid", "Fighter", "Tracker", "Warrior", "Berserker", "Twin Blade", "Spear",
            "Shield", "Short Sword", "Paladin", "Warlock", "Bard", "Ranger", "Sorcerer",
            "Monk", "Rogue", "Wizard", "Barbarian", "Artificer", "Necromancer", "Samurai", 
            "Swashbuckler", "Psion", "Inquisitor", "Alchemist", "Gunslinger", "Blood Hunter", 
            "Hexblade", "Summoner"};
        string randomClass = classes[Random.Range(0, classes.Length)];

        return GenerateTitle(characterName, randomRace, randomClass);
    }
}