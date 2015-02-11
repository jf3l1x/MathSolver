<img src="https://travis-ci.org/jf3l1x/MathSolver.svg" data-bindattr-824="824" title="Build Status Images">
# MathSolver
A Library to Parse and Solve Mathematical Expressions

A parser and solver for complex calculations.

Use cases:

Add formulas to your applications

Samples:

Very Simple:

var parser=new Parser();
parser.Parse("2+2").Calc(new ConstantResolver(1)) // returns 4 :p

Functions:

var parser=new Parser();

//Cos
parser.Parse("Cos(x)").Calc(new ConstantResolver(1)) // returns 0.5403...

//E
parser.Parse("E()".Calc(new ConstantResolver(1)) // returns 2.71828...

//Log
parser.Parse("Log(100,10)").Calc(new ConstantResolver(1)) // returns 2...


//Other supported functions
//Pi()
//Pow(base,exponent)
//Product(Expression,from,to)
//Sum(Expression,from,to)
//Root(base,exponent)
//Sen(Expression)
//Tan(Expression)

You can combine functions, with any recursive depth you want

parser.Parse("Log(Cos(x),10)").Calc(new ConstantResolver(1)) //returns -0,2673...

You can pass an IVariableResolver to get the variables values before executing the calculation

See the tests for more options.

Regards,
Jose Felix



