namespace ConsoleApp2;

/*
 *
 * The algorithm is completely easy to understand
 * We have: the numbers of the start pin and the final pin
 * We need to get: the steps to move our pins
 * Temporary: number of the pin-helper (temporary storage)
 *                  1st call
 * For example:
 * Start pos = 1
 * End pos = 2
 * Pyramid's height (n) = 3
 *
 * small  -1     pin         pin
 * middle -2     pin         pin
 * big    -3     pin         pin
 * pin_1        pin_2       pin_3
 *
 * on each step we calculate the number of the pin-helper: number = 6 - pinFromWhichWeMove - pinToWhichWeMove = 6 - 1 - 2
 * for now helper = 3
 * then we move the pyramid with height 2 (n - 1) from the start pin = 1 to the helper pin = 3
 * here we use recursive call
 *
 *                  2nd call
 * 
 * now we have the pyramid:
 * from 1
 * to 3
 * 
 * small  -1     pin         pin
 * middle -2     pin         pin
 * pin_1        pin_2       pin_3
 *
 * use the same steps: (now n = 2)
 * pin-helper: number = 6 - pinFromWhichWeMove - pinToWhichWeMove = 6 - 1 - 3 = 2
 * move pyramid via recursive call
 * we move the pyramid with height 1 (n - 1) from the start pin = 1 to the helper pin = 2
 *
 *                  3rd call
 * 
 * small  -1     pin         pin
 * pin_1        pin_2       pin_3
 *
 * As you see, we now have only one disk left, that's why we can just move it from the starting position to the finish
 * In our case start = 1 and the finish = 2:
 *
 * pin          small  -1    pin
 * pin_1        pin_2       pin_3
 *
 * Now we return to the 2nd call:
 *
 * pin          pin         pin
 * middle -2    pin         pin
 * big    -3    small  -1   pin
 * pin_1        pin_2       pin_3
 *
 * As you remember we wanted to move from the 1st pin to the 2nd
 * That's why we move the 2nd disk to the 3rd pin:
 *
 * pin          pin         pin
 * pin          pin         pin
 * big    -3    small  -1   middle -2
 * pin_1        pin_2       pin_3
 *
 * And now recursive call again but with different parameters:
 * We want to move the pyramid with height 1 (n - 1) from the 1st pin (helper) to the 3rd (finish)
 *
 *                  4th call
 *
 * pin          pin         pin
 * pin          pin         pin
 * big    -3    small  -1   middle -2
 * pin_1        pin_2       pin_3
 *
 * is being transformed into
 *
 * pin          pin         pin
 * pin          pin         small  -1
 * big    -3    pin         middle -2
 * pin_1        pin_2       pin_3
 *
 * because we had only 1 disk on the pin
 *
 * now let's return to the 1st call:
 *
 * pin          pin         pin
 * pin          pin         small  -1
 * big    -3    pin         middle -2
 * pin_1        pin_2       pin_3
 *
 * As you see we have only one disk on our starting pin
 * It means that we won a small victory (we passed half of the algorithm)
 *
 * And now we move the biggest one to the finish:
 *
 * pin          pin         pin
 * pin          pin         small  -1
 * pin          big    -3   middle -2
 * pin_1        pin_2       pin_3
 *
 * Now we do the same steps in reverse order to move a little pyramid to the 2nd pin...
 * 
 */

public static class Class1
{
    public static void Main()
    {
        var from = 0;
        while (from is > 3 or < 1)
        {
            Console.WriteLine("Enter the number of the start pin");
            from = int.Parse(Console.ReadLine()!);
        }
        var to = 0;
        while (to is > 3 or < 1)
        {
            Console.WriteLine("Enter the number of the final pin");
            to = int.Parse(Console.ReadLine()!);
        }
        var n = 0;
        while (n < 1)
        {
            Console.WriteLine("Enter the number of disks");
            n = int.Parse(Console.ReadLine()!);
        }
        Hanoi(n, from, to);
    }

    private static void Hanoi(int n, int from, int to)
    {
        if (n == 1) Console.WriteLine("Move disk <1> from the pin '{0}' to '{1}'", from, to);
        else
        {
            var tmp = 6 - from - to;      //number of 'helper' pin
            Hanoi(n - 1, from, tmp);    //move the pyramid (height = n - iteration) above the bottom disk
            Console.WriteLine("Move disk <{0}> from the pin '{1}' to '{2}'", n, from, to);   //move the nth disk (the bottom one)
            Hanoi(n - 1, tmp, to);    //then do the same actions with the pyramid (height = n - iteration) to place it above the nth disk
        }
    }
}