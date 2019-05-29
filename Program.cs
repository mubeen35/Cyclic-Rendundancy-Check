using System;


namespace CRC
{
    class Program
    {


        static void Main(string[] args)
        {
            int iterator = 1, dividendLength = 0,error_length = 0, divisorLength = 0, iterations = 0, appendingBits = 0, errorbit = 0, k = 0;
            Boolean status = false;  
            Random random = new Random();

            Console.WriteLine("Enter the 'Dividend' length.");
            dividendLength = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the 'Divisor' length.");
            divisorLength = Convert.ToInt32(Console.ReadLine());

           Console.WriteLine("Enter the 'Error Bits' length.");
            errorbit = Convert.ToInt32(Console.ReadLine());

            int[] dividend = new int[dividendLength + divisorLength];
            int[] divisor = new int[divisorLength];
            int[] rem = new int[dividendLength + divisorLength];

            for (int i = 0; i < dividendLength; i++)
                dividend[i] = (((random.Next() % 2) == 0) ? 0 : 1);

            

            for (int i = 0; i < divisorLength; i++)
                 divisor[i] = (((random.Next() % 2) == 0) ? 0 : 1);
            

            

            for (int i = 0; i < divisorLength; i++)
                rem[i] = dividend[i];

            try
            {
      if ((dividendLength < divisorLength) && (divisorLength == 0) && (dividendLength == 0))
                {
                    Console.WriteLine("'Dividend' cnanot be less than 'Divisor' and neither divisor can be '0' nordividend can be '0'");
                }
                else
                {
                    int count = dividendLength;
                    appendingBits = divisorLength - 1;

                    while (appendingBits != 0)
                    {

                        dividend[count++] = 0;

                        appendingBits--;
                    }
                    Console.WriteLine("Intial data:");
                    for (int i = 0; i < dividendLength; i++)
                    { Console.Write(dividend[i]); }

                    Console.WriteLine();

                    Console.WriteLine("Appending Bits:");
                    for (int i = dividendLength; i < dividendLength + divisorLength - 1; i++)
                    { Console.Write(dividend[i]); }

                    Console.WriteLine();

                    Console.WriteLine("Enter the number of iteration's.");
                    iterations = Convert.ToInt32(Console.ReadLine());
                    int msb = 0;
                    while (iterations != 0)
                    {
                        Console.WriteLine("Iteration # " + iterator++);
                        Console.WriteLine();

                        for (int i = 0; i < dividendLength; i++)
                        {
                            k = 0;
                            msb = rem[i];

                            for (int j = i; j < divisorLength + i; j++)
                            {
                                if (msb == 0)
                                    rem[j] = Program.XOR(rem[j], 0);
                                else
                                    rem[j] = Program.XOR(rem[j], divisor[k]);

                                k++;
                            }

                            rem[divisorLength + i] = dividend[divisorLength + i];

                        }
                   
                        Console.Write("Reminder:");
                        for (int i = dividendLength; i < dividendLength + divisorLength - 1; i++)
                        {
                            dividend[i] = rem[i];

                            if (dividend[i] == 1)
                            {
                                status = true;
                                error_length++;
                            }

                            Console.Write(dividend[i]);
                        }

                        Console.WriteLine();

                        Console.Write("Data:");
                        for (int i = 0; i < dividendLength + (divisorLength - 1); i++)
                        { Console.Write(dividend[i]); }

                   
                        Console.WriteLine();
                        Console.WriteLine("Error Length :"+error_length);

                        error_length = 0;

                        if (status == true)
                            Console.WriteLine("FAIL");
                        else
                            Console.WriteLine("PASS");

                        status = false;
                       
                        Console.WriteLine();
                        Console.WriteLine();

                        for (int i = 0; i < errorbit; i++)
                            {

                                if (dividend[i] == 0)
                                    dividend[i] = 1;
                                else
                                    dividend[i] = 0;

                            }
                        
   

                        iterations--;
                    }

                }
            }
            catch (IndexOutOfRangeException e)
            { Console.WriteLine(e.ToString()); }
          
            Console.ReadKey();
        }


        private static int XOR(int f, int s)
        {
            if (f != s)
                return 1;


            return 0;
        }

      

    }
}
