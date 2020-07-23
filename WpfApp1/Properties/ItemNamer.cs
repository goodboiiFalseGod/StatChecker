using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulsMemory;

namespace MainApp
{
    class ItemNamer
    {
            public static string WeaponName(int WeaponId)
            {
                string WeaponNameString = String.Empty;
                string WeaponReinforceString = String.Empty;
                string WeaponInfusionString = String.Empty;

                JunkCode.GetBasicWeaponInfusionReinforce(WeaponId, out int WeaponBase, out int WeaponReinforce, out int WeaponInfusion);

                switch (WeaponInfusion)
                {
                case 100:
                    WeaponInfusionString = "Heavy";
                    break;
                }

                switch (WeaponReinforce)
                {

                    case 1:
                        WeaponReinforceString = " +1";
                        break;

                    case 2:
                        WeaponReinforceString = " +2";
                        break;

                    case 3:
                        WeaponReinforceString = " +3";
                        break;

                    case 4:
                        WeaponReinforceString = " +4";
                        break;

                    case 5:
                        WeaponReinforceString = " +5";
                        break;

                    case 6:
                        WeaponReinforceString = " +6";
                        break;

                    case 7:
                        WeaponReinforceString = " +7";
                        break;

                    case 8:
                        WeaponReinforceString = " +8";
                        break;

                    case 9:
                        WeaponReinforceString = " +9";
                        break;

                    case 10:
                        WeaponReinforceString = " +10";
                        break;

                    default:
                        WeaponReinforceString = "";
                        break;
                }

                switch (WeaponBase)
                {
                    case 1000000:
                        WeaponNameString = "Dagger";
                        break;
                    case 1010000:
                        WeaponNameString = "Bandit's Knife";
                        break;
                    case 1020000:
                        WeaponNameString = "Parrying Dagger";
                        break;
                    case 1040000:
                        WeaponNameString = "Rotten Ghru Dagger";
                        break;
                    case 1060000:
                        WeaponNameString = "Harpe";
                        break;
                    case 1070000:
                        WeaponNameString = "Scholar's Candlestick";
                        break;
                    case 1080000:
                        WeaponNameString = "Tailbone Short Sword";
                        break;
                    case 1090000:
                        WeaponNameString = "Corvian Greatknife";
                        break;
                    case 1120000:
                        WeaponNameString = "Handmaid's Dagger";
                        break;
                    case 1140000:
                        WeaponNameString = "Aquamarine Dagger";
                        break;
                    case 1150000:
                        WeaponNameString = "Murky Hand Scythe";
                        break;
                    case 2000000:
                        WeaponNameString = "Shortsword";
                        break;
                    case 2030000:
                        WeaponNameString = "Broken Straight Sword";
                        break;
                    case 2060000:
                        WeaponNameString = "Lothric Knight Sword";
                        break;
                    case 2110000:
                        WeaponNameString = "Sunlight Straight Sword";
                        break;
                    case 2140000:
                        WeaponNameString = "Irithyll Straight Sword";
                        break;
                    case 2160000:
                        WeaponNameString = "Cleric's Candlestick";
                        break;
                    case 2180000:
                        WeaponNameString = "Morion Blade";
                        break;
                    case 2200000:
                        WeaponNameString = "Astora Straight Sword";
                        break;
                    case 2210000:
                        WeaponNameString = "Barbed Straight Sword";
                        break;
                    case 2220000:
                        WeaponNameString = "Executioner's Greatsword";
                        break;
                    case 2230000:
                        WeaponNameString = "Anri's Straight Sword";
                        break;
                    case 2240000:
                        WeaponNameString = "Onyx Blade";
                        break;
                    case 2250000:
                        WeaponNameString = "Ringed Knight Straight Sword";
                        break;
                    case 2260000:
                        WeaponNameString = "Gael Greatsword";
                        break;
                    case 3000000:
                        WeaponNameString = "Estoc";
                        break;
                    case 3010000:
                        WeaponNameString = "Mail Breaker";
                        break;
                    case 3020000:
                        WeaponNameString = "Rapier";
                        break;
                    case 3030000:
                        WeaponNameString = "Ricard's Rapier";
                        break;
                    case 3040000:
                        WeaponNameString = "Crystal Sage's Rapier";
                        break;
                    case 3050000:
                        WeaponNameString = "Irithyll Rapier";
                        break;
                    case 4010000:
                        WeaponNameString = "Shotel";
                        break;
                    case 4030000:
                        WeaponNameString = "Scimitar";
                        break;
                    case 4040000:
                        WeaponNameString = "Falchion";
                        break;
                    case 4050000:
                        WeaponNameString = "Carthus Curved Sword";
                        break;
                    case 4060000:
                        WeaponNameString = "Carthus Curved Greatsword";
                        break;
                    case 4070000:
                        WeaponNameString = "Pontiff Knight Curved Sword";
                        break;
                    case 4080000:
                        WeaponNameString = "Storm Curved Sword";
                        break;
                    case 4090000:
                        WeaponNameString = "Painting Guardian's Curved Sword";
                        break;
                    case 4100000:
                        WeaponNameString = "Crescent Moon Sword";
                        break;
                    case 4110000:
                        WeaponNameString = "Carthus Shotel";
                        break;
                    case 4120000:
                        WeaponNameString = "Follower Sabre";
                        break;
                    case 4130000:
                        WeaponNameString = "Demon Scar";
                        break;
                    case 5000000:
                        WeaponNameString = "Uchigatana";
                        break;
                    case 5010000:
                        WeaponNameString = "Washing Pole";
                        break;
                    case 5020000:
                        WeaponNameString = "Chaos Blade";
                        break;
                    case 5030000:
                        WeaponNameString = "Black Blade";
                        break;
                    case 5040000:
                        WeaponNameString = "Bloodlust";
                        break;
                    case 5050000:
                        WeaponNameString = "Darkdrift";
                        break;
                    case 5060000:
                        WeaponNameString = "Frayed Blade";
                        break;
                    case 6000000:
                        WeaponNameString = "Bastard Sword";
                        break;
                    case 6020000:
                        WeaponNameString = "Claymore";
                        break;
                    case 6040000:
                        WeaponNameString = "Zweihander";
                        break;
                    case 6050000:
                        WeaponNameString = "Greatsword";
                        break;
                    case 6070000:
                        WeaponNameString = "Astora Greatsword";
                        break;
                    case 6080000:
                        WeaponNameString = "Murakumo";
                        break;
                    case 6100000:
                        WeaponNameString = "Lothric Knight Greatsword";
                        break;
                    case 6130000:
                        WeaponNameString = "Black Knight Greatsword";
                        break;
                    case 6140000:
                        WeaponNameString = "Flamberge";
                        break;
                    case 6150000:
                        WeaponNameString = "Exile Greatsword";
                        break;
                    case 6170000:
                        WeaponNameString = "Greatsword of Judgment";
                        break;
                    case 6180000:
                        WeaponNameString = "Profaned Greatsword";
                        break;
                    case 6190000:
                        WeaponNameString = "Cathedral Knight Greatsword";
                        break;
                    case 6200000:
                        WeaponNameString = "Farron Greatsword";
                        break;
                    case 6230000:
                        WeaponNameString = "Yhorm's Great Machete";
                        break;
                    case 6240000:
                        WeaponNameString = "Dark Sword";
                        break;
                    case 6250000:
                        WeaponNameString = "Black Knight Sword";
                        break;
                    case 6260000:
                        WeaponNameString = "Lorian's Greatsword";
                        break;
                    case 6270000:
                        WeaponNameString = "Twin Princes' Greatsword";
                        break;
                    case 6280000:
                        WeaponNameString = "Lothric's Holy Sword";
                        break;
                    case 6290000:
                        WeaponNameString = "Wolnir's Holy Sword";
                        break;
                    case 6300000:
                        WeaponNameString = "Wolf Knight's Greatsword";
                        break;
                    case 6310000:
                        WeaponNameString = "Hollowslayer Greatsword";
                        break;
                    case 6320000:
                        WeaponNameString = "Moonlight Greatsword";
                        break;
                    case 6330000:
                        WeaponNameString = "Drakeblood Greatsword";
                        break;
                    case 6340000:
                        WeaponNameString = "Firelink Greatsword";
                        break;
                    case 6350000:
                        WeaponNameString = "Fume Ultra Greatsword";
                        break;
                    case 6360000:
                        WeaponNameString = "Old Wolf Curved Sword";
                        break;
                    case 6380000:
                        WeaponNameString = "Harald Curved Greatsword";
                        break;
                    case 7000000:
                        WeaponNameString = "Hand Axe";
                        break;
                    case 7010000:
                        WeaponNameString = "Battle Axe";
                        break;
                    case 7040000:
                        WeaponNameString = "Crescent Axe";
                        break;
                    case 7050000:
                        WeaponNameString = "Greataxe";
                        break;
                    case 2010000:
                        WeaponNameString = "Long Sword";
                        break;
                    case 7070000:
                        WeaponNameString = "Butcher Knife";
                        break;
                    case 7080000:
                        WeaponNameString = "Dragonslayer's Axe";
                        break;
                    case 7100000:
                        WeaponNameString = "Thrall Axe";
                        break;
                    case 7110000:
                        WeaponNameString = "Dragonslayer Greataxe";
                        break;
                    case 7120000:
                        WeaponNameString = "Demon's Greataxe";
                        break;
                    case 7130000:
                        WeaponNameString = "Eleonora";
                        break;
                    case 7150000:
                        WeaponNameString = "Man Serpent Hatchet";
                        break;
                    case 7170000:
                        WeaponNameString = "Millwood Battle Axe";
                        break;
                    case 7180000:
                        WeaponNameString = "Earth Seeker";
                        break;
                    case 8000000:
                        WeaponNameString = "Club";
                        break;
                    case 8010000:
                        WeaponNameString = "Mace";
                        break;
                    case 8020000:
                        WeaponNameString = "Morning Star";
                        break;
                    case 8030000:
                        WeaponNameString = "Reinforced Club";
                        break;
                    case 8060000:
                        WeaponNameString = "Large Club";
                        break;
                    case 8080000:
                        WeaponNameString = "Great Club";
                        break;
                    case 8110000:
                        WeaponNameString = "Great Mace";
                        break;
                    case 8160000:
                        WeaponNameString = "Great Wooden Hammer";
                        break;
                    case 8170000:
                        WeaponNameString = "Gargoyle Flame Hammer";
                        break;
                    case 8180000:
                        WeaponNameString = "Vordt's Great Hammer";
                        break;
                    case 8190000:
                        WeaponNameString = "Old King's Great Hammer";
                        break;
                    case 8220000:
                        WeaponNameString = "Heysel Pick";
                        break;
                    case 8240000:
                        WeaponNameString = "Warpick";
                        break;
                    case 8250000:
                        WeaponNameString = "Pickaxe";
                        break;
                    case 8260000:
                        WeaponNameString = "Dragon Tooth";
                        break;
                    case 8270000:
                        WeaponNameString = "Smough's Great Hammer";
                        break;
                    case 8280000:
                        WeaponNameString = "Blacksmith Hammer";
                        break;
                    case 8290000:
                        WeaponNameString = "Morne's Great Hammer";
                        break;
                    case 8300000:
                        WeaponNameString = "Spiked Mace";
                        break;
                    case 8310000:
                        WeaponNameString = "Quakestone Hammer";
                        break;
                    case 8320000:
                        WeaponNameString = "Ledo's Great Hammer";
                        break;
                    case 9000000:
                        WeaponNameString = "Spear";
                        break;
                    case 9010000:
                        WeaponNameString = "Winged Spear";
                        break;
                    case 9030000:
                        WeaponNameString = "Partizan";
                        break;
                    case 9080000:
                        WeaponNameString = "Greatlance";
                        break;
                    case 9090000:
                        WeaponNameString = "Lothric Knight Long Spear";
                        break;
                    case 9100000:
                        WeaponNameString = "Four-Pronged Plow";
                        break;
                    case 9110000:
                        WeaponNameString = "Gargoyle Flame Spear";
                        break;
                    case 9120000:
                        WeaponNameString = "Rotten Ghru Spear";
                        break;
                    case 9130000:
                        WeaponNameString = "Tailbone Spear";
                        break;
                    case 9140000:
                        WeaponNameString = "Soldering Iron";
                        break;
                    case 9160000:
                        WeaponNameString = "Dragonslayer Swordspear";
                        break;
                    case 9170000:
                        WeaponNameString = "Arstor's Spear";
                        break;
                    case 9180000:
                        WeaponNameString = "Saint Bident";
                        break;
                    case 9190000:
                        WeaponNameString = "Yorshka's Spear";
                        break;
                    case 9200000:
                        WeaponNameString = "Pike";
                        break;
                    case 9220000:
                        WeaponNameString = "Dragonslayer Spear";
                        break;
                    case 9230000:
                        WeaponNameString = "Follower Javelin";
                        break;
                    case 9240000:
                        WeaponNameString = "Ringed Knight Spear";
                        break;
                    case 9250000:
                        WeaponNameString = "Lothric War Banner";
                        break;
                    case 9260000:
                        WeaponNameString = "Crucifix of the Mad King (Halberd)";
                        break;
                    case 10000000:
                        WeaponNameString = "Great Scythe";
                        break;
                    case 10010000:
                        WeaponNameString = "Lucerne";
                        break;
                    case 10020000:
                        WeaponNameString = "Glaive";
                        break;
                    case 10030000:
                        WeaponNameString = "Halberd";
                        break;
                    case 10050000:
                        WeaponNameString = "Black Knight Greataxe";
                        break;
                    case 10070000:
                        WeaponNameString = "Pontiff Knight Great Scythe";
                        break;
                    case 10080000:
                        WeaponNameString = "Great Corvian Scythe";
                        break;
                    case 10090000:
                        WeaponNameString = "Winged Knight Halberd";
                        break;
                    case 10100000:
                        WeaponNameString = "Gundyr's Halberd";
                        break;
                    case 10140000:
                        WeaponNameString = "Red Hilted Halberd";
                        break;
                    case 10150000:
                        WeaponNameString = "Black Knight Glaive";
                        break;
                    case 10160000:
                        WeaponNameString = "Immolation Tinder";
                        break;
                    case 10170000:
                        WeaponNameString = "Splitleaf Greatsword (It's a Halberd)";
                        break;
                    case 10180000:
                        WeaponNameString = "Friede's Great Scythe";
                        break;
                    case 11000000:
                        WeaponNameString = "Claw";
                        break;
                    case 11010000:
                        WeaponNameString = "Caestus";
                        break;
                    case 11020000:
                        WeaponNameString = "Manikin Claws";
                        break;
                    case 11030000:
                        WeaponNameString = "Demon's Fist";
                        break;
                    case 11040000:
                        WeaponNameString = "Dark Hand";
                        break;
                    case 11050000:
                        WeaponNameString = "Crow Talons";
                        break;
                    case 12000000:
                        WeaponNameString = "Whip";
                        break;
                    case 12040000:
                        WeaponNameString = "Witch's Locks";
                        break;
                    case 12050000:
                        WeaponNameString = "Notched Whip";
                        break;
                    case 12060000:
                        WeaponNameString = "Spotted Whip";
                        break;
                    case 12070000:
                        WeaponNameString = "Rose of Ariandel";
                        break;
                    case 13050000:
                        WeaponNameString = "Talisman";
                        break;
                    case 13060000:
                        WeaponNameString = "Sorcerer's Staff";
                        break;
                    case 13070000:
                        WeaponNameString = "Storyteller's Staff";
                        break;
                    case 13080000:
                        WeaponNameString = "Mendicant's Staff";
                        break;
                    case 13100000:
                        WeaponNameString = "Man-grub's Staff";
                        break;
                    case 13110000:
                        WeaponNameString = "Archdeacon's Great Staff";
                        break;
                    case 13120000:
                        WeaponNameString = "Golden Ritual Spear";
                        break;
                    case 13140000:
                        WeaponNameString = "Yorshka's Chime";
                        break;
                    case 13160000:
                        WeaponNameString = "Sage's Crystal Staff";
                        break;
                    case 13170000:
                        WeaponNameString = "Heretic's Staff";
                        break;
                    case 13180000:
                        WeaponNameString = "Court Sorcerer's Staff";
                        break;
                    case 13190000:
                        WeaponNameString = "Witchtree Branch";
                        break;
                    case 13200000:
                        WeaponNameString = "Izalith Staff";
                        break;
                    case 13210000:
                        WeaponNameString = "Cleric's Sacred Chime";
                        break;
                    case 13220000:
                        WeaponNameString = "Priest's Chime";
                        break;
                    case 13230000:
                        WeaponNameString = "Saint-tree Bellvine";
                        break;
                    case 13240000:
                        WeaponNameString = "Caitha's Chime";
                        break;
                    case 13250000:
                        WeaponNameString = "Crystal Chime";
                        break;
                    case 13260000:
                        WeaponNameString = "Sunlight Talisman";
                        break;
                    case 13270000:
                        WeaponNameString = "Canvas Talisman";
                        break;
                    case 13280000:
                        WeaponNameString = "Sunless Talisman";
                        break;
                    case 13290000:
                        WeaponNameString = "Saint's Talisman";
                        break;
                    case 13300000:
                        WeaponNameString = "White Hair Talisman";
                        break;
                    case 13400000:
                        WeaponNameString = "Pyromancy Flame";
                        break;
                    case 13410000:
                        WeaponNameString = "Pyromancer's Parting Flame";
                        break;
                    case 13420000:
                        WeaponNameString = "Murky Longstaff";
                        break;
                    case 13600000:
                        WeaponNameString = "Dragonslayer Greatbow";
                        break;
                    case 14010000:
                        WeaponNameString = "Short Bow";
                        break;
                    case 14020000:
                        WeaponNameString = "Composite Bow";
                        break;
                    case 14040000:
                        WeaponNameString = "Light Crossbow";
                        break;
                    case 14050000:
                        WeaponNameString = "Arbalest";
                        break;
                    case 14060000:
                        WeaponNameString = "Longbow";
                        break;
                    case 14070000:
                        WeaponNameString = "Dragonrider Bow";
                        break;
                    case 14090000:
                        WeaponNameString = "Avelyn";
                        break;
                    case 14100000:
                        WeaponNameString = "Knight's Crossbow";
                        break;
                    case 14130000:
                        WeaponNameString = "Darkmoon Longbow";
                        break;
                    case 14140000:
                        WeaponNameString = "Onislayer Greatbow";
                        break;
                    case 14150000:
                        WeaponNameString = "Black Bow of Pharis";
                        break;
                    case 14170000:
                        WeaponNameString = "Sniper Crossbow";
                        break;
                    case 14180000:
                        WeaponNameString = "Millwood Greatbow";
                        break;
                    case 14190000:
                        WeaponNameString = "Repeating Crossbow";
                        break;
                    case 16000000:
                        WeaponNameString = "Sellsword Twinblades";
                        break;
                    case 16020000:
                        WeaponNameString = "Warden Twinblades";
                        break;
                    case 16030000:
                        WeaponNameString = "Winged Knight Twinaxes";
                        break;
                    case 16040000:
                        WeaponNameString = "Dancer's Enchanted Swords";
                        break;
                    case 16050000:
                        WeaponNameString = "Great Machete";
                        break;
                    case 16060000:
                        WeaponNameString = "Brigand Twindaggers";
                        break;
                    case 16070000:
                        WeaponNameString = "Gotthard Twinswords";
                        break;
                    case 16090000:
                        WeaponNameString = "Onikiri and Ubadachi";
                        break;
                    case 16100000:
                        WeaponNameString = "Drang Twinspears";
                        break;
                    case 16120000:
                        WeaponNameString = "Great Door Twinshields";
                        break;
                    case 16130000:
                        WeaponNameString = "Drang Hammers";
                        break;
                    case 16140000:
                        WeaponNameString = "Valorheart";
                        break;
                    case 16150000:
                        WeaponNameString = "Crow Quills";
                        break;
                    case 16160000:
                        WeaponNameString = "Ringed Knight Paired";
                        break;
                    case 20000000:
                        WeaponNameString = "Buckler";
                        break;
                    case 20010000:
                        WeaponNameString = "Small Leather Shield";
                        break;
                    case 20030000:
                        WeaponNameString = "Round Shield";
                        break;
                    case 20040000:
                        WeaponNameString = "Large Leather Shield";
                        break;
                    case 20070000:
                        WeaponNameString = "Hawkwood's Shield";
                        break;
                    case 20080000:
                        WeaponNameString = "Iron Round Shield";
                        break;
                    case 20110000:
                        WeaponNameString = "Wooden Shield";
                        break;
                    case 20120000:
                        WeaponNameString = "Kite Shield";
                        break;
                    case 20130000:
                        WeaponNameString = "Ghru Rotshield";
                        break;
                    case 20150000:
                        WeaponNameString = "Havel's Greatshield";
                        break;
                    case 20160000:
                        WeaponNameString = "Target Shield";
                        break;
                    case 20170000:
                        WeaponNameString = "Elkhorn Round Shield";
                        break;
                    case 20180000:
                        WeaponNameString = "Warrior's Round Shield";
                        break;
                    case 20190000:
                        WeaponNameString = "Caduceus Round Shield";
                        break;
                    case 20200000:
                        WeaponNameString = "Red and White Round Shield";
                        break;
                    case 20210000:
                        WeaponNameString = "Plank Shield";
                        break;
                    case 20220000:
                        WeaponNameString = "Leather Shield";
                        break;
                    case 20230000:
                        WeaponNameString = "Crimson Parma";
                        break;
                    case 20240000:
                        WeaponNameString = "Eastern Iron Shield";
                        break;
                    case 20250000:
                        WeaponNameString = "Llewellyn Shield";
                        break;
                    case 20270000:
                        WeaponNameString = "Golden Falcon Shield";
                        break;
                    case 20300000:
                        WeaponNameString = "Followers Shield";
                        break;
                    case 20310000:
                        WeaponNameString = "Dragonhead Shield";
                        break;
                    case 21010000:
                        WeaponNameString = "Lothric Knight Shield";
                        break;
                    case 21040000:
                        WeaponNameString = "Knight Shield";
                        break;
                    case 21060000:
                        WeaponNameString = "Pontiff Knight Shield";
                        break;
                    case 21070000:
                        WeaponNameString = "Carthus Shield";
                        break;
                    case 21100000:
                        WeaponNameString = "Black Knight Shield";
                        break;
                    case 21120000:
                        WeaponNameString = "Silver Knight Shield";
                        break;
                    case 21130000:
                        WeaponNameString = "Spiked Shield";
                        break;
                    case 21140000:
                        WeaponNameString = "Pierce Shield";
                        break;
                    case 21150000:
                        WeaponNameString = "East-West Shield";
                        break;
                    case 21160000:
                        WeaponNameString = "Sunlight Shield";
                        break;
                    case 21170000:
                        WeaponNameString = "Crest Shield";
                        break;
                    case 21180000:
                        WeaponNameString = "Dragon Crest Shield";
                        break;
                    case 21190000:
                        WeaponNameString = "Spider Shield";
                        break;
                    case 21200000:
                        WeaponNameString = "Grass Crest Shield";
                        break;
                    case 21210000:
                        WeaponNameString = "Sunset Shield";
                        break;
                    case 21220000:
                        WeaponNameString = "Golden Wing Crest Shield";
                        break;
                    case 21230000:
                        WeaponNameString = "Blue Wooden Shield";
                        break;
                    case 21240000:
                        WeaponNameString = "Silver Eagle Kite Shield";
                        break;
                    case 21250000:
                        WeaponNameString = "Stone Parma";
                        break;
                    case 21260000:
                        WeaponNameString = "Spirit Tree Crest Shield";
                        break;
                    case 21270000:
                        WeaponNameString = "Porcine Shield";
                        break;
                    case 21280000:
                        WeaponNameString = "Shield of Want";
                        break;
                    case 21290000:
                        WeaponNameString = "Wargod Wooden Shield";
                        break;
                    case 21300000:
                        WeaponNameString = "Ethereal Oak Shield";
                        break;
                    case 21310000:
                        WeaponNameString = "Dragonhead Greatshield";
                        break;
                    case 22010000:
                        WeaponNameString = "Lothric Knight Greatshield";
                        break;
                    case 22020000:
                        WeaponNameString = "Cathedral Knight Greatshield";
                        break;
                    case 22040000:
                        WeaponNameString = "Dragonslayer Greatshield";
                        break;
                    case 22050000:
                        WeaponNameString = "Moaning Shield";
                        break;
                    case 22070000:
                        WeaponNameString = "Yhorm's Greatshield";
                        break;
                    case 22080000:
                        WeaponNameString = "Black Iron Greatshield";
                        break;
                    case 22090000:
                        WeaponNameString = "Wolf Knight's Greatshield";
                        break;
                    case 22100000:
                        WeaponNameString = "Twin Dragon Greatshield";
                        break;
                    case 22120000:
                        WeaponNameString = "Curse Ward Greatshield";
                        break;
                    case 22130000:
                        WeaponNameString = "Bonewheel Shield";
                        break;
                    case 22140000:
                        WeaponNameString = "Stone Greatshield";
                        break;
                    case 23000000:
                        WeaponNameString = "Torch";
                        break;
                    case 23010000:
                        WeaponNameString = "Follower Torch";
                        break;
                }

                WeaponNameString = WeaponInfusionString + WeaponNameString + WeaponReinforceString;

                return WeaponNameString;
            }

            public static string ArmorName(int ArmorId)
            {
                string ArmorNameString = String.Empty;

                switch (ArmorId)
                {
                    case 0x121EAC0:
                        ArmorNameString = "Fallen Knight Helm";
                        break;
                    case 0x121EEA8:
                        ArmorNameString = "Fallen Knight Armor";
                        break;
                    case 0x121F290:
                        ArmorNameString = "Fallen Knight Gauntlets";
                        break;
                    case 0x121F678:
                        ArmorNameString = "Fallen Knight Trousers";
                        break;
                    case 0x1298BE0:
                        ArmorNameString = "Knight Helm";
                        break;
                    case 0x1298FC8:
                        ArmorNameString = "Knight Armor";
                        break;
                    case 0x12993B0:
                        ArmorNameString = "Knight Gauntlets";
                        break;
                    case 0x1299798:
                        ArmorNameString = "Knight Leggings";
                        break;
                    case 0x1406F40:
                        ArmorNameString = "Firelink Helm";
                        break;
                    case 0x1407328:
                        ArmorNameString = "Firelink Armor";
                        break;
                    case 0x1407710:
                        ArmorNameString = "Firelink Gauntlets";
                        break;
                    case 0x1407AF8:
                        ArmorNameString = "Firelink Leggings";
                        break;
                    case 0x1481060:
                        ArmorNameString = "Sellsword Helm";
                        break;
                    case 0x1481448:
                        ArmorNameString = "Sellsword Armor";
                        break;
                    case 0x1481830:
                        ArmorNameString = "Sellsword Gauntlet";
                        break;
                    case 0x1481C18:
                        ArmorNameString = "Sellsword Trousers";
                        break;
                    case 0x14FB180:
                        ArmorNameString = "Herald Helm";
                        break;
                    case 0x14FB568:
                        ArmorNameString = "Herald Armor";
                        break;
                    case 0x14FB950:
                        ArmorNameString = "Herald Gloves";
                        break;
                    case 0x14FBD38:
                        ArmorNameString = "Herald Trousers";
                        break;
                    case 0x15752A0:
                        ArmorNameString = "Sunless Veil";
                        break;
                    case 0x1575688:
                        ArmorNameString = "Sunless Armor";
                        break;
                    case 0x1575A70:
                        ArmorNameString = "Sunless Gauntlets";
                        break;
                    case 0x1575E58:
                        ArmorNameString = "Sunless Leggings";
                        break;
                    case 0x15EF3C0:
                        ArmorNameString = "Black Hand Hat";
                        break;
                    case 0x15EF7A8:
                        ArmorNameString = "Black Hand Armor";
                        break;
                    case 0x15EFB90:
                        ArmorNameString = "Assassin Gloves";
                        break;
                    case 0x15EFF78:
                        ArmorNameString = "Assassin Trousers";
                        break;
                    case 0x1607A60:
                        ArmorNameString = "Assassin Hood";
                        break;
                    case 0x1607E48:
                        ArmorNameString = "Assassin Armor";
                        break;
                    case 0x16694E0:
                        ArmorNameString = "Xanthous Crown";
                        break;
                    case 0x16698C8:
                        ArmorNameString = "Xanthous Overcoat";
                        break;
                    case 0x1669CB0:
                        ArmorNameString = "Xanthous Gloves";
                        break;
                    case 0x166A098:
                        ArmorNameString = "Xanthous Trousers";
                        break;
                    case 0x16E3600:
                        ArmorNameString = "Northern Helm";
                        break;
                    case 0x16E39E8:
                        ArmorNameString = "Northern Armor";
                        break;
                    case 0x16E3DD0:
                        ArmorNameString = "Northern Gloves";
                        break;
                    case 0x16E41B8:
                        ArmorNameString = "Northern Trousers";
                        break;
                    case 0x175D720:
                        ArmorNameString = "Morne's Helm";
                        break;
                    case 0x175DB08:
                        ArmorNameString = "Morne's Armor";
                        break;
                    case 0x175DEF0:
                        ArmorNameString = "Morne's Gauntlets";
                        break;
                    case 0x175E2D8:
                        ArmorNameString = "Morne's Leggings";
                        break;
                    case 0x17D7840:
                        ArmorNameString = "Silver Mask";
                        break;
                    case 0x17D7C28:
                        ArmorNameString = "Leonhard's Garb";
                        break;
                    case 0x17D8010:
                        ArmorNameString = "Leonhard's Gauntlets";
                        break;
                    case 0x17D83F8:
                        ArmorNameString = "Leonhard's Trousers";
                        break;
                    case 0x1851960:
                        ArmorNameString = "Sneering Mask";
                        break;
                    case 0x1851D48:
                        ArmorNameString = "Pale Shade Robe";
                        break;
                    case 0x1852130:
                        ArmorNameString = "Pale Shade Gloves";
                        break;
                    case 0x1852518:
                        ArmorNameString = "Pale Shade Trousers";
                        break;
                    case 0x18CBA80:
                        ArmorNameString = "Sunset Helm";
                        break;
                    case 0x18CBE68:
                        ArmorNameString = "Sunset Armor";
                        break;
                    case 0x18CC250:
                        ArmorNameString = "Sunset Gauntlets";
                        break;
                    case 0x18CC638:
                        ArmorNameString = "Sunset Leggings";
                        break;
                    case 0x1945BA0:
                        ArmorNameString = "Old Sage's Blindfold";
                        break;
                    case 0x1945F88:
                        ArmorNameString = "Cornyx's Garb";
                        break;
                    case 0x1946370:
                        ArmorNameString = "Cornyx's Wrap";
                        break;
                    case 0x1946758:
                        ArmorNameString = "Cornyx's Skirt";
                        break;
                    case 0x19BFCC0:
                        ArmorNameString = "Executioner Helm";
                        break;
                    case 0x19C00A8:
                        ArmorNameString = "Executioner Armor";
                        break;
                    case 0x19C0490:
                        ArmorNameString = "Executioner Gauntlets";
                        break;
                    case 0x19C0878:
                        ArmorNameString = "Executioner Leggings";
                        break;
                    case 0x1A39DE0:
                        ArmorNameString = "Billed Mask";
                        break;
                    case 0x1A3A1C8:
                        ArmorNameString = "Black Dress";
                        break;
                    case 0x1A3A5B0:
                        ArmorNameString = "Black Gauntlets";
                        break;
                    case 0x1A3A998:
                        ArmorNameString = "Black Leggings";
                        break;
                    case 0x1AB3F00:
                        ArmorNameString = "Pyromancer Crown";
                        break;
                    case 0x1AB42E8:
                        ArmorNameString = "Pyromancer Garb";
                        break;
                    case 0x1AB46D0:
                        ArmorNameString = "Pyromancer Wrap";
                        break;
                    case 0x1AB4AB8:
                        ArmorNameString = "Pyromancer Trousers";
                        break;
                    case 0x1BA8140:
                        ArmorNameString = "Court Sorcerer Hood";
                        break;
                    case 0x1BA8528:
                        ArmorNameString = "Court Sorcerer Robe";
                        break;
                    case 0x1BA8910:
                        ArmorNameString = "Court Sorcerer Gloves";
                        break;
                    case 0x1BA8CF8:
                        ArmorNameString = "Court Sorcerer Trousers";
                        break;
                    case 0x1C9C380:
                        ArmorNameString = "Sorcerer Hood";
                        break;
                    case 0x1C9C768:
                        ArmorNameString = "Sorcerer Robe";
                        break;
                    case 0x1C9CB50:
                        ArmorNameString = "Sorcerer Gloves";
                        break;
                    case 0x1C9CF38:
                        ArmorNameString = "Sorcerer Trousers";
                        break;
                    case 0x1CB4E08:
                        ArmorNameString = "Clandestine Coat";
                        break;
                    case 0x1D905C0:
                        ArmorNameString = "Cleric Hat";
                        break;
                    case 0x1D909A8:
                        ArmorNameString = "Cleric Blue Robe";
                        break;
                    case 0x1D90D90:
                        ArmorNameString = "Cleric Gloves";
                        break;
                    case 0x1D91178:
                        ArmorNameString = "Cleric Trousers";
                        break;
                    case 0x1F78A40:
                        ArmorNameString = "Grotto Hat";
                        break;
                    case 0x1F78E28:
                        ArmorNameString = "Grotto Robe";
                        break;
                    case 0x1F79210:
                        ArmorNameString = "Grotto Wrap";
                        break;
                    case 0x1F795F8:
                        ArmorNameString = "Grotto Trousers";
                        break;
                    case 0x2625A00:
                        ArmorNameString = "Steel Soldier Helm";
                        break;
                    case 0x1DA9048:
                        ArmorNameString = "Deserter Armor";
                        break;
                    case 0x26261D0:
                        ArmorNameString = "Soldier's Gauntlets";
                        break;
                    case 0x26265B8:
                        ArmorNameString = "Deserter Trousers";
                        break;
                    case 0x263E0A0:
                        ArmorNameString = "Soldier's Hood";
                        break;
                    case 0x29020C0:
                        ArmorNameString = "Sage's Big Hat";
                        break;
                    case 0x29024A8:
                        ArmorNameString = "Elder's Robe";
                        break;
                    case 0x29F6300:
                        ArmorNameString = "Aristocrat's Mask";
                        break;
                    case 0x29F66E8:
                        ArmorNameString = "Jailer Robe";
                        break;
                    case 0x29F6AD0:
                        ArmorNameString = "Jailer Gloves";
                        break;
                    case 0x29F6EB8:
                        ArmorNameString = "Jailer Trousers";
                        break;
                    case 0x2A70420:
                        ArmorNameString = "Saint's Veil";
                        break;
                    case 0x2A70808:
                        ArmorNameString = "Saint's Dress";
                        break;
                    case 0x2AEA540:
                        ArmorNameString = "Footman's Hood";
                        break;
                    case 0x2AEA928:
                        ArmorNameString = "Footman's Overcoat";
                        break;
                    case 0x2AEAD10:
                        ArmorNameString = "Footman's Bracelets";
                        break;
                    case 0x2AEB0F8:
                        ArmorNameString = "Footman's Trousers";
                        break;
                    case 0x2BDE780:
                        ArmorNameString = "Grave Warden Hood";
                        break;
                    case 0x2BDEB68:
                        ArmorNameString = "Grave Warden Robe";
                        break;
                    case 0x2BDEF50:
                        ArmorNameString = "Grave Warden Wrap";
                        break;
                    case 0x2BDF338:
                        ArmorNameString = "Grave Warden Skirt";
                        break;
                    case 0x2CD29C0:
                        ArmorNameString = "Worker Hat";
                        break;
                    case 0x2CD2DA8:
                        ArmorNameString = "Worker Garb";
                        break;
                    case 0x2CD3190:
                        ArmorNameString = "Worker Gloves";
                        break;
                    case 0x2CD3578:
                        ArmorNameString = "Worker Trousers";
                        break;
                    case 0x2D4CAE0:
                        ArmorNameString = "Thrall Hood";
                        break;
                    case 0x2DC6C00:
                        ArmorNameString = "Evangelist Hat";
                        break;
                    case 0x2DC6FE8:
                        ArmorNameString = "Evangelist Robe";
                        break;
                    case 0x2DC73D0:
                        ArmorNameString = "Evangelist Gloves";
                        break;
                    case 0x2DC77B8:
                        ArmorNameString = "Evangelist Trousers";
                        break;
                    case 0x2E40D20:
                        ArmorNameString = "Scholar's Shed Skin";
                        break;
                    case 0x2E41108:
                        ArmorNameString = "Scholar's Robe";
                        break;
                    case 0x2EBAE40:
                        ArmorNameString = "Winged Knight Helm";
                        break;
                    case 0x2EBB228:
                        ArmorNameString = "Winged Knight Armor";
                        break;
                    case 0x2EBB610:
                        ArmorNameString = "Winged Knight Gauntlets";
                        break;
                    case 0x2EBB9F8:
                        ArmorNameString = "Winged Knight Leggings";
                        break;
                    case 0x30291A0:
                        ArmorNameString = "Cathedral Knight Helm";
                        break;
                    case 0x3029588:
                        ArmorNameString = "Cathedral Knight Armor";
                        break;
                    case 0x3029970:
                        ArmorNameString = "Cathedral Knight Gauntlets";
                        break;
                    case 0x3029D58:
                        ArmorNameString = "Cathedral Knight Leggings";
                        break;
                    case 0x3197500:
                        ArmorNameString = "Lothric Knight Helm";
                        break;
                    case 0x31978E8:
                        ArmorNameString = "Lothric Knight Armor";
                        break;
                    case 0x3197CD0:
                        ArmorNameString = "Lothric Knight Gauntlets";
                        break;
                    case 0x31980B8:
                        ArmorNameString = "Lothric Knight Leggings";
                        break;
                    case 0x328B740:
                        ArmorNameString = "Outrider Knight Helm";
                        break;
                    case 0x328BB28:
                        ArmorNameString = "Outrider Knight Armor";
                        break;
                    case 0x328BF10:
                        ArmorNameString = "Outrider Knight Gauntlets";
                        break;
                    case 0x328C2F8:
                        ArmorNameString = "Outrider Knight Leggings";
                        break;
                    case 0x337F980:
                        ArmorNameString = "Black Knight Helm";
                        break;
                    case 0x337FD68:
                        ArmorNameString = "Black Knight Armor";
                        break;
                    case 0x3380150:
                        ArmorNameString = "Black Knight Gauntlets";
                        break;
                    case 0x3380538:
                        ArmorNameString = "Black Knight Leggings";
                        break;
                    case 0x33F9AA0:
                        ArmorNameString = "Dark Mask";
                        break;
                    case 0x33F9E88:
                        ArmorNameString = "Dark Armor";
                        break;
                    case 0x33FA270:
                        ArmorNameString = "Dark Gauntlets";
                        break;
                    case 0x33FA658:
                        ArmorNameString = "Dark Leggings";
                        break;
                    case 0x3473BC0:
                        ArmorNameString = "Exile Mask";
                        break;
                    case 0x3473FA8:
                        ArmorNameString = "Exile Armor";
                        break;
                    case 0x3474390:
                        ArmorNameString = "Exile Gauntlets";
                        break;
                    case 0x3474778:
                        ArmorNameString = "Exile Leggings";
                        break;
                    case 0x3567E00:
                        ArmorNameString = "Pontiff Knight Crown";
                        break;
                    case 0x35681E8:
                        ArmorNameString = "Pontiff Knight Armor";
                        break;
                    case 0x35685D0:
                        ArmorNameString = "Pontiff Knight Gauntlets";
                        break;
                    case 0x35689B8:
                        ArmorNameString = "Pontiff Knight Leggings";
                        break;
                    case 0x365C040:
                        ArmorNameString = "Golden Crown";
                        break;
                    case 0x365C428:
                        ArmorNameString = "Dragonscale Armor";
                        break;
                    case 0x365C810:
                        ArmorNameString = "Golden Bracelets";
                        break;
                    case 0x365CBF8:
                        ArmorNameString = "Dragonscale Waistcloth";
                        break;
                    case 0x36D6160:
                        ArmorNameString = "Wolnir's Crown";
                        break;
                    case 0x3750280:
                        ArmorNameString = "Undead Legion Helm";
                        break;
                    case 0x3750668:
                        ArmorNameString = "Undead Legion Armor";
                        break;
                    case 0x3750A50:
                        ArmorNameString = "Undead Legion Gauntlet";
                        break;
                    case 0x3750E38:
                        ArmorNameString = "Undead Legion Leggings";
                        break;
                    case 0x38BE5E0:
                        ArmorNameString = "Man Serpent's Mask";
                        break;
                    case 0x38BE9C8:
                        ArmorNameString = "Man Serpent's Robe";
                        break;
                    case 0x3938700:
                        ArmorNameString = "Fire Witch Helm";
                        break;
                    case 0x3938AE8:
                        ArmorNameString = "Fire Witch Armor";
                        break;
                    case 0x3938ED0:
                        ArmorNameString = "Fire Witch Gauntlets";
                        break;
                    case 0x39392B8:
                        ArmorNameString = "Fire Witch Leggings";
                        break;
                    case 0x3A2C940:
                        ArmorNameString = "Lorian's Helm";
                        break;
                    case 0x3A2CD28:
                        ArmorNameString = "Lorian's Armor";
                        break;
                    case 0x3A2D110:
                        ArmorNameString = "Lorian's Gauntlets";
                        break;
                    case 0x3A2D4F8:
                        ArmorNameString = "Lorian's Leggings";
                        break;
                    case 0x3AA6A60:
                        ArmorNameString = "Hood of Prayer";
                        break;
                    case 0x3AA6E48:
                        ArmorNameString = "Robe of Prayer";
                        break;
                    case 0x3AA7618:
                        ArmorNameString = "Skirt of Prayer";
                        break;
                    case 0x3B20B80:
                        ArmorNameString = "Giant's crown";
                        break;
                    case 0x3B20F68:
                        ArmorNameString = "Giant's Armor";
                        break;
                    case 0x3B21350:
                        ArmorNameString = "Giant's Gauntlets";
                        break;
                    case 0x3B21738:
                        ArmorNameString = "Giant's Leggings";
                        break;
                    case 0x3C14DC0:
                        ArmorNameString = "Dancer's Crown";
                        break;
                    case 0x3C151A8:
                        ArmorNameString = "Dancer's Armor";
                        break;
                    case 0x3C15590:
                        ArmorNameString = "Dancer's Gauntlets";
                        break;
                    case 0x3C15978:
                        ArmorNameString = "Dancer's Leggings";
                        break;
                    case 0x3D09000:
                        ArmorNameString = "Gundyr's Helm";
                        break;
                    case 0x3D093E8:
                        ArmorNameString = "Gundyr's Armor";
                        break;
                    case 0x3D097D0:
                        ArmorNameString = "Gundyr's Gauntlets";
                        break;
                    case 0x3D09BB8:
                        ArmorNameString = "Gundyr's Leggings";
                        break;
                    case 0x3DFD240:
                        ArmorNameString = "Old Monarch's Crown";
                        break;
                    case 0x3DFD628:
                        ArmorNameString = "Old Monarch's Robe";
                        break;
                    case 0x3EF1480:
                        ArmorNameString = "Archdeacon White Crown";
                        break;
                    case 0x3EF1868:
                        ArmorNameString = "Archdeacon Holy Garb";
                        break;
                    case 0x3EF2038:
                        ArmorNameString = "Archdeacon Skirt";
                        break;
                    case 0x3F6B988:
                        ArmorNameString = "Deacon Robe";
                        break;
                    case 0x3F6C158:
                        ArmorNameString = "Deacon Skirt";
                        break;
                    case 0x3FE56C0:
                        ArmorNameString = "Frigid Valley Mask";
                        break;
                    case 0x40D9900:
                        ArmorNameString = "Dingy Hood";
                        break;
                    case 0x40D9CE8:
                        ArmorNameString = "Fire Keeper Robe";
                        break;
                    case 0x40DA0D0:
                        ArmorNameString = "Fire Keeper Gloves";
                        break;
                    case 0x40DA4B8:
                        ArmorNameString = "Fire Keeper Skirt";
                        break;
                    case 0x42C1D80:
                        ArmorNameString = "Chain Helm";
                        break;
                    case 0x42C2168:
                        ArmorNameString = "Chain Armor";
                        break;
                    case 0x42C2550:
                        ArmorNameString = "Leather Gauntlets";
                        break;
                    case 0x42C2938:
                        ArmorNameString = "Chain Leggings";
                        break;
                    case 0x43B5FC0:
                        ArmorNameString = "Nameless Knight Helm";
                        break;
                    case 0x43B63A8:
                        ArmorNameString = "Nameless Knight Armor";
                        break;
                    case 0x43B6790:
                        ArmorNameString = "Nameless Knight Gauntlets";
                        break;
                    case 0x43B6B78:
                        ArmorNameString = "Nameless Knight Leggings";
                        break;
                    case 0x44AA200:
                        ArmorNameString = "Elite Knight Helm";
                        break;
                    case 0x44AA5E8:
                        ArmorNameString = "Elite Knight Armor";
                        break;
                    case 0x44AA9D0:
                        ArmorNameString = "Elite Knight Gauntlets";
                        break;
                    case 0x44AADB8:
                        ArmorNameString = "Elite Knight Leggings";
                        break;
                    case 0x459E440:
                        ArmorNameString = "Faraam Helm";
                        break;
                    case 0x459E828:
                        ArmorNameString = "Faraam Armor";
                        break;
                    case 0x459EC10:
                        ArmorNameString = "Faraam Gauntlets";
                        break;
                    case 0x459EFF8:
                        ArmorNameString = "Faraam Boots";
                        break;
                    case 0x4692680:
                        ArmorNameString = "Catarina Helm";
                        break;
                    case 0x4692A68:
                        ArmorNameString = "Catarina Armor";
                        break;
                    case 0x4692E50:
                        ArmorNameString = "Catarina Gauntlets";
                        break;
                    case 0x4693238:
                        ArmorNameString = "Catarina Leggings";
                        break;
                    case 0x470C7A0:
                        ArmorNameString = "Standard Helm";
                        break;
                    case 0x470CB88:
                        ArmorNameString = "Hard Leather Armor";
                        break;
                    case 0x470CF70:
                        ArmorNameString = "Hard Leather Gauntlets";
                        break;
                    case 0x470D358:
                        ArmorNameString = "Hard Leather Boots";
                        break;
                    case 0x47868C0:
                        ArmorNameString = "Havel's Helm";
                        break;
                    case 0x4786CA8:
                        ArmorNameString = "Havel's Armor";
                        break;
                    case 0x4787090:
                        ArmorNameString = "Havel's Gauntlets";
                        break;
                    case 0x4787478:
                        ArmorNameString = "Havel's Leggings";
                        break;
                    case 0x48009E0:
                        ArmorNameString = "Brigand Hood";
                        break;
                    case 0x4800DC8:
                        ArmorNameString = "Brigand Armor";
                        break;
                    case 0x48011B0:
                        ArmorNameString = "Brigand Gauntlets";
                        break;
                    case 0x4801598:
                        ArmorNameString = "Brigand Trousers";
                        break;
                    case 0x487AB00:
                        ArmorNameString = "Pharis's Hat";
                        break;
                    case 0x487AEE8:
                        ArmorNameString = "Leather Armor";
                        break;
                    case 0x487B2D0:
                        ArmorNameString = "Leather Gloves";
                        break;
                    case 0x487B6B8:
                        ArmorNameString = "Leather Boots";
                        break;
                    case 0x48F4C20:
                        ArmorNameString = "Ragged Mask";
                        break;
                    case 0x48F5008:
                        ArmorNameString = "Master's Attire";
                        break;
                    case 0x48F53F0:
                        ArmorNameString = "Master's Gloves";
                        break;
                    case 0x48F57D8:
                        ArmorNameString = "Loincloth";
                        break;
                    case 0x496ED40:
                        ArmorNameString = "Old Sorcerer Hat";
                        break;
                    case 0x496F128:
                        ArmorNameString = "Old Sorcerer Coat";
                        break;
                    case 0x496F510:
                        ArmorNameString = "Old Sorcerer Gauntlets";
                        break;
                    case 0x496F8F8:
                        ArmorNameString = "Old Sorcerer Boots";
                        break;
                    case 0x49E8E60:
                        ArmorNameString = "Conjurator Hood";
                        break;
                    case 0x49E9248:
                        ArmorNameString = "Conjurator Robe";
                        break;
                    case 0x49E9630:
                        ArmorNameString = "Conjurator Manchettes";
                        break;
                    case 0x49E9A18:
                        ArmorNameString = "Conjurator Boots";
                        break;
                    case 0x2656740:
                        ArmorNameString = "Thief Mask";
                        break;
                    case 0x4A63368:
                        ArmorNameString = "Black Leather Armor";
                        break;
                    case 0x4A63750:
                        ArmorNameString = "Black Leather Gloves";
                        break;
                    case 0x4A63B38:
                        ArmorNameString = "Black Leather Boots";
                        break;
                    case 0x4ADD0A0:
                        ArmorNameString = "Symbol of Avarice";
                        break;
                    case 0x4B571C0:
                        ArmorNameString = "Creighton's Steel Mask";
                        break;
                    case 0x4B575A8:
                        ArmorNameString = "Mirrah Chain Mail";
                        break;
                    case 0x4B57990:
                        ArmorNameString = "Mirrah Chain Gloves";
                        break;
                    case 0x4B57D78:
                        ArmorNameString = "Mirrah Chain Leggings";
                        break;
                    case 0x4BD12E0:
                        ArmorNameString = "Maiden Hood";
                        break;
                    case 0x4BD16C8:
                        ArmorNameString = "Maiden Robe";
                        break;
                    case 0x4BD1AB0:
                        ArmorNameString = "Maiden Gloves";
                        break;
                    case 0x4BD1E98:
                        ArmorNameString = "Maiden Skirt";
                        break;
                    case 0x4C4B400:
                        ArmorNameString = "Alva Helm";
                        break;
                    case 0x4C4B7E8:
                        ArmorNameString = "Alva Armor";
                        break;
                    case 0x4C4BBD0:
                        ArmorNameString = "Alva Gauntlets";
                        break;
                    case 0x4C4BFB8:
                        ArmorNameString = "Alva Leggings";
                        break;
                    case 0x4D3F640:
                        ArmorNameString = "Shadow Mask";
                        break;
                    case 0x4D3FA28:
                        ArmorNameString = "Shadow Garb";
                        break;
                    case 0x4D3FE10:
                        ArmorNameString = "Shadow Gauntlets";
                        break;
                    case 0x4D401F8:
                        ArmorNameString = "Shadow Leggings";
                        break;
                    case 0x4E33880:
                        ArmorNameString = "Eastern Helm";
                        break;
                    case 0x4E33C68:
                        ArmorNameString = "Eastern Armor";
                        break;
                    case 0x4E34050:
                        ArmorNameString = "Eastern Gauntlets";
                        break;
                    case 0x4E34438:
                        ArmorNameString = "Eastern Leggings";
                        break;
                    case 0x4F27AC0:
                        ArmorNameString = "Helm of Favor";
                        break;
                    case 0x4F27EA8:
                        ArmorNameString = "Embraced Armor of Favor";
                        break;
                    case 0x4F28290:
                        ArmorNameString = "Gauntlets of Favor";
                        break;
                    case 0x4F28678:
                        ArmorNameString = "Leggings of Favor";
                        break;
                    case 0x501BD00:
                        ArmorNameString = "Brass Helm";
                        break;
                    case 0x501C0E8:
                        ArmorNameString = "Brass Armor";
                        break;
                    case 0x501C4D0:
                        ArmorNameString = "Brass Gauntlets";
                        break;
                    case 0x501C8B8:
                        ArmorNameString = "Brass Leggings";
                        break;
                    case 0x510FF40:
                        ArmorNameString = "Silver Knight Helm";
                        break;
                    case 0x5110328:
                        ArmorNameString = "Silver Knight Armor";
                        break;
                    case 0x5110710:
                        ArmorNameString = "Silver Knight Gauntlets";
                        break;
                    case 0x5110AF8:
                        ArmorNameString = "Silver Knight Leggings";
                        break;
                    case 0x5204180:
                        ArmorNameString = "Lucatiel's Mask";
                        break;
                    case 0x5204568:
                        ArmorNameString = "Mirrah Vest";
                        break;
                    case 0x5204950:
                        ArmorNameString = "Mirrah Gloves";
                        break;
                    case 0x5204D38:
                        ArmorNameString = "Mirrah Trousers";
                        break;
                    case 0x52F83C0:
                        ArmorNameString = "Iron Helm";
                        break;
                    case 0x52F87A8:
                        ArmorNameString = "Armor of the Sun";
                        break;
                    case 0x52F8B90:
                        ArmorNameString = "Iron Bracelets";
                        break;
                    case 0x52F8F78:
                        ArmorNameString = "Iron Leggings";
                        break;
                    case 0x53EC600:
                        ArmorNameString = "Drakeblood Helm";
                        break;
                    case 0x53EC9E8:
                        ArmorNameString = "Drakeblood Armor";
                        break;
                    case 0x53ECDD0:
                        ArmorNameString = "Drakeblood Gauntlets";
                        break;
                    case 0x53ED1B8:
                        ArmorNameString = "Drakeblood Leggings";
                        break;
                    case 0x54E0C28:
                        ArmorNameString = "Drang Armor";
                        break;
                    case 0x54E1010:
                        ArmorNameString = "Drang Gauntlets";
                        break;
                    case 0x54E13F8:
                        ArmorNameString = "Drang Shoes";
                        break;
                    case 0x55D4A80:
                        ArmorNameString = "Black Iron Helm";
                        break;
                    case 0x55D4E68:
                        ArmorNameString = "Black Iron Armor";
                        break;
                    case 0x55D5250:
                        ArmorNameString = "Black Iron Gauntlets";
                        break;
                    case 0x55D5638:
                        ArmorNameString = "Black Iron Leggings";
                        break;
                    case 0x56C8CC0:
                        ArmorNameString = "Painting Guardian Hood";
                        break;
                    case 0x56C90A8:
                        ArmorNameString = "Painting Guardian Gown";
                        break;
                    case 0x56C9490:
                        ArmorNameString = "Painting Guardian Gloves";
                        break;
                    case 0x56C9878:
                        ArmorNameString = "Painting Guardian Waistcloth";
                        break;
                    case 0x57BCF00:
                        ArmorNameString = "Wolf Knight Helm";
                        break;
                    case 0x57BD2E8:
                        ArmorNameString = "Wolf Knight Armor";
                        break;
                    case 0x57BD6D0:
                        ArmorNameString = "Wolf Knight Gauntlets";
                        break;
                    case 0x57BDAB8:
                        ArmorNameString = "Wolf Knight Leggings";
                        break;
                    case 0x58B1140:
                        ArmorNameString = "Dragonslayer Helm";
                        break;
                    case 0x58B1528:
                        ArmorNameString = "Dragonslayer Armor";
                        break;
                    case 0x58B1910:
                        ArmorNameString = "Dragonslayer Gauntlets";
                        break;
                    case 0x58B1CF8:
                        ArmorNameString = "Dragonslayer Leggings";
                        break;
                    case 0x59A5380:
                        ArmorNameString = "Smough's Helm";
                        break;
                    case 0x59A5768:
                        ArmorNameString = "Smough's Armor";
                        break;
                    case 0x59A5B50:
                        ArmorNameString = "Smough's Gauntlets";
                        break;
                    case 0x59A5F38:
                        ArmorNameString = "Smough's Leggings";
                        break;
                    case 0x5A995C0:
                        ArmorNameString = "Hexer's Hood";
                        break;
                    case 0x5A999A8:
                        ArmorNameString = "Hexer's Robes";
                        break;
                    case 0x5A99D90:
                        ArmorNameString = "Hexer's Gloves";
                        break;
                    case 0x5A9A178:
                        ArmorNameString = "Hexer's Boots";
                        break;
                    case 0x5B8D800:
                        ArmorNameString = "Helm of Thorns";
                        break;
                    case 0x5B8DBE8:
                        ArmorNameString = "Armor of Thorns";
                        break;
                    case 0x5B8DFD0:
                        ArmorNameString = "Gauntlets of Thorns";
                        break;
                    case 0x5B8E3B8:
                        ArmorNameString = "Leggings of Thorns";
                        break;
                    case 0x5C81A40:
                        ArmorNameString = "Varangian Helm";
                        break;
                    case 0x5C81E28:
                        ArmorNameString = "Varangian Armor";
                        break;
                    case 0x5C82210:
                        ArmorNameString = "Varangian Cuffs";
                        break;
                    case 0x5C825F8:
                        ArmorNameString = "Varangian Leggings";
                        break;
                    case 0x5D75C80:
                        ArmorNameString = "Crown of Dusk";
                        break;
                    case 0x5D76068:
                        ArmorNameString = "Antiquated Dress";
                        break;
                    case 0x5D76450:
                        ArmorNameString = "Antiquated Gloves";
                        break;
                    case 0x5D76838:
                        ArmorNameString = "Antiquated Skirt";
                        break;
                    case 0x5E69EC0:
                        ArmorNameString = "Karla's Pointed Hat";
                        break;
                    case 0x5E6A2A8:
                        ArmorNameString = "Karla's Coat";
                        break;
                    case 0x5E6A690:
                        ArmorNameString = "Karla's Gloves";
                        break;
                    case 0x5E6AA78:
                        ArmorNameString = "Karla's Trousers";
                        break;
                    case 0x37CA3A0:
                        ArmorNameString = "Follower Helm";
                        break;
                    case 0x37CA788:
                        ArmorNameString = "Follower Armor";
                        break;
                    case 0x37CAB70:
                        ArmorNameString = "Follower Gloves";
                        break;
                    /*case 0x37CAB70:
                        ArmorNameString = "Follower Boots";
                        break;*/
                    case 0x34EDCE0:
                        ArmorNameString = "Slave Knight Hood";
                        break;
                    case 0x34EE0C8:
                        ArmorNameString = "Slave Knight Armor";
                        break;
                    case 0x34EE4B0:
                        ArmorNameString = "Slave Knight Gauntlets";
                        break;
                    case 0x34EE898:
                        ArmorNameString = "Slave Knight Leggings";
                        break;
                    case 0x1312D00:
                        ArmorNameString = "Vilhelm's Helm";
                        break;
                    case 0x13130E8:
                        ArmorNameString = "Vilhelm's Armor";
                        break;
                    case 0x13134D0:
                        ArmorNameString = "Vilhelm's Gauntlets";
                        break;
                    /*case 0x13134D0:
                        ArmorNameString = "Vilhelm's Leggings";
                        break;*/
                    case 0x39B2820:
                        ArmorNameString = "Millwood Knight Helm";
                        break;
                    case 0x39B2C08:
                        ArmorNameString = "Millwood Knight Armor";
                        break;
                    case 0x39B2FF0:
                        ArmorNameString = "Millwood Knight Gauntlets";
                        break;
                    case 0x39B33D8:
                        ArmorNameString = "Millwood Knight Leggings";
                        break;
                    case 0x35E1F20:
                        ArmorNameString = "Ordained Hood";
                        break;
                    case 0x35E2308:
                        ArmorNameString = "Ordained Dress";
                        break;
                    case 0x35E2AD8:
                        ArmorNameString = "Ordained Trousers";
                        break;
                    case 0x1B2E408:
                        ArmorNameString = "Antiquated Plain Garb";
                        break;
                    case 0x1B2E7F0:
                        ArmorNameString = "Violet Wrappings";
                        break;
                    case 0x1B2EBD8:
                        ArmorNameString = "Loincloth Not the one already in the game";
                        break;
                    case 0x1C22260:
                        ArmorNameString = "Shira's Crown";
                        break;
                    case 0x1C22648:
                        ArmorNameString = "Shira's Armor";
                        break;
                    case 0x1C22A30:
                        ArmorNameString = "Shira's Gloves";
                        break;
                    case 0x1C22E18:
                        ArmorNameString = "Shira's Trousers";
                        break;
                    case 0x1E84800:
                        ArmorNameString = "Lapp's Helm";
                        break;
                    case 0x1E84BE8:
                        ArmorNameString = "Lapp's Armor";
                        break;
                    case 0x1E84FD0:
                        ArmorNameString = "Lapp's Gauntlets";
                        break;
                    case 0x1E853B8:
                        ArmorNameString = "Lapp's Leggings";
                        break;
                    case 0x3C8EEE0:
                        ArmorNameString = "Ringed Knight Hood";
                        break;
                    case 0x3C8F2C8:
                        ArmorNameString = "Ringed Knight Armor";
                        break;
                    case 0x3C8F6B0:
                        ArmorNameString = "Ringed Knight Gauntlets";
                        break;
                    case 0x3C8FA98:
                        ArmorNameString = "Ringed Knight Leggings";
                        break;
                    case 0x3D83508:
                        ArmorNameString = "Harald Legion Armor";
                        break;
                    case 0x3D838F0:
                        ArmorNameString = "Harald Legion Gauntlets";
                        break;
                    case 0x3D83CD8:
                        ArmorNameString = "Harald Legion Leggings";
                        break;
                    case 0x405F7E0:
                        ArmorNameString = "Iron Dragonslayer Helm";
                        break;
                    case 0x405FBC8:
                        ArmorNameString = "Iron Dragonslayer Armor";
                        break;
                    case 0x405FFB0:
                        ArmorNameString = "Iron Dragonslayer Gauntlets";
                        break;
                    case 0x4060398:
                        ArmorNameString = "Iron Dragonslayer Leggings";
                        break;
                    case 0x4153A20:
                        ArmorNameString = "White Preacher Head";
                        break;
                    case 0x4CC5520:
                        ArmorNameString = "Ruin Sentinel Helm";
                        break;
                    case 0x4CC5908:
                        ArmorNameString = "Ruin Sentinel Armor";
                        break;
                    case 0x4CC5CF0:
                        ArmorNameString = "Ruin Sentinel Gauntlets";
                        break;
                    case 0x4CC60D8:
                        ArmorNameString = "Ruin Sentinel Leggings";
                        break;
                    case 0x4DB9760:
                        ArmorNameString = "Desert Pyromancer Hood";
                        break;
                    case 0x4DB9B48:
                        ArmorNameString = "Desert Pyromancer Garb";
                        break;
                    case 0x4DB9F30:
                        ArmorNameString = "Desert Pyromancer Gloves";
                        break;
                    case 0x4DBA318:
                        ArmorNameString = "Desert Pyromancer Skirt";
                        break;
                    case 0x4FA1BE0:
                        ArmorNameString = "Black Witch Veil";
                        break;
                    case 0x4EAD9A0:
                        ArmorNameString = "Black Witch Hat";
                        break;
                    case 0x4EADD88:
                        ArmorNameString = "Black Witch Garb";
                        break;
                    case 0x4EAE170:
                        ArmorNameString = "Black Witch Wrappings";
                        break;
                    case 0x4EAE558:
                        ArmorNameString = "Black Witch Trousers";
                        break;
                    case 0x5095E20:
                        ArmorNameString = "Blindfold Mask";
                        break;
                    case 0x0:
                        ArmorNameString = "Armor of dragons";
                        break;
                    case 0x00F4240:
                        ArmorNameString = "Dragon's head";
                        break;
                    case 0x00F4628:
                        ArmorNameString = "Dragon's chestplace";
                        break;
                    case 0x00F4A10:
                        ArmorNameString = "Dragon's gauntlets";
                        break;
                    case 0x00F4DF8:
                        ArmorNameString = "Dragon's leggins";
                        break;
                }

                ArmorNameString = ArmorNameString;

                return ArmorNameString;
            }

            public static string RingName(int RingId)
            {
                string RingNameString = String.Empty;

                switch (RingId)
                {
                    case 0x0004E20:
                        RingNameString = "Life Ring";
                        break;
                    case 0x0004E21:
                        RingNameString = "Life Ring+1";
                        break;
                    case 0x0004E22:
                        RingNameString = "Life Ring+2";
                        break;
                    case 0x0004E23:
                        RingNameString = "Life Ring+3";
                        break;
                    case 0x0004E2A:
                        RingNameString = "Chloranthy Ring";
                        break;
                    case 0x0004E2B:
                        RingNameString = "Chloranthy Ring+1";
                        break;
                    case 0x0004E2C:
                        RingNameString = "Chloranthy Ring+2";
                        break;
                    case 0x0004E34:
                        RingNameString = "Havel's Ring";
                        break;
                    case 0x0004E35:
                        RingNameString = "Havel's Ring+1";
                        break;
                    case 0x0004E36:
                        RingNameString = "Havel's Ring+2";
                        break;
                    case 0x0004E3E:
                        RingNameString = "Ring of Favor";
                        break;
                    case 0x0004E3F:
                        RingNameString = "Ring of Favor+1";
                        break;
                    case 0x0004E40:
                        RingNameString = "Ring of Favor+2";
                        break;
                    case 0x0004E48:
                        RingNameString = "Ring of Steel Protection";
                        break;
                    case 0x0004E49:
                        RingNameString = "Ring of Steel Protection+1";
                        break;
                    case 0x0004E4A:
                        RingNameString = "Ring of Steel Protection+2";
                        break;
                    case 0x0004E52:
                        RingNameString = "Flame Stoneplate Ring";
                        break;
                    case 0x0004E53:
                        RingNameString = "Flame Stoneplate Ring+1";
                        break;
                    case 0x0004E54:
                        RingNameString = "Flame Stoneplate Ring+2";
                        break;
                    case 0x0004E5C:
                        RingNameString = "Thunder Stoneplate Ring";
                        break;
                    case 0x0004E5D:
                        RingNameString = "Thunder Stoneplate Ring+1";
                        break;
                    case 0x0004E5E:
                        RingNameString = "Thunder Stoneplate Ring+2";
                        break;
                    case 0x0004E66:
                        RingNameString = "Magic Stoneplate Ring";
                        break;
                    case 0x0004E67:
                        RingNameString = "Magic Stoneplate Ring+1";
                        break;
                    case 0x0004E68:
                        RingNameString = "Magic Stoneplate Ring+2";
                        break;
                    case 0x0004E70:
                        RingNameString = "Dark Stoneplate Ring";
                        break;
                    case 0x0004E71:
                        RingNameString = "Dark Stoneplate Ring+1";
                        break;
                    case 0x0004E72:
                        RingNameString = "Dark Stoneplate Ring+2";
                        break;
                    case 0x0004E7A:
                        RingNameString = "Speckled Stoneplate Ring";
                        break;
                    case 0x0004E7B:
                        RingNameString = "Speckled Stoneplate Ring+1";
                        break;
                    case 0x0004E84:
                        RingNameString = "Bloodbite Ring";
                        break;
                    case 0x0004E85:
                        RingNameString = "Bloodbite Ring+1";
                        break;
                    case 0x0004E8E:
                        RingNameString = "Poisonbite Ring";
                        break;
                    case 0x0004E8F:
                        RingNameString = "Poisonbite Ring+1";
                        break;
                    case 0x0004E98:
                        RingNameString = "Cursebite Ring";
                        break;
                    case 0x0004EA2:
                        RingNameString = "Fleshbite Ring";
                        break;
                    case 0x0004EA3:
                        RingNameString = "Fleshbite Ring+1";
                        break;
                    case 0x0004EAC:
                        RingNameString = "Wood Grain Ring";
                        break;
                    case 0x0004EAD:
                        RingNameString = "Wood Grain Ring+1";
                        break;
                    case 0x0004EAE:
                        RingNameString = "Wood Grain Ring+2";
                        break;
                    case 0x0004EB6:
                        RingNameString = "Scholar Ring";
                        break;
                    case 0x0004EC0:
                        RingNameString = "Priestess Ring";
                        break;
                    case 0x0004ECA:
                        RingNameString = "Red Tearstone Ring";
                        break;
                    case 0x0004ED4:
                        RingNameString = "Blue Tearstone Ring";
                        break;
                    case 0x0004EDE:
                        RingNameString = "Wolf Ring";
                        break;
                    case 0x0004EDF:
                        RingNameString = "Wolf Ring+1";
                        break;
                    case 0x0004EE0:
                        RingNameString = "Wolf Ring+2";
                        break;
                    case 0x0004EE8:
                        RingNameString = "Leo Ring";
                        break;
                    case 0x0004EF2:
                        RingNameString = "Ring of Sacrifice";
                        break;
                    case 0x0004F06:
                        RingNameString = "Young Dragon Ring";
                        break;
                    case 0x0004F07:
                        RingNameString = "Bellowing Dragoncrest Ring";
                        break;
                    case 0x0004F10:
                        RingNameString = "Great Swamp Ring";
                        break;
                    case 0x0004F11:
                        RingNameString = "Witch's Ring";
                        break;
                    case 0x0004F1A:
                        RingNameString = "Morne's Ring";
                        break;
                    case 0x0004F1B:
                        RingNameString = "Ring of the Sun's First Born";
                        break;
                    case 0x0004F2E:
                        RingNameString = "Lingering Dragoncrest Ring";
                        break;
                    case 0x0004F2F:
                        RingNameString = "Lingering Dragoncrest Ring+1";
                        break;
                    case 0x0004F30:
                        RingNameString = "Lingering Dragoncrest Ring+2";
                        break;
                    case 0x0004F38:
                        RingNameString = "Sage Ring";
                        break;
                    case 0x0004F39:
                        RingNameString = "Sage Ring+1";
                        break;
                    case 0x0004F3A:
                        RingNameString = "Sage Ring+2";
                        break;
                    case 0x0004F42:
                        RingNameString = "Slumbering Dragoncrest Ring";
                        break;
                    case 0x0004F4C:
                        RingNameString = "Dusk Crown Ring";
                        break;
                    case 0x0004F56:
                        RingNameString = "Saint's Ring";
                        break;
                    case 0x0004F60:
                        RingNameString = "Deep Ring";
                        break;
                    case 0x0004F6A:
                        RingNameString = "Darkmoon Ring";
                        break;
                    case 0x0004F74:
                        RingNameString = "Ring of the Sun's Firstborn";
                        break;
                    case 0x0004F88:
                        RingNameString = "Leo Ring";
                        break;
                    case 0x0004F92:
                        RingNameString = "Hawk Ring";
                        break;
                    case 0x0004F9C:
                        RingNameString = "Hornet Ring";
                        break;
                    case 0x0004FA6:
                        RingNameString = "Covetous Gold Serpent Ring";
                        break;
                    case 0x0004FA7:
                        RingNameString = "Covetous Gold Serpent Ring+1";
                        break;
                    case 0x0004FA8:
                        RingNameString = "Covetous Gold Serpent Ring+2";
                        break;
                    case 0x0004FB0:
                        RingNameString = "Covetous Silver Serpent Ring";
                        break;
                    case 0x0004FB1:
                        RingNameString = "Covetous Silver Serpent Ring+1";
                        break;
                    case 0x0004FB2:
                        RingNameString = "Covetous Silver Serpent Ring+2";
                        break;
                    case 0x0004FBA:
                        RingNameString = "Sun Princess Ring";
                        break;
                    case 0x0004FC4:
                        RingNameString = "Silvercat Ring";
                        break;
                    case 0x0004FCE:
                        RingNameString = "Skull Ring";
                        break;
                    case 0x0004FD8:
                        RingNameString = "Untrue White Ring";
                        break;
                    case 0x0004FE2:
                        RingNameString = "Carthus Milkring";
                        break;
                    case 0x0004FEC:
                        RingNameString = "Knight's Ring";
                        break;
                    case 0x0004FF6:
                        RingNameString = "Hunter's Ring";
                        break;
                    case 0x0005000:
                        RingNameString = "Knight Slayer's Ring";
                        break;
                    case 0x000500A:
                        RingNameString = "Magic Clutch Ring";
                        break;
                    case 0x0005014:
                        RingNameString = "Lightning Clutch Ring";
                        break;
                    case 0x000501E:
                        RingNameString = "Fire Clutch Ring";
                        break;
                    case 0x0005028:
                        RingNameString = "Dark Clutch Ring";
                        break;
                    case 0x000503C:
                        RingNameString = "Flynn's Ring";
                        break;
                    case 0x0005046:
                        RingNameString = "Prisoner's Chain";
                        break;
                    case 0x0005050:
                        RingNameString = "Untrue Dark Ring";
                        break;
                    case 0x0005064:
                        RingNameString = "Obscuring Ring";
                        break;
                    case 0x000506E:
                        RingNameString = "Ring of the Evil Eye";
                        break;
                    case 0x000506F:
                        RingNameString = "Ring of the Evil Eye+1";
                        break;
                    case 0x0005070:
                        RingNameString = "Ring of the Evil Eye+2";
                        break;
                    case 0x0005078:
                        RingNameString = "Calamity Ring";
                        break;
                    case 0x0005082:
                        RingNameString = "Farron Ring";
                        break;
                    case 0x000508C:
                        RingNameString = "Aldrich's Ruby";
                        break;
                    case 0x0005096:
                        RingNameString = "Aldrich's Sapphire";
                        break;
                    case 0x00050B4:
                        RingNameString = "Lloyd's Sword Ring";
                        break;
                    case 0x00050BE:
                        RingNameString = "Lloyd's Shield Ring";
                        break;
                    case 0x00050DC:
                        RingNameString = "Estus Ring";
                        break;
                    case 0x00050E6:
                        RingNameString = "Ashen Estus Ring";
                        break;
                    case 0x00050F0:
                        RingNameString = "Horsehoof Ring";
                        break;
                    case 0x00050FA:
                        RingNameString = "Carthus Bloodring";
                        break;
                    case 0x0005104:
                        RingNameString = "Reversal Ring";
                        break;
                    case 0x000510E:
                        RingNameString = "Pontiff's Right Eye";
                        break;
                    case 0x0005136:
                        RingNameString = "Pontiff's Left Eye";
                        break;
                    case 0x000515E:
                        RingNameString = "Dragonscale Ring";
                        break;
                    case 0x0005208:
                        RingNameString = "Chillbite Ring";
                        break;
                    case 0x0004E2D:
                        RingNameString = "Chloranthy Ring +3";
                        break;
                    case 0x0004E37:
                        RingNameString = "Havel's ring +3";
                        break;
                    case 0x0004E41:
                        RingNameString = "Ring of Favor +3";
                        break;
                    case 0x0004E4B:
                        RingNameString = "Ring of Steel Protection +3";
                        break;
                    case 0x0004EE1:
                        RingNameString = "Wolf Ring +3";
                        break;
                    case 0x0004FA9:
                        RingNameString = "Covetous Gold Serpent Ring +3";
                        break;
                    case 0x0004FB3:
                        RingNameString = "Covetous Silver Serpent Ring +3";
                        break;
                    case 0x0005071:
                        RingNameString = "Ring of the Evil Eye +3";
                        break;
                    case 0x00DE2B0:
                        RingNameString = "CutContentRing";
                        break;
                }

                RingNameString = RingNameString;

                return RingNameString;
            }
    
    }
}
