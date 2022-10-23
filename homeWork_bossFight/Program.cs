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


            int scaleHpWarriorWichSword = 2;
            int scaleDamageWarriorWichSword = 2;
            int scaleHpWarriorWhichBow = 1;
            int scaleDamageWarriorWichBow = 4;
            int scaleHpWarriorWichShieald = 6;
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
            bool userUsedMove = false;

            string userInput;
            int useBlood = 0;

            Console.WriteLine($"Попав в тронный зал, вы видите {nameBoss}");

            while (hpBoss > 0 && hpPalyer > 0)
            {
                userUsedMove = false;
                Console.WriteLine($"Хп игрока - {hpPalyer}" +
                    $"\nУровень меча - {levelSword}" +
                    $"\nКоличество крови - {countBlood}");

                if (hpWarriorWichSword > 0) Console.WriteLine($"Хп мечника - {hpWarriorWichSword}\nУрон мечника - {damageWarriorWichSword}");

                if (hpWarriorWichShieald > 0) Console.WriteLine($"Хп защитника - {hpWarriorWichShieald}\nУрон защитника - {damageWarriorWichShieald}");

                if (hpWarriorWichBow > 0) Console.WriteLine($"Хп мечника - {hpWarriorWichBow}\nУрон мечника - {damageWarriorWichBow}");

                Console.WriteLine($"Хп {nameBoss} - {hpBoss}");

                if (powerBleeding > 0) Console.WriteLine($"У {nameBoss} кровотичение действует на {powerBleeding} ход(-ов) ");

                while (userUsedMove == false)
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
                            Console.ReadKey();
                            hpBoss -= dameagSword * levelSword;
                            countBlood += levelSword;
                            powerBleeding ++;
                            powerBleeding += levelSword;
                            userUsedMove = true;
                            break;

                        case CommandBloodExplosion: 
                            Console.Write("Сколько крови вы хотите искользовать: ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < 1 || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение");
                            }
                            else
                            {
                                Console.WriteLine($"Вы взрывете кровь {nameBoss} нанося ему {useBlood * damaegBlood * powerBleeding} урона.\nКрвотечение у {nameBoss} остановлено ");
                                hpBoss -= useBlood * damaegBlood * powerBleeding;
                                powerBleeding = 0;
                                countBlood -= useBlood;
                                userUsedMove = true;
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

                            if (useBlood < 1 || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение");
                            }
                            else
                            {
                                countBlood -= useBlood;

                                switch (userInput)
                                {
                                    case CommandCreateWarriorWichSword:
                                        if (hpWarriorWichSword == 0)
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
                                        if (hpWarriorWichBow == 0)
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
                                        if (hpWarriorWichShieald == 0)
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
                                userUsedMove = true;
                            }
                            break;

                        case CommandLevelUpSword:
                            Console.Write("Сколько крови вы хотите влить в меч ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < 3 || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение или недостаточно крови");
                            }
                            else
                            {
                                levelSword = useBlood / priseLevelUpSword;
                                countBlood = useBlood % priseLevelUpSword;
                                Console.WriteLine($"Вы улучшили свой меч. Теперть он {levelSword} уровня");
                                userUsedMove = true;
                            }
                            break;

                        case CommandHealing:
                            Console.Write("Сколько крови вы хотите влить в себя ");
                            useBlood = Convert.ToInt32(Console.ReadLine());

                            if (useBlood < 1 || useBlood > countBlood)
                            {
                                Console.WriteLine("Введино неверное значение или недостаточно крови");
                            }
                            else
                            {
                                hpPalyer += useBlood * poverHeal;
                                countBlood -= useBlood;
                                userUsedMove = true;
                            }
                            break;

                        default:
                            Console.WriteLine("Ошибка ввода");
                            break;
                    }
                }

                if (powerBleeding > 0 ) powerBleeding--;

                if (hpWarriorWichSword > 0)
                {
                    hpBoss -= damageWarriorWichSword;
                    powerBleeding += damageWarriorWichSword;
                    countBlood++;
                    Console.WriteLine($"Вион наносит {nameBoss} {damageWarriorWichSword} урона, изымая у него кровь и продлевает кровотичение до {powerBleeding}");
                }

                if (hpWarriorWichBow > 0)
                {
                    hpBoss -= damageWarriorWichBow;
                    Console.WriteLine($"Лучник наносит {nameBoss} {damageWarriorWichBow} урона");
                }

                if (hpWarriorWichShieald > 0) 
                {
                    hpBoss -= damageWarriorWichShieald;
                    Console.WriteLine($"Защитник наносит {nameBoss} {damageWarriorWichShieald}");
                }

                if (hpWarriorWichShieald > 0)
                {
                    hpWarriorWichShieald -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит защитнику {damageBoss} урона");
                }
                else if (hpWarriorWichSword > 0)
                {
                    hpWarriorWichSword -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит мечнику {damageBoss} урона");
                }
                else if (hpWarriorWichBow > 0) 
                {
                    hpWarriorWichBow -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит лучнику {damageBoss} урона");
                }
                else 
                {
                    hpPalyer -= damageBoss;
                    Console.WriteLine($"{nameBoss} наносит вам {damageBoss} урона");
                }

                Console.Clear();
            }


            
        }
    }
}
