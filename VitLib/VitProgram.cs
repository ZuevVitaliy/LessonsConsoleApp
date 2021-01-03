using Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Tv
    {
        private int mCurrentChannel;

        public int CurrentChannel
        {
            get => mCurrentChannel;
            set
            {
                if (!IsSwitchedOn) return;

                mCurrentChannel = value;
            }
        }

        public bool IsSwitchedOn { get; private set; }

        public Tv() { }

        public Tv(int startChannel)
        {
            CurrentChannel = startChannel;
        }

        public void Switch()
        {
            IsSwitchedOn = !IsSwitchedOn;
        }

        public void PreviousChannel()
        {
            CurrentChannel--;
            if (CurrentChannel < 0)
            {
                CurrentChannel = 99;
            }
        }

        public void NextChannel()
        {
            CurrentChannel++;
            if (CurrentChannel > 99)
            {
                CurrentChannel = 0;
            }
        }

        public void ToChannel(int channel)
        {
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
    }

    public class VitProgram
    {
        private static readonly string cFileName = "D:\\ChanellFile.txt";

        static void Main()
        {

        }

        public static void Start()
        {
            int savedChannel = GetChannelFromFile(cFileName);
            var myTV = new Tv(savedChannel);
            while (true)
            {
                Console.Clear();
                if (!myTV.IsSwitchedOn)
                {
                    Console.WriteLine("Телевизор выключен \nesc- включить телевизор");
                    var inputKey = Console.ReadKey().Key;
                    switch (inputKey)
                    {
                        case ConsoleKey.Escape:
                            myTV.Switch();
                            break;
                        default:
                            ShowError();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Канал: " + myTV.CurrentChannel);
                    Console.WriteLine("Выберите опцию: \n1- предыдущий канал; \n2- следующий канал; \n3- ввод номера канала; \nesc- выключить телевизор");
                    var inputKey = Console.ReadKey().Key;
                    switch (inputKey)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            myTV.PreviousChannel();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            myTV.NextChannel();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.WriteLine("\nВведите номер канала:");
                            string str = Console.ReadLine();
                            if (!string.IsNullOrEmpty(str) && str.All(x => x.IsDigit()))
                            {
                                int channel = Convert.ToInt32(str);
                                myTV.ToChannel(channel);
                            }
                            else
                            {
                                ShowError();
                            }
                            break;
                        case ConsoleKey.Escape:
                            myTV.Switch();
                            break;
                        default:
                            ShowError();
                            break;

                    }
                }
            }
        }

        private static void ShowError()
        {
            Console.Beep();
            Console.WriteLine("\nОшибка! Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        private static int GetChannelFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string val = reader.ReadToEnd();
            if (string.IsNullOrEmpty(val))
                return default;

            return val.All(x => x.IsDigit()) ? Convert.ToInt32(val) : default;
        }
    }
}
