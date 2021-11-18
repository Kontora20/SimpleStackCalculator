# SimpleStackCalculator

The calculator stores numbers as 10 bit unsigned integers on an internal stack and has the following commands:
Push <value>
Pushes <value> on the memory stack. The stack has a maximum capacity of 5. When the stack
capacity is exceeded the command results in error. <value> is guaranteed to be a valid.

Pop
Pops a value from the memory stack and discards it. If no values on the stack no operation is performed.

Add
Pops two values from the stack, adds them together, prints the result and pushes the result back to the stack.
If the required operands are not on the stack the command results in error

Sub
Pops two values from the stack, subtracts the second topmost from the topmost prints the result,
and pushes the result back to the stack. If the required operands are not on the stack the
command results in error

A computation involving unsigned operands should never overflow. A result that cannot be
represented by the resulting unsigned integer type is reduced modulo the number that is one
greater than the largest value that can be represented by the resulting type.
