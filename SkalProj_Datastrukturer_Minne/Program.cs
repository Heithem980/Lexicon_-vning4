namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            /*
                 Övning 1: ExamineList()

              2. När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
                 S: När antal Element överstiger max kapaciteten.


              3. Med hur mycket ökar kapaciteten?
                 S: Med dubbla kappaciteten.


              4. Varför ökar inte listans kapacitet i samma takt som element läggs till ?
                 S: Eftersom det skapas en ny större array varje gång antal element överstiger kapaciteten. Ökningen görs för att 
                    optimera prestanda och minska antalet minnesallokeringar. 


              5. Minskar kapaciteten när element tas bort ur listan?
                 S: Nej.

              6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista ?
                 S: När man vet antalet element som man ska placera i Array. 
            */

            bool run = true;
            List<string> theList = new List<string>();

            while (run)
            {

                Console.WriteLine("Enter text to add or remove words from the list by putting (+/-) before the word. Enter '0' to exit ExamineList \n ");
                string input = Console.ReadLine()!;

                char nav = input[0];

                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"{value} was added to the list.  \n Count:{theList.Count} Capacity: {theList.Capacity} ");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"{value} was removed from the list.  \n Count:{theList.Count} Capacity: {theList.Capacity} ");
                        break;
                    case '0':

                        run = false;
                        break;

                    default:
                        Console.WriteLine("Please enter only (+/-).    Enter '0' to exit ExamineList");
                        break;

                }



            }



        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            bool run = true;

            Queue<string> queue = new Queue<string>();
            Console.WriteLine("To enqueue, use '+Text' .  \n To dequeue, just enter '-' . Enter '0' to exit ExamineList ");

            while (run)
            {

                string input = Console.ReadLine()!;

                char nav = input[0];

                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':

                        queue.Enqueue(value);

                        ShowQueue(queue);
                        break;
                    case '-':

                        queue.Dequeue();
                        ShowQueue(queue);
                        break;
                    case '0':
                        queue.Clear();
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Please enter only (+/-).    Enter '0' to exit ExamineList");
                        break;

                }


            }

        }

        private static void ShowQueue(Queue<string> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }



        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             * 
             * Övning 3
              
               1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det inte så smart att använda 
                  en stack i det här fallet?

                  S: Eftersom i en Kö gäller Först in Först ut, FILO principen är orelevant i detta sammanhanget.
            */

            Stack<string> stack = new Stack<string>();
            Stack<char> reverseText = new Stack<char>();

            bool run = true;



            while (run)
            {
                Console.WriteLine("Enter +/- to push or pop. Enter 'r' to reverse text. (Enter '0' to Exit to main menu.)");
                string input = Console.ReadLine()!;

                char nav = input[0];


                switch (nav)
                {
                    case '+':
                        Console.WriteLine("Add text to push: ");
                        input = Console.ReadLine()!;

                        stack.Push(input);
                        ViewStack(stack);

                        break;
                    case '-':
                        stack.Pop();
                        ViewStack(stack);

                        break;
                    case 'r':
                        Console.WriteLine("Add text to reverse: ");

                        input = Console.ReadLine()!;

                        ReverseText(input, reverseText);


                        break;

                    case '0':
                        stack.Clear();
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Please enter only (+/-).    Enter '0' to exit ExamineList");
                        break;

                }







                //run = false;
            }


        }

        private static void ReverseText(string input, Stack<char> reverseText)
        {

            foreach (char character in input)
            {
                reverseText.Push(character);
            }

            while (reverseText.Count > 0)
            {
                char x = reverseText.Pop();
                Console.Write(x);
            }

            Console.Write("\n");

        }



        private static void ViewStack(Stack<string> stack)
        {
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.WriteLine("Enter a string to check for well-formed parentheses:");
            string input = Console.ReadLine()!;

            if (IsValid(input))
            {
                Console.WriteLine("The string is well-formed.");
            }
            else
            {
                Console.WriteLine("The string is not well-formed.");
            }
        }

        static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0) return false;

                    char openBracket = stack.Pop();

                    if (!IsMatchingPair(openBracket, c)) return false;

                }
            }
            return stack.Count == 0;
        }

        static bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }

    }
}

//  1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.

//     Stacken: Används för lokala variabler och funktionsanrop, hanterar minne automatiskt.
//     Heapen:  Används för dynamisk minnesallokering, kräver manuell hantering av minnet, och kan hantera minne som
//     behövs under längre tid.


//  2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

//     Reference Types är typer som ärver från System.Object ex. Class, Interface och String. Dessa lagras endast på Heapen.
//     Value Types som Int, bool, enum och float lagras där det deklareras, vilket innebär att de kan lagras både på Stacken och Heapen.


//  3. Följande metoder(se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?

//     I den första så tildelas värden till x och y, den andra är både x och y en referens till samma värde som är sparat på heapen.
//     