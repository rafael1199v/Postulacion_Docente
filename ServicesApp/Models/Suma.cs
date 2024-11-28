public class Matematica
{
    public static int Sumar(int a, int b)
    {
        return a + b;
    }

    public static int SumarNumerosNaturales(int a, int b)
    {
        if(a <= 0 || b <= 0)
        {
            return 0;
        }

        return a + b;
    }
}