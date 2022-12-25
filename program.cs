  static ref T[] Resize<T>(ref T[] anyArr, int qtyElm)
        {
            T[] newArr = new T[qtyElm];

            for (int i = 0; i < anyArr.Length && i < newArr.Length; i++)
                newArr[i] = anyArr[i];

            anyArr = newArr;

            return ref anyArr;
        }

        static void RandomizerValueOfArraysElements(int[] anyArr)
        {
            Random randomizer = new Random();

            for (int i = 0; i < anyArr.Length; i++)
            {
                anyArr[i] = randomizer.Next(10, 100);
            }
        }

        static ref T[] AddFirstElement<T>(ref T[] anyArr, T value)
        {
            T[] newArr = new T[anyArr.Length + 1];

            newArr[0] = value;

            for (int i = 0; i < newArr.Length - 1; i++)
            {
                newArr[i + 1] = anyArr[i];
            }

            anyArr = newArr;

            return ref anyArr;
        }

        static ref T[] AddLastElement<T>(ref T[] anyArr, T value)
        {
            T[] newArr = new T[anyArr.Length + 1];

            newArr[anyArr.Length] = value;

            for (int i = 0; i < newArr.Length - 1; i++)
            {
                newArr[i] = anyArr[i];
            }

            anyArr = newArr;

            return ref anyArr;
        }

        static ref T[] AddElementByIndex<T>(ref T[] anyArr, T value, int index)
        {
            T[] newArr = new T[anyArr.Length + 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                if (i < index)
                {
                    newArr[i] = anyArr[i];
                }
                else if (i == index)
                {
                    newArr[index] = value;
                }
                else
                {
                    newArr[i] = anyArr[i - 1];
                }
            }

            anyArr = newArr;

            return ref anyArr;
        }
        
        static ref T[] RemoveFirstElement<T>(ref T[] anyArr)
        {
            T[] newArr = new T[anyArr.Length - 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = anyArr[i + 1];
            }

            anyArr = newArr;

            return ref anyArr;
        }

        static ref T[] RemoveLastElement<T>(ref T[] anyArr)
        {
            T[] newArr = new T[anyArr.Length - 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = anyArr[i];
            }

            anyArr = newArr;

            return ref anyArr;
        }

        static ref T[] RemoveElementByIndex<T>(ref T[] anyArr, int index)
        {
            T[] newArr = new T[anyArr.Length - 1];

            for (int i = 0; i < newArr.Length && i < index; i++)
            {
                newArr[i] = anyArr[i];
            }
            for (int i = index; i < newArr.Length; i++)
            {
                newArr[i] = anyArr[i + 1];
            }

            anyArr = newArr;

            return ref anyArr;
        }

        static void Main(string[] args)
        {
            bool mainMenu = true;
            int[] myArr = new int[0];

            while (mainMenu == true)
            {
                Console.Clear();
                Console.WriteLine("------------   WELCOME   ------------");
                Console.WriteLine($"Your current Array has {myArr.Length} Elements");
                for (int i = 0; i < myArr.Length; i++)
                    Console.WriteLine($"Element {i + 1}: {myArr[i]}");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("------------   MENU   ------------");
                Console.WriteLine("-Press 1 - Create or Resize Array");
                Console.WriteLine("-Press 2 - Randomizer of value your Array's Elements");
                Console.WriteLine("-Press 3 - Add ONE Array's Element");
                Console.WriteLine("-Press 4 - Remove ONE Array's Element");
                Console.WriteLine("--- Press Any Button to EXITE ---");

                ConsoleKey navigator = Console.ReadKey().Key;

                switch (navigator)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            Console.WriteLine("How much Array's size do you want?");
                            int newQty = int.Parse(Console.ReadLine());

                            Resize(ref myArr, newQty);

                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            RandomizerValueOfArraysElements(myArr);

                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            bool newElm = true;

                            int value;

                            while (newElm == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Now your Array has {myArr.Length} Elements");
                                for (int i = 0; i < myArr.Length; i++)
                                    Console.WriteLine($"Element {i + 1}: {myArr[i]}");

                                Console.WriteLine();
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine("-Add first element - press 1\n-Add last element - press 2\n-Add element by your index request - press 3\n--- Press Any Button to BACK MAIN MENU ---");

                                navigator = Console.ReadKey().Key;

                                Console.Clear();

                                switch (navigator)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        {
                                            Console.Write("Add new first element: ");
                                            value = int.Parse(Console.ReadLine());

                                            AddFirstElement(ref myArr, value);

                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            Console.Write("Add new last element: ");
                                            value = int.Parse(Console.ReadLine());

                                            AddLastElement(ref myArr, value);

                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            Console.Write($"By which index do you want to add Element {0} - {myArr.Length}: ");
                                            int index = int.Parse(Console.ReadLine());
                                            Console.Clear();

                                            if (index > myArr.Length)
                                            {
                                                Console.Write("Error - Out of Array's bounds! Any button to continue");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.Write($"Add element by index {index}: ");
                                                value = int.Parse(Console.ReadLine());

                                                AddElementByIndex(ref myArr, value, index);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            newElm = false;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        {
                            bool newElm = true;

                            if (myArr.Length == 0)
                            {
                                Console.Clear();
                                Console.Write("No elements to remove");
                                Console.ReadKey();
                                newElm = false;
                            }

                            while (newElm == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Now your Array has {myArr.Length} Elements");
                                for (int i = 0; i < myArr.Length; i++)
                                    Console.WriteLine($"Element {i + 1}: {myArr[i]}");

                                Console.WriteLine();
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine("-Remove first element - press 1\n-Remove last element - press 2\n-Remove element by your index request - press 3\n--- Press Any Button to BACK MAIN MENU ---");

                                navigator = Console.ReadKey().Key;

                                Console.Clear();

                                switch (navigator)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        {
                                            RemoveFirstElement(ref myArr);
                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            RemoveLastElement(ref myArr);
                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            Console.Write($"By which index do you want to add Element {0} - {myArr.Length}: ");
                                            int index = int.Parse(Console.ReadLine());

                                            if (index > myArr.Length)
                                            {
                                                Console.Write("Error - Out of Array's bounds! Any button to continue");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                RemoveElementByIndex(ref myArr, index);
                                            }
                                            
                                            break;
                                        }
                                    default:
                                        {
                                            newElm = false;
                                            break;
                                        }
                                }
                                if (myArr.Length == 0)
                                {
                                    Console.Clear();
                                    Console.Write("No elements to remove");
                                    Console.ReadKey();

                                    newElm = false;
                                }
                            }
                            break;
                        }
                    default:
                        {
                            mainMenu = false;
                            break;
                        }
                }
            }
        }
