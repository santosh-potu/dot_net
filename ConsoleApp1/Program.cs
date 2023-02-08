
class Program
{
    public static void Main(String[] args)
    {
       
        
        System.Console.WriteLine("Please enter a String");
        String input = Console.ReadLine();
        char[] chars = input.ToCharArray();

        for(int i=0,j=input.Length-1;i<input.Length;i++,j--)
        {
            System.Console.WriteLine(chars[i] + "------" + chars[j]);
            if(chars[i] != chars[j])
            {
                Console.WriteLine("Not polindrome");
                return;
            }
        }
        System.Console.WriteLine("Polyndrome");
        /* System.Console.WriteLine(IsPrime(Convert.ToInt32(input)) == true ? "GIven is prime" : "Not Prime");*/

    }

    /*
     * Is prime or not
     * Returns true/false
     */
    public static bool IsPrime(int n)
    {
        if(n < 2) return false;
        for (int i = 2; i < n / 2; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

