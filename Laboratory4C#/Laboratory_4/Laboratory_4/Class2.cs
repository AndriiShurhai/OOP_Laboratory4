using Laboratory_4;

internal class MyComplex : IMyNumber<MyComplex>
{
    private readonly double re;
    private readonly double im;

    public MyComplex(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public MyComplex(MyComplex that)
    {
        this.re = that.re;
        this.im = that.im;
    }

    public MyComplex()
    {
        this.re = 21;
        this.im = 100;
    }

    public MyComplex Add(MyComplex that)
    {
        return new MyComplex(this.re + that.re, this.im + that.im);
    }

    public MyComplex Substruct(MyComplex that)
    {
        return new MyComplex(this.re - that.re, this.im - that.im);
    }

    public MyComplex Multiply(MyComplex that)
    {
        return new MyComplex(
            this.re * that.re - this.im * that.im,
            this.re * that.im + this.im * that.re
        );
    }

    public MyComplex Divide(MyComplex that)
    {
        ValidateDivisionByZero(that);
        double denominator = that.re * that.re + that.im * that.im;
        return new MyComplex(
            (this.re * that.re + this.im * that.im) / denominator,
            (this.im * that.re - this.re * that.im) / denominator
        );
    }

    private void ValidateDivisionByZero(MyComplex that)
    {
        if (Math.Abs(that.re * that.re + that.im * that.im) < double.Epsilon)
        {
            throw new DivideByZeroException("Division by zero");
        }
    }

    public override string ToString()
    {
        if (im >= 0)
            return $"{re} + {im}i";
        return $"{re} - {Math.Abs(im)}i";
    }
}