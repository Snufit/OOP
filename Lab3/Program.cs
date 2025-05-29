using FuelManagement;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс Программа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main.
        /// </summary>
        internal static void Main()
        {
            bool workProgram = true;

            while (workProgram)
            {
                Console.WriteLine("\n1 - Выполнить расчет расхода топлива" +
               "\n2 - Выйти");

                char readProgram = Console.ReadKey().KeyChar;

                switch (readProgram)
                {
                    case '1':
                        {
                            TransportBase transport = ConsoleTransport.SelectTransport();
                            ConsoleTransport.СalculateСonsumptionFuel(transport);
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine("\nПрограмма завершена");
                            workProgram = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nНекорректный ввод. Попробуйте еще раз");
                            break;
                        }
                }
            }
        }
    }
}
