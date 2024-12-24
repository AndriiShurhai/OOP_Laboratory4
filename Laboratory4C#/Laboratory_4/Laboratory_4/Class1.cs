using Laboratory_4;
using System.Numerics;

internal class Frac : IMyNumber<Frac>, IComparable<Frac>
{
    private BigInteger nom;
    private BigInteger denom;

    public Frac(BigInteger nom, BigInteger denom)
    {
        this.nom = nom;
        this.denom = denom;
        Reduce();
    }

    public Frac(int nom, int denom)
    {
        this.nom = nom;
        this.denom = denom;
        Reduce();
    }

    public Frac()
    {
        this.nom = 1;
        this.denom = 1;
    }

    private static BigInteger GCD(BigInteger a, BigInteger b)
    {
        a = BigInteger.Abs(a);
        b = BigInteger.Abs(b);
        while (b != 0)
        {
            BigInteger temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private void Reduce()
    {
        if (denom < 0)
        {
            nom = -nom;
            denom = -denom;
        }

        BigInteger gcd = GCD(nom, denom);
        if (gcd != 0)
        {
            nom /= gcd;
            denom /= gcd;
        }
    }

    public int CompareTo(Frac that)
    {
        BigInteger leftSide = this.nom * that.denom;
        BigInteger rightSide = that.nom * this.denom;

        if (leftSide < rightSide) return -1;
        if (leftSide > rightSide) return 1;
        return 0;
    }

    public Frac Add(Frac that)
    {
        return new Frac(this.nom * that.denom + that.nom * this.denom,
                       this.denom * that.denom);
    }

    public Frac Substruct(Frac that)
    {
        return new Frac(this.nom * that.denom - that.nom * this.denom,
                       this.denom * that.denom);
    }

    public Frac Multiply(Frac that)
    {
        return new Frac(this.nom * that.nom,
                       this.denom * that.denom);
    }

    public Frac Divide(Frac that)
    {
        ValidateDivisionByZero(that);
        return new Frac(this.nom * that.denom,
                       this.denom * that.nom);
    }

    private void ValidateDivisionByZero(Frac that)
    {
        if (this.denom * that.nom == 0)
        {
            throw new DivideByZeroException("Division by zero");
        }
    }

    public override string ToString()
    {
        return $"{this.nom} / {this.denom}";
    }
}