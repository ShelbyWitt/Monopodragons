//SkillGenerator.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]

[ExecuteAlways]
public class SkillGenerator : MonoBehaviour
{

    //TODO -- make a secret character thats completely broken (danni head looking ass)


                //TODO -- make attributes (fire, ice, wind, earth, grass, etc and attatch to character creator) called type or attribute or element


        // Race-based skill prefixes
    public Dictionary<string, string[]> raceSkillPrefixes = new Dictionary<string, string[]>
    {
        { "Human", new string[] { "Versatile", "Adaptive", "Resourceful", "Tactical", "Disciplined" } },
        { "Giant", new string[] { "Crushing", "Massive", "Thundering", "Earth-Shattering", "Colossal" } },
        { "Elf", new string[] { "Mystical", "Ancient", "Starlight", "Moonweave", "Natural" } },
        { "Werewolf", new string[] { "Feral", "Lunar", "Beast", "Primal", "Savage" } },
        { "Dwarf", new string[] { "Stone", "Mountain", "Forge", "Deep", "Crystal" } },
        { "Ogre", new string[] { "Brutal", "Smashing", "Mighty", "Destructive", "Fearsome" } },
        { "Triling", new string[] { "Triple", "Trinity", "Threefold", "Triangular", "Triadic" } },
        { "Morphling", new string[] { "Shifting", "Morphic", "Changeling", "Fluid", "Adaptive" } },
        { "Changeling", new string[] { "Deceptive", "Illusory", "Shadowy", "Mimicking", "Transforming" } },
        { "Minotaur", new string[] { "Galloping", "Charging", "Stampeding", "Swift", "Hoofed" } },
        { "Troll", new string[] { "Regenerating", "Trollish", "Unstoppable", "Resilient", "Enduring" } },
        { "Undead", new string[] { "Haunting", "Spectral", "Deathly", "Unholy", "Necrotic" } },
        { "Skeleton", new string[] { "Rattling", "Brittle", "Skeletal", "Eerie", "Haunted" } },
        { "Ghoul", new string[] { "Savage", "Feral", "Diseased", "Ghastly", "Noxious" } },
        { "Tiefling", new string[] { "Infernal", "Demonic", "Fiery", "Hellish", "Cunning" } },
        { "High Elf", new string[] { "Arcane", "Noble", "Elegant", "Ethereal", "Radiant" } },
        { "Dark Elf", new string[] { "Dark", "Shadowy", "Poisonous", "Sinister", "Vicious" } },
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
        { "Firbolg", new string[] { "Woodland", "Furred", "Serene", "Mystic", "Elusive" } },
        { "Yuan-Ti", new string[] { "Serpentine", "Malevolent", "Venomous", "Fanatical", "Sly" } },
        { "Kenku", new string[] { "Clever", "Artful", "Deceitful", "Imitative", "Observant" } },
        { "Tabaxi", new string[] { "Feline", "Curious", "Agile", "Graceful", "Sneaky" } },
        { "Aasimar", new string[] { "Celestial", "Angelic", "Radiant", "Insightful", "Noble" } },
        { "Genasi", new string[] { "Elemental", "Powerful", "Independent", "Mystical", "Planar" } },
        { "Bugbear", new string[] { "Massive", "Brutal", "Hirsute", "Skulking", "Fearsome" } },
        { "Gnoll", new string[] { "Savage", "Ferocious", "Hyena-like", "Warlike", "Bloodthirsty" } },
        { "Satyr", new string[] { "Mirthful", "Hedonistic", "Magical", "Pan-like", "Bacchanalian" } },
        { "Harpy", new string[] { "Luring", "Avian", "Malevolent", "Winged", "Screeching" } }
    
    
    
    };

        // Class-based skill suffixes
    public Dictionary<string, string[]> classSkillSuffixes = new Dictionary<string, string[]>
    {
        { "Mage", new string[] { "Blast", "Bolt", "Nova", "Storm", "Eruption" } },
        { "Knight", new string[] { "Strike", "Guard", "Shield", "Stance", "Charge" } },
        { "Thief", new string[] { "Strike", "Slash", "Shadow", "Stealth", "Backstab" } },
        { "Archer", new string[] { "Shot", "Arrow", "Volley", "Rain", "Pierce" } },
        { "Cleric", new string[] { "Prayer", "Blessing", "Heal", "Smite", "Banishment" } },
        { "Druid", new string[] { "Growth", "Nature", "Wild", "Beast", "Element" } },
        { "Fighter", new string[] { "Slash", "Combat", "Battle", "Strike", "Attack" } },
        { "Tracker", new string[] { "Hunt", "Track", "Trap", "Mark", "Snare" } },
        { "Warrior", new string[] { "Cleave", "Assault", "Rush", "Fury", "Valor" } },
        { "Berserker", new string[] { "Strike", "Slam", "Smash", "Charge", "Assault" } },
        { "Twin Blade", new string[] { "Strike", "Slash", "Flurry", "Dance", "Whirlwind" } },
        { "Spear", new string[] { "Thrust", "Pierce", "Sweep", "Charge", "Impale" } },
        { "Shield", new string[] { "Block", "Bash", "Guard", "Protect", "Counter" } },
        { "Short Sword", new string[] { "Strike", "Slash", "Thrust", "Cut", "Stab" } },
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
        { "Necromancer", new string[] { "Death", "Undead", "Curse", "Drain", "Raise" } },
        { "Samurai", new string[] { "Strike", "Guard", "Stance", "Charge", "Counter" } },
        { "Swashbuckler", new string[] { "Slash", "Strike", "Thrust", "Dodge", "Taunt" } },
        { "Psion", new string[] { "Mind", "Psychic", "Telekinetic", "Telepathic", "Psionic" } },
        { "Inquisitor", new string[] { "Judgment", "Punish", "Smite", "Banish", "Exorcise" } },
        { "Alchemist", new string[] { "Potion", "Elixir", "Bomb", "Transmutation", "Alchemy" } },
        { "Gunslinger", new string[] { "Fire", "Aim", "Reload", "Shoot", "Duel" } },
        { "Blood Hunter", new string[] { "Blood", "Hunt", "Slay", "Track", "Curse" } },
        { "Hexblade", new string[] { "Hex", "Blade", "Shadow", "Dark", "Mystic" } },
        { "Summoner", new string[] { "Summon", "Conjure", "Call", "Bind", "Control" } }
    
    
    };

        // Class-based skill types and base stats
    public Dictionary<string, (string type, int minDamage, int minHealing, int manaRange)> classBaseStats =
        new Dictionary<string, (string, int, int, int)>
    {
        { "Mage", ("Magical", 30, 0, 40) },
        { "Knight", ("Physical", 20, 10, 25) },
        { "Thief", ("Physical", 25, 0, 20) },
        { "Archer", ("Physical", 25, 0, 15) },
        { "Cleric", ("Support", 15, 30, 35) },
        { "Druid", ("Nature", 20, 20, 30) },
        { "Fighter", ("Physical", 35, 0, 20) },
        { "Tracker", ("Physical", 20, 0, 15) },
        { "Warrior", ("Physical", 30, 0, 25) },
        { "Berserker", ("Physical", 30, 0, 25) },
        { "Twin Blade", ("Physical", 35, 5, 20) },
        { "Spear", ("Physical", 25, 0, 20) },
        { "Shield", ("Physical", 25, 0, 20) },
        { "Short Sword", ("Physical", 20, 0, 25) },
        { "Necromancer", ("Magical", 30, 10, 35) },
        { "Samurai", ("Physical", 30, 10, 35) },
        { "Swashbuckler", ("Physical", 35, 0, 20) },
        { "Psion", ("Magical", 20, 0, 15) },
        { "Inquisitor", ("Physical", 30, 0, 25) },
        { "Alchemist", ("Magical", 30, 0, 25) },
        { "Gunslinger", ("Physical", 35, 5, 20) },
        { "Blood Hunter", ("Physical", 25, 0, 20) },
        { "Hexblade", ("Physical", 25, 0, 20) },
        { "Summoner", ("Magical", 20, 0, 25) },
    };

    //TODO make a toggle for names based on attribute (Flame, Fire, Snowy, Ice, etc...) -- Elemental

    //TODO impliment first skill to UI skills

    //race based skills
    public Dictionary<string, List<Skill>> raceSignatureSkills = new Dictionary<string, List<Skill>>
    {
        {
            "Human", new List<Skill>
            {
                new Skill {
                    skillName = "Hidden Power",
                    description = "Attacks all opponents with lower health and mana",
                    manaCost = 45,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Fury Fists",
                    description = "Unleashes a barrage of fists aimed at a target",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Divine Protection",
                    description = "Calls upon the gods to grant temporary protection from incoming damage",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 3, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Zeus",
                    description = "Calls upon Zeus to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Adaptive Strategy",
                    description = "Quickly adapts to the situation, gaining varied bonuses based on battlefield conditions",            //TODO impliment targeted attacks
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3), 
                        new BuffEffect(Skill.BuffType.Defense, 3, 3),
                        new BuffEffect(Skill.BuffType.Speed, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Resourceful Improvisation",
                    description = "Improvises a solution using available resources, creating an unexpected attack",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = false,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Tactical Analysis",
                    description = "Analyzes the battlefield for tactical advantages, gaining insight into enemy weaknesses",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Disciplined Focus",
                    description = "Channels inner discipline to perform a perfectly executed attack",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 1)
                    }
                },
                new Skill {
                    skillName = "Versatile Approach",
                    description = "Uses versatility to adapt attack style to the opponent's weaknesses",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 2, 2)
                    }
                },
            }
        },
        {
            "Giant", new List<Skill>
            {
                new Skill {
                    skillName = "Hammer of Destruction",
                    description = "Drops a deadly hammer on enemy and increases strength for 2 turns",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Drain Smash",
                    description = "Smashes at enemy hitting its vital spots healing for half the damage done",
                    manaCost = 30,
                    damage = 45,
                    healing = 0,    //TODO make a drain buff and impliment half damage here
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Destructive Quake",
                    description = "Devastatingly jumps and pounds into the ground causing an immense quake",
                    manaCost = 50,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from the Titans",
                    description = "Calls upon the Titans to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Earth-Shattering Stomp",
                    description = "Stomps the ground with such force that it damages all enemies in a 4 tile radius",  //TODO impliment aoe attacks
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Colossal Strength",
                    description = "Channels giant heritage to temporarily increase strength beyond normal limits",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Massive Swing",
                    description = "Uses size advantage to deliver a wide, powerful attack that's difficult to dodge",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Thundering Voice",
                    description = "Lets out a booming shout that stuns enemies and intimidates them",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Crushing Grip",
                    description = "Grabs an opponent and crushes them with immense strength",
                    manaCost = 40,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Elf", new List<Skill>
            {
                new Skill {
                    skillName = "Pot of Destruction",
                    description = "Summons a pot that explodes on contact damaging a tile radius of 5", //TODO make function for attacking tiles /areas instead of players
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Sylvan Strike",
                    description = "Hides and ambushes target dealing huge critical damage",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 6, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 6, 3)
                    }
                },
                new Skill {
                    skillName = "This or That",
                    description = "50/50 Chance to petrify self for 2 turns or deal massive damage to an enemy",
                    manaCost = 60,
                    damage = 65,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)   //TODO -- make 50/50 split for attack -- make petrify stat and debuff and impliment
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Freyr",
                    description = "Calls upon Freyr to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Ancient Wisdom",
                    description = "Draws upon ancient elven knowledge to enhance magical abilities",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Magic, 4, 3),
                        new BuffEffect(Skill.BuffType.Intelligence, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Starlight Arrow",
                    description = "Infuses arrows with starlight energy for increased damage and accuracy",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Mystical Connection",
                    description = "Connects with the natural world to gain insight and power",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment mana regen + 10 for 3 turns
                    }
                },
                new Skill {
                    skillName = "Moonweave barrier",
                    description = "Creates a protective barrier woven from moonlight",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 3),
                        new BuffEffect(Skill.BuffType.Magic, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Natural Harmony",
                    description = "Aligns with nature to heal wounds and increase agility",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Agility, 3, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2)
                    }
                },
            }
        },
        {
            "Werewolf", new List<Skill>
            {
                new Skill {
                    skillName = "Night Slash",
                    description = "Transforms and attacks viciously",
                    manaCost = 50,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make tranform function for races and classes and impliment
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 4, 2),
                        new BuffEffect(Skill.BuffType.Agility, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2),
                        new BuffEffect(Skill.BuffType.Strength, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Quick Claw",
                    description = "Transforms and slashes opponent",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make tranform function for races and classes and impliment
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Flesh Eater",
                    description = "Bites a chunk out of opponent, higher chance to crit and more crit damage dealt",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 2),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from King Lycaon",
                    description = "Calls upon King Lycaon to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Lunar Fury",
                    description = "Channels the power of the moon to enter a berserk state",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 4, 3),
                        new BuffEffect(Skill.BuffType.Speed, 3, 3),
                        new BuffEffect(Skill.BuffType.Defense, -2, 3)
                    }
                },
                new Skill {
                    skillName = "Feral Pounce",
                    description = "Leaps at an enemy with primal ferocity",
                    manaCost = 35,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Beast Within",
                    description = "Partially transforms to gain enhanced physical abilities",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 3),
                        new BuffEffect(Skill.BuffType.Speed, 2, 3),
                        new BuffEffect(Skill.BuffType.Agility, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Primal Howl",
                    description = "Unleashes a terrifying howl that frightens enemies",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Savage Claws",
                    description = "Attacks with razor-sharp claws for devastating damage",
                    manaCost = 40,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 1)
                    }
                },
            }
        },
        {
            "Dwarf", new List<Skill>
            {
                new Skill {
                    skillName = "The Seven Hallows",
                    description = "Attacks 7 times dealing different damage types randomly",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make a randomizer for stats and effects
                        //make randomized chance for frozen, burned, poisoned, etc
                    }
                },
                new Skill {
                    skillName = "Knee Chop",
                    description = "Attacks opponents knees to weaken them",
                    manaCost = 25,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make debuff on target and impliment agility debuff on target
                    }
                },
                new Skill {
                    skillName = "Shin Splints",
                    description = "Bashes opponents shins repeatedly",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Odin",
                    description = "Calls upon Odin to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Mountain's Endurance",
                    description = "Channels the endurance fo the mountains to increase defense",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3),
                        new BuffEffect(Skill.BuffType.Shield, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Stone Resolve",
                    description = "Adopts the unyielding nature of stone to resist damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- Damage reduction 30 % for 2 turns
                    }
                },
                new Skill {
                    skillName = "Forge Hammer",
                    description = "Strikes with the precision and power of a master smith",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Crystal Vision",
                    description = "Sees through deception with the clarity of a flawless crystal",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Deep Roots",
                    description = "Establishes an unshakable stance that prevents movement effects",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)   //TODO -- impliment immunity to movement effects for 3 turns
                    }
                },
            }
        },
        {
            "Ogre", new List<Skill>
            {
                new Skill {
                    skillName = "Brutal Swing",
                    description = "Grabs a hammer and swings devastatingly at all opponents within a 3 tile radius",
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Skull Smash",
                    description = "Bashes the head of the opponent violently",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Blind Fury",
                    description = "Loses eye sight for the exchange of a much higher attack and critical chance",
                    manaCost = 45,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -5, 3),
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3),
                        new BuffEffect(Skill.BuffType.Strength, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Orcus",
                    description = "Calls upon Orcus to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Brutal Rampage",
                    description = "Goes on a destructive rampage, hitting multiple enemies in a line of 3 tiles",   //TODO -- impliment aoe attacks
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mighty Roar",
                    description = "Lets out a deafening roar that intimidates enemies",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)  //TODO -- enemies get attack -3 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Smashing Blow",
                    description = "Delivers a devastating blow that can break through defenses",
                    manaCost = 40,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 3, 1)
                    }
                },
                new Skill {
                    skillName = "Destructive Rage",
                    description = "Enters a state of blind rage, increasing damage output",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 5, 3),
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, -2, 3)
                    }
                },
                new Skill {
                    skillName = "Fearsome Presence",
                    description = "Uses intimidating size and appearance to frighten enemies",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment enemies get critical chance - 3 for 2 turns
                    }
                },
            }
        },
        {
            "Triling", new List<Skill>
            {
                new Skill {
                    skillName = "Creation",
                    description = "Channels the ancient spirits, draining natural resources and 20% of max health, but boosting all stats",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,    //TODO make a lose 20% max health function and impliment
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {

                        new BuffEffect(Skill.BuffType.Defense, 4, 3),
                        new BuffEffect(Skill.BuffType.Strength, 4, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 3),
                        new BuffEffect(Skill.BuffType.Attack, 4, 3),
                        new BuffEffect(Skill.BuffType.Agility, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3)

                    }
                },
                new Skill {
                    skillName = "Elemental Fury",
                    description = "Takes weapon and coats it in types field, then charges through enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Tri-Attack",
                    description = "Attacks with the full force of your power, taking down anything in its way",
                    manaCost = 60,
                    damage = 75,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from the Divine",
                    description = "Calls upon the Divine to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Triple Threat",
                    description = "Attacks from three angles simultaneously, very difficult to dodge",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Trinity Force",
                    description = "Harness the power of three to enhance physical attributes",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 3),
                        new BuffEffect(Skill.BuffType.Strength, 3, 3),
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Threefold Mind",
                    description = "Uses multifaceted thinking to predict and counter enemy moves",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Triangular Formation",
                    description = "Creates a defensive triangle that grants protection",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 3),
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Triadic Harmony",
                    description = "Balances three aspects of self to achieve peak performance",
                    manaCost = 50,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 2, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3),
                        new BuffEffect(Skill.BuffType.DodgeChance, 2, 3),
                        new BuffEffect(Skill.BuffType.Speed, 2, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 2, 3),
                        new BuffEffect(Skill.BuffType.Luck, 2, 3),
                        new BuffEffect(Skill.BuffType.Agility, 2, 3),
                        new BuffEffect(Skill.BuffType.Magic, 2, 3),
                        new BuffEffect(Skill.BuffType.Intelligence, 2, 3),
                        new BuffEffect(Skill.BuffType.Dexterity, 2, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 2, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 2, 3),
                        new BuffEffect(Skill.BuffType.Strength, 2, 3),
                        new BuffEffect(Skill.BuffType.Attack, 2, 3),
                        new BuffEffect(Skill.BuffType.Mana, 2, 3)                    
                    }
                },
            }
        },
        {
            "Morphling", new List<Skill>
            {
                new Skill {
                    skillName = "Stealth",
                    description = "Turns invisible to other players and increases stats sharply",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make an invisibility bool and impliment invisibility toggle
                        //TODO make a accuracy buff of some sort 
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Agility, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Steal",
                    description = "Takes opponents attack at random and uses it against themselves",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO -- make some way to create a skill stealer function and use it 
                    }
                },
                new Skill {
                    skillName = "Cycle 3",
                    description = "Transforms into large ____ and hits all enemies",    //TODO -- transform here
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from the Divine",
                    description = "Calls upon the Divine to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Shifting Form",
                    description = "Rapidly changes form to confuse enemies and avoid attacks",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Morphic Assault",
                    description = "Transforms limbs into weapons for a devastating attack",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Fluid Movement",
                    description = "Flows like liquid between attacks, increasing speed and agility",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 3),
                        new BuffEffect(Skill.BuffType.Agility, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Adaptive Defense",
                    description = "Changes body composition to resist incoming damage",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Changeling Strike",
                    description = "Mimics opponent's attack style for increased effectiveness",
                    manaCost = 45,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical", //TODO -- may be Magical depending on opponent 
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Changeling", new List<Skill>
            {
                new Skill {
                    skillName = "Forceful Blade",
                    description = "Transforms into a blade and attacks always hit",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make coat type and impliment here -- delete strength buff
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Transform",
                    description = "Changes attributes to that of a character or object within eyesight for 3 turns",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make a change base attribute function to trigger for 3 turns
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Overclock",
                    description = "Boosts all stats and picks a player to lose attack",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 2),
                        new BuffEffect(Skill.BuffType.Speed, 3, 2),
                        new BuffEffect(Skill.BuffType.Agility, 3, 2),
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 2),
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),
                        new BuffEffect(Skill.BuffType.Luck, 3, 2),
                        new BuffEffect(Skill.BuffType.Magic, 3, 2),
                        new BuffEffect(Skill.BuffType.Intelligence, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 3, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2),
                        new BuffEffect(Skill.BuffType.Dexterity, 3, 2),
                        new BuffEffect(Skill.BuffType.Pierce, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from the Divine",
                    description = "Calls upon the Divine to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Deceptive Appearance",
                    description = "Takes on the appearance of an ally to confuse enemies",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Illusory Attack",
                    description = "Creates multiple illusory copies that all seem to attack",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Shadowy Transformation",
                    description = "Shifts into a shadowy form thats difficult to hit",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 2),
                        new BuffEffect(Skill.BuffType.None, 3, 2)   //TODO -- make this invisibility for 2 turns
                    }
                },
                new Skill {
                    skillName = "Mimicking Strike",
                    description = "Copies opponent's most powerful attack and uses it against them",
                    manaCost = 45,
                    damage = 0, //TODO -- make this copy opponents attack
                    healing = 0,    
                    isAttack = true,
                    skillType = "Magical",  //TODO -- make this copy opponents attack
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Transforming Escape",
                    description = "Transforms to quickly escape dangerous situations",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2),
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
            }
        },
        {
            "Minotaur", new List<Skill>
            {
                new Skill {
                    skillName = "Stampede",
                    description = "Jumps and tramples a single opponent",
                    manaCost = 50,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Stomp",
                    description = "Stomps on enemy... Now thats true horse power!",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "All Caught Up",
                    description = "Advance up to 5 tiles during your turn",
                    manaCost = 50,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",  //TODO -- add Game Option ig idk what to call
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                        //TODO -- make function to advance tiles during turn and impliment here
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Dionysus",
                    description = "Calls upon Dionysus to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Galloping Charge",
                    description = "Charges at high speed toward an enemy, building momentum for a powerful attack",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Charging Assault",
                    description = "Builds speed before delivering a devastating blow",
                    manaCost = 45,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Stampede Force",
                    description = "Tramples multiple enemies underfoot",
                    manaCost = 50,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Swift Movement",
                    description = "Uses natural speed to improve battlefield positioning",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 3),
                        new BuffEffect(Skill.BuffType.Agility, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Hoofed Strike",
                    description = "Delivers a powerful kick with rear hooves",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Troll", new List<Skill>
            {
                new Skill {
                    skillName = "Caveman Smash",
                    description = "Swings arms down brutally on opponents",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Toll Free",
                    description = "Takes a fee from every player",
                    manaCost = 50,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO -- make function for stealing gold from players available
                    }
                },
                new Skill {
                    skillName = "Behind the Shadows",
                    description = "Gain a accuracy buff and dodge buff",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from the Divine",
                    description = "Calls upon the Divine to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",      //TODO -- 'type' is going to be like (Pyro - fire, Aqua - water, etc.)
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- impliment a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Regenerating Flesh",
                    description = "Accelerates natural troll regeneration to quickly heal wounds",
                    manaCost = 40,
                    damage = 0,
                    healing = 35,   //TODO -- add plus 10 per turn for 3 turns
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Trollish Vitality",
                    description = "Channels troll heritage to increase stamina and endurance",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- health + 50 for 3 turns
                    }
                },
                new Skill {
                    skillName = "Unstoppable Recovery",
                    description = "Continues fighting through injuries that would stop others",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 3, 2)   //TODO -- make this damage reduction 35 % for 2 turns
                    }
                },
                new Skill {
                    skillName = "Resilient Hide",
                    description = "Toughens skin to resist physical damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3),
                        new BuffEffect(Skill.BuffType.Shield, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Enduring Spirit",
                    description = "Draws on troll resilience to maintain fighting effectiveness despite injuries",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                            //TODO -- make all these +2 while below 50 % health for 3 turns
                        //new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        //new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        //new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        //new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        //new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        //new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        //new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        //new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        //new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        //new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        //new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        //new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        //new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        //new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        //new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        //new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
            }
        },
        {
            "Undead", new List<Skill>
            {
                new Skill {
                    skillName = "Necrotic Touch",
                    description = "Drains life with a chilling grasp, sapping the enemy’s vitality",
                    manaCost = 30,
                    damage = 35,
                    healing = 20,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Undeath’s Endurance",
                    description = "Bolsters resilience, shrugging off blows with unnatural toughness",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Grave Whisper",
                    description = "Unleashes a haunting wail that unnerves foes",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2) //TODO -- make this reduces enemy attack
                    }
                },
                new Skill {
                    skillName = "Corpse Explosion",
                    description = "Detonates necrotic energy in a wide burst, harming all nearby",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Death’s Embrace",
                    description = "Wraps an enemy in dark tendrils, slowing their actions",
                    manaCost = 35,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -3, 2) // TODO: Implement slow effect on enemy
                    }
                },
                new Skill {
                    skillName = "Spectral Step",
                    description = "Fades into the ethereal, boosting evasion briefly",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Rotting Aura",
                    description = "Exudes a miasma that weakens enemies over time",
                    manaCost = 30,
                    damage = 10,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -3, 3)   //TODO -- make this on enemy
                    }
                },
                new Skill {
                    skillName = "Bone Shard Volley",
                    description = "Hurls jagged bone fragments at multiple foes",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Soul Leech",
                    description = "Steals a fragment of an enemy’s soul to restore mana",
                    manaCost = 0,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Mana, 15, 1)
                    }
                },
            }
        },
        {
            "Skeleton", new List<Skill>
            {
                new Skill {
                    skillName = "Rattling Strike",
                    description = "Delivers a swift, clattering blow with bony limbs",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Bone Armor",
                    description = "Reinforces skeletal frame, boosting defense",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Skull Toss",
                    description = "Throws its own skull, which explodes on impact",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Chattering Curse",
                    description = "Clatters teeth to curse an enemy, lowering their accuracy",
                    manaCost = 25,
                    damage = 10,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -3, 2)  //TODO -- make this on enemy
                    }
                },
                new Skill {
                    skillName = "Brittle Bash",
                    description = "Sacrifices a limb for a powerful, shattering strike",
                    manaCost = 40,
                    damage = 60,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 2) // Self-debuff from limb loss
                    }
                },
                new Skill {
                    skillName = "Reassemble",
                    description = "Pulls scattered bones back together to heal",
                    manaCost = 30,
                    damage = 0,
                    healing = 40,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Bone Cage",
                    description = "Traps an enemy in a cage of animated ribs",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -4, 2) // TODO: Implement immobilization on enemy
                    }
                },
                new Skill {
                    skillName = "Calcium Storm",
                    description = "Spins rapidly, flinging sharp bone shards in all directions",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Undying Will",
                    description = "Channels necromantic energy to resist defeat momentarily",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Health, 20, 2) // Temporary HP boost
                    }
                },
            }
        },
        {
            "Ghoul", new List<Skill>
            {
                new Skill {
                    skillName = "Fetid Claw",
                    description = "Rakes an enemy with filthy claws, risking infection",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3) // TODO: Implement poison damage over time on enemy
                    }
                },
                new Skill {
                    skillName = "Ghastly Howl",
                    description = "Unleashes a bloodcurdling scream to terrify foes",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make this on enemy
                    }
                },
                new Skill {
                    skillName = "Paralyzing Bite",
                    description = "Sinks teeth into a foe, potentially freezing them in place",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -5, 1) // TODO: Implement paralysis on enemy
                    }
                },
                new Skill {
                    skillName = "Feast",
                    description = "Devours flesh to regain strength",
                    manaCost = 30,
                    damage = 25,
                    healing = 30,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Plague Breath",
                    description = "Exhales a cloud of noxious fumes",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 10, 2)    // TODO: Implement poison damage over time on enemy
                    }
                },
                new Skill {
                    skillName = "Grave Stench",
                    description = "Releases a nauseating odor that weakens foes",
                    manaCost = 25,
                    damage = 10,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, -3, 3)  //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Frenzied Assault",
                    description = "Unleashes a flurry of wild, clawing attacks",
                    manaCost = 45,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Carrion Call",
                    description = "Summons a swarm of flies to harass enemies",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -2, 3)  //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Undead Tenacity",
                    description = "Draws on ghoulish resilience to endure punishment",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Health, 25, 2) // Temporary HP
                    }
                },
            }
        },
        {
            "Tiefling", new List<Skill>
            {
                new Skill {
                    skillName = "Hellfire Bolt",
                    description = "Hurls a searing ball of infernal flame",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Fiendish Guile",
                    description = "Sharpens wits with infernal cunning",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Tail Lash",
                    description = "Whips an enemy with a barbed tail",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Infernal Gaze",
                    description = "Locks eyes with a foe, instilling fear",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Brimstone Burst",
                    description = "Unleashes a fiery explosion around the tiefling",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Devil’s Bargain",
                    description = "Sacrifices health to gain a surge of power",
                    manaCost = 0,
                    damage = 0,
                    healing = -20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Shadow Veil",
                    description = "Wraps self in darkness, improving evasion",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Hellish Rebuke",
                    description = "Retaliates with flames when struck",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Trigger counter attack on taking damage
                    }
                },
                new Skill {
                    skillName = "Soul Brand",
                    description = "Marks an enemy with an infernal sigil, weakening them",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -3, 3)   //TODO -- make enemy debuff
                    }
                },
            }
        },
        {
            "High Elf", new List<Skill>
            {
                new Skill {
                    skillName = "Arcane Missile",
                    description = "Fires a volley of magical energy bolts",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elven Grace",
                    description = "Enhances agility with elven poise",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Moonlit Blade",
                    description = "Strikes with an enchanted blade glowing with lunar light",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mystic Ward",
                    description = "Casts a protective barrier against magic",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 5, 3)    //TODO -- make SP Def 
                    }
                },
                new Skill {
                    skillName = "Starfall",
                    description = "Summons a cascade of radiant stars to strike foes",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Ethereal Sight",
                    description = "Sees through illusions and enhances precision",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Frostwind",
                    description = "Unleashes a chilling gust to slow enemies",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -3, 2) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Healing Light",
                    description = "Bathes an ally in restorative elven magic",
                    manaCost = 35,
                    damage = 0,
                    healing = 40,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Arcane Barrage",
                    description = "Unleashes a relentless storm of magical energy",
                    manaCost = 50,
                    damage = 60,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Dark Elf", new List<Skill>
            {
                new Skill {
                    skillName = "Shadow Strike",
                    description = "Attacks from the shadows with deadly precision",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Cloak of Night",
                    description = "Wraps self in darkness to avoid detection",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Venomous Dart",
                    description = "Fires a poisoned projectile that festers",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3)   //TODO -- make poison debuff on enemy
                    }
                },
                new Skill {
                    skillName = "Darkfire",
                    description = "Conjures flames of shadow that burn unnaturally",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
},
                new Skill {
                    skillName = "Web of Shadows",
                    description = "Traps foes in sticky, shadowy tendrils",
                    manaCost = 40,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -4, 2) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Silent Step",
                    description = "Moves with elven stealth, boosting speed",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Poison Cloud",
                    description = "Releases a toxic mist over a wide area",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 10, 2)  //TODO -- make enemy poison debuff
                    }
                },
                new Skill {
                    skillName = "Drow’s Curse",
                    description = "Curses an enemy with dark magic, weakening them",
                    manaCost = 30,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, -3, 3)  //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Nightblade Frenzy",
                    description = "Unleashes a rapid series of shadowy slashes",
                    manaCost = 50,
                    damage = 60,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Goblin", new List<Skill>
            {
                new Skill {
                    skillName = "Sneak Attack",
                    description = "Deals extra damage if the target is unaware",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Trap Setting",
                    description = "Sets a trap that damages the first enemy to step on it",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Disguise",
                    description = "Blends in with surroundings, increasing evasion",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 15, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Maglubiyet",
                    description = "Calls upon Maglubiyet to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Pickpocket",
                    description = "Steals gold from an enemy with nimble fingers",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Hide",
                    description = "Becomes nearly invisible, avoiding attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Ambush",
                    description = "Springs a surprise attack, stunning the target for 1 turn",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Poisoned Blade",
                    description = "Strikes with a poisoned weapon, dealing extra damage over time",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3)   //TODO -- implement poison dealing 5 damage/turn
                    }
                },
                new Skill {
                    skillName = "Quick Escape",
                    description = "Boosts speed to flee or reposition swiftly",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                }
            }
        },
        {
            "Orc", new List<Skill>
            {
                new Skill {
                    skillName = "War Cry",
                    description = "Roars to intimidate, reducing enemy attack",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -3 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Brutal Smash",
                    description = "Delivers a crushing blow with immense force",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Berserk",
                    description = "Enters a rage, boosting attack but lowering defense",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, -3, 3)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Gruumsh",
                    description = "Calls upon Gruumsh to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Charge",
                    description = "Charges forward, dealing damage and knocking back the enemy",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Crushing Blow",
                    description = "A heavy strike that stuns the target",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Enduring Spirit",
                    description = "Channels orcish resilience, granting a temporary shield",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Savage Roar",
                    description = "Roars fiercely, damaging and stunning nearby enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement stun for 1 turn on multiple enemies
                    }
                },
                new Skill {
                    skillName = "Mighty Swing",
                    description = "Swings weapon in a wide arc, hitting multiple foes",
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement AoE attack
                    }
                }
            }
        },
        {
            "Gnome", new List<Skill>
            {
                new Skill {
                    skillName = "Gadget Toss",
                    description = "Throws an explosive gadget at the enemy",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Illusionary Decoy",
                    description = "Creates a decoy to distract enemies",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 2)
                    }
                },
                new Skill {
                    skillName = "Tinker’s Spark",
                    description = "Zaps an enemy with an electric shock",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 2)   //TODO -- implement shock damage over time
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Garl Glittergold",
                    description = "Calls upon Garl Glittergold to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Clockwork Shield",
                    description = "Deploys a mechanical shield to block damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Magic Missile",
                    description = "Fires an unerring bolt of arcane energy",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Gear Grind",
                    description = "Sabotages enemy equipment, reducing their attack",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -3 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Ingenious Trap",
                    description = "Sets a clever trap that immobilizes and damages",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement immobilization for 1 turn
                    }
                },
                new Skill {
                    skillName = "Arcane Surge",
                    description = "Unleashes a burst of magical energy",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Halfling", new List<Skill>
            {
                new Skill {
                    skillName = "Lucky Strike",
                    description = "Lands a fortunate blow with increased critical chance",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Quick Dodge",
                    description = "Evades an attack with nimble footwork",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 20, 2)
                    }
                },
                new Skill {
                    skillName = "Sling Shot",
                    description = "Fires a precise stone from a sling",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Yondalla",
                    description = "Calls upon Yondalla to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Second Chance",
                    description = "Rerolls fate to avoid a fatal blow",
                    manaCost = 35,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement reroll mechanic
                    }
                },
                new Skill {
                    skillName = "Cheerful Boost",
                    description = "Inspires an ally with optimism, boosting their attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2)   //TODO -- apply to ally
                    }
                },
                new Skill {
                    skillName = "Hobbit Hustle",
                    description = "Dashes around foes with surprising speed",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Agility, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Tricky Feint",
                    description = "Misleads an enemy, lowering their accuracy",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy accuracy -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Fateful Blow",
                    description = "A luck-fueled attack with high critical potential",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalDamage, 10, 1)
                    }
                }
            }
        },
        {
            "Merfolk", new List<Skill>
            {
                new Skill {
                    skillName = "Tidal Wave",
                    description = "Summons a wave to crash into enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement AoE attack
                    }
                },
                new Skill {
                    skillName = "Aqua Veil",
                    description = "Shields self with a protective layer of water",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Trident Jab",
                    description = "Strikes with a trident, piercing armor",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Deep Sashelas",
                    description = "Calls upon Deep Sashelas to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Siren’s Call",
                    description = "Charms an enemy, reducing their attack",
                    manaCost = 30,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Water Jet",
                    description = "Blasts a high-pressure stream of water",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Healing Tide",
                    description = "Restores health with soothing waves",
                    manaCost = 30,
                    damage = 0,
                    healing = 25,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Frost Fin",
                    description = "Freezes an enemy with icy water",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement freeze effect for 1 turn
                    }
                },
                new Skill {
                    skillName = "Mermaid’s Grace",
                    description = "Moves fluidly, boosting agility",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Agility, 10, 3)
                    }
                }
            }
        },
        {
            "Centaur", new List<Skill>
            {
                new Skill {
                    skillName = "Galloping Charge",
                    description = "Charges at high speed, dealing damage",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Hoof Strike",
                    description = "Kicks with powerful hooves",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Swift Galloper",
                    description = "Increases speed for swift movement",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Ehlonna",
                    description = "Calls upon Ehlonna to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Stampede",
                    description = "Tramples enemies in a wide area",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement AoE attack
                    }
                },
                new Skill {
                    skillName = "Healing Herbs",
                    description = "Uses natural herbs to heal wounds",
                    manaCost = 30,
                    damage = 0,
                    healing = 25,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Centaur Pride",
                    description = "Inspires allies with fierce pride",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2)   //TODO -- apply to allies
                    }
                },
                new Skill {
                    skillName = "Bow Mastery",
                    description = "Fires a precise arrow with high penetration",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Endurance Run",
                    description = "Boosts stamina for prolonged combat",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 5, 3)
                    }
                }
            }
        },
        {
            "Dragonborn", new List<Skill>
            {
                new Skill {
                    skillName = "Breath Weapon",
                    description = "Unleashes a blast of elemental breath",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement elemental type variation
                    }
                },
                new Skill {
                    skillName = "Dragon Scales",
                    description = "Hardens scales to resist damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 10, 3)
                    }
                },
                new Skill {
                    skillName = "Draconic Roar",
                    description = "Roars with draconic fury, intimidating foes",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Bahamut",
                    description = "Calls upon Bahamut to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Claw Swipe",
                    description = "Slashes with sharp claws",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Fireball",
                    description = "Hurls a ball of flame at the enemy",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement fire damage over time
                    }
                },
                new Skill {
                    skillName = "Dragon Might",
                    description = "Boosts strength with draconic power",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Wing Buffet",
                    description = "Strikes with wings, knocking back enemies",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Tail Lash",
                    description = "Whips with a powerful tail",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Kobold", new List<Skill>
            {
                new Skill {
                    skillName = "Pack Tactics",
                    description = "Attacks with allies, increasing damage",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2)   //TODO -- bonus if allies are nearby
                    }
                },
                new Skill {
                    skillName = "Trap Snap",
                    description = "Sets a trap that snaps shut on an enemy",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement immobilization for 1 turn
                    }
                },
                new Skill {
                    skillName = "Sneaky Stab",
                    description = "Stabs with a small blade from hiding",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Kurtulmak",
                    description = "Calls upon Kurtulmak to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Poison Dart",
                    description = "Fires a poisoned dart at the enemy",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3)   //TODO -- implement poison damage over time
                    }
                },
                new Skill {
                    skillName = "Burrow",
                    description = "Digs underground to avoid attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 15, 2)
                    }
                },
                new Skill {
                    skillName = "Scavenge",
                    description = "Finds gold scraps on the battlefield",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Dragon Worship",
                    description = "Prays to dragons, boosting magic",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Magic, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Quick Hide",
                    description = "Hides swiftly, avoiding damage",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 20, 2)
                    }
                }
            }
        },
        {
            "Vampire", new List<Skill>
            {
                new Skill {
                    skillName = "Blood Drain",
                    description = "Bites an enemy, draining their life",
                    manaCost = 35,
                    damage = 40,
                    healing = 20,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mist Form",
                    description = "Transforms into mist, boosting evasion",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 20, 2)
                    }
                },
                new Skill {
                    skillName = "Bat Swarm",
                    description = "Summons bats to attack enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement AoE attack
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Strahd",
                    description = "Calls upon Strahd to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Hypnotic Gaze",
                    description = "Charms an enemy, reducing their attack",
                    manaCost = 30,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Night Stalker",
                    description = "Boosts speed in darkness",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Vampiric Strength",
                    description = "Increases strength with undead power",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Shadow Bite",
                    description = "Bites from the shadows, dealing critical damage",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Blood Frenzy",
                    description = "Enters a frenzy, boosting attack",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 10, 2)
                    }
                }
            }
        },
        {
            "Fairy", new List<Skill>
            {
                new Skill {
                    skillName = "Pixie Dust",
                    description = "Sprinkles dust that confuses enemies",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy accuracy -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Fairy Flight",
                    description = "Flutters away, boosting evasion",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 15, 2)
                    }
                },
                new Skill {
                    skillName = "Glitter Blast",
                    description = "Blasts enemies with sparkling energy",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Titania",
                    description = "Calls upon Titania to display a 'type' aura of buffs for 5 turns and heals 25 % of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Healing Pollen",
                    description = "Releases pollen to heal allies",
                    manaCost = 30,
                    damage = 0,
                    healing = 25,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- apply to allies
                    }
                },
                new Skill {
                    skillName = "Fey Charm",
                    description = "Charms an enemy, reducing their attack",
                    manaCost = 25,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- implement enemy attack -5 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Sparkle Shield",
                    description = "Creates a shimmering barrier",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 2)
                    }
                },
                new Skill {
                    skillName = "Fairy Dance",
                    description = "Dances to boost agility",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Agility, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Moonbeam",
                    description = "Fires a beam of lunar energy",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Firbolg", new List<Skill>
            {
                new Skill {
                    skillName = "Nature's Fury",
                    description = "Calls upon the forest to unleash a storm of vines and thorns on all enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Healing Touch",
                    description = "Uses nature’s magic to heal an ally’s wounds",
                    manaCost = 35,
                    damage = 0,
                    healing = 30,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Invisible Stalker",
                    description = "Turns invisible, making it harder for enemies to hit",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Mielikki",
                    description = "Calls upon Mielikki to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Forest's Blessing",
                    description = "Draws power from the woods to shield against attacks",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Entangle",
                    description = "Summons roots to trap and slow enemies",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -3, 2)    //TODO -- apply to enemies
                    }
                },
                new Skill {
                    skillName = "Firbolg's Might",
                    description = "Channels giant heritage to enhance physical power",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Camouflage",
                    description = "Blends into surroundings, avoiding detection",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Ancient Wisdom",
                    description = "Taps into ancient knowledge to boost magical prowess",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Magic, 5, 2),
                        new BuffEffect(Skill.BuffType.Intelligence, 5, 2)
                    }
                }
            }
        },
        {
            "Yuan-Ti", new List<Skill>
            {
                new Skill {
                    skillName = "Poisonous Bite",
                    description = "Delivers a venomous bite that poisons the target",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3)    //TODO -- implement poison damage over time on enemy
                    }
                },
                new Skill {
                    skillName = "Sneak Attack",
                    description = "Strikes from hiding with increased damage",
                    manaCost = 25,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Charm Gaze",
                    description = "Hypnotizes an enemy with a serpentine stare",
                    manaCost = 35,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- apply to enemy
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Zehir",
                    description = "Calls upon Zehir to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Snake Form",
                    description = "Transforms into a snake, boosting speed and evasion",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Dark Magic Blast",
                    description = "Unleashes a blast of dark energy at an enemy",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Scaly Armor",
                    description = "Hardens scales to resist damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Hissing Roar",
                    description = "Emits a terrifying hiss to stun enemies",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Venomous Spit",
                    description = "Spits venom that deals damage over time",
                    manaCost = 35,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 3)    //TODO -- implement poison damage over time on enemy
                    }
                }
            }
        },
        {
            "Kenku", new List<Skill>
            {
                new Skill {
                    skillName = "Mimic Voice",
                    description = "Imitates an enemy’s voice to confuse them",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -3, 2)    //TODO -- apply to enemy
                    }
                },
                new Skill {
                    skillName = "Winged Flight",
                    description = "Takes to the air, increasing speed",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Wind Blast",
                    description = "Unleashes a gust of wind to knock back enemies",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Syranita",
                    description = "Calls upon Syranita to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Feather Storm",
                    description = "Sends a flurry of sharp feathers at enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Thief's Reflexes",
                    description = "Quickly dodges incoming attacks",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Sleight of Hand",
                    description = "Steals gold from an enemy with nimble talons",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Echoing Scream",
                    description = "Releases a piercing scream that damages and stuns",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Plummeting Strike",
                    description = "Dives from above with devastating force",
                    manaCost = 40,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Tabaxi", new List<Skill>
            {
                new Skill {
                    skillName = "Pounce",
                    description = "Leaps at an enemy, knocking them down",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement knockdown for 1 turn
                    }
                },
                new Skill {
                    skillName = "Stealthy Strike",
                    description = "Attacks from hiding with increased critical damage",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalDamage, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Cat's Grace",
                    description = "Increases agility to dodge attacks",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Bast",
                    description = "Calls upon Bast to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Claw Swipe",
                    description = "Slashes with claws, causing bleeding damage over time",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 2)    //TODO -- implement bleed damage over time
                    }
                },
                new Skill {
                    skillName = "Night Vision",
                    description = "Enhances accuracy in low light conditions",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Feline Fury",
                    description = "Unleashes a burst of speed and power",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2),
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Purring Healing",
                    description = "Purrs soothingly to heal minor wounds",
                    manaCost = 35,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Acrobatic Dodge",
                    description = "Performs agile maneuvers to evade attacks",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 15, 1)
                    }
                }
            }
        },
        {
            "Aasimar", new List<Skill>
            {
                new Skill {
                    skillName = "Holy Smite",
                    description = "Strikes an enemy with radiant holy energy",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Healing Touch",
                    description = "Heals an ally with a touch of celestial light",
                    manaCost = 35,
                    damage = 0,
                    healing = 30,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Angelic Wings",
                    description = "Sprouts wings to increase mobility",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Celestia",
                    description = "Calls upon Celestia to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Divine Shield",
                    description = "Creates a protective barrier of light",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Radiant Blast",
                    description = "Unleashes a burst of radiant energy",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Celestial Inspiration",
                    description = "Inspires allies with celestial power",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),    //TODO -- apply to allies
                        new BuffEffect(Skill.BuffType.Defense, 3, 2)    //TODO -- apply to allies
                    }
                },
                new Skill {
                    skillName = "Searing Light",
                    description = "Blinds enemies with blinding light",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -3, 2)    //TODO -- apply to enemies
                    }
                },
                new Skill {
                    skillName = "Aasimar's Grace",
                    description = "Channels celestial grace to avoid harm",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 20, 1)
                    }
                }
            }
        },
        {
            "Genasi", new List<Skill>
            {
                new Skill {
                    skillName = "Elemental Blast",
                    description = "Unleashes a blast of elemental energy",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)    //TODO -- vary by element (fire, water, etc.)
                    }
                },
                new Skill {
                    skillName = "Elemental Shield",
                    description = "Creates a shield of elemental power",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 3)
                    }
                },
                new Skill {
                    skillName = "Summon Elemental",
                    description = "Summons an elemental ally to fight alongside",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Istishia",
                    description = "Calls upon Istishia to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Elemental Fury",
                    description = "Channels elemental rage to increase damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Healing from Elements",
                    description = "Draws healing power from the elements",
                    manaCost = 25,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Movement",
                    description = "Uses elemental energy to move swiftly",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Resist Elements",
                    description = "Enhances resistance to elemental damage",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3)    //TODO -- specify elemental resistance
                    }
                },
                new Skill {
                    skillName = "Elemental Empowerment",
                    description = "Boosts magical power with elemental energy",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Magic, 5, 2)
                    }
                }
            }
        },
        {
            "Bugbear", new List<Skill>
            {
                new Skill {
                    skillName = "Savage Strike",
                    description = "Delivers a brutal blow with savage strength",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Intimidating Roar",
                    description = "Roars to intimidate, weakening enemy resolve",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- apply to enemies
                    }
                },
                new Skill {
                    skillName = "Long Reach",
                    description = "Strikes from a distance with extended limbs",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Hruggek",
                    description = "Calls upon Hruggek to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Brutal Slam",
                    description = "Slams an enemy, stunning them",
                    manaCost = 45,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Feral Regeneration",
                    description = "Regenerates health over time",
                    manaCost = 30,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Pack Mentality",
                    description = "Increases damage when near allies",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Hide in Shadows",
                    description = "Conceals self in shadows to avoid detection",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Bear Hug",
                    description = "Grabs and crushes an enemy in a tight grip",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Gnoll", new List<Skill>
            {
                new Skill {
                    skillName = "Rampage",
                    description = "Goes on a frenzied rampage, increasing attack speed",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2),
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Hyena's Bite",
                    description = "Bites with savage teeth, causing bleeding",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 5, 2)    //TODO -- implement bleed damage over time
                    }
                },
                new Skill {
                    skillName = "Pack Hunter",
                    description = "Boosts damage when fighting alongside allies",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Yeenoghu",
                    description = "Calls upon Yeenoghu to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Scavenge",
                    description = "Feeds on fallen enemies to regain health",
                    manaCost = 20,
                    damage = 0,
                    healing = 15,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Feral Scream",
                    description = "Screams to stun nearby enemies",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Gnoll's Endurance",
                    description = "Increases resilience with savage stamina",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Hunger for Blood",
                    description = "Deals extra damage to bleeding enemies",
                    manaCost = 25,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalDamage, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Wild Charge",
                    description = "Charges forward, knocking back enemies",
                    manaCost = 45,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement knockback effect
                    }
                }
            }
        },
        {
            "Satyr", new List<Skill>
            {
                new Skill {
                    skillName = "Pipes of Pan",
                    description = "Plays enchanting music to charm enemies",
                    manaCost = 35,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- apply to enemies
                    }
                },
                new Skill {
                    skillName = "Hoof Kick",
                    description = "Kicks with powerful hooves, knocking back the target",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Nature's Dance",
                    description = "Dances with fey grace to avoid attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Oberon",
                    description = "Calls upon Oberon to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Forest Friend",
                    description = "Calls a woodland creature to assist in battle",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Healing Tune",
                    description = "Plays a soothing melody to heal wounds",
                    manaCost = 35,
                    damage = 0,
                    healing = 25,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Satyr's Leap",
                    description = "Leaps with fey agility to reposition",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Wine of the Gods",
                    description = "Shares divine wine to boost morale",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Wild Abandon",
                    description = "Embraces fey madness to increase attack at a cost",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 2),
                        new BuffEffect(Skill.BuffType.Defense, -2, 2)
                    }
                }
            }
        },
        {
            "Harpy", new List<Skill>
            {
                new Skill {
                    skillName = "Siren's Song",
                    description = "Sings an enchanting song to charm enemies",
                    manaCost = 35,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- apply to enemies
                    }
                },
                new Skill {
                    skillName = "Wings of Fury",
                    description = "Beats wings to increase speed and evasion",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 5, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Talons of Death",
                    description = "Rakes an enemy with sharp talons",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Gift from Aerdrie Faenya",
                    description = "Calls upon Aerdrie Faenya to display a 'type' aura of buffs for 5 turns and heals 25% of max health",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,    //TODO -- implement a percentage of max health option here
                    isAttack = true,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 5),
                        new BuffEffect(Skill.BuffType.Defense, 4, 5),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 5),
                        new BuffEffect(Skill.BuffType.Speed, 4, 5),
                        new BuffEffect(Skill.BuffType.Pierce, 4, 5),
                        new BuffEffect(Skill.BuffType.Luck, 4, 5),
                        new BuffEffect(Skill.BuffType.Agility, 4, 5),
                        new BuffEffect(Skill.BuffType.Magic, 4, 5),
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 5),
                        new BuffEffect(Skill.BuffType.Dexterity, 4, 5),
                        new BuffEffect(Skill.BuffType.Accuracy, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 5),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 4, 5),
                        new BuffEffect(Skill.BuffType.Strength, 4, 5),
                        new BuffEffect(Skill.BuffType.Attack, 4, 5),
                        new BuffEffect(Skill.BuffType.Mana, 4, 5)
                    }
                },
                new Skill {
                    skillName = "Feather Storm",
                    description = "Flings sharp feathers at enemies",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Harpy's Shriek",
                    description = "Shrieks to stun enemies",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement stun for 1 turn
                    }
                },
                new Skill {
                    skillName = "Aerial Assault",
                    description = "Attacks from above with increased critical chance",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Wind Gust",
                    description = "Creates a gust of wind to knock back enemies",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 1)    //TODO -- implement knockback effect
                    }
                },
                new Skill {
                    skillName = "Harpy's Grace",
                    description = "Moves with avian grace to avoid attacks",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                }
            }
        }
    };



    //class based skills
    public Dictionary<string, List<Skill>> classSignatureSkills = new Dictionary<string, List<Skill>>
    {
        {
            "Mage", new List<Skill>
            {
                new Skill {
                    skillName = "Arcane Missile",
                    description = "A concentrated blast of magical energy",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mana Shield",
                    description = "Converts mana into temporary shield",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 4)
                    }
                },
                new Skill {
                    skillName = "Fire Blast",
                    description = "Shoots a devastating blast of fire at any enemy nearby",
                    manaCost = 45,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mana Field",
                    description = "Decrease mana usage for all players within 5 spaces",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -1, -1),
                        //TODO add new buff effect manaCost to decrease mana use for all players
                    }
                },
                new Skill {
                    skillName = "Elemental Wind",
                    description = "Causes all enemies to experience (toggle type) ",            //TODO impliment type toggle
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Arcane Explosion",
                    description = "Release a blast of arcane energy that hits all enemies within a 5 tile radius",            //TODO impliment aoe attacks
                    manaCost = 45,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Temporal Shift",
                    description = "Manipulates time to gain an extra action and increase speed for 2 turns",            //TODO impliment gain extra action
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Runic Barrier",
                    description = "Creates a protective barrier of runbes that absorbs incoming damage",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Spell Theft",
                    description = "Steals the last spell cast by an opponent and uses it against them",            //TODO impliment steal spell and use it on an enemy of a players choosing
                    manaCost = 50,
                    damage = 0,     //TODO Variable (depending on stolen spell
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mana Burn",
                    description = "Drains opponent's mana and converts it to damage",            //TODO impliment steal mana
                    manaCost = 30,
                    damage = 40,    //TODO + opponent's mana drain
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Knight", new List<Skill>
            {
                new Skill {
                    skillName = "Shield Bash",
                    description = "A powerful strike with your shield",
                    manaCost = 20,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Defensive Stance",
                    description = "Increases defense temporarily",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Heavy Slash",
                    description = "Lunges forward and slashes enemy doing extra pierce damage",
                    manaCost = 45,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 2),
                        new BuffEffect(Skill.BuffType.Pierce, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Atomic Weight",
                    description = "Buffs Defense, then scales an attack based on Defense",
                    manaCost = 30,
                    damage = 0, //TODO -- change this to go off of player current defense
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        //TODO make a attack that scales on defense
                    }
                },
                new Skill {
                    skillName = "Elemental Blade",
                    description = "Coats Blade in (type effect) and slashes into enemies and inflicts (type debuff) for 3 turns",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                new Skill {
                    skillName = "Valiant Charge",
                    description = "Rushes toward an enemy with shield raised, dealing damage and gaining defense",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Blade Mastery",
                    description = "Expertly wields blade to increase critical chance and damage for 3 turns",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Honor Guard",
                    description = "Takes a defrensive stance, reducing damage taken by allies within 3 tiles",      //TODO: Impliment possible allies if not change allies to enemies
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Cleaving Strike",
                    description = "Performs a powerful swing that hits multiple enemies in a 3 tile radius",            //TODO impliment aoe attacks 
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Righteous Fury",
                    description = "Channels inner strength to increase all combat abilities for 3 turns",
                    manaCost = 50,
                    damage = 0,    //TODO + opponent's mana drain
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.Defense, 3, 3),
                        new BuffEffect(Skill.BuffType.Strength, 3, 3)
                    }
                },
            }
        },
        {
            "Thief", new List<Skill>
            {
                new Skill {
                    skillName = "Backstab",
                    description = "A sneaky attack dealing high damage",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Dagger Throw",
                    description = "Buffs Accuracy and throws Daggers until it misses (Max 5)",
                    manaCost = 30,
                    damage = 12,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make a accuracy buff of some sort -- delete defense 2 2 
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Stealth",
                    description = "Turns invisible to other players and increases stats sharply",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make an invisibility bool and impliment invisibility toggle
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Agility, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Golden Touch",
                    description = "Attempt to steal gold from target",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elemental Steal",
                    description = "Takes opponents attack at random and uses it against themselves with (current type)",
                    manaCost = 40,
                    damage = 0,        //TODO impliment damage == random player id . random attack . damage
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO -- make some way to create a skill stealer function and use it 
                    }
                },
                new Skill {
                    skillName = "Shadow Step",
                    description = "Teleports behind an enemy within 8 tiles for a surprise attack with increased critical chance",            //TODO impliment targeted attacks
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 1)
                    }
                },
                new Skill {
                    skillName = "Poison Blade",
                    description = "Coats weapon in poison, dealing poison damage when striking an enemy",            //TODO impliment gain extra action
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = false,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 2)  //TODO -- change this to a give poison to enemy player
                    }
                },
                new Skill {
                    skillName = "Smoke Bomb",
                    description = "Throws a smoke bomb, increasing dodge chance and escape ability",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3),
                        new BuffEffect(Skill.BuffType.Speed, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Cutpurse",
                    description = "Steals gold from target and gains speed boost",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Vital Strike",
                    description = "Precisely strikes vital points, dealing high damage with chance to stun",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment stun status and effect here as a chance
                    }
                },
            }
        },
        {
            "Archer", new List<Skill>
            {
                new Skill {
                    skillName = "Precise Shot",
                    description = "A carefully aimed shot with high accuracy",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -1, -1)
                    }
                },
                new Skill {
                    skillName = "Piercing Shot",
                    description = "Buffs Pierce, Crit Damage, Crit Chance then shoots an arrow dealing deadly damage",
                    manaCost = 50,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Stealth",
                    description = "Turns invisible to other players and increases stats sharply",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make an invisibility bool and impliment invisibility toggle
                        new BuffEffect(Skill.BuffType.Accuracy, 2, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Agility, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Quick Draw",
                    description = "Increases attack and speed slightly for 2 turns",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Elemental Shot",
                    description = "Coats arrow in (type effect) and shoots at enemies and inflicts (type debuff) for 3 turns",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                new Skill {
                    skillName = "Multishot",
                    description = "Fires multiple arrows at once, hitting all opponents up to 3 tiles away",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Eagle Eye",
                    description = "Enhances vision and accuracy, increasing critical chance and hit rate",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Pinning Shot",
                    description = "Fires an arrow that pins the target in place, reducing their speed",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 3)  //TODO -- impliment target getting debuff of speed -3 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Trick Shot",
                    description = "Performs an impressive shot that bounces between multiple targets",
                    manaCost = 45,
                    damage = 40,    //TODO -- impliment 3 hits second being 30 third being either 20 or 40
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Rain of Arrows",
                    description = "Fires arrows into the sky that rain down on a 3 tile radius",
                    manaCost = 50,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Cleric", new List<Skill>
            {
                new Skill {
                    skillName = "Holy Smite",
                    description = "Channel divine energy to damage foes",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Drain Rush",
                    description = "Charges at opponent and drains half the damage the attack does",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,    //TODO make a drain buff and impliment half damage here
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Divine Healing",
                    description = "Restore health to yourself or allies",
                    manaCost = 35,
                    damage = 0,
                    healing = 45,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                //TODO make system that goes through turns and still heals 'healing' amt per turn for 5 turns
                new Skill {
                    skillName = "Dark Arts Healing",
                    description = "Calls upon dark arts and releases healing randomly for 5 turns",
                    manaCost = 20,
                    damage = 0,
                    healing = 12,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Health, 12, 5)
                    }
                },
                new Skill {
                    skillName = "Elemental Drain",
                    description = "Coats weapon in (type effect) and attacks enemies inflicting (type debuff) for 3 turns healing for 25% of damage done",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,        //TODO make a drain buff and impliment quarter damage here
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                new Skill {
                    skillName = "Divine Blessing",
                    description = "Channels divine energy to heal allies within 3 tiles",            //TODO impliment aoe healing
                    manaCost = 40,
                    damage = 0,
                    healing = 45,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Holy Nova",
                    description = "Releases a burst of holy energy that damages enemies and heals allies",            //TODO impliment aoe healing and attacks
                    manaCost = 45,
                    damage = 35,
                    healing = 25,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Prayer of Protection",
                    description = "Prays for divine protection, granting shield and defense for 3 turns",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 3),
                        new BuffEffect(Skill.BuffType.Defense, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Spirit Link",
                    description = "Creates a spiritual bond with the spirits, dealing damage and healing",
                    manaCost = 40,
                    damage = 30,
                    healing = 20,
                    isAttack = true,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Righteous Hammer",
                    description = "Summons a glowing hammer that strikes with divine judgement",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
            }
        },
        {
            "Druid", new List<Skill>
            {
                new Skill {
                    skillName = "Nature's Wrath",
                    description = "Call upon nature to damage enemies",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Tree Cutter",
                    description = "Grows branches of a tree to form a dagger as strong as the gods themselves",
                    manaCost = 50,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 4, 2),
                        new BuffEffect(Skill.BuffType.Defense, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 4, 2),
                        new BuffEffect(Skill.BuffType.Attack, 4, 2)
                    }
                },
                new Skill {
                    skillName = "Magic of the Occult",
                    description = "Sharply increases stats at the expense of something...",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 4, 2),
                        new BuffEffect(Skill.BuffType.Defense, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 4, 2),
                        new BuffEffect(Skill.BuffType.Attack, 4, 2),
                        new BuffEffect(Skill.BuffType.Agility, 4, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, -2, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, -2, 3)
                    }
                },
                //TODO make system that goes through turns and still heals 'healing' amt over 3 turns
                new Skill {
                    skillName = "Regeneration",
                    description = "Heal gradually over time",
                    manaCost = 30,
                    damage = 0,
                    healing = 40,
                    isAttack = false,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Health, (40/3), 2)
                    }
                },
                 new Skill {
                    skillName = "Elemental Quake",
                    description = "Changes the terrain to (type effect) and attacks enemies inflicting (type debuff) for 3 turns draining 25% of damage done",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,        //TODO make a drain buff and impliment quarter damage here
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                 new Skill {
                    skillName = "Wild Growth",
                    description = "Causes plants to rapidly grow, entangling enemies and healing ",            //TODO impliment targeted attacks
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Animal Aspect",
                    description = "Takes on aspects of various animals, gaining their abilities",            //TODO impliment gain extra action
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 3),
                        new BuffEffect(Skill.BuffType.Agility, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Healing Spring",
                    description = "Creates a magical spring that heals anyone standing in it for 3 turns",
                    manaCost = 45,
                    damage = 0,
                    healing = 20,   //TODO -- make this 20 healing each round for 3 turns
                    isAttack = false,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Storm of Thorns",
                    description = "Conjures a swirling stormn of thorns that damages all enemies in 3 tile radius",
                    manaCost = 50,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Nature's Blessing",
                    description = "Calls upon nature's power to gradually restore health and increase defense",
                    manaCost = 40,
                    damage = 0,
                    healing = 15,   //TODO -- make it 15 for 3 turns so 45 total
                    isAttack = false,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                },
            }
        },
        {
            "Fighter", new List<Skill>
            {
                new Skill {
                    skillName = "Mighty Swing",
                    description = "A powerful attack with your weapon",
                    manaCost = 25,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Fist of Fury",
                    description = "Unleashes a barrage of attacks at anything in your way",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Drunken Monkey Kung Fu",
                    description = "Sharply increases stats, but at the cost of your motor functions",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 4, 2),
                        new BuffEffect(Skill.BuffType.Defense, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 4, 2),
                        new BuffEffect(Skill.BuffType.Attack, 4, 2),
                        new BuffEffect(Skill.BuffType.Agility, -2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 5, 3)
                        //TODO make a 'drunk' or 'inebriated' option that distorts some function
                    }
                },
                new Skill {
                    skillName = "Battle Cry",
                    description = "Boost your combat abilities",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 2, 3),
                        new BuffEffect(Skill.BuffType.Attack, 2, 3),
                        new BuffEffect(Skill.BuffType.Strength, 2, 3),
                        new BuffEffect(Skill.BuffType.Agility, 2, 3),
                    }
                },
                new Skill {
                    skillName = "Elemental Fist",
                    description = "Coats fists in (type effect) and punches enemies inflicting (type debuff) for 3 turns",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                new Skill {
                    skillName = "Whirlwind Attack",
                    description = "Spins with weapon extended, hitting all surrounding enemies in a 2 tile radius",            //TODO impliment aoe attacks
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Combat Expertise",
                    description = "Uses fighting experience to increase attack and defense capabilities",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Stunning Blow",
                    description = "Delivers a precise strike that has a chance to stun the target",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment stun chance to enemy
                    }
                },
                new Skill {
                    skillName = "Second Wind",
                    description = "Catches a second wind in battle, restoring health and increasing stamina",
                    manaCost = 40,
                    damage = 0,
                    healing = 35,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Perfect Strike",
                    description = "Executes a flawless attack with guaranteed critical hit",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 100, 1)   //TODO -- make this a guarenteed crit
                    }
                },
            }
        },
        {
            "Tracker", new List<Skill>
            {
                new Skill {
                    skillName = "Hunt Mark",
                    description = "Mark target for increased damage",
                    manaCost = 20,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Marked Prey",
                    description = "Unleashes a huge attack and does 1.5 damage for any status conditions",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 2),
                    }
                },
                new Skill {
                    skillName = "Stealth",
                    description = "Turns invisible to other players and increases stats sharply",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make an invisibility bool and impliment invisibility toggle
                        new BuffEffect(Skill.BuffType.Accuracy, 2, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Agility, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Survival Instincts",
                    description = "Increase dodge chance temporarily",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2),
                    }
                },
                 new Skill {
                    skillName = "Elemental Trap",
                    description = "Sets up a (type effect) trap and lures enemies inflicting (type debuff) for 3 turns",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                 new Skill {
                    skillName = "Weakpoint Detection",
                    description = "Analyzes enemy for weakness, increasing damage dealt to them",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Camouflage",
                    description = "Blends into surroundings, becoming difficult to detect",            //TODO impliment invisibility
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        //TODO -- create invisibility and make here
                    }
                },
                new Skill {
                    skillName = "Trapper's Snare",
                    description = "Sets a trap that immobilizes and damages enemies who trigger it, gaining 100% damage dealt in health",
                    manaCost = 35,
                    damage = 40,
                    healing = 40,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                        //TODO -- impliment attack like trap that triggers when stepped on
                    }
                },
                new Skill {
                    skillName = "Precise Targeting",
                    description = "Takes careful aim to increase accuracy and critical damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Predator's Instinct",
                    description = "Channels primal instincts to hunt prey more effectively",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 2),
                        new BuffEffect(Skill.BuffType.Strength, 2, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2)
                    }
                },
            }
        },
        {
            "Warrior", new List<Skill>
            {
                new Skill {
                    skillName = "Brutal Strike",
                    description = "A devastating attack with high damage",
                    manaCost = 35,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "War Cry",
                    description = "Boost strength and defense",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 2),
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),
                    }

                },
                new Skill {
                    skillName = "Petrifying Fist",
                    description = "Punches enemy with such an overwhelming force that it freezes enemy for 2 turns",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO figure out how to link isFrozen bool to specific targeted enemy
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Battle Fury",
                    description = "Increases attack power significantly",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 4, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 2),
                        new BuffEffect(Skill.BuffType.Attack, 4, 2),
                    }
                },
                 new Skill {
                    skillName = "Elemental Bash",
                    description = "Coats shield in (type effect) and charges at enemies inflicting (type debuff) for 3 turns",       //TODO impliment type effect and debuff
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO impliment type effect and debuff
                    }
                },
                 new Skill {
                    skillName = "Berserker Rage",
                    description = "Enters a frenzied state, increasing damage but reducing defense",            //TODO impliment targeted attacks
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 5, 3),
                        new BuffEffect(Skill.BuffType.Strength, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, -2, 3)
                    }
                },
                new Skill {
                    skillName = "Devastating Blow",
                    description = "Delivers an attack with all strength, dealing massive damage",
                    manaCost = 45,
                    damage = 65,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Intimidating Shout",
                    description = "Lets out a terrifying battle cry that reduces enemy attack power",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- make enemies get attack -3 for 2 turns
                    }
                },
                new Skill {
                    skillName = "Battle Momentum",
                    description = "Builds momentum in battle, increasing attack with each successful hit",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 1, 3) //TODO -- impliment way for this to trigger and stack up to 5 times with successful hits
                    }
                },
                new Skill {
                    skillName = "Unstoppable Force",
                    description = "Becomes an unstoppable juggernaut, ignoring obstacles and dealing heavy damage",
                    manaCost = 50,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 4, 2),
                        new BuffEffect(Skill.BuffType.Strength, 3, 2)
                    }
                },
            }
        },
        {
            "Berserker", new List<Skill>
            {
                new Skill {
                    skillName = "Fury Strike",
                    description = "Unleashes a ferocious attack, dealing heavy damage but reducing defense temporarily",
                    manaCost = 30,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 2)
                    }
                },
                new Skill {
                    skillName = "Bloodlust",
                    description = "Gains increased attack power for each point of damage taken",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 1, 0)   // TODO: Implement stacking based on damage taken
                    }
                },
                new Skill {
                    skillName = "War Cry",
                    description = "Lets out a mighty roar, intimidating enemies and reducing their attack power",
                    manaCost = 20,
                    damage = 10,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -3, 2) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Unrelenting Assault",
                    description = "Launches a series of rapid attacks that cannot be interrupted",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Adrenaline Rush",
                    description = "Taps into adrenaline to increase speed and attack speed",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Berserk Mode",
                    description = "Enters a state of fury, increasing damage output but also taking more damage",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 5, 3),
                        new BuffEffect(Skill.BuffType.Defense, -3, 3)
                    }
                },
                new Skill {
                    skillName = "Overpower",
                    description = "Delivers a crushing blow that stuns the enemy",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 1)  // TODO: Implement stunning on enemy
                    }
                },
                new Skill {
                    skillName = "Second Wind",
                    description = "Takes a deep breath, healing and refreshing",
                    manaCost = 30,
                    damage = 0,
                    healing = 30,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 1) // TODO: Implement cleanse
                    }
                },
                new Skill {
                    skillName = "Rage Fueled",
                    description = "The lower the health, the higher the damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement dynamic damage based on health
                    }
                },
            }
        },
        {
            "Twin Blade", new List<Skill>
            {
                new Skill {
                    skillName = "Dual Strike",
                    description = "Strikes twice with each blade, dealing damage twice",
                    manaCost = 25,
                    damage = 25, // Per strike, total 50
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Whirlwind Blades",
                    description = "Spins rapidly, striking all enemies within range",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)  // TODO: Implement AOE attack
                    }
                },
                new Skill {
                    skillName = "Blade Dance",
                    description = "Performs a series of swift, precise attacks that speed up over time",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Defensive Flourish",
                    description = "Uses blades to deflect attacks and counter with a quick strike",
                    manaCost = 20,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 1)
                    }
                },
                new Skill {
                    skillName = "Precision Cut",
                    description = "A precise strike that ignores part of the enemy's defense",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Twin Blade Tornado",
                    description = "Creates a whirlwind of blades around the user, damaging enemies over time",
                    manaCost = 45,
                    damage = 25, // Per tick
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 25, 3)  // TODO: Implement DoT 25 damage for 3 turns
                    }
                },
                new Skill {
                    skillName = "Agile Evasion",
                    description = "Becomes highly agile, increasing evasion and speed",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Speed, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Cross Slash",
                    description = "Crosses the blades to create an X-shaped area of damage",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment aoe 
                    }
                },
                new Skill {
                    skillName = "Blade Mastery",
                    description = "Each successful hit increases attack speed and damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                             // TODO: Implement stacking per hit
                        new BuffEffect(Skill.BuffType.Strength, 1, 0),
                        new BuffEffect(Skill.BuffType.Speed, 1, 0)
                    }
                },
            }
        },
        {
            "Spear", new List<Skill>
            {
                new Skill {
                    skillName = "Lance Charge",
                    description = "Charges forward, impaling all enemies in a straight line",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) //TODO -- impliment aoe
                    }
                },
                new Skill {
                    skillName = "Spear Throw",
                    description = "Throws the spear, dealing damage and potentially stunning the target",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 1) // TODO -- impliment Probability or condition for stunning
                    }
                },
                new Skill {
                    skillName = "Piercing Thrust",
                    description = "A powerful thrust that ignores part of the enemy's defense",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Defensive Stance",
                    description = "Holds the spear defensively, increasing defense and preparing to counter-attack",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3),
                        new BuffEffect(Skill.BuffType.None, 1, 3) // TODO: Implement counter-attack when targeted
                    }
                },
                new Skill {
                    skillName = "Sweep Attack",
                    description = "Swings the spear in a wide arc, hitting multiple enemies",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment aoe attack 
                    }
                },
                new Skill {
                    skillName = "Impale",
                    description = "Pins an enemy to the ground, preventing movement and dealing damage over time",
                    manaCost = 45,
                    damage = 20, // Initial + 10 per turn for 2 turns
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 2, 2),  //TODO -- impliment stun on enemy 
                        new BuffEffect(Skill.BuffType.None, 10, 2)   //TODO -- impliment Damage over Time for 10 damage for 2 turns
                    }
                },
                new Skill {
                    skillName = "Spear Wall",
                    description = "Creates a wall of spears that damages enemies who get too close",
                    manaCost = 35,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment aoe attack 
                    }
                },
                new Skill {
                    skillName = "Quick Jab",
                    description = "A swift jab that deals minor damage and can disrupt enemy actions",
                    manaCost = 15,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -15, 3) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Spear Mastery",
                    description = "Increases the damage and accuracy of spear attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 1, 3)
                    }
                },
            }
        },
        {
            "Shield", new List<Skill>
            {
                new Skill {
                    skillName = "Shield Bash",
                    description = "Bashes an enemy with the shield, stunning them",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 1) //TODO -- impliment stun
                    }
                },
                new Skill {
                    skillName = "Shield Wall",
                    description = "Raises the shield to increase defense and block attacks",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Reflective Shield",
                    description = "Reflects a portion of incoming damage back to the attacker",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 20, 3)    // TODO -- impliment 20% reflect
                    }
                },
                new Skill {
                    skillName = "Taunt",
                    description = "Taunts enemies, making them focus on the user",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 3) // TODO: Implement taunt
                    }
                },
                new Skill {
                    skillName = "Shield Slam",
                    description = "Slam the shield into the ground, stunning nearby enemies",
                    manaCost = 40,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 1, 1),  //TODO -- impliment stun
                        new BuffEffect(Skill.BuffType.None, 0, 0) //TODO -- impliment aoe attack
                    }
                },
                new Skill {
                    skillName = "Healing Ward",
                    description = "Creates a ward that heals the user over time",
                    manaCost = 35,
                    damage = 0,
                    healing = 10, // Per turn for 3 turns
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Health, 10, 3)
                    }
                },
                new Skill {
                    skillName = "Shield Charge",
                    description = "Charges forward, knocking back enemies",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 2, 1) // TODO: Implement knockback
                    }
                },
                new Skill {
                    skillName = "Unbreakable",
                    description = "Becomes unbreakable, increasing defense and immunity to crowd control",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3),
                        new BuffEffect(Skill.BuffType.None, 1, 3)   //TODO -- make invulnerability to all debuffs
                    }
                },
                new Skill {
                    skillName = "Shield of Courage",
                    description = "Inspires nearby allies, increasing their attack power",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 3) //TODO -- impliment AOE buff
                    }
                },
            }
        },
        {
            "Short Sword", new List<Skill>
            {
                new Skill {
                    skillName = "Backstab",
                    description = "Strikes from behind, dealing increased damage",
                    manaCost = 25,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 0, 0) 
                    } 
                },
                new Skill {
                    skillName = "Evasive Maneuver",
                    description = "Performs an evasive maneuver, increasing evasion and speed",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 2),
                        new BuffEffect(Skill.BuffType.Speed, 3, 2) 
                    }
                },
                new Skill {
                    skillName = "Rapid Strikes",
                    description = "Unleashes a series of quick attacks",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 0, 0) //TODO -- impliment Multiple hits
                    } 
                },
                new Skill {
                    skillName = "Shadow Step",
                    description = "Teleports behind an enemy for a surprise attack",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- impliment Teleport effect
                    } 
                },
                new Skill {
                    skillName = "Poisoned Blade",
                    description = "Coats the sword with poison, dealing damage over time",
                    manaCost = 25,
                    damage = 20, // Initial + 10 per turn for 2 turns
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 10, 2) //TODO -- impliment aoe attack
                    }
                },
                new Skill {
                    skillName = "Disarm",
                    description = "Disarms an enemy, making them drop their weapon",
                    manaCost = 30,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 1, 2) // TODO: Implement disarm on enemy
                    } 
                },
                new Skill {
                    skillName = "Stealth",
                    description = "Becomes invisible, increasing evasion and enabling surprise attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.None, 1, 3), //TODO -- create and impliment invisibility boolean
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3) 
                    }
                },
                new Skill {
                    skillName = "Critical Hit",
                    description = "Increases the chance of landing a critical hit",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect> 
                    { 
                        new BuffEffect(Skill.BuffType.CriticalChance, 20, 3) //TODO -- make this a percentage and make that 20 %
                    } 
                },
                new Skill {
                    skillName = "Assassin's Fury",
                    description = "A powerful attack that can instantly kill weakened enemies",
                    manaCost = 40,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 6, 3)
                    }
                }
            }
        },
        {
            "Paladin", new List<Skill>
            {
                new Skill {
                    skillName = "Divine Smite",
                    description = "Channels divine energy into a weapon strike, searing foes with radiant power",
                    manaCost = 30,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Lay on Hands",
                    description = "Heals an ally or self with a touch of divine grace",
                    manaCost = 35,
                    damage = 0,
                    healing = 45,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Aura of Protection",
                    description = "Radiates a holy aura, bolstering allies’ resilience within 3 tiles",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Holy Shield",
                    description = "Conjures a radiant barrier to absorb damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Sacred Oath",
                    description = "Swears a vow, enhancing combat prowess with divine fervor",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 3),
                        new BuffEffect(Skill.BuffType.Attack, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Smite Evil",
                    description = "Strikes with divine wrath, excelling against fiends and undead",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Cleansing Touch",
                    description = "Purges ailments with a holy touch, restoring vitality",
                    manaCost = 20,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement debuff removal
                    }
                },
                new Skill {
                    skillName = "Hammer of Justice",
                    description = "Slams foes with a radiant hammer, potentially stunning them",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add stun chance
                    }
                },
                new Skill {
                    skillName = "Beacon of Hope",
                    description = "Inspires allies within 5 tiles, amplifying healing and morale",
                    manaCost = 45,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement +50% healing received for 3 turns
                    }
                },
                new Skill {
                    skillName = "Holy Nova",
                    description = "Unleashes a burst of light, damaging enemies and healing allies in a 3-tile radius",
                    manaCost = 50,
                    damage = 30,
                    healing = 20,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Warlock", new List<Skill>
            {
                new Skill {
                    skillName = "Eldritch Blast",
                    description = "Fires a beam of dark energy at a foe",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Pact Boon",
                    description = "Draws on a patron’s gift, enhancing personal power",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Hex",
                    description = "Curses an enemy, weakening them and amplifying damage taken",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 3) // TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Dark Pact",
                    description = "Sacrifices health to gain forbidden strength",
                    manaCost = 35,
                    damage = 0, // TODO: Implement self-damage of 10
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 4, 4)
                    }
                },
                new Skill {
                    skillName = "Eldritch Chains",
                    description = "Binds an enemy with shadowy tendrils, halting their movement",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add immobilization effect
                    }
                },
                new Skill {
                    skillName = "Patron’s Grasp",
                    description = "Summons a spectral hand to crush foes",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Maddening Whispers",
                    description = "Whispers drive an enemy to madness, lowering their accuracy",
                    manaCost = 25,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -3, 2) //TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Shadow Veil",
                    description = "Cloaks self in darkness, evading attacks",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Soul Drain",
                    description = "Siphons life from an enemy to heal self",
                    manaCost = 35,
                    damage = 30,
                    healing = 15,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Otherworldly Wrath",
                    description = "Unleashes a patron’s fury, devastating all foes in a 5-tile radius",
                    manaCost = 50,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Bard", new List<Skill>
            {
                new Skill {
                    skillName = "Vicious Mockery",
                    description = "Hurls insults that psychically wound an enemy",
                    manaCost = 20,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2) //TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Song of Rest",
                    description = "Plays a soothing melody to heal allies within 3 tiles",
                    manaCost = 30,
                    damage = 0,
                    healing = 35,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Inspiring Tune",
                    description = "Uplifts allies with music, boosting their combat ability",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Charm Melody",
                    description = "Enchants an enemy with song, bending their will",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add charm effect
                    }
                },
                new Skill {
                    skillName = "Thunderclap Chord",
                    description = "Strums a deafening note, staggering foes in a 3-tile radius",
                    manaCost = 40,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Bardic Flourish",
                    description = "Performs with flair, enhancing agility and precision",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Cutting Words",
                    description = "Taunts an enemy, disrupting their focus and attack",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, -3, 2) // TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Healing Hymn",
                    description = "Sings a hymn that gradually restores health over time",
                    manaCost = 35,
                    damage = 0,
                    healing = 15, // TODO: Implement 15 healing per turn for 3 turns
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Discordant Blast",
                    description = "Unleashes a jarring chord, damaging and disorienting foes",
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -2, 2) // TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Song of Valor",
                    description = "Rallies allies with an epic ballad, boosting all stats",
                    manaCost = 50,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 4),
                        new BuffEffect(Skill.BuffType.Defense, 3, 4),
                        new BuffEffect(Skill.BuffType.Speed, 3, 4)
                    }
                }
            }
        },
        {
            "Ranger", new List<Skill>
            {
                new Skill {
                    skillName = "Hunter’s Mark",
                    description = "Marks a target, increasing damage dealt to it",
                    manaCost = 20,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Volley",
                    description = "Fires a barrage of arrows at enemies in a 3-tile radius",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Nature’s Stride",
                    description = "Moves swiftly through terrain, gaining speed and evasion",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 3),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Beast Call",
                    description = "Summons a spectral beast to aid in battle",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Precise Shot",
                    description = "Takes careful aim for a devastating ranged attack",
                    manaCost = 30,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Camouflage",
                    description = "Blends into surroundings, avoiding detection",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Entangling Roots",
                    description = "Vines ensnare an enemy, rooting them in place",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Nature",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add immobilization effect
                    }
                },
                new Skill {
                    skillName = "Survivalist’s Instinct",
                    description = "Heightens senses, boosting accuracy and critical chance",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Poison Arrow",
                    description = "Fires a venom-tipped arrow, poisoning the target",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add poison DoT, 10 damage/2 turns
                    }
                },
                new Skill {
                    skillName = "Storm of Arrows",
                    description = "Unleashes a rain of arrows across a 5-tile radius",
                    manaCost = 50,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Sorcerer", new List<Skill>
            {
                new Skill {
                    skillName = "Magic Missile",
                    description = "Launches unerring bolts of arcane force",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Wild Magic Surge",
                    description = "Unleashes chaotic magic with unpredictable effects",
                    manaCost = 30,
                    damage = 30, // TODO: Implement random variance
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add random effect, e.g., Strength +2 or Enemy Defense -2
                    }
                },
                new Skill {
                    skillName = "Arcane Shield",
                    description = "Erects a protective magical barrier",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Fireball",
                    description = "Hurls an explosive sphere of flame at a 3-tile radius",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Metamagic Boost",
                    description = "Enhances spellcasting with innate power",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3) // Applies to Magical skills
                    }
                },
                new Skill {
                    skillName = "Lightning Bolt",
                    description = "Fires a crackling bolt through enemies in a line",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Haste",
                    description = "Accelerates time, granting swiftness",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Chaos Bolt",
                    description = "Hurls a shifting bolt of energy with random effects",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add random elemental debuff
                    }
                },
                new Skill {
                    skillName = "Sorcerous Restoration",
                    description = "Taps into innate magic to recover mana",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement mana recovery +20
                    }
                },
                new Skill {
                    skillName = "Meteor Swarm",
                    description = "Calls down fiery meteors to devastate a 5-tile radius",
                    manaCost = 50,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Monk", new List<Skill>
            {
                new Skill {
                    skillName = "Flurry of Blows",
                    description = "Unleashes a rapid series of strikes",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Stunning Strike",
                    description = "Delivers a precise blow to stun an enemy",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add stun chance
                    }
                },
                new Skill {
                    skillName = "Ki Focus",
                    description = "Centers ki to enhance physical abilities",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 3),
                        new BuffEffect(Skill.BuffType.Speed, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Deflect Missiles",
                    description = "Reacts swiftly to block ranged attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Wind Step",
                    description = "Moves with supernatural speed to evade foes",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3),
                        new BuffEffect(Skill.BuffType.Speed, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Shadow Strike",
                    description = "Strikes from the shadows with lethal precision",
                    manaCost = 35,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Healing Touch",
                    description = "Channels ki to mend wounds",
                    manaCost = 30,
                    damage = 0,
                    healing = 35,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Whirlwind Kick",
                    description = "Spins with a powerful kick, hitting all enemies in a 2-tile radius",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Ki Burst",
                    description = "Releases a burst of energy, damaging foes and boosting self",
                    manaCost = 45,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Tranquility",
                    description = "Enters a meditative state, restoring health and focus",
                    manaCost = 50,
                    damage = 0,
                    healing = 40,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 3)
                    }
                }
            }
        },
        {
            "Rogue", new List<Skill>
            {
                new Skill {
                    skillName = "Sneak Attack",
                    description = "Strikes a distracted foe with deadly precision",
                    manaCost = 25,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Stealth",
                    description = "Fades into the shadows, becoming nearly invisible",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3) // TODO: Add invisibility toggle
                    }
                },
                new Skill {
                    skillName = "Poisoned Dagger",
                    description = "Coats a blade in poison, dealing lingering damage",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add poison DoT, 10 damage/2 turns
                    }
                },
                new Skill {
                    skillName = "Pickpocket",
                    description = "Steals gold or items from an unsuspecting target",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Shadow Dash",
                    description = "Quickly dashes through shadows, striking with precision",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Trap Disarm",
                    description = "Disables a trap or sets one for enemies",
                    manaCost = 20,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add trap-setting mechanic
                    }
                },
                new Skill {
                    skillName = "Evasion",
                    description = "Heightens reflexes, dodging incoming attacks",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Backstab",
                    description = "Strikes an enemy from behind, exploiting their weakness",
                    manaCost = 30,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 1)
                    }
                },
                new Skill {
                    skillName = "Smoke Screen",
                    description = "Throws a smoke bomb, obscuring vision and aiding escape",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 4, 3),
                        new BuffEffect(Skill.BuffType.Speed, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Assassinate",
                    description = "Delivers a lethal blow to an unaware enemy",
                    manaCost = 50,
                    damage = 60,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Wizard", new List<Skill>
            {
                new Skill {
                    skillName = "Magic Missile",
                    description = "Fires unerring bolts of arcane energy",
                    manaCost = 25,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Arcane Shield",
                    description = "Conjures a barrier of magical energy to block attacks",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Fireball",
                    description = "Launches a fiery explosion, hitting enemies in a 3-tile radius",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Invisibility",
                    description = "Renders self invisible, avoiding detection",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 5, 3) // TODO: Add invisibility toggle
                    }
                },
                new Skill {
                    skillName = "Lightning Bolt",
                    description = "Unleashes a bolt of lightning through enemies in a line",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Counterspell",
                    description = "Disrupts an enemy’s spellcasting, negating their magic",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement spell negation
                    }
                },
                new Skill {
                    skillName = "Haste",
                    description = "Grants supernatural speed to self or an ally",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 3)
                    }
                },
                new Skill {
                    skillName = "Arcane Recovery",
                    description = "Restores mana through arcane focus",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Implement mana recovery +20
                    }
                },
                new Skill {
                    skillName = "Disintegrate",
                    description = "Fires a beam of destructive energy, obliterating a target",
                    manaCost = 45,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Meteor Swarm",
                    description = "Summons meteors to rain down on a 5-tile radius",
                    manaCost = 50,
                    damage = 55,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Barbarian", new List<Skill>
            {
                new Skill {
                    skillName = "Rage",
                    description = "Enters a furious rage, boosting damage and resilience",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 4, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Savage Strike",
                    description = "Delivers a brutal blow with raw power",
                    manaCost = 25,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Battle Roar",
                    description = "Roars fiercely, intimidating foes and inspiring allies",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2), // TODO -- make Enemy debuff
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)   // Ally buff
                    }
                },
                new Skill {
                    skillName = "Reckless Assault",
                    description = "Attacks with wild abandon, increasing damage but lowering defense",
                    manaCost = 35,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 2)
                    }
                },
                new Skill {
                    skillName = "Frenzy",
                    description = "Unleashes a flurry of attacks in a frenzied state",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Unbreakable Will",
                    description = "Hardens resolve, resisting damage and effects",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add resistance to debuffs
                    }
                },
                new Skill {
                    skillName = "Whirlwind Rage",
                    description = "Spins with fury, striking all enemies in a 3-tile radius",
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Bloodlust",
                    description = "Feeds on combat, healing with each strike",
                    manaCost = 25,
                    damage = 30,
                    healing = 15,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Primal Charge",
                    description = "Charges forward, knocking back and damaging an enemy",
                    manaCost = 35,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add knockback effect
                    }
                },
                new Skill {
                    skillName = "Berserker’s Might",
                    description = "Channels primal strength for a devastating blow",
                    manaCost = 50,
                    damage = 60,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Artificer", new List<Skill>
            {
                new Skill {
                    skillName = "Arcane Turret",
                    description = "Deploys a turret that fires arcane bolts at enemies",
                    manaCost = 35,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Infused Weapon",
                    description = "Enhances a weapon with magical power, boosting damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3)
                    }
                },
                new Skill {
                    skillName = "Healing Drone",
                    description = "Deploys a drone that heals allies within 3 tiles",
                    manaCost = 30,
                    damage = 0,
                    healing = 35,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Shock Trap",
                    description = "Sets a trap that shocks and stuns enemies who trigger it",
                    manaCost = 25,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0) // TODO: Add stun chance
                    }
                },
                new Skill {
                    skillName = "Mechanical Servant",
                    description = "Summons a construct to fight alongside you",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Arcane Barrier",
                    description = "Creates a protective field to absorb damage",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 5, 3)
                    }
                },
                new Skill {
                    skillName = "Explosive Bolt",
                    description = "Fires a bolt that explodes on impact, hitting a 3-tile radius",
                    manaCost = 45,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Tinker’s Boost",
                    description = "Enhances allies’ gear, improving combat efficiency",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 2, 3),
                        new BuffEffect(Skill.BuffType.Defense, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Flash Grenade",
                    description = "Throws a grenade that blinds enemies, reducing accuracy",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, -3, 2) //TODO -- make Enemy debuff
                    }
                },
                new Skill {
                    skillName = "Overclock",
                    description = "Pushes inventions to the limit, boosting all abilities",
                    manaCost = 50,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 3),
                        new BuffEffect(Skill.BuffType.Speed, 3, 3),
                        new BuffEffect(Skill.BuffType.Strength, 3, 3)
                    }
                }
            }
        },
        {
            "Necromancer", new List<Skill>
            {
                new Skill {
                    skillName = "Raise Undead",
                    description = "Summons a zombie to attack a target",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Necrotic Blast",
                    description = "Fires a blast of necrotic energy, healing the caster",
                    manaCost = 40,
                    damage = 30,
                    healing = 10,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Life Drain",
                    description = "Drains life from a target to heal the caster",
                    manaCost = 35,
                    damage = 25,
                    healing = 25,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Curse of Decay",
                    description = "Curses a target, reducing their defense",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 3)
                    }
                },
                new Skill {
                    skillName = "Spectral Shield",
                    description = "Creates a spectral shield to absorb damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Animate Dead",
                    description = "Summons a powerful undead creature to attack",
                    manaCost = 40,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Death's Touch",
                    description = "A touch attack with a chance to instantly kill low-health targets",
                    manaCost = 50,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Soul Theft",
                    description = "Steals a defeated enemy's soul to boost stats",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Undead Mastery",
                    description = "Increases control over death magic, boosting attack",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Reaper's Scythe",
                    description = "A powerful magical scythe attack",
                    manaCost = 50,
                    damage = 50,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Samurai", new List<Skill>
            {
                new Skill {
                    skillName = "Katana Strike",
                    description = "A precise strike with the katana",
                    manaCost = 20,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Defensive Stance",
                    description = "Takes a defensive stance, increasing defense",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Samurai's Resolve",
                    description = "Gains temporary hit points",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 10, 1)
                    }
                },
                new Skill {
                    skillName = "Iaido Technique",
                    description = "Quick draw and strike, boosting next attack",
                    manaCost = 20,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Bushido Code",
                    description = "Gains inspiration, boosting attack and defense",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 1, 3),
                        new BuffEffect(Skill.BuffType.Defense, 1, 3)
                    }
                },
                new Skill {
                    skillName = "Seppuku Threat",
                    description = "Intimidates a target, reducing their attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Samurai's Fury",
                    description = "Enters a fury state, boosting speed and attack",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 2),
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Arrow Deflection",
                    description = "Deflects ranged attacks, boosting defense",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 5, 2)
                    }
                },
                new Skill {
                    skillName = "Ancestral Guidance",
                    description = "Calls on ancestors for guidance",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Honorable Duel",
                    description = "Challenges an enemy, locking their attacks",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Swashbuckler", new List<Skill>
            {
                new Skill {
                    skillName = "Rapier Thrust",
                    description = "Quick thrust with the rapier",
                    manaCost = 15,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Acrobatic Dodge",
                    description = "Dodges attacks with agility",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 10, 2)
                    }
                },
                new Skill {
                    skillName = "Charm Offensive",
                    description = "Distracts an enemy with charm",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Swashbuckler's Leap",
                    description = "Leaps over enemies, striking as you go",
                    manaCost = 20,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Duelist's Focus",
                    description = "Focuses on an enemy for precision",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Piratical Swagger",
                    description = "Intimidates enemies with swagger",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 3)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Cutlass Sweep",
                    description = "Sweeps with cutlass, hitting multiple foes",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Acrobatic Escape",
                    description = "Escapes danger with agility",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Swashbuckler's Gambit",
                    description = "Risky strike dealing extra damage",
                    manaCost = 35,
                    damage = 35,
                    healing = -10,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Pirate's Curse",
                    description = "Curses an enemy, reducing critical chance",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, -10, 3)   //TODO -- make enemy debuff
                    }
                }
            }
        },
        {
            "Psion", new List<Skill>
            {
                new Skill {
                    skillName = "Telekinetic Blast",
                    description = "Releases telekinetic energy at a target",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mind Shield",
                    description = "Creates a mental shield for protection",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Telepathy",
                    description = "Reads a target's mind for advantage",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Levitation",
                    description = "Levitate to increase movement speed",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Psychic Scream",
                    description = "Emits a scream to stun nearby enemies",
                    manaCost = 35,
                    damage = 0,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -5, 1)    //TODO -- make enemy stun debuff
                    }
                },
                new Skill {
                    skillName = "Clairvoyance",
                    description = "Gains visions to boost attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Teleportation",
                    description = "Teleports to any visible location",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Mind Control",
                    description = "Controls an enemy's mind to attack allies",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Psionic Healing",
                    description = "Heals allies within 10 feet",
                    manaCost = 30,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Psionic Barrier",
                    description = "Creates a barrier to absorb damage",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 20, 1)
                    }
                }
            }
        },
        {
            "Inquisitor", new List<Skill>
            {
                new Skill {
                    skillName = "Divine Judgment",
                    description = "Calls divine power to strike an enemy",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Detect Evil",
                    description = "Senses evil, boosting attack against it",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Interrogation",
                    description = "Interrogates for advantage",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Holy Shield",
                    description = "Creates a shield with divine power",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 1)
                    }
                },
                new Skill {
                    skillName = "Purify",
                    description = "Removes negative effects and heals",
                    manaCost = 20,
                    damage = 0,
                    healing = 10,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Divine Wrath",
                    description = "Channels wrath to damage and stun",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -5, 1)    //TODO -- make stun on enemy
                    }
                },
                new Skill {
                    skillName = "Divine Inspiration",
                    description = "Inspires with divine power",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Holy Light",
                    description = "Heals allies within 10 feet",
                    manaCost = 25,
                    damage = 0,
                    healing = 15,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Divine Retribution",
                    description = "Strikes back at attackers",
                    manaCost = 30,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 25, 1)
                    }
                },
                new Skill {
                    skillName = "Divine Blessing",
                    description = "Blesses allies to boost attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 1, 3)
                    }
                }
            }
        },
        {
            "Alchemist", new List<Skill>
            {
                new Skill {
                    skillName = "Healing Potion",
                    description = "Drinks a potion to heal",
                    manaCost = 20,
                    damage = 0,
                    healing = 20,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Poison Dart",
                    description = "Throws a dart that poisons the target",
                    manaCost = 25,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -5, 2)    //TODO -- make poison and trigger on enemy
                    }
                },
                new Skill {
                    skillName = "Alchemical Bomb",
                    description = "Throws a bomb hitting multiple targets",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elixir of Strength",
                    description = "Drinks an elixir to boost attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Acid Flask",
                    description = "Throws acid, reducing defense",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, -2, 2)       //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Alchemical Shield",
                    description = "Creates a shield with alchemy",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 1)
                    }
                },
                new Skill {
                    skillName = "Explosive Mixture",
                    description = "Creates an explosive for area damage",
                    manaCost = 35,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Elixir of Speed",
                    description = "Drinks an elixir to boost speed",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Corrosive Cloud",
                    description = "Releases a cloud dealing damage over time",
                    manaCost = 40,
                    damage = 10,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -10, 3)   //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Alchemical Analysis",
                    description = "Analyzes a target to reveal weaknesses",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                }
            }
        },
        {
            "Gunslinger", new List<Skill>
            {
                new Skill {
                    skillName = "Quick Draw",
                    description = "Draws and fires quickly",
                    manaCost = 15,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Deadeye Shot",
                    description = "Aims precisely, boosting critical chance",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 5, 1)
                    }
                },
                new Skill {
                    skillName = "Reload",
                    description = "Reloads quickly, boosting next shot",
                    manaCost = 10,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Trick Shot",
                    description = "Fires a trick shot, knocking target prone",
                    manaCost = 20,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -2, 1) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Sniper's Focus",
                    description = "Takes aim to boost attack",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2)
                    }
                },
                new Skill {
                    skillName = "Fan Fire",
                    description = "Fires multiple shots at nearby targets",
                    manaCost = 30,
                    damage = 15,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Gunsmith's Craft",
                    description = "Crafts ammo to boost damage",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 1, 3)
                    }
                },
                new Skill {
                    skillName = "Piercing Shot",
                    description = "Fires through multiple targets",
                    manaCost = 35,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Quick Reload",
                    description = "Reloads instantly, boosting speed",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Final Shot",
                    description = "Fires a powerful shot that stuns",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -5, 1)    //TODO -- make enemy debuff
                    }
                }
            }
        },
        {
            "Blood Hound", new List<Skill>
            {
                new Skill {
                    skillName = "Blood Scent",
                    description = "Tracks wounded enemies, boosting attack",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Savage Bite",
                    description = "Bites with ferocity, dealing damage",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Blood Rage",
                    description = "Enters a rage fueled by blood",
                    manaCost = 30,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),
                        new BuffEffect(Skill.BuffType.Speed, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Claw Slash",
                    description = "Slashes with claws, wounding deeply",
                    manaCost = 20,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Pierce, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Howl of the Hunt",
                    description = "Howls to intimidate enemies",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Blood Feast",
                    description = "Feasts on blood to heal",
                    manaCost = 30,
                    damage = 20,
                    healing = 20,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Predator's Leap",
                    description = "Leaps at a target to attack",
                    manaCost = 25,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Pack Instinct",
                    description = "Boosts stats when allies are near",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Blood Mark",
                    description = "Marks a target for increased damage",
                    manaCost = 15,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 3)
                    }
                },
                new Skill {
                    skillName = "Frenzied Assault",
                    description = "Launches a frenzied attack",
                    manaCost = 40,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Hexblade", new List<Skill>
            {
                new Skill {
                    skillName = "Hex Strike",
                    description = "Strikes with a cursed blade",
                    manaCost = 25,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Curse of Shadows",
                    description = "Curses a target with shadows",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, -2, 2)    //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Pact Blade",
                    description = "Summons a pact blade for a powerful strike",
                    manaCost = 30,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Hex Shield",
                    description = "Creates a shield with hex magic",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 1)
                    }
                },
                new Skill {
                    skillName = "Shadow Step",
                    description = "Steps through shadows to reposition",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 2, 1)
                    }
                },
                new Skill {
                    skillName = "Hexed Wrath",
                    description = "Unleashes wrath with hex magic",
                    manaCost = 35,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Soul Drain",
                    description = "Drains a soul to heal",
                    manaCost = 30,
                    damage = 25,
                    healing = 15,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Dark Pact",
                    description = "Boosts stats via a dark pact",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Hexed Chains",
                    description = "Binds a target with magical chains",
                    manaCost = 30,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, -2, 2) //TODO -- make enemy debuff
                    }
                },
                new Skill {
                    skillName = "Blade of Doom",
                    description = "Strikes with a dooming blade",
                    manaCost = 40,
                    damage = 45,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
        {
            "Summoner", new List<Skill>
            {
                new Skill {
                    skillName = "Summon Familiar",
                    description = "Summons a familiar to attack",
                    manaCost = 20,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Protective Ward",
                    description = "Creates a ward to shield allies",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Shield, 15, 1)
                    }
                },
                new Skill {
                    skillName = "Summon Elemental",
                    description = "Summons an elemental to fight",
                    manaCost = 30,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Binding Call",
                    description = "Binds a summoned creature to boost its power",
                    manaCost = 20,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Summon Spirit",
                    description = "Summons a spirit to harass enemies",
                    manaCost = 25,
                    damage = 25,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Dismissal",
                    description = "Dismisses a summon to heal the caster",
                    manaCost = 15,
                    damage = 0,
                    healing = 15,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Summon Guardian",
                    description = "Summons a guardian to defend",
                    manaCost = 35,
                    damage = 20,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Empower Summon",
                    description = "Empowers a summon to boost its stats",
                    manaCost = 25,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Summon Horde",
                    description = "Summons multiple weak creatures",
                    manaCost = 40,
                    damage = 30,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                },
                new Skill {
                    skillName = "Master's Call",
                    description = "Calls all summons to attack at once",
                    manaCost = 50,
                    damage = 40,
                    healing = 0,
                    isAttack = true,
                    skillType = "Magical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0)
                    }
                }
            }
        },
    };


    //ultimate move based on class and race
    public Dictionary<string, List<Skill>> raceAndClassSignatureSkills = new Dictionary<string, List<Skill>>
    {
        {
            "Human Mage", new List<Skill>
            {
                new Skill {
                    skillName = "Adaptive Arcane Convergence",
                    description = "Channels human adaptability to simultaneously control multiple elemental forces, creating a devastating magical vortex that evolves to counter enemy defenses",
                    manaCost = 85,
                    damage = 100,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate", //TODO -- make Ultimate a skill type
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Intelligence, 7, 3),
                        new BuffEffect(Skill.BuffType.Magic, 7, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- Spell penetration - ignores 50 % of enemy magical resistance
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- Adaptive Elements - spell automatically uses enemy's elemental weakness
                    }
                },
                new Skill {
                    skillName = "Versatile Spellweaver",
                    description = "Demonstrates the pinnacle of human magical innovation, weaving together disparate spell schools that should be incompatible into a harmonious magical symphony",
                    manaCost = 80,
                    damage = 90,
                    healing = 45,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Intelligence, 4, 4),
                        new BuffEffect(Skill.BuffType.Magic, 4, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- Create Magical field for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Enemies -4 to sp defense for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- Mana regeneration increased by 40 % for 4 turns
                    }
                },
                new Skill {
                    skillName = "Resourceful Arcanist's Gambit",
                    description = "Improvises a complex spell using minimal magical resources, channeling human ingenuity to achieve maximum effect with unprecedented efficiency",
                    manaCost = 60,  //TODO -- refund 30 mana if successful
                    damage = 85,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 8, 3),
                        new BuffEffect(Skill.BuffType.Intelligence, 5, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- each successful hit reduces future spell cost by 15 % (stacks up to 45 %)
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- create acrcane momentum - each spell cast increases damage of next spell by 25 % for 3 turns
                    }
                },
            }
        },
        {
            "Human Knight", new List<Skill>
            {
                new Skill {
                    skillName = "Tactical Battlefield Mastery",
                    description = "Employs perfect combat positioning and timing from extensive human military tradition, becoming an unstoppable force of calculated martial precision",
                    manaCost = 75,
                    damage = 90,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 8, 3),
                        new BuffEffect(Skill.BuffType.Shield, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- counterattack automatically for 60 % damage for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- takes 40 % reduced damage when defending allies for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- battlefield control: can lock down enemy movement in 4 tile radius for 3 turns
                    }
                },
                new Skill {
                    skillName = "Adaptive Combat Evolution",
                    description = "Continuously adapts fighting stance and technique to counter enemy moves, embodying the human capacity to evolve combat strategies mid-battle",
                    manaCost = 70,
                    damage = 85,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- gains resistance to damage types recently received for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- each successful defense increases attack by 2 (stacks up to 10) for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Adaptive armor - defense automatically increases against most common enemy damage type for 4 turns
                        new BuffEffect(Skill.BuffType.Pierce, 6, 4),
                        new BuffEffect(Skill.BuffType.Strength, 4, 4),
                        new BuffEffect(Skill.BuffType.Defense, 4, 4),
                        new BuffEffect(Skill.BuffType.Attack, 4, 4),
                        new BuffEffect(Skill.BuffType.CriticalChance, 4, 4)
                    }
                },
                new Skill {
                    skillName = "Disciplined Protector's Resolve",
                    description = "Channels generations of human knightly tradition into perfect defensive stance that inspires allies while demoralizing enemies",
                    manaCost = 80,
                    damage = 75,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 6, 4),
                        new BuffEffect(Skill.BuffType.Defense, 7, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- reflects 35 % of damage taken to offender for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- taunts all enemies in 6 tile radius, forcing them to attack for 2 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- becomes immune to crowd control effects for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- creates protected zone - within 5 tiles radius, gains + 5 defense and + 5 shield for 4 turns
                    }
                },
            }
        },
        {
            "Human Thief", new List<Skill>
            {
                new Skill {
                    skillName = "Adaptive Shadow Infiltrator",
                    description = "Reaches the pinnacle of human stealth adaptation, becoming virtually undetectable and striking from impossible angles with uncanny precision",
                    manaCost = 65,
                    damage = 95,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.DodgeChance, 9, 3),
                        new BuffEffect(Skill.BuffType.Speed, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- invisibility for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- each successful strike steals one beneficial effect from target for 3 turns
                    }
                },
                new Skill {
                    skillName = "Resourceful Opportunist",
                    description = "Exploits every possible advantage through human ingenuity, turning enemy strengths into weaknesses and creating attack opportunities where none existed",
                    manaCost = 70,
                    damage = 85,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 10, 3),
                        new BuffEffect(Skill.BuffType.Agility, 7, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Exploits vulnerabilities - damage increase by 50 % against debuffed targets for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Each successful attack has 30 % chance to steal a random item for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Combat improvision - can use environmental objects as weapons for bonus effects for 3 turns
                    }
                },
                new Skill {
                    skillName = "Versatile Master Thief",
                    description = "Demonstrates unparalleled mastery of all thieving arts simultaneously, becoming a legendary phantom that can steal anythign while remaining untouchable",
                    manaCost = 75,
                    damage = 90,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Agility, 9, 4),
                        new BuffEffect(Skill.BuffType.Speed, 9, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO --creates illusory duplicates that can attack independently for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Perfect pickpocket - 100 % success rate on theft attempts for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Shadow manipulation - can teleport between shadows for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Each successful attack applies poison - 15 damage per turn for 4 turns
                    }
                },
            }
        },
        {
            "Human Archer", new List<Skill>
            {
                new Skill {
                    skillName = "Adaptive Precision Archery",
                    description = "Achieves perfect synthesis of human adaptability with archery mastery, firing arrows that adjust mid-flight to hit vital points with uncanny accuracy",
                    manaCost = 75,
                    damage = 100,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Accuracy, 10, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 8, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 7, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Arrows track moving targets for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Each hit reveals enemy vulnerabilities, increasing next shot damage by 15 % for 3 turns
                    }
                },
                new Skill {
                    skillName = "Versatile Arrow Mastery",
                    description = "Demonstrates mastery of countless arrow types and shooting techniques developed throughout human history, having the perfect shot for any situation",
                    manaCost = 80,
                    damage = 95,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Speed, 4, 4),
                        new BuffEffect(Skill.BuffType.Attack, 4, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- specialized ammo - each attack applies different effect (stunning, burning, freezing, etc.) for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- can hit targets out of range by 2 tiles for 4 turns
                    }
                },
                new Skill {
                    skillName = "Tactical Sharpshooter's Focus",
                    description = "Enters state of perfect concentration unique to human archers, calculating all environmental variables for shots of impossible precision",
                    manaCost = 70,
                    damage = 105,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.CriticalChance, 100, 3),  //TODO -- make this 100 % for 3 turns
                        new BuffEffect(Skill.BuffType.Accuracy, 12, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 9, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- marks tagets - all marked targets take 40 % increased damage from all sources for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Perfect shot - Attacks ignore 70 % of enemy defense for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- can target specific body parts for special effects (head = stun, legs = immobilize, etc.) for 3 turns
                    }
                },
            }
        },
        {
            "Human Cleric", new List<Skill>
            {
                new Skill {
                    skillName = "Versatile Divine Channeler",
                    description = "Channels multiple aspects of divine power simultaneously through human spiritual versatility, creating miraculous effects of unprecedented magnitude",
                    manaCost = 85,
                    damage = 80,
                    healing = 100,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Magic, 8, 4), 
                        new BuffEffect(Skill.BuffType.Intelligence, 8, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- creates divine sanctuatry - while in radius of 7 tiles, gain immunity to status effects for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- continuous blessing - gain 20 health per round for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Divine Judgement - enemies in 4 tile radius take 25 holy damage per turn for 4 turns
                    }
                },
                new Skill {
                    skillName = "Adaptive Faith Weaver",
                    description = "Adapts divine channeling techniques based on battlefield conditions, creating the perfect balance of healing, protection, and holy damage",
                    manaCost = 80,
                    damage = 85,
                    healing = 90,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- creates adaptive blessing that changes based on ally needs for 3 turns
                        new BuffEffect(Skill.BuffType.Shield, 5, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- healing effectiveness increased by 60 % for 3 rounds
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- Holy strikes deal damage proportional to enemy corruption level for 3 turns
                    }
                },
                new Skill {
                    skillName = "Tactical Divine Strategist",
                    description = "",
                    manaCost = 75,
                    damage = 75,
                    healing = 85,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 4, 4),
                        new BuffEffect(Skill.BuffType.Attack, 4, 4),
                        new BuffEffect(Skill.BuffType.Strength, 4, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Can see enemy intentions one turn ahead for 4 turns
                    }
                },
            }
        },
        {
            "Human Druid", new List<Skill>
            {
                new Skill {
                    skillName = "Adaptive Nature Synthesis",
                    description = "Achieves unprecedented harmony with natural world through human adaptability, seamlessly flowing between elemental forms while maintaining perfect balance",
                    manaCost = 80,
                    damage = 85,
                    healing = 60,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 10, 3),
                        new BuffEffect(Skill.BuffType.Strength, 7, 3),
                        new BuffEffect(Skill.BuffType.Attack, 7, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),    //TODO -- make 25 health regen per turn for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Adaptive Shapeshifting - can change animal forms freely without cooldown for 4 turns
                    }
                },
                new Skill {
                    skillName = "Versatile Natural Convergence",
                    description = "Channels countless aspects of natural world simultaneously through human versatility, combining plant, animal, and elemental forces",
                    manaCost = 85,
                    damage = 90,
                    healing = 65,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- summons three different elemental spirits as allies for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Plant growth - creates advantageous terrain that heals allies and hinders enemies for 3 turns
                        new BuffEffect(Skill.BuffType.Speed, 8, 3),
                        new BuffEffect(Skill.BuffType.Strength, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- attacks deal additional elemental damage for 3 turns
                    }
                },
                new Skill {
                    skillName = "Resourceful Primordial Connection",
                    description = "Forms unprecedented bond with ancient nature forces through human resourcefulness, accessing primal magics thought lost to time",
                    manaCost = 75,
                    damage = 80,
                    healing = 55,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Primal surge - all nature abilities amplified by 70 % for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Primal senses - reveals all living beings on battlefield and their weaknesses for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Primordial Healing - converts 30 % of damage dealt to healing for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- Earth Connection - can travel through natrual terrain unhindered for 3 turns
                        new BuffEffect(Skill.BuffType.Shield, 6, 3),
                        new BuffEffect(Skill.BuffType.Defense, 6, 3),
                        new BuffEffect(Skill.BuffType.DodgeChance, 6, 3),
                        new BuffEffect(Skill.BuffType.Speed, 6, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 6, 3),
                        new BuffEffect(Skill.BuffType.Luck, 6, 3),
                        new BuffEffect(Skill.BuffType.Agility, 6, 3),
                        new BuffEffect(Skill.BuffType.Magic, 6, 3),
                        new BuffEffect(Skill.BuffType.Intelligence, 6, 3),
                        new BuffEffect(Skill.BuffType.Dexterity, 6, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 6, 3),
                        new BuffEffect(Skill.BuffType.CriticalChance, 6, 3),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 6, 3),
                        new BuffEffect(Skill.BuffType.Strength, 6, 3),
                        new BuffEffect(Skill.BuffType.Attack, 6, 3),
                        new BuffEffect(Skill.BuffType.Mana, 6, 3)
                    }
                },
            }
        },
        {
            "Human Fighter", new List<Skill>
            {
                new Skill {
                    skillName = "Verstaile Combat Virtuoso",
                    description = "Masters countless fighting styles simultaneously through human adaptability, flawlessly switching between techniques to counter any enemy",
                    manaCost = 70,
                    damage = 95,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Defense, 6, 3),
                        new BuffEffect(Skill.BuffType.Attack, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- combat adaptation - automatically counters enemy attack styles for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Technique mastery - each successful attack increases damage of next attack by 15 % for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Style switching - can change combat form each turn fo different bonuses for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Perfect counter - 40 % chance to completely negate and counter enemy attacks for 3 turns
                    }
                },
                new Skill {
                    skillName = "Disciplined Battle Perfection",
                    description = "Achieves state of perfect combat focus through rigorous human discipline, executing flawless techniques with maximum efficiency",
                    manaCost = 75,
                    damage = 100,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- all attacks are critical hits for 3 turns
                        new BuffEffect(Skill.BuffType.Accuracy, 10, 3),
                        new BuffEffect(Skill.BuffType.Pierce, 8, 3),
                        new BuffEffect(Skill.BuffType.DodgeChance, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- reduces incoming damage by 40 % for 3 turns
                        new BuffEffect(Skill.BuffType.Strength, 9, 3),
                        new BuffEffect(Skill.BuffType.Agility, 7, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- flow state - each perfect attack execution grants additional action for 3 turns
                    }
                },
                new Skill {
                    skillName = "Adaptive Combat Evolution",
                    description = "Continuously improves fighting technique mid-battle through human learning capacity, becoming increasingly dangerous as fight progresses",
                    manaCost = 65,
                    damage = 85,    //TODO -- make this increase over time 95, 105, 125
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- Technique analysis - after being hit, gains 50 % resistance to that attack type for 4 turns
                        new BuffEffect(Skill.BuffType.Strength, 2, 4),
                        new BuffEffect(Skill.BuffType.Defense, 2, 4),
                        new BuffEffect(Skill.BuffType.Attack, 2, 4),
                        new BuffEffect(Skill.BuffType.Shield, 2, 4),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- weakness exploitation - each attack reveals enemy vulnerabilities, increasing damage by 10 % (stacks) for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- adaptive strength - damage increases by 20 % for each turn in combat for 4 turns
                        new BuffEffect(Skill.BuffType.Speed, 4, 4),
                    }
                },
            }
        },
        {
            "Human Tracker", new List<Skill>
            {
                new Skill {
                    skillName = "Adaptive Hunter's Intuition",
                    description = "Reaches apex of human tracking ability, instinctively predicting prey movement and exploiting environmental advantages with uncanny precision",
                    manaCost = 70,
                    damage = 90,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- perfect tracking - reveals all enemies and their planned movements for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- terrain mastery - gains significant advantage based on environment for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),   //TODO -- predator's focus - marked targets take 50 % additional damage from all sources for 3 turns
                        new BuffEffect(Skill.BuffType.CriticalChance, 8, 3),
                        new BuffEffect(Skill.BuffType.Accuracy, 8, 3),
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- adaptive hunting - automatically uses optimal attack method for each target for 3 turns
                    }
                },
                new Skill {
                    skillName = "Resourceful Wilderness Master",
                    description = "Employs countless survival techniques developed throughout human history, turning any environment to advantage while neutralizing threats",
                    manaCost = 65,
                    damage = 85,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- environmental adaptation - gains immunity to terrain effects and weather conditions for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- improvised attack - can set multiple deadly traos using available materials for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- wilderness medicine - can heal 40 health using foraged materials once per turn for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- camouflage mastery - gains stealth even in open terrain for 4 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0)   //TODO -- survival instinct - automatically evades first lethal attack with 100 % success for 4 turns
                    }
                },
                new Skill {
                    skillName = "Tactical Predator's Dominance",
                    description = "Combines strategic human intellect with primal hunting instincts, methodically controlling battlefield while relentlessly pursuing prey",
                    manaCost = 75,
                    damage = 95,
                    healing = 0,
                    isAttack = true,
                    skillType = "Ultimate",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- hunting grounds control - restricts enemy movement while enhancing own mobility by 4 for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- tactical analysis - reveals all enemy weaknesses and optimal attack patterns for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- predator's presence - induces fear in nearby enemies, reducing their stats by 4 for 3 turns
                        new BuffEffect(Skill.BuffType.Speed, 9, 3),  //TODO -- pursuit mastery - guarenteed to catch fleeing targets for 3 turns
                        new BuffEffect(Skill.BuffType.None, 0, 0),  //TODO -- perfect ambush - first strike against each target deals triple damage for 3 turns
                    }
                },
            }
        },
        {
            "Human Warrior", new List<Skill>
            {
                new Skill {
                    skillName = "",
                    description = "",
                    manaCost = 40,
                    damage = 35,
                    healing = 0,
                    isAttack = true,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make coat type and impliment here -- delete strength buff
                        new BuffEffect(Skill.BuffType.Strength, 2, 2)
                    }
                },
                new Skill {
                    skillName = "Transform",
                    description = "Changes attributes to that of a character or object within eyesight for 3 turns",
                    manaCost = 40,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Support",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        //TODO make a change base attribute function to trigger for 3 turns
                        new BuffEffect(Skill.BuffType.Attack, 2, 2),
                    }
                },
                new Skill {
                    skillName = "Overclock",
                    description = "Boosts all stats and picks a player to lose attack",
                    manaCost = 55,
                    damage = 0,
                    healing = 0,
                    isAttack = false,
                    skillType = "Physical",
                    
                    
                    buffEffects = new List<BuffEffect>
                    {
                        new BuffEffect(Skill.BuffType.Strength, 3, 2),
                        new BuffEffect(Skill.BuffType.Speed, 3, 2),
                        new BuffEffect(Skill.BuffType.Agility, 3, 2),
                        new BuffEffect(Skill.BuffType.Accuracy, 3, 2),
                        new BuffEffect(Skill.BuffType.Attack, 3, 2),
                        new BuffEffect(Skill.BuffType.Luck, 3, 2),
                        new BuffEffect(Skill.BuffType.Magic, 3, 2),
                        new BuffEffect(Skill.BuffType.Intelligence, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalChance, 3, 2),
                        new BuffEffect(Skill.BuffType.CriticalDamage, 3, 2),
                        new BuffEffect(Skill.BuffType.Defense, 3, 2),
                        new BuffEffect(Skill.BuffType.DodgeChance, 3, 2),
                        new BuffEffect(Skill.BuffType.Dexterity, 3, 2),
                        new BuffEffect(Skill.BuffType.Pierce, 3, 2)
                    }
                },
            }
        },
    };




    public Skill GenerateSkill(string race, string characterClass, bool isAttack = true)
    {
        if (!raceSkillPrefixes.ContainsKey(race) || !classSkillSuffixes.ContainsKey(characterClass))
        {
            Debug.LogWarning($"Invalid race ({race}) or class ({characterClass})");
            return null;
        }

        string[] prefixes = raceSkillPrefixes[race];
        string[] suffixes = classSkillSuffixes[characterClass];
        var baseStats = classBaseStats[characterClass];

        string prefix = prefixes[Random.Range(0, prefixes.Length)];
        string suffix = suffixes[Random.Range(0, suffixes.Length)];

        Skill skill = new Skill
        {
            skillName = $"{prefix} {suffix}",
            isAttack = isAttack,
            skillType = baseStats.type
        };

        // Randomize stats based on class base stats
        if (isAttack)
        {
            skill.damage = baseStats.minDamage + Random.Range(0, 20);
            skill.healing = 0;
        }
        else
        {
            skill.damage = 0;
            skill.healing = baseStats.minHealing + Random.Range(0, 25);
        }

        skill.manaCost = Random.Range(baseStats.manaRange - 10, baseStats.manaRange + 10);

        // Generate description based on stats
        skill.description = GenerateDescription(skill);

        return skill;
    }

    private string GenerateDescription(Skill skill)
    {
        if (skill.isAttack)
        {
            return $"A {skill.skillType.ToLower()} attack that deals {skill.damage} damage. Costs {skill.manaCost} mana.";
        }
        else
        {
            return $"A {skill.skillType.ToLower()} ability that heals for {skill.healing}. Costs {skill.manaCost} mana.";
        }
    }

    public List<Skill> GenerateSkillSet(string race, string characterClass, int attackCount = 5, int supportCount = 5)
    {
        List<Skill> skillSet = new List<Skill>();

        // Get race and class signature skills, defaulting to empty lists if not found
        List<Skill> raceSkills = raceSignatureSkills.ContainsKey(race) ? raceSignatureSkills[race] : new List<Skill>();
        List<Skill> classSkills = classSignatureSkills.ContainsKey(characterClass) ? classSignatureSkills[characterClass] : new List<Skill>();

        // Combine race and class skills into a single pool
        List<Skill> allSkills = raceSkills.Concat(classSkills).ToList();

        // Separate into attack and support skills
        List<Skill> attackSkills = allSkills.Where(s => s.isAttack).ToList();
        List<Skill> supportSkills = allSkills.Where(s => !s.isAttack).ToList();

        // Select random race attack skills
        int availableAttacks = attackSkills.Count;
        int toSelectAttacks = Mathf.Min(attackCount, availableAttacks);
        //var selectedAttackSkills = attackSkills.OrderBy(x => UnityEngine.Random.value).Take(toSelectAttacks).ToList();
        skillSet.AddRange(attackSkills); 

        // Generate additional random attack skills if needed
        int remainingAttacks = attackCount - toSelectAttacks;
        for (int i = 0; i < remainingAttacks; i++)
        {
            Skill randomAttackSkill = GenerateSkill(race, characterClass, true);
            if (randomAttackSkill != null)
            {
                skillSet.Add(randomAttackSkill);
            }
        }

        // Select random race support skills
        int availableSupport = supportSkills.Count;
        int toSelectSupport = Mathf.Min(supportCount, availableSupport);
        //var selectedSupportSkills = supportSkills.OrderBy(x => UnityEngine.Random.value).Take(toSelectSupport).ToList();
        skillSet.AddRange(supportSkills);

        // Generate additional random support skills if needed
        int remainingSupport = supportCount - toSelectSupport;
        for (int i = 0; i < remainingSupport; i++)
        {
            Skill randomSupportSkill = GenerateSkill(race, characterClass, false);
            if (randomSupportSkill != null)
            {
                skillSet.Add(randomSupportSkill);
            }
        }

        

        // Optional: Shuffle the final skill set for mixed presentation
        skillSet = skillSet.OrderBy(x => UnityEngine.Random.value).ToList();

        return skillSet;
    }
}