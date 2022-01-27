# MorgantiCalculator
A C# Calculator built on windows forms for CSC 260 - Assignment 1

I based this program off of a state diagram. The calculator uses 7 total state and performs operations based on the current state

States:
-1 - Error state
0 - Ready state; nothing has been done to the calculator
1 - Initial typing state; the user has started to enter numerical data
2 - Operator state; the user has pressed a regular operator (+, -, /, *, ^)
3 - Second typing state; the user has entered more numerical data after state 2
4 - Equals state; the user has pressed = and the statement has been evaluated and stored
5 - Special Operator 1 - when a special operator (sqrt, sqr, 1/x) has been pressed before a normal operator  
6 - Speical Operator 2 - when a special operator has been pressed after a normal operator has already been pressed
