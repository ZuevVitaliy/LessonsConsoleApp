using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp
{
    public class TV
    {
        private int mVolume;

        public int Volume
        {
            get => mVolume;
            set
            {
                if (value < 0)
                {
                    mVolume = 0;
                }
                else if (value > 100)
                {
                    mVolume = 100;
                }
                else
                {
                    mVolume = value;
                }
            }
        }

        public int CurrentChannel { get; set; }
        public bool SwitchedOn { get; set; }

        public void Switch()
        {
            SwitchedOn = !SwitchedOn;
        }

        public void PreviousChannel()
        {
            if (!SwitchedOn)
                return;

            CurrentChannel -= 1;
            if (CurrentChannel < 0)
            {
                CurrentChannel = 99;
            }
        }

        public void NextChannel()
        {
            if (!SwitchedOn)
                return;
            CurrentChannel += 1;
            if (CurrentChannel > 99)
            {
                CurrentChannel = 0;
            }
        }

        public void ToChannel(int channel)
        {
            if (!SwitchedOn)
                return;
            CurrentChannel = channel;
            if (CurrentChannel < 0)
            {
                CurrentChannel = 0;
            }
            else if (CurrentChannel > 99)
            {
                CurrentChannel = 99;
            }
        }

        public void AddVolume()
        {
            Volume++;
        }

        public void AddVolume(int value)
        {
            Volume += value;
        }

        public static void MyTVProgram()
        {
            TV myTv = new TV();
            do
            {
                Console.Clear();
                if (!myTv.SwitchedOn)
                {
                    Console.WriteLine("Включите телевизор, чтобы включить, нажмите любую клавишу");
                    Console.ReadKey();
                    Console.WriteLine();
                    myTv.Switch();
                }
                else
                {
                    Console.WriteLine("Канал: " + myTv.CurrentChannel);
                    Console.WriteLine("Громкость: " + myTv.Volume);
                    Console.WriteLine(
                        "Выберите опцию: \n" +
                        "<- - предыдущий канал; \n" +
                        "-> - следующий канал; \n" +
                        "Tab - ввод номера канала \n" +
                        "^ - увеличить громкость \n" +
                        "v - уменьшить громкость \n" +
                        "Esc - выключите телевизор ");
                    var inputKey = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (inputKey)
                    {
                        case ConsoleKey.LeftArrow:
                            myTv.PreviousChannel();
                            break;
                        case ConsoleKey.RightArrow:
                            myTv.NextChannel();
                            break;
                        case ConsoleKey.UpArrow:
                            myTv.AddVolume(5);
                            break;
                        case ConsoleKey.DownArrow:
                            myTv.AddVolume(-5);
                            break;
                        case ConsoleKey.Tab:
                            Console.WriteLine("Введите номер канала:");
                            string str = Console.ReadLine();
                            Console.WriteLine();
                            if (Program.CheckForDigit(str))
                            {
                                int channel = Convert.ToInt32(str);
                                myTv.ToChannel(channel);
                            }
                            else Console.WriteLine("Error!");

                            Console.ReadKey();
                            Console.WriteLine();
                            break;
                        case ConsoleKey.Escape:
                            myTv.Switch();
                            break;
                        default:
                            Console.WriteLine("Error!");
                            Console.ReadKey();
                            Console.WriteLine();
                            break;
                    }
                }
            } while (true);
        }
    }
}
