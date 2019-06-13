using DungeonsAndCodeWizards.Entities;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Factories;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private Dictionary<string, Character> party;
        private Stack<Item> itemsPool;
        private ItemFactory itemFactory;
        private CharacterFactory characterFactory;
        private int lastSurvivorsRounds;

        public DungeonMaster()
        {
            this.party = new Dictionary<string, Character>();
            this.itemsPool = new Stack<Item>();
            this.itemFactory = new ItemFactory();
            this.characterFactory = new CharacterFactory();
            this.lastSurvivorsRounds = 0;
        }

        public string JoinParty(string[] args)
        {

            string factionType = args[0];
            string characterType = args[1];
            string name = args[2];

            Faction faction;

            try
            {
                faction = Enum.Parse<Faction>(factionType);
                var character = this.characterFactory.GetCharacter(characterType, name, faction);

                if (character == null)
                {
                    throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
                }

                this.party[name] = character;
            }
            catch
            {
                throw new ArgumentException($"Invalid faction \"{ factionType }\"!");
            }

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            var item = this.itemFactory.GetItem(itemName);

            if (item == null)
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            this.itemsPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            IsInPartyValidation(characterName);

            if (this.itemsPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.itemsPool.Pop();
            var character = this.party[characterName];
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {

            string characterName = args[0];
            string itemName = args[1];

            IsInPartyValidation(characterName);
            var character = this.party[characterName];
            var item = character.Bag.GetItem(itemName);
            item.AffectCharacter(character);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            IsInPartyValidation(giverName);
            IsInPartyValidation(receiverName);
            var giver = this.party[giverName];
            var receiver = this.party[receiverName];
            var item = giver.Bag.GetItem(itemName);
            receiver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            IsInPartyValidation(giverName);
            IsInPartyValidation(receiverName);
            var giver = this.party[giverName];
            var receiver = this.party[receiverName];
            var item = giver.Bag.GetItem(itemName);
            receiver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder result = new StringBuilder();
            // Returns info about all characters, sorted by whether they are alive(descending)
            //, then by their health(descending)
            foreach (var kvp in this.party
                .OrderByDescending(x => x.Value.IsAlive).ThenByDescending(x => x.Value.Health))
            {
                var name = kvp.Key;
                var character = kvp.Value;
                var status = character.IsAlive ? "Alive" : "Dead";
                result.AppendLine($"{name} - HP: {character.Health}/{character.BaseHealth}," +
                    $" AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            IsInPartyValidation(attackerName);
            IsInPartyValidation(receiverName);

            var attacker = this.party[attackerName];
            var receiver = this.party[receiverName];

            if (attacker is IAttackable attackable)
            {
                attackable.Attack(receiver);
            }
            else
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            IsInPartyValidation(healerName);
            IsInPartyValidation(healingReceiverName);

            var healer = this.party[healerName];
            var receiver = this.party[healingReceiverName];


            if (healer is IHealable healable)
            {
                healable.Heal(receiver);
            }
            else
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
                $"{receiver.Name} has {receiver.Health} health now!");

            return result.ToString().TrimEnd();

        }

        public string EndTurn(string[] args)
        {

            StringBuilder result = new StringBuilder();

            var aliveHeroes = this.party.Where(x => x.Value.IsAlive);

            if (aliveHeroes.Count() <= 1)
            {
                this.lastSurvivorsRounds++;
            }

            foreach (var hero in aliveHeroes)
            {
                var character = hero.Value;
                var healthBeforeRest = character.Health;
                character.Rest();

                result.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return result.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorsRounds > 1;
        }

        private void IsInPartyValidation(string name)
        {
            if (!this.party.ContainsKey(name))
            {
                throw new ArgumentException($"Character {name} not found!");
            }
        }
    }
}
