# Operations

In this lecture, we will learn about some of the operations that can be performed on the types that we have previously discussed. We will discuss some of the common mistakes using these operators. Additionally, we discuss concepts such as promotion and order of operations which are typical sources of confusion for operations.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/5-operations/
```

This simply changes the directory that we refer to with other commands.

## Operators

In order to apply useful transformations to our variables, we need to use operators. Generally, operators take a certain number of values, called **operands**, and returns a result of the operation. Most of the operators that we discuss in this lecture are **binary operators** meaning they take in exactly two values and produce a single result. We've already used a **unary operator** which takes in a single value and produces a single result. Namely, the `-` operator used to make a number negative as in `-10` is a unary operator. As a side note, abstract operators can be **n-ary** which take n values and produce a result.

### Numerical

For numerical types, all of the standard operations of arithmetic are available for use. That is, we can add, subtract, multiply, and divide numbers. All of the numerical operators behave mostly intuitively to what you would expect by typing their equivalent into a calculator.

- Addition operator (`+`) - Adds the second operand to the first operand. For instance:
    ```csharp
    int valueA = 2 + 5;
    double valueB = -1.3 + 2.22;

    Console.WriteLine(valueA);  // Outputs 7
    Console.WriteLine(valueB);  // Outputs 0.92
    ```
- Subtraction operator (`-`) - Subtracts the second operand from the first operand. For instance:
    ```csharp
    long valueC = 5L - 1L;
    float valueD = 2.00f - 0.01f;

    Console.WriteLine(valueC);  // Outputs 4
    Console.WriteLine(valueD);  // Outputs 1.99
    ```
- Multiplication operator (`*`) - Multiplies the first operand by the second operand. For instance:
    ```csharp
    int valueE = 3 * 5;
    float valueF = -1.2 * 2.0;

    Console.WriteLine(valueE);  // Outputs 15
    Console.WriteLine(valueF);  // Outputs -2.4
    ```
- Division operator (`/`) - Divides the first operand by the second operand. For instance:
    ```csharp
    long valueG = 24L / 2L;
    double valueH = 3.0 / -2.0;

    Console.WriteLine(valueG);  // Outputs 12
    Console.WriteLine(valueH);  // Outputs -1.5
    ```
    There is a small caveat to division that often catches programmers off guard. Suppose we divide two integers that *do not* divide evenly such as:
    ```csharp
    var result = 7 / 2;
    ```
    We would expect the result to be 3.5, but if we output the value,
    ```csharp
    Console.WriteLine(result);  // Outputs 3
    ```
    we get 3 instead. This is because the numbers used in the operation are of type `int` so the division operator returns type `int` (the type of `return`). Since `int` types cannot store floating-point values, the result gets rounded down to 3. If we wanted to obtain 3.5 we would have to use a floating-point type such as `float` or `double` like so:
    ```csharp
    var result = 7.0 / 2.0;
    Console.WriteLine(result);  // Outputs 3.5
    ```
    Here, `result` is of type `double`. Additionally, we could use type promotion.

**Type promotion** occurs when we use multiple different types in a numerical operation. For instance, adding an `int` to `float` results in a `float`.
```csharp
int valueA = 1;
float valueB = 2f;
var valueC = valueA + valueB;   // Has type `float`. Equals 3
```
Type promotion can also be used in the case of integer division by converting one of the values to a double.
```csharp
int valueA = 7;
double valueB = 2.0;
var valueC = valueA / valueB;   // Has type `double`. Equals 3.5
```
The following numerical types support promotion:
- `int` to `long`, `float`, `double`, `decimal`
- `long` to `float`, `double`, `decimal`
- `float` to `double`

Note that we cannot convert a `float` nor `double` to `decimal`.

### Boolean

Some less familiar operators are those that operate on booleans. Recall that a boolean simply represents a state that is either `true` or `false`. So, these operators are simply logical statements that we would use in everyday speech.

- AND operator (`&&`) - The AND operator is true only if both of its operands are true. For instance:
    ```csharp
    bool trueAndTrue = true && true;
    bool trueAndFalse = true && false;
    bool falseAndTrue = false && true;
    bool falseAndFalse = false && false;

    Console.WriteLine(trueAndTrue);     // Outputs True
    Console.WriteLine(trueAndFalse);    // Outputs False
    Console.WriteLine(falseAndTrue);    // Outputs False
    Console.WriteLine(falseAndFalse);   // Outputs False
    ```
- OR operator (`||`) - The OR operator is true if either of its operands are true or both are true. For instance:
    ```csharp
    bool trueOrTrue = true || true;
    bool trueOrFalse = true || false;
    bool falseOrTrue = false || true;
    bool falseOrFalse = false || false;

    Console.WriteLine(trueOrTrue);      // Outputs True
    Console.WriteLine(trueOrFalse);     // Outputs True
    Console.WriteLine(falseOrTrue);     // Outputs True
    Console.WriteLine(falseOrFalse);    // Outputs False
    ```
- NOT operator (`!`) - The NOT operator is a unary operator. It is true if its operand is false and false if its operand is true. For instance:
    ```csharp
    bool notTrue = !true;
    bool notFalse = !false;

    Console.WriteLine(notTrue);     // Outputs False
    Console.WriteLine(notFalse);    // Outputs True
    ```

### Comparison

To check whether two values are equal or not, we can use the equality and inequality operators. These operators return `bool` types to indicate whether values are equal or inequal.

- Equality operator (`==`) - Checks for equality between the two operands. For instance:
    ```csharp
    bool equalityA = 2 == 3;
    bool equalityB = "Hello" == "Hello";

    Console.WriteLine(equalityA);   // Outputs False
    Console.WriteLine(equalityB);   // Outputs True
    ```
- Inequality operator (`!=`) - Checks for inequality between two operands. For instance:
    ```csharp
    bool inequalityA = 4 != 5;
    bool inequalityB = "World" != "World";

    Console.WriteLine(inequalityA); // Ouputs True
    Console.WriteLine(inequalityB); // Outputs False
    ```

Except for numeric types, values of different types are usually considered to be inequal. For instance a `string` and a `bool` can never be equal. For numeric types, equality can be checked across different types. For instance:

```csharp
bool equality = 1L == 1.0f;
Console.WriteLine(equality);    // Outputs True
```

For numeric types, there are also other comparison operators that allow us to order numbers. These operators return `bool` types to indicate whether a condition is `true` or `false`

- Less than operator (`<`) - Checks whether the first operand is strictly less than the second operand. For instance:
    ```csharp
    bool lessThanA = 1 < 2;
    bool lessThanB = -1.0 < -2;

    Console.WriteLine(lessThanA);   // Outputs True
    Console.WriteLine(lessThanB);   // Outputs False
    ```
- Greater than operator (`>`) - Checks whether the first operand is strictly greater than the second operand. For instance:
    ```csharp
    bool greaterThanA = 3 > 2;
    bool greaterThanB = -2.0 > -2;

    Console.WriteLine(greaterThanA);    // Outputs True
    Console.WriteLine(greaterThanB);    // Outputs False
    ```

The following operators are combinations of the less than `<` and greater than `>` operators with the equality operator `==`. 

- Less than or equal to (`<=`) - Checks whether the first operand is less than or equal to the second operand. For instance:
    ```csharp
    bool lessThanOrEqualA = 1 <= 2;
    bool lessThanOrEqualB = -2.0 <= -2;

    Console.WriteLine(lessThanA);   // Outputs True
    Console.WriteLine(lessThanB);   // Outputs True
    ```
    Note that the following two statements are equivalent.
    ```csharp
    var result = valueA < valueB || valueA == valueB;
    var result = valueA <= valueB;
    ```
- Greater than or equal to (`>=`) - Checks whether the first operand is greater than or equal to the second operand. For instance:
    ```csharp
    bool greaterThanOrEqualA = 1 >= 2;
    bool greaterThanOrEqualB = 3.0 >= 3;

    Console.WriteLine(greaterThanA);    // Outputs False
    Console.WriteLine(greaterThanB);    // Outputs Trie
    ```
    Note that the following two statements are equivalent.
    ```csharp
    var result = valueA > valueB || valueA == valueB;
    var result = valueA >= valueB;
    ```

In general, the following rules of comparison apply:
- The expression `a == b` is equivalent to `b == a`.
- The expression `a != b` is equivalent to `b != a`.
- The expression `a < b` is equivalent to `b > a`.
- If `a == b` is `true`, then `a != b` is `false`.
- If `a >= b` is `true`, then `a < b` is `false`.
- If `a <= b` is `true`, then `a > b` is `false`.

Make sure that these statements make intuitive sense.

### Order of Operations

Just as in arithmetic, each of the operators we have discussed has an order of evaluation also known as the **order of operations**.

In C#, operations are evaluated in the following first to last order:
1. Parentheses: `()`
2. NOT: `!`
3. Multiplication/Division: `*`, `/`
4. Addition/Subtraction: `+`, `-`
5. Comparison: `<`, `>`, `<=`, `>=`
6. Equality/Inequality: `==`, `!=`
7. AND/OR: `&&`, `||`

For example, try to manually verify the following output:
```csharp
var result = !(2 < 3) || (-5 * 4 + 1 >= -20 == !false);
Console.WriteLine(result);  // Outputs True
```

## Exercises

A program demonstrating the use of the operators is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command. Try modifying the values in the code and determining how the ouputs change.

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work. *Each of these exercises can replace the example code or be appended to it.*

1. The **remainder operator** `%` is an operator that returns the remainder of a division operation. For instance, dividing 7 into 3, we obtain 7 = 3 * 2 + 1 so the remainder is 1. Therefore,
    ```csharp
    int remainder = 7 % 3;
    Console.WriteLine(remainder);   // Outputs 1
    ```
    Write a small program that determines if an integer variable `number` is even (divisible by 2) or odd (not divisible by 2). Output this result to the user. *Hint: Use ` == 0` to check for divisibility and report the results back using a `bool`.*
2. A **ternary operator** is an operator that takes three values and produces a single result. C# provides a single ternary operator called the conditional operator `?:` that has the following notation:
    ```csharp
    var result = condition ? value1 : value2;
    ```
    In this expression, `condition` is a `bool` that determines the value of `result`. If `condition == true`, then `result` is assigned to `value1`. If `condition == false`, then `result` is assigned to `value2`. For instance:
    ```csharp
    var result = 2 < 3 ? "Two is less than three" : "Three is less than two";
    Console.WriteLine(result);  // Outputs "Two is less than three"
    ```
    Modify your previous program to output "The number is even" or "The number is odd" respectively for each condition using the conditional operator.
3. Implement the Fizzbuzz procedure using the `%` and `?:` operators:
   1. Define a variable `number` which is a positive integer.
   2. If `number` is evenly divisible by 3 output "Fizz".
   3. If `number` is evenly divisible by 5 output "buzz".
   4. If `number` is evenly divisible by both 3 and 5 output "Fizzbuzz".
   
   For instance:
   - If `number == 1`, output nothing.
   - If `number == 3`, output "Fizz".
   - If `number == 10`, output "buzz".
   - If `number == 30`, output "Fizzbuzz".

    *Hint: This should only require two **separate** conditional operators.*

### Links
[Previous](../4-var-keyword/) |
[Home](../../../readme.md) |
[Next](../6-constants/)

### References
- [Arithmetic Operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators)
- [Boolean Operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators)
- [Comparison Operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators)
- [Numeric Conversions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions)
- [Operator Precedence](https://docs.microsoft.com/en-us/cpp/c-language/precedence-and-order-of-evaluation)
- [Conditional Operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)
- [Fizzbuzz](https://en.wikipedia.org/wiki/Fizz_buzz)