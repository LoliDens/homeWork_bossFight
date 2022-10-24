using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_bossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSwordStrike = "1";
            const string CommandBloodExplosion = "2";
            const string CommandWarriors = "3";
            const string CommandLevelUpSword = "4";
            const string CommandHealing = "5";

            const string CommandCreateWarriorWichSword = "1";
            const string CommandCreateWarriorWichBow = "2";
            const string CommandCreateWarriorWichShieald = "3";

            int hpPalyer = 100;
            int dameagSword = 12;
            int damaegBlood = 10;
            int countBlood = 0;
            int levelSword = 1;
            int powerBleeding = 0;
            int priseLevelUpSword = 2;
            int poverHeal = 10;

            int scaleHpWarriorWichSword = 1;
            int scaleDamageWarriorWichSword = 1;
            int scaleHpWarriorWhichBow = 1;
            int scaleDamageWarriorWichBow = 4;
            int scaleHpWarriorWichShieald = 10;
            int scaleDamageWarriorWhichShieald = 1; 

            int hpWarriorWichSword = 0;
            int damageWarriorWichSword = 0;
            int hpWarriorWichBow = 0;
            int damageWarriorWichBow = 0;
            int hpWarriorWichShieald = 0;
            int damageWarriorWichShieald = 0;

            int hpBoss = 1000;
            string nameBoss = "NightKing";
            int damageBoss = 5;

            bool gameOver = false;
            bool isUsedMove = false;

            string userInput;
            int useBlood = 0;
            int criticalLevel = 0;
            int levelUpSwordCost = 3;
            int minimulPriseCast = 1;
            int minimulBleeding = 0;

            Console.WriteLine($"Попав в тронный зал, вы видите {nameBoss}");

            while (hpBoss > criticalLevel && hpPalyer > criticalLevel)
            {
                isUsedMove = false;
                Console.WriteLine($"Хп игрока - {hpPalyer}" +
                    $"\nУровень меча - {levelSword}" +
                    $"\nКоличество крови - {countBlood}");

                if (hpWarriorWichSword > criticalLevel) Console.WriteLine($"Хп мечника - {hpWarriorWichSword}\nУрон мечника - {damageWarriorWichSword}");

                if (hpWarriorWichShieald > criticalLevel) Console.WriteLine($"Хп защитника - {hpWarriorWichShieald}\nУрон защитника - {damageWarriorWichShieald}");

                if (hpWarriorWichBow > criticalLevel) Console.WriteLine($"Хп мечника - {hpWarriorWichBow}\nУрон мечника - {damageWarriorWichBow}");

                Console.WriteLine($"Хп {nameBoss} - {hpBoss}");

                if (powerBleeding > 0) Console.WriteLine($"У {nameBoss} кровотичение действует на {powerBleeding} ход(-ов) ");

                while (isUsedMove == false)
                {
                    Console.WriteLine($"Что вы хотите сделать" +
                        $"\n {CommandSwordStrike} - чтобы сделать удар мечом" +
                        $"\n {CommandBloodExplosion} - что бы вызвать заклинание взрыв крови" +
                        $"\n {CommandWarriors} - чтобы призвать или улучшить своих воинов" +
                        $"\n {CommandLevelUpSword} - чтобы улучшить свой меч" +
                        $"\n {CommandHealing} - чтобы исцилиться");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandSwordStrike: 
                            Console.WriteLine($"Взмахнув мечем вы ударяете по {nameBoss}, нанося {dameagSword * levelSword} урона и вызываете у него кровотичение");
                            hpBoss -= dameagSword * levelSword;
                            countBlood += levelSword;
                            powerBleeding ++;
                            powerBleeding += levelSword;
                            isUsedMove = true;
                            break;

                        case CommandBloodExplosion: 
                            Console.Write("Сколько крови вы хотите искользовать: ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < minimulPriseCast || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение");
                            }
                            else
                            {
                                Console.WriteLine($"Вы взрывете кровь {nameBoss} нанося ему {useBlood * damaegBlood * powerBleeding} урона.\nКрвотечение у {nameBoss} остановлено ");
                                hpBoss -= useBlood * damaegBlood * powerBleeding;
                                powerBleeding = 0;
                                countBlood -= useBlood;
                                isUsedMove = true;
                            }
                            break;

                        case CommandWarriors: 
                            Console.WriteLine("В кого вы хотите влить кровь?" +
                                $"\n{CommandCreateWarriorWichSword} - Воин" +
                                $"\n{CommandCreateWarriorWichBow} - Лучник" +
                                $"\n{CommandCreateWarriorWichShieald} - Защитник");
                            userInput = Console.ReadLine();
                            Console.Write("Сколько крови влить :");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < minimulPriseCast || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение");
                            }
                            else
                            {
                                countBlood -= useBlood;

                                switch (userInput)
                                {
                                    case CommandCreateWarriorWichSword:
                                        if (hpWarriorWichSword <= criticalLevel)
                                        {
                                            Console.WriteLine($"Создан Воин с {useBlood * scaleHpWarriorWichSword} хп и {useBlood * scaleDamageWarriorWichSword} уроном");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Воин был улучшин, теперь у него {hpWarriorWichSword + useBlood * scaleHpWarriorWichSword} хп и {damageWarriorWichSword + useBlood * scaleDamageWarriorWichSword} урона ");
                                        }

                                        hpWarriorWichSword += useBlood * scaleHpWarriorWichSword;
                                        damageWarriorWichSword += useBlood * scaleDamageWarriorWichSword;
                                        break;

                                    case CommandCreateWarriorWichBow:
                                        if (hpWarriorWichBow <= criticalLevel)
                                        {
                                            Console.WriteLine($"Создан Лучник с {useBlood * scaleHpWarriorWhichBow} хп и {useBlood * scaleDamageWarriorWichBow} уроном");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Лучник был улучшин, теперь у него {hpWarriorWichBow + useBlood * scaleHpWarriorWhichBow} хп и {damageWarriorWichBow + useBlood * scaleDamageWarriorWichBow} урона ");
                                        }

                                        hpWarriorWichBow += useBlood * scaleHpWarriorWhichBow;
                                        damageWarriorWichBow += useBlood * scaleDamageWarriorWichBow;
                                        break;

                                    case CommandCreateWarriorWichShieald:
                                        if (hpWarriorWichShieald <= criticalLevel)
                                        {
                                            Console.WriteLine($"Создан Защитник с {useBlood * scaleHpWarriorWichShieald} хп и {useBlood * scaleDamageWarriorWhichShieald} уроном");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Лучник был улучшин, теперь у него {hpWarriorWichShieald + useBlood * scaleHpWarriorWichShieald} хп и {damageWarriorWichShieald + useBlood * scaleDamageWarriorWhichShieald} урона ");
                                        }

                                        hpWarriorWichShieald += useBlood * scaleHpWarriorWichShieald;
                                        damageWarriorWichShieald += useBlood * scaleDamageWarriorWhichShieald;
                                        break;
                                }

                                isUsedMove = true;
                            }
                            break;

                        case CommandLevelUpSword:
                            Console.Write("Сколько крови вы хотите влить в меч ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < levelUpSwordCost || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение или недостаточно крови");
                            }
                            else
                            {
                                levelSword = useBlood / priseLevelUpSword;
                                countBlood = useBlood % priseLevelUpSword;
                                Console.WriteLine($"Вы улучшили свой меч. Теперть он {levelSword} уровня");
                                isUsedMove = true;
                            }
                            break;

                        case CommandHealing:
                            Console.Write("Сколько крови вы хотите влить в себя ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < minimulPriseCast || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение или недостаточно крови");
                            }
                            else
                            {
                                hpPalyer += useBlood * poverHeal;
                                countBlood -= useBlood;
                                isUsedMove = true;
                            }
                            break;

                        default:
                            Console.WriteLine("Ошибка ввода");
                            break;
                    }
                }

                if (powerBleeding > minimulBleeding ) powerBleeding--;

                if (hpWarriorWichSword > criticalLevel)
                {
                    hpBoss -= damageWarriorWichSword;
                    powerBleeding += damageWarriorWichSword;
                    countBlood++;
                    Console.WriteLine($"Вион наносит {nameBoss} {damageWarriorWichSword} урона, изымая у него кровь и продлевает кровотичение до {powerBleeding}");
                }

                if (hpWarriorWichBow > criticalLevel)
                {
                    hpBoss -= damageWarriorWichBow;
                    Console.WriteLine($"Лучник наносит {nameBoss} {damageWarriorWichBow} урона");
                }

                if (hpWarriorWichShieald > criticalLevel) 
                {
                    hpBoss -= damageWarriorWichShieald;
                    Console.WriteLine($"Защитник наносит {nameBoss} {damageWarriorWichShieald}");
                }

                if (hpWarriorWichShieald > criticalLevel)
                {
                    hpWarriorWichShieald -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит защитнику {damageBoss} урона");

                    if (hpWarriorWichShieald <= criticalLevel)
                    {
                        hpWarriorWichShieald = 0;
                        damageWarriorWichShieald = 0;
                        Console.WriteLine($"Защитник пал от рук {nameBoss}");
                    }
                }
                else if (hpWarriorWichSword > criticalLevel)
                {
                    hpWarriorWichSword -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит мечнику {damageBoss} урона");

                    if (hpWarriorWichSword <= criticalLevel)
                    {
                        hpWarriorWichSword = 0;
                        damageWarriorWichSword = 0;
                        Console.WriteLine($"Мечник пал от рук {nameBoss}");
                    }
                }
                else if (hpWarriorWichBow > criticalLevel) 
                {
                    hpWarriorWichBow -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит лучнику {damageBoss} урона");

                    if (hpWarriorWichBow <= criticalLevel)
                    {
                        hpWarriorWichBow = 0;
                        damageWarriorWichBow = 0;
                        Console.WriteLine($"Лучник пал от рук {nameBoss}");
                    }
                }
                else 
                {
                    hpPalyer -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит вам {damageBoss} урона");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            if (hpPalyer <= criticalLevel)
            {
                Console.WriteLine($"{nameBoss} победил вас");
            }
            else if (hpBoss <= criticalLevel)
            {
                Console.WriteLine($"Вы победили {nameBoss}");
            }
            else if (hpBoss == criticalLevel && hpPalyer == criticalLevel) 
            {
                Console.WriteLine("Битва была легендарной, но оба война пали");
            }

            Console.ReadKey();
        }
    }
}
