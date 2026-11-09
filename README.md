# Mars Rover

My 2019 solution to the classic **Mars Rover** coding exercise, in C# with unit
tests. Rovers land on a rectangular plateau and follow strings of `L`, `R` and
`M` commands; the program prints where each one ends up.

```text
Input            Output
5 5              1 3 N
1 2 N            5 1 E
LMLMLMLMM
3 3 E
MMRMMRMRRM
```

## The problem

NASA lands a squad of robotic rovers on a plateau on Mars. The plateau is a grid,
and a rover's position is its `x y` coordinates plus the compass direction it
faces, e.g. `0 0 N` is the bottom-left corner facing north. The square directly
north of `(x, y)` is `(x, y+1)`.

- `L` and `R` turn the rover 90° left or right without moving.
- `M` moves it forward one grid point, keeping its heading.

**Input:** the first line is the plateau's upper-right corner (the lower-left is
`0 0`). Each rover then has two lines: its starting position, and its commands.
Rovers move one after another: the second starts only when the first has
finished.

**Output:** each rover's final coordinates and heading.

## How it's built

| Type | Role |
|---|---|
| `Plateau` | The grid. Rejects a rover that lands outside it, and knows which squares are taken. |
| `IRover` / `RoverCuriosity` | Holds a position and a heading; turns, moves forward, and runs a whole command string. Refuses to drive into a square another rover occupies. |
| `IDirection` + `DirectionNorth/East/South/West` | Each heading knows which heading is to its left and right, so turning is a lookup instead of a chain of `if`s. |

The rules are covered by 29 NUnit test cases in `MarsRover.UnitTests` for
directions, the plateau and the rover.

## Run it

It targets .NET Framework 4.5.2. Open `MarsRover/MarsRover.sln` in Visual
Studio, press F5 and type or paste the input above. Run the tests with any
NUnit 3 runner (in Visual Studio, add the NUnit 3 Test Adapter).
