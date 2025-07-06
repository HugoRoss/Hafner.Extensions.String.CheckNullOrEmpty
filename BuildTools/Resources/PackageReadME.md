# Hafner.Extensions.String.CheckNullOrEmpty

This micro package provides extension method `System.String.CheckNullOrEmpty()`.

## Description

Package `Hafner.Extensions.String.CheckNullOrEmpty` contains an extension method for a `System.String` that checks whether it is null (Nothing in Visual Basic)
or empty and in case it is, throws an `ArgumentNullException` with a speaking message (using the automatically by the compiler filled in 2nd argument `parameterName`); 
otherwise, the object is returned.

This method is especially useful in conjunction with C#'s primary constructors where there is no built-in way to check the arguments before they are assigned.

```
public class Person(string firstName, string lastName) {

    public string FirstName { get; } = firstName.CheckNullOrEmpty();
    public string LastName { get; } = lastName.CheckNullOrEmpty();

}
```

## Behavior and Edge Cases:

 - If the string is not `null` and not empty, the same instance is returned.
 - If the string is `null` or empty and the parameter name is `null` an `ArgumentNullException` with a generic message is thrown ("The argument is mandatory and cannot be null or empty!")
 - If the string is `null` or empty and the parameter name is recognized as an expression, an `ArgumentNullException` with an according message is thrown ("The result of the expression '\{paramName}' is mandatory and cannot be null or empty!")
 - If the string is `null` or empty and the parameter name is recognized as a parameter name, an `ArgumentNullException` with an according message is thrown ("The argument for parameter '\{paramName}' is mandatory and cannot be null or empty!")

## Supported Frameworks:

 - .NET Framework versions `2.0`, `3.0`, `3.5`, `4.0`, `4.0.3`, `4.5`, `4.5.1`, `4.5.2`, `4.6`, `4.6.1`, `4.6.2`, `4.7`, `4.7.1`, `4.7.2`, `4.8`, `4.8.1`
 - .NET Core versions `1.0`, `1.1`, `2.0`, `2.1`, `2.2`, `3.0`, `3.1`, `5.0`, `6.0`, `7.0`, `8.0`, `9.0`, `10.0`
 - .NET Standard versions `1.0`, `1.1`, `1.2`, `1.3`, `1.4`, `1.5`, `1.6`, `2.0`, `2.1`
