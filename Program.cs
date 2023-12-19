using System.Data;
using System.Formats.Tar;

namespace MyProgram
{
    public class Program
    {
        /// <summary>
        /// Print Out The Array in Order
        /// </summary>
        /// <typeparam name="T">Generic Type (could be int, string)</typeparam>
        /// <param name="array">Array To Be Print</param>
        public static void PrintArray<T>(T[] array)
        {
            // Print out Every ELement in the Array
            Console.WriteLine("Property list: ");
            Console.Write("Value: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index] + "\t");
            }
            Console.WriteLine();

            // Print the Index Corresponding to the Element
            Console.Write("Index: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(index + "\t");
            }
            Console.WriteLine();
        }
        public static void Swap<T>(T[] array, int index1, int index2)
        {
            (array[index1], array[index2]) = (array[index2], array[index1]);
        }
        public static void InsertElement1<T>(T[] array, int index_to_insert, T element)
        {
            int temp_index = index_to_insert;

            // Change The Position of the Element in the Array by 1 for every element
            for (int index = index_to_insert + 1; index < array.Length; index++)
            {
                Swap<T>(array, index, temp_index);
            }

            // Insert At the index_to_insert
            array[index_to_insert] = element;
        }

        public static void InsertElement2<T>(T[] array, int index_to_insert, T element)
        {
            // Change The Position of the Element in the Array by 1 for every element
            for (int index = array.Length - 1; index > index_to_insert; index--)
            {
                array[index] = array[index - 1];
            }

            // Insert At the index_to_insert
            array[index_to_insert] = element;
        }

        public static void Main(string[] args)
        {
            // Creating an array to hold the value
            int[] array = new int[10];

            // Insert The Value
            array[0] = 10;
            array[1] = 4;
            array[2] = 6;
            array[3] = 7;
            array[4] = 8;
            array[5] = 10;
            array[6] = 13;
            array[7] = 78;
            array[8] = 101;
            array[9] = -9;

            // Print Out The Array
            PrintArray<int>(array);

            // Ask Element To Input
            int element;
        askElementInput:
            Console.Write("Value to input: ");
            bool isValid = Int32.TryParse(Console.ReadLine(), out element);
            if (!isValid)
            {
                Console.WriteLine("Size should not be a Character nor a Symbol!");
                goto askElementInput;
            }

            // Ask Index To Input
            bool hasInsert = false;
            int index_to_insert;
        askIndexInsert:
            Console.Write("Index to input to the array: ");
            isValid = Int32.TryParse(Console.ReadLine(), out index_to_insert);
            if (!isValid)
            {
                Console.WriteLine("Size should not be a Character nor a Symbol!");
                goto askIndexInsert;
            }
            else if (index_to_insert < 0)
            {
                Console.WriteLine("Cannot Insert at Negative Index!");
                goto askIndexInsert;
            }
            else if (index_to_insert >= array.Length - 1)
            {
                // If That Index is NOT the Last-Index
                if (index_to_insert != array.Length - 1)
                {
                    Console.WriteLine($"Maximum index to Insert is {array.Length - 1}");
                    goto askIndexInsert;
                }

                // IF That Index is the Last-Index
                // Check That Index is Default Value
                if (array[index_to_insert] == default(int))
                {
                    hasInsert = true;
                    array[index_to_insert] = element;
                }
                // IF Different Value
                else
                {
                    Console.WriteLine($"At Index {index_to_insert} currently have value {array[index_to_insert]!}");
                    Console.Write("Input a new ones?[y/n]: ");
                    string? ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        // Replace the New Value
                        hasInsert = true;
                        array[index_to_insert] = element;
                    }
                    else
                    {
                        // Ask Index To input Again
                        goto askIndexInsert;
                    }
                }
            }

            // 2 Approaches: InsertElement1 or InsertElement2
            // Insert a New Value
            if (!hasInsert)
            {
                InsertElement2<int>(array, index_to_insert, element);
            }

            // Print Out The Array
            PrintArray<int>(array);
        }
    }
}