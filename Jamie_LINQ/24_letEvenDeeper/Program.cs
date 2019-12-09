using System;


namespace _24_letEvenDeeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new[]
            {
                new{a = 1, b = 2, c = 3},
                new{a = 2, b = 9, c = 4},
                new{a = 7, b = 3, c = 6},
            };

            var result = from coef in inputs
                            let negB = -coef.b
                            let discriminant = coef.b * coef.b - 4 * coef.a * coef.c
                            let twoA = 2 * coef.a
                            select new
                            {
                                firstRoot = (negB + discriminant) / twoA,
                                secondRoot = (negB - discriminant) / twoA
                            };
            
            var result2 = //from coef in inputs
                            inputs
                            .Select(coef => new{coef, negB = -coef.b}) 
                            .Select(tp1 => new{tp1, discriminant = tp1.coef.b * tp1.coef.b - 4 * tp1.coef.a * tp1.coef.c})
                            .Select(tp2 => new {tp2, twoA = 2 * tp2.tp1.coef.a}) 
                            .Select(tp3, new
                            {
                                firstRoot = (tp3.tp2.tp1.negB + tp3.tp2.discriminant) / tp3.twoA,
                                secondRoot = (tp3.tp2.tp1.negB - tp3.tp2.discriminant) / tp3.twoA
                            });
        }
    }
}
